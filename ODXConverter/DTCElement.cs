using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODXConverter
{
    //klasa do przechowywania pojedyńczego DTC, identyfikowanego przez nazwę (Text) i kod (TroubleCode)
    class DTCElement
    {
        string troubleCode;
        string text;
        string shortName;
        string displayTroubleCode;

        public DTCElement()
        {
            troubleCode = "";
            text = "";
            shortName = "";
            displayTroubleCode = "";
        }

        public DTCElement(DTCElement obj)
        {
            this.troubleCode = obj.troubleCode;
            this.text = obj.text;
            this.shortName = obj.shortName;
            this.displayTroubleCode = obj.displayTroubleCode;
        }

        public DTCElement(string param_TroubleCode, string param_Text, string param_shortName, string param_displayTroubleCode)
        {
            string[] tmp = param_TroubleCode.Split('x');
            int missingBytes = 6 - tmp[1].Length;
            string filler = "";
            for (int i = 0; i < missingBytes; ++i)
                filler += "0";
            troubleCode = tmp[0] + "x" +  filler + tmp[1];
            text = param_Text;
            shortName = param_shortName;
            displayTroubleCode = param_displayTroubleCode;
        }

        public string TroubleCode
        {
            get
            {
                return troubleCode;
            }
            set
            {
                string str = (string)value;
                string[] tmp = str.Split('X');
                int missingBytes = 6 - tmp[1].Length;
                string filler = "";
                for (int i = 0; i < missingBytes; ++i)
                    filler += "0";
                troubleCode = tmp[0] + "x" + filler + tmp[1];
                
            }
        }

        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
        }

        public string ShortName
        {
            get
            {
                return shortName;
            }
            set
            {
                shortName = value;
            }
        }

        public string DisplayTroubleCode
        {
            get
            {
                return displayTroubleCode;
            }
            set
            {
                displayTroubleCode = value;
            }
        }
    };
}
