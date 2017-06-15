using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using Excel; //Need to instal ExcelDataReader from NuGet to use this

namespace Digital.ComponentHelper
{
    public class ValidationHelper
    {

        public static DataSet GetInputDataFromfile(string fileForInputData)
        {
            DataSet inputDataSet;
            
            //Reading from an xlsx Excel file (2007 format; *.xlsx) 
            FileStream stream = File.Open(fileForInputData, FileMode.Open, FileAccess.Read);
            IExcelDataReader xlsxReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            //Reads data from file into a dataset that is declared above. The "true" paramenter means that the the file uses headers
            inputDataSet = ReadExcelFile.xlsxReadFile(xlsxReader, fileForInputData, true);

            return inputDataSet;
        }

        
    }
}
