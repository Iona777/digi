using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Excel;
using sys=System.Data;

namespace Digital.ComponentHelper
{
    //The methods in this class are used to READ from Excel files
    public static class ReadExcelFile
    {
        public static sys.DataSet xlsReadFile(string filePath, bool firstRowAsColumnNames)
        {
            try
            {
                FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

                //Reading from a binary Excel file ('97-2003 format; *.xls)
                IExcelDataReader xlsReader = ExcelReaderFactory.CreateBinaryReader(stream);

                //Specify wheather or not to create column names from first row
                xlsReader.IsFirstRowAsColumnNames = firstRowAsColumnNames;

                //DataSet - The output of each spreadsheet will be created in the result Dataset
                sys.DataSet result = xlsReader.AsDataSet();

                xlsReader.Close();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Cannot find/open file " + e.Message, e );
            }
            
        }


        public static sys.DataSet xlsxReadFile(IExcelDataReader dataReader, string filePath, bool firstRowAsColumnNames)
        {
            //This method will use the dataReader that is passed in as a parameter
            try
            {
                //Reading from a OpenXml Excel file (2007 format; *.xlsx)
                IExcelDataReader xlsxReader = dataReader;

                //Specify wheather or not to create column names from first row
                xlsxReader.IsFirstRowAsColumnNames = firstRowAsColumnNames;

                //DataSet - The output of each spreadsheet will be created in the result dataset
                sys.DataSet result = xlsxReader.AsDataSet();

                xlsxReader.Close();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Cannot find/open file " + e.Message, e);
            }
        }

        public static sys.DataSet xlsxReadFile(string filePath, bool firstRowAsColumnNames)
        {
            //This method will create its own dataReader
            try
            {
                FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

                //Reading from a OpenXml Excel file (2007 format; *.xlsx)
                IExcelDataReader xlsxReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                //Specify wheather or not to create column names from first row
                xlsxReader.IsFirstRowAsColumnNames = firstRowAsColumnNames;

                //DataSet - The output of each spreadsheet will be created in the result dataset
                sys.DataSet result = xlsxReader.AsDataSet();

                xlsxReader.Close();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception ("Cannot find/open file " + e.Message, e);
            }
            
        }


        public static string readSpecificCell(sys.DataSet data, int row, string columnName)
        {
            //If your worksheet contains headings, then use this method. 
            //Otherwise use the other overload of this method

            //Rows and columns are numbered like arrays, so A1 = [0,0], C2 = [2,1] etc.
            //The headings do not count so are effectively in row -1.

            //For this method, you reference row and column name, so if you want data that
            //is in C3 and the heading of column C is "Customer" and dataSet output from
            //xlsxReadFile, is MyData, you would use:
            //[row][columnName] of [1]["Customer"], so you would call the method like this
            //readSpecificCell(MyData,1,Customer)
            
            string result;
            //We need a DataTable to be able to access in the individual rows and columns
            sys.DataTable table = new sys.DataTable();
            table = data.Tables[0];

            //Check that there is data at the specified location
            if (table.Rows[row][columnName] == null)
            {
                return "No data found at specifed location, row" + row + " column " + columnName;
            }
            else
            {
                result = table.Rows[row][columnName].ToString();
                return result;
            }
        }

        public static string readSpecificCell(sys.DataSet sheet, int row, int columnNo)
        {
            //If your worksheet does NOT contain headings, then use this method. 
            //Otherwise use the other overload of this method

            //Rows and columns are numbered like arrays, so A1 = [0,0], C2 = [2,1] etc.
            //The headings do not count so are effectively in row -1.

            //For this method, you reference row and column name, so if you want data that
            //is in C4 and dataSet output from xlsxReadFile, is MyData, you would use:
            //[row][columnName] of [2][3], so you would call the method like this
            //readSpecificCell(MyData,2,3)

            string result;
            //We need a DataTable to be able to access in the individual rows and columns
            sys.DataTable table = new sys.DataTable();
            table = sheet.Tables[0];

            //Check that there is data at the specified location
            if (table.Rows[row][columnNo] == null)
            {
                return "No data found at specifed location, row" + row + " column " + columnNo;
            }
            else
            {
                result = table.Rows[row][columnNo].ToString();
                return result;
            }
        }
    }
 
}

