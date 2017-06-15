using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Digital.Settings;
using Digital.ComponentHelper;
using System.Data;

namespace Digital
{
    [Binding]
    public sealed class Database_connection_Steps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        [Given(@"I want to query the database")]


        public void GivenIWantToQueryTheDatabase()
        {

            //Don't need user id or password since Trusted_connection = yes (since we are using windows authentication
            //Add \ to the server name as an escape character
            //Don't need connection timeout since it will take the default of 15 seconds
            //It is recommended to wrap the SqlConnection in a using block. 
            //This ensures that the connection is actually closed once we’re done with it

            using (SqlConnection myconnection = DataBaseHelper.ConnectToDatabase("580462-TEDBO05", "SQL019", "LowellServices"))
            {
                myconnection.Open();
                try
                {
                 // string returnedDOB        = DataBaseHelper.readDOBFromDB(myconnection, 10000014);
                  List<string> EmailAndDOB  = DataBaseHelper.readDOBAndEmailFromDB(myconnection, 10000014);

                }
                catch (Exception e)
                {
                    ObjectRepository.writer.WriteToLog("Error writing to database " + e);
                }
            }

                //    SqlDataReader myReader = null;
                //    SqlCommand myCommand = new SqlCommand("select top 10 * from customer", myconnection);
                //    var dataReadMemberId = "stuff"; //this is just so we can see what is being read from database
                //    var dataReadEmail = "stuff";
                //    var dataReadDOB = "stuff";
                //    var dataReadPostCode = "stuff";

                //    //Alternative syntax
                //    string commandString2 = "SELECT TOP 5 MemberId, Email,DateOfBirth,[PostCode] FROM [Customer] WHERE [LandlinePhone] IS NULL";
                //    SqlCommand myCommand2 = new SqlCommand();
                //    myCommand2.Connection = myconnection; //we are connecting to same database as before
                //    myCommand2.CommandText = commandString2;

                //    //Alternative syntax
                //    //SqlCommand myCommand2 = new SqlCommand(commandString2, myconnection);

                //    myReader = myCommand2.ExecuteReader(); //Initialises the reader



                //    while (myReader.Read()) //I believe that this checks to see if there is any more data to read.
                //    {
                //        //The value in the square brackets is the database column name
                //        Console.WriteLine(myReader["MemberId"].ToString());

                //        dataReadMemberId = myReader["MemberId"].ToString();
                //        dataReadEmail = myReader["Email"].ToString();
                //        dataReadPostCode = myReader["PostCode"].ToString();
                //        dataReadDOB = myReader["DateOfBirth"].ToString();

                //    }

                //}
                //catch (Exception e)
                //{

                //    ObjectRepository.writer.WriteToLog("Error writing to database " + e);
                //}

       //     }




            //    //using (SqlConnection myconnection = new SqlConnection("Server=580462-TEDBO05\\SQL019;Database=LowellServices;Trusted_Connection=True;"))

            //    {
            //        myconnection.Open();
            //        try
            //        {
            //            SqlDataReader myReader = null;
            //            SqlCommand myCommand = new SqlCommand("select top 10 * from customer", myconnection);
            //            var dataReadMemberId = "stuff"; //this is just so we can see what is being read from database
            //            var dataReadEmail = "stuff";
            //            var dataReadDOB = "stuff";
            //            var dataReadPostCode = "stuff";

            //            //Alternative syntax
            //            string commandString2 = "SELECT TOP 5 MemberId, Email,DateOfBirth,[PostCode] FROM [Customer] WHERE [LandlinePhone] IS NULL";
            //            SqlCommand myCommand2= new SqlCommand();
            //            myCommand2.Connection = myconnection; //we are connecting to same database as before
            //            myCommand2.CommandText = commandString2;

            //            //Alternative syntax
            //            //SqlCommand myCommand2 = new SqlCommand(commandString2, myconnection);

            //            myReader = myCommand2.ExecuteReader(); //Initialises the reader



            //            while (myReader.Read()) //I believe that this checks to see if there is any more data to read.
            //            {
            //                //The value in the square brackets is the database column name
            //                Console.WriteLine(myReader["MemberId"].ToString());

            //                dataReadMemberId = myReader["MemberId"].ToString();
            //                dataReadEmail = myReader["Email"].ToString();
            //                dataReadPostCode = myReader["PostCode"].ToString();
            //                dataReadDOB = myReader["DateOfBirth"].ToString();

            //            }

            //        }
            //        catch (Exception e)
            //        {

            //            ObjectRepository.writer.WriteToLog("Error writing to database " + e);
            //        }

            //    }
            //}

        }
        
    }
}
