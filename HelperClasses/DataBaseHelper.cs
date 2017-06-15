using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Data.Odbc;

namespace Digital.ComponentHelper
{
    public static class DataBaseHelper
    {

        public static void ProgressQuery()
        {



        }

        public static SqlConnection ConnectToDatabase(string server, string instance, string Database)
        {
            string connectionString = "Server=" + server + "\\" + instance + ";Database=" + Database + ";Trusted_Connection = True";
            SqlConnection myconnection = new SqlConnection(connectionString);

            return myconnection;
        }

        public static string readDOBFromDB(SqlConnection myConnection, int IDtoUse)
        {
            string commandSting = "SELECT [InitialLowellReference],[DateOfBirth] FROM [Customer] WHERE [InitialLowellReference]='" + IDtoUse.ToString() + "'";
            string dataReadDOB = null;
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand(commandSting, myConnection);
            myReader = myCommand.ExecuteReader(); //Initialises the reader

            //Read() Advances the SqlDataReader to the next record and returns  true if there are more rows; otherwise false.
            //he default position of the SqlDataReader is before the first record. Therefore, you must call Read to begin accessing any data.
            //Otherwise it wil say that there are not rows to read.
            while (myReader.Read()) 
            {
                //The value in the square brackets is the database column name
                dataReadDOB = myReader["DateOfBirth"].ToString();
            }

            return dataReadDOB;
        }

        public static List<string> readDOBAndEmailFromDB(SqlConnection myConnection, int IDtoUse)
        {
            string commandString = "SELECT [InitialLowellReference],[Email],[DateOfBirth] FROM [Customer] WHERE [InitialLowellReference]='" + IDtoUse.ToString()+"'";
            string dataReadEmailAddress = null;
            string dataReadDOB = null;
            List<string> returnList = new List<string>();

            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand(commandString, myConnection);
            myReader = myCommand.ExecuteReader(); //Initialises the reader

            //Read() Advances the SqlDataReader to the next record and returns  true if there are more rows; otherwise false.
            //he default position of the SqlDataReader is before the first record. Therefore, you must call Read to begin accessing any data.
            //Otherwise it wil say that there are no rows to read.
            while (myReader.Read())
            {
                //The value in the square brackets is the database column name
                dataReadEmailAddress    = myReader["Email"].ToString();
                //Date of birth field is a datetimestamps, so just want the date part which is 8 characters
                dataReadDOB = GenericHelper.GetFirstFewChars(myReader["DateOfBirth"].ToString(),8);  
            }

            returnList.Add(dataReadEmailAddress);
            returnList.Add(dataReadDOB);
            return returnList;
        }
    }



}
