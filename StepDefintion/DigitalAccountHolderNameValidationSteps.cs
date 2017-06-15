using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Data;
using TechTalk.SpecFlow;
using Digital.Settings;
using Digital.ComponentHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excel;


namespace Digital
{
    [Binding]
    public sealed class DigitalAccountHolderNameValidationSteps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        


        [When(@"I navigate to the Direct Debit page")]
        public void WhenINavigateToTheDirectDebitPage()
        {
            ObjectRepository.digitalDirectDebitJourney = ObjectRepository.newDigitalMyAccountPage.navigateToDirectDebitPlan();
        }

        [When(@"I submit the page while leaving the Bank Account Holder Name field blank")]
        public void WhenISubmitThePageWhileLeavingTheBankAccountHolderNameFieldBlank()
        {
            Thread.Sleep(2000);
            ObjectRepository.digitalDirectDebitJourney.clickContinueButton();
        }

        [Then(@"the '(.*)' message should be displayed on the screen")]
        public void ThenTheMessageShouldBeDisplayedOnTheScreen(string expectedErrorMsg)
        {
            Thread.Sleep(2000);
            Assert.IsTrue(ObjectRepository.digitalDirectDebitJourney.getAccountHolderErrorMsg() == expectedErrorMsg, "Checking account holder name  error message");
        }




        [Then(@"Validate the Account Holder Name field using data read from the file '(.*)'")]
        public void ThenValidateTheAccountHolderNameFieldUsingDataReadFromTheFile(string inputFileName)
        {
            DataSet inputDataSet;
            string inputColumnName = "Invalid AccountHolder Name";
            string expectedErrorMsg = "The field Account Holder's Name must only contain letters, hyphen, full stop and apostrophe.";

            //Reading from an xlsx Excel file (2007 format; *.xlsx)
            inputDataSet = ValidationHelper.GetInputDataFromfile(inputFileName);

            //FileStream stream = File.Open(inputFileName, FileMode.Open, FileAccess.Read);
            //IExcelDataReader xlsxReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            //This will read the input data from the file into a dataset 
            //inputDataSet = ObjectRepository.digitalDirectDebitJourney.readInputDataFromFile(inputFileName,xlsxReader);

            // This will return the number rows read so this can be used to loop round the dataset
            DataTable tableOfData = new DataTable();
            tableOfData = inputDataSet.Tables[0];
            int numberOfInputRows = tableOfData.Rows.Count;


            for (int index = 0; index < numberOfInputRows; index++) //might need to amend index so it does not read the header
            {
                //This will set the value of 'fileData_AccountHolderName' variable within the page object
                ObjectRepository.digitalDirectDebitJourney.getInputDataFromDataSet(inputDataSet,index,inputColumnName);
                //This will populate the Account Holder Name field with the value from fileData_AccountHolderName
                ObjectRepository.digitalDirectDebitJourney.enterAccountHolderNameFromFile();
                Thread.Sleep(500);
                ObjectRepository.digitalDirectDebitJourney.clickContinueButton();

                string dataUsed = ObjectRepository.digitalDirectDebitJourney.getFileData_AccountHolderName();

                //Check error message. Need to Assert here, but that means changing the feature file
                Assert.IsTrue(ObjectRepository.digitalDirectDebitJourney.getAccountHolderErrorMsg() == expectedErrorMsg
                ,"Checking account holder name  error message. Data used= "+dataUsed);


                ObjectRepository.digitalDirectDebitJourney.clearAccountHolderName();
                ObjectRepository.digitalDirectDebitJourney.refresh();
            }
        }

    }
}
