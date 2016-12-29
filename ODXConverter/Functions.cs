using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ODXConverter
{

    
    partial class Form1
    {
        public delegate void Add();//bedzie nam potrzebne podczas dodawania do drzewa
        //public delegate void dele();
        public delegate TreeNode dele_tree();
        string filename;
        string path;
        //ścieżka do katalogu w którym znajduje się plik XML, potrzebne do wygenerowania .zip
        string catalogPath;
        //pojemnik na dane z pliku
        XMLData data = new XMLData();
        public void AddDTCToTree()
        {
            treeView1.Nodes.Add("Diagnostic Trouble Code / DTC", "Diagnostic Trouble Code / DTC").Tag = "DTC";
        }
        public void AddDIDToTree()
        {
            treeView1.Nodes.Add("Data Identifier / DID", "Data Identifier / DID").Tag = "DID";
        }
        //funkcja odczytu pliku XML i umieszczenia elementów w klasie XMLData. Typ zwracany: obiekt XMLData wypełniony polami z otwartego wcześniej dokuemntu przekazanego w parametrze
        //dodałem nowe parametry do funkcji. DTC/DID path to sciezki do wezlow w odpowiednich plikach 
        //bool decyduje w jaki sposob czytamy(struktura plikow troche sie rozni)
        //nie rozgryzłem jeszcze wczytywania didow z PDXa(nie jest jeszcze zaimplementowanie dodawanie ich tam)
        //trzeba skonsultowac strukture PDX(nie do konca podoba mi sie miejsce zapisu danych no i budowa na starym smieciu pełnym róznego syfu)
        private XMLData readfromXML(XmlDocument doc, string DTCPath, string DIDPath, bool pdx)
        {
            XMLData container = new XMLData();

            //węzeł główny
            XmlElement root = doc.DocumentElement;


            //lista interesujących nas węzłów DTCs
            XmlNodeList DTCnodesList;
            if(pdx) 
            {
                DTCnodesList = doc.SelectSingleNode(".//" + "DTCS").ChildNodes;
            }
            else
            {//do odczytu z XMLa
                DTCnodesList = root.SelectNodes(DTCPath);
            }
            

            //lista interesujących nas węzłów DataIdentifiers (DID)
            XmlNodeList DIDnodesList = root.SelectNodes(DIDPath);

            if (DTCnodesList.Count != 0 || DIDnodesList.Count != 0)
            {
                //maksymalna liczba obrotów pętli - liczba węzłów z danymi do przetworzenia
                int totalnumber = DTCnodesList.Count + DIDnodesList.Count;

                //wyświetlenie paska postępu
                this.InvokeIfRequired(value => ProgressBar.Visible = value, true);
                this.InvokeIfRequired(value => ProgressBar.Minimum = value, 1);
                this.InvokeIfRequired(value => ProgressBar.Maximum = value, totalnumber);
                this.InvokeIfRequired(value => ProgressBar.Value = value, 1);
                this.InvokeIfRequired(value => ProgressBar.Step = value, 1);
                /*PĘTLA DO ODCZYTU DTC*/
                foreach (XmlNode oDTC in DTCnodesList)
                {
                    string DTC_text = "";
                    string DTC_troubleCode = "";
                    string DTC_shortName = "";
                    string DTC_displayTC = "";
                    //Thread.Sleep(1000);// testowanie dzialania watku (smiga)
                    //odczytanie zawartości pola ResponseItem Name
                    //rozne wersje wypelniania listy
                    switch (pdx)
                    {
                        case true:
                            DTC_text = oDTC["TEXT"].InnerText;
                            DTC_shortName = oDTC["SHORT-NAME"].InnerText;
                            DTC_troubleCode = oDTC["TROUBLE-CODE"].InnerText;
                            DTC_displayTC = oDTC["DISPLAY-TROUBLE-CODE"].InnerText;
                           
                            if (DTC_text != "" && DTC_troubleCode != "")
                            {
                                container.AddDTC(DTC_troubleCode, DTC_text,DTC_shortName,DTC_displayTC);
                            }
                            break;
                        case false://odczyt z XML

                            //sprawdzenie czy da się odczytać CompareValue i węzeł zawiera tylko CompareValue (1 dziecko)
                            if (oDTC.HasChildNodes == true && oDTC.ChildNodes.Count == 1)
                            {
                                var CompareValueElement = oDTC.FirstChild;
                                //usunięcie znaku =
                                string DeletedChars = CompareValueElement.InnerText.Trim(new Char[] { ' ', '*', '.', ',', '=' });
                                DTC_troubleCode = DeletedChars;
                            }
                            //odczyt nazwy DTC
                            if (oDTC.Attributes != null)
                            {
                                var nameAttribute = oDTC.Attributes["Name"];
                                if (nameAttribute != null)
                                {
                                    string tempShort = "";
                                  
                                    tempShort = nameAttribute.Value.Replace(' ', '_');
                                    string clean = Regex.Replace(tempShort, "[^A-Za-z0-9 _]", "");
                                  

                                    DTC_shortName = DTC_troubleCode + "_" + clean;
                                    DTC_text = nameAttribute.Value;

                                }

                            }


                            //dodajemy dtc do listy jeśli odczytana wartość nie jest pusta
                            if (DTC_text != "" && DTC_troubleCode != "")
                            {
                                container.AddDTC(DTC_troubleCode, DTC_text, DTC_shortName, "DTC" + DTC_troubleCode);
                            }
                            break;
                    }
                    this.InvokeIfRequired(value => ProgressBar.PerformStep(), ProgressBar.Step);
                }
                /*KONIEC PĘTLI ODCZYTU DTC*/


                /*Pętla odczytu DID*/
                foreach (XmlNode oDID in DIDnodesList)
                {
                    DIDElement singleDID = new DIDElement();
                    //Thread.Sleep(1000);
                    //odczytanie zawartości pola DataIdentifier Name
                    if (oDID.Attributes != null)
                    {
                        var nameAttribute = oDID.Attributes["Name"];
                        var idAttribute = oDID.Attributes["ID"];

                        if (nameAttribute != null && idAttribute != null)
                            //wypełniamy obiekt
                            singleDID.Name = nameAttribute.Value;
                        singleDID.ID = "0x" + idAttribute.Value;
                    }

                    //tworzymy listę węzłów ResponseItems i przechodząc po liście węzłów, dodajemy do niej elementy (pojedyńcze resposneItemy)
                    XmlNodeList responseItemNodeList = oDID.SelectNodes(DIDPath + "[@Name=\"" + singleDID.Name + "\"]" + "/ResponseItems/ResponseItem");

                    foreach (XmlNode responseItemNode in responseItemNodeList)
                    {
                        //Thread.Sleep(1000);
                        string nameAttribute = responseItemNode.Attributes["Name"].Value;
                        string inDataTypeAttribute = responseItemNode.Attributes["InDataType"].Value;
                        string outDataTypeAttribute = responseItemNode.Attributes["OutDataType"].Value;
                        string offsetAttribute = responseItemNode.Attributes["Offset"].Value;
                        string sizeAttribute = responseItemNode.Attributes["Size"].Value;
                        string resultPrecisionAttribute = responseItemNode.Attributes["ResultPrecision"].Value;

                        string formula = "", unit = "", compareValue = "";

                        XmlNode formulaNode = responseItemNode[Name = "Formula"];
                        XmlNode unitNode = responseItemNode[Name = "Unit"];
                        XmlNode compareValueNode = responseItemNode[Name = "CompareValue"];

                        if (formulaNode != null)
                            formula = formulaNode.InnerText;
                        if (unitNode != null)
                            unit = unitNode.InnerText;

                        if (compareValueNode != null)
                            compareValue = compareValueNode.InnerText;


                        if (nameAttribute != null && inDataTypeAttribute != null && outDataTypeAttribute != null && offsetAttribute != null && sizeAttribute != null && resultPrecisionAttribute != null && (formula != null || unit != null || compareValue != null))
                        {
                            DIDResponseItem responseItem = new DIDResponseItem(nameAttribute, inDataTypeAttribute, outDataTypeAttribute, offsetAttribute, sizeAttribute, resultPrecisionAttribute, formula, unit, compareValue);

                            //zapewnienie warunku unikalności parametru offset - tylko jedno wystąpienie
                            if (singleDID.ResponseList.Find(toFind => toFind.OffSet == offsetAttribute) == null)
                                singleDID.ResponseList.Add(responseItem);
                        }
                    }

                    //dodajemy DID do listy jeśli odczytana wartość nie jest pusta
                    if (singleDID.ID != "" && singleDID.Name != "")
                    {
                        container.AddDID(singleDID);
                    }
                    this.InvokeIfRequired(value => ProgressBar.PerformStep(), ProgressBar.Step);

                }
                /*KONIEC PĘTLI ODCZYTU DID*/
            }
            return container;
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Columns[3].Visible = true;
            //wyłączenie widoczności nadmiarowych kolumn
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            TreeNode node = treeView1.SelectedNode;

            if (node != null)
            {

                List<DIDElement> DIDList = data.ReturnDIDList;
                DIDElement oneDID = DIDList.Find(DID => DID.ID == node.Tag.ToString());
                //wyświetlenie listy "Response" danego DID
                if (oneDID != null )
                {

                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[3].Visible = false;
                    //włącznie widoczności kolumn odpowiadających za wyświetlenie listy response item DID
                    dataGridView1.Columns[4].Visible = true;
                    dataGridView1.Columns[5].Visible = true;
                    dataGridView1.Columns[6].Visible = true;
                    dataGridView1.Columns[7].Visible = true;
                    dataGridView1.Columns[8].Visible = true;
                    dataGridView1.Columns[9].Visible = true;
                    dataGridView1.Columns[10].Visible = true;
                    dataGridView1.Columns[11].Visible = true;
                    dataGridView1.Columns[12].Visible = true;


                    foreach (DIDResponseItem oneResponse in oneDID.ResponseList)
                    {
                        string[] row = {
                                         "","","","", oneResponse.Name,oneResponse.InDataType,oneResponse.OutDataType,oneResponse.OffSet,oneResponse.Size,oneResponse.ResultPrecision,oneResponse.Formula,oneResponse.Unit,oneResponse.CompareValue
                                      };

                        dataGridView1.Rows.Add(row);
                    }
                    
                }
                else //lista wszystkich elementów DTC lub DID
                {
                    List<DTCElement> DTCList = data.ReturnDTCList;
                    DTCElement oneDTC = DTCList.Find(DTC => DTC.TroubleCode== node.Tag.ToString());
                    if (node.Tag.ToString() == "DTC")
                    {

                        foreach (DTCElement tempEl in DTCList)
                        {
                            string[] row2 = { tempEl.TroubleCode, tempEl.ShortName, tempEl.Text, tempEl.DisplayTroubleCode };
                            dataGridView1.Rows.Add(row2);
                        }
                    }
                    else if (node.Tag.ToString() == "DID")
                    {
                        dataGridView1.Columns[0].Visible = true;
                        dataGridView1.Columns[1].Visible = false;
                        dataGridView1.Columns[2].Visible = false;
                        dataGridView1.Columns[3].Visible = false;
                        //wyłączenie widoczności nadmiarowych kolumn
                        dataGridView1.Columns[4].Visible = true;
                        dataGridView1.Columns[5].Visible = false;
                        dataGridView1.Columns[6].Visible = false;
                        dataGridView1.Columns[7].Visible = false;
                        dataGridView1.Columns[8].Visible = false;
                        dataGridView1.Columns[9].Visible = false;
                        dataGridView1.Columns[10].Visible = false;
                        dataGridView1.Columns[11].Visible = false;
                        dataGridView1.Columns[12].Visible = false;
                        if (node.Nodes.Count == 0 && node.Level > 0)
                        {
                            string[] row2 = { node.Tag.ToString(), "", "", "", node.Text };
                            dataGridView1.Rows.Add(row2);
                        }
                        else
                        {
                            foreach (TreeNode tempnode in node.Nodes)
                            {
                                string[] row2 = { tempnode.Tag.ToString(), "", "", "", tempnode.Text };
                                dataGridView1.Rows.Add(row2);
                            }
                        }

                    }
                        //informacje o pojedyńczym DTC
                    else if(node.Parent != null && node.Parent.Tag.ToString() == "DTC")
                    {
                        if(oneDTC!=null)
                        {
                            string[] row3 = { oneDTC.TroubleCode, oneDTC.ShortName, oneDTC.Text, oneDTC.DisplayTroubleCode };
                            dataGridView1.Rows.Add(row3);
                        }
                       
                    }
                    
                    
                }

            }
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        }
        //funkcja generowania widoku "drzewa" z listą DTC i DID. Na formatce kontrolka TreeView1
        private void GenerateTreeView(XMLData data_param)
        {
            treeView1.Invoke(new Add(treeView1.Nodes.Clear));
            treeView1.Invoke(new Add(treeView1.BeginUpdate));
            treeView1.Invoke(new Add(AddDTCToTree));
            treeView1.Invoke(new Add(AddDIDToTree));

            TreeNode DTCNode = treeView1.Nodes[0];
            TreeNode DIDNode = treeView1.Nodes[1];
            foreach (DTCElement oneDTC in data_param.ReturnDTCList)
            {
                this.InvokeIfRequired(value => DTCNode.Nodes.Add(oneDTC.TroubleCode, oneDTC.TroubleCode + " - " + oneDTC.Text).Tag = value, oneDTC.TroubleCode);
            }
            foreach (DIDElement oneDID in data_param.ReturnDIDList)
            {
                this.InvokeIfRequired(value => DIDNode.Nodes.Add(oneDID.ID, oneDID.ID + " - " + oneDID.Name).Tag = value, oneDID.ID);
            }
            treeView1.Invoke(new Add(treeView1.EndUpdate));
            
            treeView1.Invoke(new Add(treeView1.Refresh));
            this.InvokeIfRequired(value => treeView1.TreeViewNodeSorter = value, new NodeSorter());
            this.InvokeIfRequired(value => DTCNumberStatusCount.Text = value, data.NumberOfDTCs.ToString());
            this.InvokeIfRequired(value => DIDNumerStatusCount.Text = value, data.NumberOfDIDs.ToString());
            
        }
        //funkcja czyszcząca zawartość katalogu którego ścieżka jest parametrem(nie wiem czy tutaj coś z uprawnieniami się nie posypie)
        private void deleteContent(string  path)
        {
            DirectoryInfo dir = Directory.CreateDirectory(path);
            foreach (FileInfo it in dir.GetFiles())
                it.Delete();
            foreach (DirectoryInfo it in dir.GetDirectories())
                it.Delete();
        }
        //funkcja szukajaca pliku odx w naszym archiwum pdx
        private string findODXD(DirectoryInfo dir)
        {
            foreach(FileInfo it in dir.GetFiles())
            {
                if (it.Extension == ".odx-d" || it.Extension == ".odx")
                    return it.FullName;
            }
            return null;
        }   
        //funkcje nadpisująca istniejący plik odx/odx-d
        private void addToDTCS(XmlDocument doc,XMLData data)
        {
            XmlElement root = doc.DocumentElement;
            string dtcsPath = "DIAG-LAYER-CONTAINER/BASE-VARIANTS/BASE-VARIANT/DIAG-DATA-DICTIONARY-SPEC/DTC-DOPS/DTC-DOP/DTCS";
            XmlNode dtcs = root.SelectSingleNode(dtcsPath);
            dtcs.RemoveAll();
            int i = 1;
            foreach(DTCElement it in data.ReturnDTCList)
            {
                
                dtcs.AppendChild(createDTC(doc,it.ShortName,it.TroubleCode,it.DisplayTroubleCode,it.Text,"DTC_" + i.ToString()));
                ++i;
            }
            
        }
        private void addToDIDs(XmlDocument doc, XMLData data)
        {
            
            // todo
        }
        private XmlElement createDTC(XmlDocument doc,string shortName, string trouble, string display, string text, string id)
        {
            XmlElement node = doc.CreateElement("DTC");
            node.SetAttribute("ID", id);
            XmlElement tmp = doc.CreateElement("SHORT-NAME");
            tmp.InnerText = shortName;
            node.AppendChild(tmp);
            tmp = doc.CreateElement("TROUBLE-CODE");
            tmp.InnerText = trouble;
            node.AppendChild(tmp);
            tmp = doc.CreateElement("DISPLAY-TROUBLE-CODE");
            tmp.InnerText = display;
            node.AppendChild(tmp);
            tmp = doc.CreateElement("TEXT");
            tmp.InnerText = text;
            node.AppendChild(tmp);
            return node;
        }
    }
}
