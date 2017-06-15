using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml; //This is downloaded from the http://epplus.codeplex.com/ site

namespace Digital.ComponentHelper
{
    public static class WriteExcelFile
    {

        //Writes given value to specified cell with an specified worksheet in specified file 
        public static void WriteToWorksheet(string destinationFileName, string sheetName, string cellRef, string data)
        {
            try
            {
                var excelFile = new FileInfo(destinationFileName);

                //'Using' in this context basically means 'get some temporary space for this code, 
                //run it, then release the space'. It is useful for code that uses lots of memory
                using (ExcelPackage package = new ExcelPackage(excelFile))
                {
                    ExcelWorksheet sheetRef;
                     
                    //If the worksheet does not already exist, then create it.
                    if (package.Workbook.Worksheets[sheetName] == null)
                    {
                         sheetRef = package.Workbook.Worksheets.Add(sheetName);
                    }
                    else
                    {
                        //Otherwise use the existing sheet.
                        sheetRef = package.Workbook.Worksheets[sheetName];
                    }
                    
                    //CellRef could be a name "PlannedWork",a cell number "A2", a reference "1,2" or range "A1:C34"
                    sheetRef.Cells[cellRef].Value = data;
                    package.Save();
                }
            }
            catch (Exception e)
            {
                //Using e.message, e is a good practice as it gives you a summary of the error followed by the detail
                //rather than confusing you with just a lot of detail
                throw new Exception("unable to create file with name " + destinationFileName + e.Message, e);
            }
        }

        //Writes specified headings to specified worksheet in specified file
        public static void WriteWorksheetHeadings(string destinationFileName, string sheetName, string[] headings)
        {
            try
            {
                var excelFile = new FileInfo(destinationFileName);

                //Using in this context basically means 'get some temporary space for this code, 
                //run it, then release the space'. It is useful for code that uses lots of memory
                using (ExcelPackage package = new ExcelPackage(excelFile))
                {
                    ExcelWorksheet sheetRef;

                    //If the worksheet does not already exist, then create it.
                    if (package.Workbook.Worksheets[sheetName] == null)
                    {
                        sheetRef = package.Workbook.Worksheets.Add(sheetName);
                    }
                    else
                    {
                        //Otherwise use the existing sheet.
                        sheetRef = package.Workbook.Worksheets[sheetName];
                    }

                    // Fill in headings. Headings are in array so index is i-1
                    for (int i = 1; i <= headings.Length; i++)
                    {
                        sheetRef.Cells[1, i].Value = headings[i-1];
                    }

                    package.Save();
                }
            }
            catch (Exception e)
            {

                throw new Exception ("unable to create file with name " + destinationFileName + e.Message, e);
            }

        }

    }
}
