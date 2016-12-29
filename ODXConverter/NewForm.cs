using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ODXConverter
{
    public partial class NewForm : Form
    {
        public string DTCNumber{get; set;}
        public string DTCText {get; set; }
        
        public string DTCDisplayTC { get; set; } //Display Trouble Code

        public string DTCShortName { get; set; } //Short Name

        //tryb otwierania formatki : 0 - dodawanie nowego elementu, 1 - edycja
        int mode;

        public NewForm()
        {
            InitializeComponent();
        }
        public NewForm(int param)
        {
            InitializeComponent();
            mode = param;
        }

       

        public bool IsHex(string test)
        {
            // For C-style hex notation (0xFF) you can use @"\A\b(0[xX])?[0-9a-fA-F]+\b\Z"
            return System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\b(0[xX])?[0-9a-fA-F]{0,6}\b\Z");
        }

        //reakcja na załadowanie formatki
        private void NewForm_Load(object sender, EventArgs e)
        {
            //tryb dodawania nowego elementu
            if(mode == 0)
            {
                this.Name = "Add DTC / Add DID";
                button1.Text = "Add DTC";

            }
                //tryb edycji
            else if(mode == 1)
            {
                this.Text = "Edit DTC / Edit DID";
                button1.Text = "Save";
                tbDTCNumber.Text = DTCNumber;
                tbDTCName.Text = DTCText;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbDTCNumber.BackColor = Color.White;
            tbDTCName.BackColor = Color.White;
            if((tbDTCName.Text!="") && (tbDTCNumber.Text !=""))
            {
                if(IsHex(tbDTCNumber.Text))
                {
                    int missingBytes = 6 - tbDTCNumber.Text.Length;
                    string filler = "";
                    for (int i = 0; i < missingBytes; ++i)
                        filler += "0";
                    this.DTCNumber = filler + tbDTCNumber.Text.ToUpper();
                    this.DTCText = tbDTCName.Text;
                    this.DTCDisplayTC = tbDTCDisplayTrobuleCode.Text;
                    this.DTCShortName = tbDTCShortName.Text;
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    tbDTCNumber.BackColor = Color.Red;
                }
            }
            else 
            {
                if (tbDTCNumber.Text == "" || !IsHex(tbDTCNumber.Text))
                    tbDTCNumber.BackColor = Color.Red;
                if (tbDTCName.Text == "")
                    tbDTCName.BackColor = Color.Red;
            }
        }

        private void tbDTCNumber_TextChanged(object sender, EventArgs e)
        {
            tbDTCDisplayTrobuleCode.Text = "DTC"+tbDTCNumber.Text.ToUpper();

            string tempShort = "";
            tempShort = tbDTCName.Text.Replace(' ', '_');
            string clean = Regex.Replace(tempShort, "[^A-Za-z0-9 _]", "");
            tbDTCShortName.Text = tbDTCNumber.Text.ToUpper() + clean;
        }

        private void tbDTCName_TextChanged(object sender, EventArgs e)
        {
            string tempShort = "";
            tempShort = tbDTCName.Text.Replace(' ', '_');
            string clean = Regex.Replace(tempShort, "[^A-Za-z0-9 _]", "");
            tbDTCShortName.Text = tbDTCNumber.Text.ToUpper()+"_"+clean;
        }

        private void tbDTCTextBox_BackColorChanged(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            if (TB.BackColor == Color.Red && TB.Name == "tbDTCName")
            {
                int VisibleTime = 3000;  //in milliseconds
                ToolTip tt = new ToolTip();
                tt.Show("Cant be empty", TB, 200, 0, VisibleTime);
            }
            else if (TB.BackColor == Color.Red && TB.Name == "tbDTCNumber")
            {
                int VisibleTime = 5000;  //in milliseconds
                ToolTip tt = new ToolTip();
                tt.Show("Cant be empty, MAX 3 BYTE HEX", TB, 200, 0, VisibleTime);
            }
        }

    }
}
