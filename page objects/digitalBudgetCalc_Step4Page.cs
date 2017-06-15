using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Digital.BaseClasses;
using Digital.ComponentHelper;
using Digital.Settings;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Digital.PageObject
{
    public class digitalBudgetCalc_Step4Page : digitalNavigationBar
    {
        private IWebDriver driver;

        #region fileData fields
        //Input data fields from file
        private string fileData_Balance; //NEED TO ADD THIS TO INPUT FILE
        #endregion

        #region element locators
        //BudgetCalculator_Step4
        public const string MonthlyIncomeLocator            = "//*[@id='content']/div/div/div[1]/p[2]/span[2]";
        public const string PriorityHouseholdBillsLocator   = "//*[@id='content']/div/div/div[1]/p[3]/span[2]";
        public const string MonthlyDisposableIncomeLocator  = "//*[@id='content']/div/div/div[1]/p[4]/span[2]";
        
        //BudgetCalculator_Step4 - payment predictor, may not be required?
        public const string PaymentPredictor_MonthlyLocator     = "//*[@value='Monthly'][@type='radio']";
        public const string PaymentPredictor_FourWeeklyLocator  = "//*[@value='FourWeekly'][@type='radio']";
        public const string PaymentPredictor_FortnightlyLocator = "//*[@value='Fortnightly'][@type='radio']";
        public const string PaymentPredictor_WeeklyLocator      = "//*[@value='Weekly'][@type='radio']";
        public const string PaymentPredictor_BalanceLocator     = "//*[@id='balance']";
        public const string PaymentPredictor_InstalmentsLocator = "//*[@id='time']";
        public const string PaymentPredictor_AmountLocator      = "//*[@id='amount']";
        public const string PaymentPredictor_InstalDisplayLocator = "//*[@id='timeDisplay']";
        public const string PaymentPredictor_AmountDisplayLocator = "//*[@id='amountDisplay']";

        //This is the Payment Options button if you access Budget Calculator anonymously.
        public const string MyAccountButtonLocator  = "//*[@id='next']";
        public const string BackButtonLocator       = "//*[@value='Back']";
        
        #endregion

        #region WebElement
        [FindsBy(How = How.XPath, Using = PaymentPredictor_MonthlyLocator)]
        private IWebElement PaymentPredictor_Monthly;

        [FindsBy(How = How.XPath, Using = PaymentPredictor_FourWeeklyLocator)]
        private IWebElement PaymentPredictor_FourWeekly;

        [FindsBy(How = How.XPath, Using = PaymentPredictor_FortnightlyLocator)]
        private IWebElement PaymentPredictor_Fortnightly;

        [FindsBy(How = How.XPath, Using = PaymentPredictor_WeeklyLocator)]
        private IWebElement PaymentPredictor_Weekly;

        [FindsBy(How = How.XPath, Using = PaymentPredictor_BalanceLocator)]
        private IWebElement PaymentPredictor_Balance;

        [FindsBy(How = How.XPath, Using = PaymentPredictor_InstalmentsLocator)]
        private IWebElement PaymentPredictor_InstalmentsSlider;

        [FindsBy(How = How.XPath, Using = PaymentPredictor_AmountLocator)]
        private IWebElement PaymentPredictor_AmountSlider;

        [FindsBy(How = How.XPath, Using = PaymentPredictor_InstalDisplayLocator)]
        private IWebElement PaymentPredictor_InstalmentsDisplay;

        [FindsBy(How = How.XPath, Using = PaymentPredictor_AmountDisplayLocator)]
        private IWebElement PaymentPredictor_AmountDisplay;

        [FindsBy(How = How.XPath, Using = MyAccountButtonLocator)]
        private IWebElement MyAccountButton;

        [FindsBy(How = How.XPath, Using = BackButtonLocator)]
        private IWebElement BackButton;
        #endregion

        //I tried to change this to use PAGEFACTORY.INITELEMENTS(), but base page uses PageFactory, so no need?
        public digitalBudgetCalc_Step4Page(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions
        public DataSet readFileIntoDataSet(string fileToUse)
        {
            DataSet inputData;

            //Reads data from file into a dataset that is declared above
            inputData = ReadExcelFile.xlsxReadFile(fileToUse, true);
            return inputData;
        }


        public void getStep4InputDataFromFile(string fileToUse)
        { 
            //This is for use when you only want to use one row of input data.

            //Reads data from input file into a dataset 
            DataSet inputData = readFileIntoDataSet(fileToUse);

            //Read specic cells of that dataset into variables 
            fileData_Balance = ReadExcelFile.readSpecificCell(inputData,0,"Balance");
        }


        public void getStep4InputDataFromDataSet(DataSet inputDataSet, int rowToRead)
        {
            //This is for use when you want to use multiple rows of input data.
            //The full input file will be read into a dataset prior to calling this method
            //and then passed to this method as a parameter. This avoids the file being read
            //on each iteration.
            //The calling method will call this method within a loop and pass in a different rowToRead
            //on each iteration. 

            //Read specific cells of that dataset into variables 
            fileData_Balance = ReadExcelFile.readSpecificCell(inputDataSet, rowToRead, "Balance");
            
        }

        public void populateStep4FieldsFromFile(string inputFileName)
        {
            //Use this version of the method if you are just reading one line of input data
            ObjectRepository.writer.WriteToLog("This Budget Calculator dependants page is being completed");

            getStep4InputDataFromFile(inputFileName);

            enterBalance(fileData_Balance.ToString());
        }


        public void populateStep4FieldsFromDataSet(DataSet inputDataSet, int rowToRead, string frequency)
        {
            //This can be used with tests where the input dataset is populated with multiple rows
            //and this method is called once for each row

            //Reads specific cells of that dataset into variables 
            getStep4InputDataFromDataSet(inputDataSet, rowToRead);

            enterBalance(fileData_Balance.ToString());
        }



        //These methods are used to send the data to the webpage.

        //Populate Payment Predictor Balance
        public void enterBalance(string input)
        {
            DataEntryHelper.EnterText(input, PaymentPredictor_Balance);
        }

        
        //Click the various buttons, this means they are accessible from outside of the page
        //These methods should be renamed once this is split into multiple page objects
        public void clickContinueButton()
        {
            DataEntryHelper.ButtonClick(MyAccountButton);
        }

        public void clickBackButton()
        {
            DataEntryHelper.ButtonClick(BackButton);
        }
        
        //Looks like this is inherited from NavigationBar. See if removing it causes problems.         
        //public void refresh()
        //{
        //    driver.Navigate().Refresh();
        //}

        #endregion
    }
}
