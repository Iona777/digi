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
    public class digitalBudgetCalc_DependantsPage : digitalNavigationBar
    {
        private IWebDriver driver;

        #region fileData fields
        //Input data fields from file
        private string fileData_DependentAdults;
        private string fileData_DependentChild14to18;
        private string fileData_DependentChildUnder14;
        #endregion

        #region element locators
        //BugetCalculator_Dependants
        public const string DependentAdultsLocator          = "//*[@id='dependants_Adults']";
        public const string Dependent14to18ChildrenLocator  = "//*[@id='dependants_Child14to18']";
        public const string DependentUnder14ChildLocator    = "//*[@id='dependants_ChildUnder14']";
        public const string TotalDependentsLocator          = "//*[@id='dependenciesDisplay']";
        public const string ContinueButtonLocator           = "//*[@value='Continue']";
        public const string BackButtonLocator               = "//*[@value='Back']";

        //Error messages - these locators use CSSSelectors 
        public const string AdultsErroMsgLocator        = "[data-valmsg-for='dependants.Adults']";
        public const string Child14To18ErroMsgLocator   = "[data-valmsg-for='dependants.Child14to18']";
        public const string ChildUnder14ErroMsgLocator  = "[data-valmsg-for='dependants.ChildUnder14']";
        #endregion

        #region WebElement
        [FindsBy(How = How.XPath, Using = DependentAdultsLocator)]
        private IWebElement DependentAdults;

        [FindsBy(How = How.XPath, Using = Dependent14to18ChildrenLocator)]
        private IWebElement Dependent14to18Children;

        [FindsBy(How = How.XPath, Using = DependentUnder14ChildLocator)]
        private IWebElement DependentUnder14Child;

        [FindsBy(How = How.XPath, Using = TotalDependentsLocator)]
        private IWebElement TotalDependents;

        [FindsBy(How = How.XPath, Using = ContinueButtonLocator)]
        private IWebElement ContinueButton;

        [FindsBy(How = How.XPath, Using = BackButtonLocator)]
        private IWebElement BackButton;

        //Error Messages
        [FindsBy(How = How.CssSelector, Using = AdultsErroMsgLocator)]
        private IWebElement AdultsErrorMsg;

        [FindsBy(How = How.CssSelector, Using = Child14To18ErroMsgLocator)]
        private IWebElement Child14To18ErrorMsg;

        [FindsBy(How = How.CssSelector, Using = ChildUnder14ErroMsgLocator)]
        private IWebElement ChildUnder14ErrorMsg;
        #endregion

        //I tried to change this to use PAGEFACTORY.INITELEMENTS(), but base page uses PageFactory, so no need?
        public digitalBudgetCalc_DependantsPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions
        public bool AllDependantsErrorMsgsDisplayed()
        //If any of the error messages are missing, the WaitForElement will timeout and
        //return an exception. This will then cause this method to return false
        {
            try
            {
                DataEntryHelper.WaitForElementByCSS(AdultsErroMsgLocator);
                DataEntryHelper.WaitForElementByCSS(Child14To18ErroMsgLocator);
                DataEntryHelper.WaitForElementByCSS(ChildUnder14ErroMsgLocator);
            }
            catch (Exception e)
            {

                return false;
            }
            return true;
        }

        public DataSet readFileIntoDataSet(string fileToUse)
        {
            DataSet inputData;

            //Reads data from file into a dataset that is declared above
            inputData = ReadExcelFile.xlsxReadFile(fileToUse, true);
            return inputData;
        }


        public void getDependantsInputDataFromFile(string fileToUse)
        { 
            //This is for use when you only want to use one row of input data.

            //Reads data from input file into a dataset 
            DataSet inputData = readFileIntoDataSet(fileToUse);

            //Read specific cells of that dataset into variables 
            fileData_DependentAdults        = ReadExcelFile.readSpecificCell(inputData,0,"Dependent Adults");
            fileData_DependentChild14to18   = ReadExcelFile.readSpecificCell(inputData,0,"Dependent Child 14 to 18");
            fileData_DependentChildUnder14  = ReadExcelFile.readSpecificCell(inputData,0,"Dependent Child under 14");
        }

        
        public void getDependantsInputDataFromDataSet(DataSet inputDataSet, int rowToRead)
        {
            //This is for use when you want to use multiple rows of input data.
            //The full input file will be read into a dataset prior to calling this method
            //and then passed to this method as a parameter. This avoids the file being read
            //on each iteration.
            //The calling method will call this method within a loop and pass in a different rowToRead
            //on each iteration. 

            //Read specific cells of that dataset into variables 
            fileData_DependentAdults        = ReadExcelFile.readSpecificCell (inputDataSet, rowToRead, "Dependent Adults");
            fileData_DependentChild14to18   = ReadExcelFile.readSpecificCell (inputDataSet, rowToRead, "Dependent Child 14 to 18");
            fileData_DependentChildUnder14  = ReadExcelFile.readSpecificCell (inputDataSet, rowToRead, "Dependent Child under 14");   
        }


        public void populateDependantsFieldsFromFile(string inputFileName)
        {
            //Use this version of the method if you are just reading one line of input data
            ObjectRepository.writer.WriteToLog("This Budget Calculator dependants page is being completed");

            getDependantsInputDataFromFile(inputFileName);

            enterDependentAdults(fileData_DependentAdults.ToString());
            enterDependentChild14to18(fileData_DependentChild14to18.ToString());
            enterDependendChildUnder14(fileData_DependentChildUnder14.ToString());
        }


        public void populateDependantsFieldsFromDataSet(DataSet inputDataSet, int rowToRead, string frequency)
        {
            //This can be used with tests where the input dataset is populated with multiple rows
            //and this method is called once for each row

            //Reads specific cells of that dataset into variables 
            getDependantsInputDataFromDataSet(inputDataSet, rowToRead);

            enterDependentAdults(fileData_DependentAdults.ToString());
            enterDependentChild14to18(fileData_DependentChild14to18.ToString());
            enterDependendChildUnder14(fileData_DependentChildUnder14.ToString());
        }

        //These methods are used to send the data to the webpage.

        //Populate Dependents
        public void enterDependentAdults(string input)
        {
            DataEntryHelper.EnterText(input,DependentAdults);

        }

        public void enterDependentChild14to18(string input)
        {
            DataEntryHelper.EnterText(input,Dependent14to18Children);
        }

        public void enterDependendChildUnder14(string input)
        {
            DataEntryHelper.EnterText(input,DependentUnder14Child);
        }
        
        //Click the various buttons, this means they are accessible from outside of the page
        //These methods should be renamed once this is split into multiple page objects
        public void clickContinueButton()
        {
            DataEntryHelper.ButtonClick(ContinueButton);
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
