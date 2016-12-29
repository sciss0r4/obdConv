using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODXConverter
{
    //klasa do przechowywania pojedyńczego DID, składającego się z pól ID i Name
    class DIDElement
    {
        string id;
        string name;
        List<DIDResponseItem> responseList = new List<DIDResponseItem>();

        public DIDElement()
        {
            id = "";
            name = "";
            responseList = new List<DIDResponseItem>();
        }
        public DIDElement(DIDElement obj)
        {
            this.id = obj.id;
            this.name = obj.name;
            foreach (DIDResponseItem it in obj.ResponseList)
                responseList.Add(it);
        }

        public DIDElement(string param_ID, string param_Name)
        {
            string[] tmp = param_ID.Split('x');
            int missingBytes = 6 - tmp[1].Length;
            string filler = "";
            for (int i = 0; i < missingBytes; ++i)
                filler += "0";
            id = tmp[0] + "x" + filler + tmp[1];
            name = param_Name;
        }
        //konstruktor elementu wraz z dodatkowym parametrem responseItem
        public DIDElement(string param_ID, string param_Name,DIDResponseItem responseItem)
        {
            id = param_ID;
            name = param_Name;
            responseList.Add(responseItem);
        }

        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                string str = (string)value;
                string[] tmp = str.Split('x');
                int missingBytes = 6 - tmp[1].Length;
                string filler = "";
                for (int i = 0; i < missingBytes; ++i)
                    filler += "0";
                id = tmp[0] + "x" + filler + tmp[1];
                
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        void AddResponseItem(string param_name, string param_inDataType, string param_outDataType, string param_offset, string param_size, string param_resultPrecision, string param_formula, string param_unit, string param_compareValue)
        {

            DIDResponseItem singleResponse = new DIDResponseItem(param_name, param_inDataType, param_outDataType, param_offset, param_size, param_resultPrecision, param_formula,param_unit,param_compareValue);
            responseList.Add(singleResponse);
        }

        public List<DIDResponseItem> ResponseList
        {
            get { return responseList; }
        }
    };
}
