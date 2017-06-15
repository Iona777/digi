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
    public sealed class BudgetCalculatorValidationSteps
    {

        

        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        [Then(@"Validate that error messages for invalid data are displayed for each field using data from file '(.*)'")]
            public void ThenValidateThatErrorMessagesForInvalidDataAreDisplayedForEachFieldUsingDataFromFile(string invalidInputFileName)
            {
            //This is a more complex validation method. It will read in multiple rows of invalid data and check for the presence of the 
            //error messages for each set of input data. The input and assert need to be in the same method since both need to be done
            //for each iteration of the loop.

            DataSet inputDataSet;

            inputDataSet = ValidationHelper.GetInputDataFromfile(invalidInputFileName);

            // This will return the number rows read so this can be used to loop round the dataset
            DataTable tableOfData = new DataTable();
            tableOfData = inputDataSet.Tables[0];
            int numberOfInputRows = tableOfData.Rows.Count;

            for (int index = 0; index < numberOfInputRows; index++)
            {
                ObjectRepository.theDigitalBudgetCalc_IncomePage.populateIncomeFieldsFromDataSet(inputDataSet,index,"Monthly");
                ObjectRepository.theDigitalBudgetCalc_IncomePage.clickContinueButton();
                Assert.IsTrue(ObjectRepository.theDigitalBudgetCalc_IncomePage.AllIncomeErrorMsgsDisplayed(), "Checking that budget calculator income error messages are al displayed");
                Thread.Sleep(500);
            }
        }


        [When(@"Populate the Budget Calculator Income Page with invalid alphabetic data using data from file '(.*)'")]
        public void WhenPopulateTheBudgetCalculatorIncomePageWithInvalidAlphabeticDataUsingDataFromFile(string invalidInputFileName)
        {
            //This is a simple validation that just takes one row of invalid data before checking for the presence of the error messages
            DataSet inputDataSet;

            inputDataSet = ValidationHelper.GetInputDataFromfile(invalidInputFileName);


            ObjectRepository.theDigitalBudgetCalc_IncomePage.populateIncomeFieldsFromDataSet(inputDataSet,0,"Monthly");
            ObjectRepository.theDigitalBudgetCalc_IncomePage.clickContinueButton();
        }



        [Then(@"The error messages for invalid alphabetic data are displayed for each field")]
        public void ThenTheErrorMessagesForInvalidAlphabeticDataAreDisplayedForEachField()
        {
            Assert.IsTrue(ObjectRepository.theDigitalBudgetCalc_IncomePage.AllIncomeErrorMsgsDisplayed(), "Checking that budget calculator income error messages are al displayed");
        }


    }
}
