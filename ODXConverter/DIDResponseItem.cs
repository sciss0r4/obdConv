using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODXConverter
{
    class DIDResponseItem
    {
        string name;
        string inDataType;
        string outDataType;
        string offset;
        string size;
        string resultPrecision;
        string formula;
        string unit;
        string compareValue;

      

        public DIDResponseItem()
        {
            name="";
            inDataType="";
            outDataType="";
            offset="";
            size="";
            resultPrecision="";
        }
        public DIDResponseItem(DIDResponseItem obj)
        {
            this.name = obj.name;
            this.inDataType = obj.inDataType;
            this.outDataType = obj.outDataType;
            this.offset = obj.offset;
            this.size = obj.size;
            this.resultPrecision = obj.resultPrecision;
        }

        public DIDResponseItem(string param_name, string param_inDataType,string param_outDataType, string param_offset,string param_size, string param_resultPrecision, string param_formula, string param_unit, string param_compareValue)
        {
            name = param_name;
            inDataType = param_inDataType;
            outDataType = param_outDataType;
            offset = param_offset;
            size = param_size;
            resultPrecision = param_resultPrecision;
            formula = param_formula;
            unit = param_unit;
            compareValue = param_compareValue;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string InDataType
        {
            get
            {
                return inDataType;
            }
        }
        public string OutDataType
        {
            get { return outDataType; }
        }
        public string OffSet
        {
            get { return offset; }
        }
        public string Size
        {
            get { return size; }
        }
        public string ResultPrecision
        {
            get { return resultPrecision; }
        }
        public string Formula
        {
            get { return formula; }
        }
        public string Unit
        {
            get { return unit; }
        }
        public string CompareValue
        {
            get { return compareValue; }
        }


      
    }
}
