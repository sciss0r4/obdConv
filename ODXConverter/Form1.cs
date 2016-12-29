using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Reflection;



namespace ODXConverter
{
    public partial class Form1 : Form
    {
        const string DTCPath = "/Project/System/ECUs/ECU/SWs/SW/Services/Service[@Name='Read DTC Information']/Subfunctions/Subfunction[@ID='02']/DataParameters/DataParameter[@ID='01']/ResponseItems/ResponseItem";
        const string DIDPath = "/Project/System/ECUs/ECU/SWs/SW/Services/Service[@Name='Read Data By Identifier']/DataIdentifiers/DataIdentifier";
        const string PdxDTCPath = "/ODX/DIAG-LAYER-CONTAINER/BASE-VARIANTS/BASE-VARIANT[@ID='Door']/DIAG-DATA-DICTIONARY-SPEC/DTC-DOPS/DTC-DOP[@ID='_Door_73']/DTCS/DTC";
        public Form1()
        {
            InitializeComponent();
            newPDX();
           
            //treeView1.TreeViewNodeSorter = new NodeSorter();
            
        }

        public bool IsHex(string test)
        {
            // For C-style hex notation (0xFF) you can use @"\A\b(0[xX])?[0-9a-fA-F]+\b\Z"
            return System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\b(0[xX])?[0-9a-fA-F]+\b\Z");
        }
       
        // Wywołanie przeglądania w poszukiwaniu pliku wejściowego
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".xml";
            dlg.Filter = "Pliki PDX (*.pdx)|*.pdx|Pliki XML (*.xml)|*.xml";
           
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                 filename = dlg.FileName;
                 path = dlg.InitialDirectory + dlg.FileName;
                 catalogPath = System.IO.Path.GetDirectoryName(dlg.FileName); 
                
                //inicjalizacja background workera(stworzony zostanie osobny watek dla GUI i logiki)
                //cala logika programu przeniesiona zostala do funkcji bw_DoWork
                //co z kolei powoduje problemy z odswieżaniem interfejsu bo jest w innym watku niz logika
                //dlatego stworzylem statyczna klase ControlRefresh ktora pozwoli na komunikacje miedzy watkiem logiki a GUI

                 bw = new BackgroundWorker();
                 bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                 bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
                 bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
                 bw.WorkerReportsProgress = true;
                 bw.WorkerSupportsCancellation = true;
                 bw.RunWorkerAsync();
                 makezipToolStripMenuItem.Enabled = true;
            }
        }
        //funkcja generowania widoku "drzewa" z listą DTC i DID. Na formatce kontrolka TreeView1          
        //funkcja odczytu pliku XML i umieszczenia elementów w klasie XMLData. Typ zwracany: obiekt XMLData wypełniony polami z otwartego wcześniej dokuemntu przekazanego w parametrze
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (bw.CancellationPending)
                e.Cancel = true;
            else
            {
                //załadowanie dokumentu
                XmlDocument document = new XmlDocument();
                bool version = false;
                DirectoryInfo dir = null;
                string extractDir = "";
                string xmldoc = "";
                //ustalamy obsluge pliku PDX czy xml
                if (Path.GetExtension(path) == ".xml")
                    xmldoc = File.ReadAllText(path, Encoding.UTF8);
                else
                {
                    //czesc dotyczaca PDX
                    version = true;
                    
                    string file = Path.GetFileNameWithoutExtension(filename);
                    string tempPath = System.IO.Path.GetTempPath();
                    extractDir = tempPath + "\\" + file;
                    try
                    {
                        if (Directory.Exists(extractDir))
                            deleteContent(extractDir);
                        dir = Directory.CreateDirectory(extractDir);
                        if(file == "template")
                        {
                            if(File.Exists(tempPath+filename))
                            {
                                ZipFile.ExtractToDirectory(tempPath + filename, extractDir);
                            }
                        }
                        else
                        {
                            ZipFile.ExtractToDirectory(filename, extractDir);
                        }
                       
                        //znalezienie pliu odx/odx-d
                        xmldoc = File.ReadAllText(findODXD(dir), Encoding.UTF8);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("nie udało się wykonać operacji " + ex.Message.ToString(), "Ops... Coś poszło nie tak");
                    }
                    finally
                    {
                        deleteContent(extractDir);
                        dir.Delete();
                    }
                }
                try
                {
                    document.LoadXml(xmldoc);
                    //uzupełniamy pojemnik na dane odczytane z pliku
                    if (!version)
                        data = readfromXML(document, DTCPath, DIDPath, false);
                    else
                    {
                        data = readfromXML(document, PdxDTCPath, DIDPath, true);
                        deleteContent(extractDir);
                        dir.Delete();
                    }

                   

                    //wyświetlenie drzewka
                    GenerateTreeView(data);
                    
                    //wykomentowałem bo to nie błąd tylko brak danych, nie powoduje wyjątku. wyswietla sie ladne puste drzewo
                    //string ErrorString = "Wystąpiły następujące błędy przy odczycie pliku błędy:\n";
                    //bool error = false;
                    //if (data.NumberOfDIDs == 0)
                    //{
                    //    error = true;
                    //    ErrorString += "Nie udało się odczytać żadnego DID z pliku!\n";
                    //}
                    //if (data.NumberOfDTCs == 0)
                    //{
                    //    error = true;
                    //    ErrorString += "Nie udało się odczytać żadnego DTC z pliku!\n";
                    //}
                    //if (error)
                    //    MessageBox.Show(ErrorString, "Ops... cos poszło nie tak");
                }
                catch (Exception except)
                {
                    MessageBox.Show("Nie udało się odczytać pliku.\nSzczegóły problemu:\n" + except.ToString(), "Ops... cos poszło nie tak");
                }
            }
            
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                MessageBox.Show("Przerwano wykonanie");
        }

      

        //tworzenie pliku ZIP z XMLa. 
        //modyfikujemy istniejący juz plik PDX(żeby zachować index i wszystkie inne jego składowe.
        //korzystamy z "szablonowego" pliku pdx, w którym nadpisujemy informacje po wypakowaniu
        //wybrany plik pdx musi zawierać plik *.odx lub *.odx-d, a w tych plikach ścieżka do DTCS powinna wyglądać następująco:
        //DIAG-LAYER-CONTAINER/BASE-VARIANTS/BASE-VARIANT/DIAG-DATA-DICTIONARY-SPEC/DTC-DOPS/DTC-DOP/DTCS
        private void makezipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dostęp do szablonowego pliku pdx
            var pdx = ODXConverter.Properties.Resources.template;
     
            string tempPath = System.IO.Path.GetTempPath();
            File.WriteAllBytes(tempPath+"template.pdx", pdx);
            string pdxPath = Path.Combine(tempPath, "template.pdx");

            MessageBox.Show("Wybierz miejsce zapisu generowanego pliku pdx");
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = ".pdx";
            dlg.Filter = "Pliki PDX (*.pdx)|*.pdx";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //ścieżka na tymczasowe rozpakowanie pliku pdx, w celu wyłuskania z niego .odx-d
                string extractDir = tempPath + "\\" + "ODXtemp";

                XmlDocument doc = new XmlDocument();
                filename = dlg.FileName;
                DirectoryInfo dir = null;
                path = dlg.InitialDirectory + dlg.FileName;
                catalogPath = Path.GetDirectoryName(dlg.FileName);
                string file = Path.GetFileNameWithoutExtension(filename);
                try
                {
                    if (Directory.Exists(extractDir))
                        deleteContent(extractDir);
                    dir = Directory.CreateDirectory(extractDir);

                    ZipFile.ExtractToDirectory(pdxPath, extractDir);
                    string odxdFilePath = findODXD(dir);
                    doc.Load(odxdFilePath);
                    addToDTCS(doc, data);
                    doc.Save(odxdFilePath);
                    if (File.Exists(catalogPath + "\\" + file + "_gen.pdx"))
                        File.Delete(catalogPath + "\\" + file + "_gen.pdx");
                    ZipFile.CreateFromDirectory(extractDir, catalogPath + "\\" + file + "_gen.pdx");
                    deleteContent(extractDir);
                    dir.Delete();
                    MessageBox.Show("Poprawnie zapisano plik pdx w lokalizacji" + catalogPath);
                }
                catch (Exception except)
                {
                    deleteContent(extractDir);
                    dir.Delete();
                    MessageBox.Show("Nie udało się zapisać pliku\n" + except.ToString(), "Ops... cos poszło nie tak");
                }
            }

            //usunięcie pliku tymczasowego
            File.Delete(pdxPath);
        }


        //Założenie: po kliknięciu na przycisk New program otwiera "szablon" pliku PDX, który można modyfikować poprzez dodawanie / usuwanie / edycję DTC i DID
        //Szablon zaszyty w programie dzięki skorzystaniu z Resources
        void newPDX()
        {
            //dostęp do szablonowego pliku pdx
            dataGridView1.Rows.Clear();
            var pdx = ODXConverter.Properties.Resources.template;
            string tempPath = System.IO.Path.GetTempPath();
            string pdxPath = Path.Combine(tempPath, "template.pdx");
            File.WriteAllBytes(pdxPath, pdx);
            path = pdxPath;
            filename = "template.pdx";
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.RunWorkerAsync();
            makezipToolStripMenuItem.Enabled = true;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newPDX();
             
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

            NewForm addForm = new NewForm(0);   //0 w parametrze - tryb dodawania nowego DTC
       
            var result = addForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                string DTCnum = addForm.DTCNumber;
                string DTCshort = addForm.DTCShortName;
                string DTCdisplayTC = addForm.DTCDisplayTC;
                string DTCname = addForm.DTCText;
                try
                {
                    if (DTCnum[0] != 0 && DTCnum[1] != 'x')
                    {
                        DTCnum = "0x" + DTCnum;
                    }
                }
                catch (Exception except)
                {
                    MessageBox.Show("Nieprawidłowy format DTC \n" + except.ToString(), "Ops... cos poszło nie tak");
                }

              
             
               //sprawdzenie, czy dodawany element nie istnieje już na liście
                DTCElement el = null;
                el = data.ReturnDTCList.Find(item => item.TroubleCode == DTCnum);
                if(el != null)
                {
                    MessageBox.Show("Na liście istnieje już DTC o podanym kodzie", "BŁĄD");
                }
                else
                {
                    data.AddDTC(DTCnum, DTCname,DTCshort,DTCdisplayTC);
                    //"odświeżenie widoku drzewa"
                    GenerateTreeView(data);
                }
            }
        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        contextMenu.Show(Cursor.Position);
                        break;
                    }                
            }
        }

        private void contextAdd_Click(object sender, EventArgs e)
        {
            //TreeNode parent = treeView1.SelectedNode.Parent;
            //if ((parent != null && parent.Tag.ToString() == "DTC") || (treeView1.SelectedNode.Tag.ToString() == "DTC"))
            //{
                //
            //}
                //TODO: obsługa dodawania DID
            //else if (parent != null && parent.Tag.ToString() == "DID")
            //{
            //    MessageBox.Show("Right click add in DID");

            //}
            //tu zrobimy 2 funkcje osobno dtc i did
            addToolStripMenuItem_Click(sender, e);
                       
        }

        private void contextEdit_Click(object sender, EventArgs e)
        {
            string number = "";
            TreeNode parent = treeView1.SelectedNode.Parent;
            if (parent == null && dataGridView1.SelectedRows.Count > 0)
                number = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            else
                number = treeView1.SelectedNode.Tag.ToString();
            //obsługa edycji DTC
            if (number != "")
            {
                //który numer został wybrany przez użytkownika na liście
                //odszukanie elementu do edycji
                DTCElement doEdycji = null;
                try
                {
                    doEdycji = data.ReturnDTCList.Find(el => el.TroubleCode == number);
                }
                catch(Exception except)
                {
                    MessageBox.Show("Nie odnaleziono podanego elementu na liście\n" + except.ToString(), "Ops... cos poszło nie tak");
                }
               
                if(doEdycji != null)
                {
                     NewForm editForm = new NewForm(1);   //1 w parametrze - tryb edycji DTC
                     editForm.DTCNumber = doEdycji.TroubleCode;
                     editForm.DTCText = doEdycji.Text;
                     editForm.DTCShortName = doEdycji.ShortName;
                     editForm.DTCDisplayTC = doEdycji.DisplayTroubleCode;
                     var result = editForm.ShowDialog();
                     if (result == DialogResult.OK)
                     {
                         //ustawienie parametrów po edycji
                         doEdycji.TroubleCode = editForm.DTCNumber;
                         doEdycji.Text = editForm.DTCText;
                         doEdycji.DisplayTroubleCode = editForm.DTCDisplayTC;
                         doEdycji.ShortName = editForm.DTCShortName;
                         GenerateTreeView(data);
                     }

                }

            }
                //TODO: obsługa edycji DID
            else if (parent != null && parent.Tag.ToString() == "DID")
            {
                MessageBox.Show("Right edit  click in DID");

            }

        }

        private void contextDelete_Click(object sender, EventArgs e)
        {
            TreeNode parent = treeView1.SelectedNode.Parent;
            string number = "";
            if (parent == null)
                number = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            else
                number = treeView1.SelectedNode.Tag.ToString();
            //obsługa usuwania DTC
            if (number != "")
            {
                //który numer został wybrany przez użytkownika na liście
                //string number = treeView1.SelectedNode.Tag.ToString();
                //odszukanie elementu do edycji
                DTCElement doUsuniecia = null;
                try
                {
                    doUsuniecia = data.ReturnDTCList.Find(el => el.TroubleCode == number);
                }
                catch (Exception except)
                {
                    MessageBox.Show("Nie odnaleziono podanego elementu na liście\n" + except.ToString(), "Ops... cos poszło nie tak");
                }

                if (doUsuniecia != null)
                {
                    DialogResult pytanie = MessageBox.Show("Czy potwierdzasz usunięcie elementu DTC:" + doUsuniecia.TroubleCode, "DECYZJA", MessageBoxButtons.YesNo);
                    if (pytanie == DialogResult.Yes)
                    {
                        data.ReturnDTCList.Remove(doUsuniecia);
                        data.NumberOfDTCs--;
                        GenerateTreeView(data);
                    }
                }

            }
            //TODO: obsługa usuwania DID
            else if (parent != null && parent.Tag.ToString() == "DID")
            {
                MessageBox.Show("Right edit  click in DID");

            }
        }

        //sprzątanie w folderze temp
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string tempPath = System.IO.Path.GetTempPath();
            if (File.Exists(tempPath + "template.pdx"))
            {
                File.Delete(tempPath + "template.pdx");
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        contextMenu.Show(Cursor.Position);
                        //addToolStripMenuItem_Click(sender, e);
                        break;
                    }
            }
        }


    }
}
