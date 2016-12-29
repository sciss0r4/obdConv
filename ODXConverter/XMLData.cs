using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODXConverter
{
    //klasa do przechowywania odczytanych elementów z pliku XML. Wewnątrz dwie listy z DTC i DID
    class XMLData
    {
        int numberOfDTCs;
        int numberOfDIDs;

        List<DTCElement> DTCList; 
        List<DIDElement> DIDList;
        
        public XMLData()
        {
            numberOfDIDs = 0;
            numberOfDTCs = 0;
            DTCList = new List<DTCElement>();
            DIDList = new List<DIDElement>();
        }

        public XMLData(XMLData obj)
        {
            this.numberOfDTCs = obj.numberOfDTCs;
            this.numberOfDIDs = obj.numberOfDIDs;
            foreach (var it in obj.DIDList)
                this.DIDList.Add(it);
            foreach (var it in obj.DTCList)
                this.DTCList.Add(it);
        }
        public List<DTCElement> AddDTC(string param_TroubleCode, string param_Text, string param_short, string param_displayTC)
        {

            DTCElement singleDTC = new DTCElement(param_TroubleCode,param_Text,param_short,param_displayTC);
            DTCList.Add(singleDTC);
            numberOfDTCs++;
            return DTCList;
        }

        public List<DIDElement> AddDID(string p_ID, string p_Name)
        {

            DIDElement singleDID = new DIDElement(p_ID, p_Name);
            DIDList.Add(singleDID);
            numberOfDIDs++;
            return DIDList;
        }

        public List<DIDElement> AddDID(DIDElement obj)
        {
            DIDElement singleDID = new DIDElement(obj);
            DIDList.Add(singleDID);
            numberOfDIDs++;
            return DIDList;
        }


        //akcesor dostępu do liczebności DTC
        public int NumberOfDTCs
        {
            get { return numberOfDTCs;}
            set { numberOfDTCs = value; }
        }
        //akcesor dostępu do liczebności DID
        public int NumberOfDIDs
        {
            get { return numberOfDIDs;}
            set { numberOfDIDs = value;  }
        }

        public List<DTCElement> ReturnDTCList
        {
            get{return DTCList;}   
        }

        public List<DIDElement> ReturnDIDList
        {
            get { return DIDList; }
        }
       


    };

}
