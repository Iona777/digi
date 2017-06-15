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
using System.Text.RegularExpressions;
using System.Globalization;

namespace Digital.PageObject
{
    public class digitalRegisterPage : digitalNavigationBar
    {
        private IWebDriver driver;

        #region fileData fields
        //Input data fields from file
        private string fileData_LowellRefNo;
        private string fileData_DOB;
        private string fileData_Postcode;
        private string fileData_LandlinePhone;
        private string fileData_MobilePhone;
        private string fileData_Email;
        private string fileData_ConfirmEmail;
        private string fileData_Password;
        private string fileData_ConfirmPassword;
        #endregion

        #region element locators      
        public const string RegisterLowellRefNoLocator      = "//*[@id='Register_LowellReference']";
        public const string RegisterDOBLocator              = "//*[@id='Register_DateOfBirth']";
        public const string RegisterPostCodeLocator         = "//*[@id='Register_PostCode']";
        public const string RegisterLandlinePhoneLocator    = "//*[@id='Register_LandlinePhone']";
        public const string RegisterMobilePhoneLocator      = "//*[@id='Register_MobilePhone']";
        public const string RegisterEmailLocator            = "//*[@id='Register_Email']";
        public const string RegisterConfirmEmailLocator     = "//*[@id='Register_ConfirmEmail']";
        public const string RegisterPasswordLocator         = "//*[@id='Register_Password']";
        public const string RegisterConfirmPasswordLocator  = "//*[@id='Register_ConfirmPassword']";
        public const string RegisterContinueBtnLocator      = "//*[@id='Register']";
        public const string RegisterFinishBtnLocator        = "//*/a[text()='Finish']";

        //Error messages - some of these locators are used for more than one error message. 
        public const string LowellRefNoErrorMsgLocator  = "//*[@id='Register_LowellReference-error']";
        public const string DOBErrorMsgLocator          = "//*[@id='Register_DateOfBirth-error']";
        public const string PostCodeErrorMsgLocator     = "//*[@id='Register_PostCode-error']";
        public const string EmailErrorMsgLocator        = "//*[@id='Register_Email-error']";
        public const string PasswordErrorMsgLocator     = "//*[@id='Register_Password-error']";
        #endregion

        #region WebElement
        [FindsBy(How = How.XPath, Using = RegisterLowellRefNoLocator)]
        private IWebElement LowellRefNo;

        [FindsBy(How = How.XPath, Using = RegisterDOBLocator)]
        private IWebElement DOB;

        [FindsBy(How = How.XPath, Using = RegisterPostCodeLocator)]
        private IWebElement Postcode;

        [FindsBy(How = How.XPath, Using = RegisterLandlinePhoneLocator)]
        private IWebElement LandlinePhone;

        [FindsBy(How = How.XPath, Using = RegisterMobilePhoneLocator)]
        private IWebElement MobilePhone;

        [FindsBy(How = How.XPath, Using = RegisterEmailLocator)]
        private IWebElement Email;

        [FindsBy(How = How.XPath, Using = RegisterConfirmEmailLocator)]
        private IWebElement ConfirmEmail;

        [FindsBy(How = How.XPath, Using = RegisterPasswordLocator)]
        private IWebElement Password;

        [FindsBy(How = How.XPath, Using = RegisterConfirmPasswordLocator)]
        private IWebElement ConfirmPassword;

        [FindsBy(How = How.XPath, Using = RegisterContinueBtnLocator)]
        private IWebElement ContinueButton;

        [FindsBy(How = How.XPath, Using = RegisterFinishBtnLocator)]
        private IWebElement FinishButton;
        
        
        //Error Messages
        [FindsBy(How = How.CssSelector, Using = LowellRefNoErrorMsgLocator)]
        private IWebElement LowellRefNoErrorMsg;

        [FindsBy(How = How.CssSelector, Using = DOBErrorMsgLocator)]
        private IWebElement DOBErrorMsg;

        [FindsBy(How = How.CssSelector, Using = PostCodeErrorMsgLocator)]
        private IWebElement PostCodeErrorMsg;

        [FindsBy(How = How.CssSelector, Using = EmailErrorMsgLocator)]
        private IWebElement EmailErrorMsg;

        [FindsBy(How = How.CssSelector, Using = PasswordErrorMsgLocator)]
        private IWebElement PasswordErrorMsg;
        #endregion
        //I tried to change this to use PAGEFACTORY.INITELEMENTS(), but base page uses PageFactory, so no need?
        public digitalRegisterPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions
        public bool AllRegisterErrorMsgsDisplayed()
        //If any of the error messages are missing, the WaitForElement will timeout and
        //return an exception. This will then cause this method to return false
        {
            try
            {
                DataEntryHelper.WaitForElementByXpath(LowellRefNoErrorMsgLocator);
                DataEntryHelper.WaitForElementByXpath(DOBErrorMsgLocator);
                DataEntryHelper.WaitForElementByXpath(PostCodeErrorMsgLocator);
                DataEntryHelper.WaitForElementByXpath(EmailErrorMsgLocator);
                DataEntryHelper.WaitForElementByXpath(PasswordErrorMsgLocator);
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

        public void getRegistrationInputDataFromFile(string fileToUse)
        {
            //This is for use when you only want to use one row of input data.

            //Reads data from input file into a dataset 
            DataSet inputData = readFileIntoDataSet(fileToUse);

            //Read specic cells of that dataset into variables 
            fileData_LowellRefNo        = ReadExcelFile.readSpecificCell(inputData, 0, "LowellRefNo");
            fileData_DOB                = ReadExcelFile.readSpecificCell(inputData, 0, "DOB");
            fileData_Postcode           = ReadExcelFile.readSpecificCell(inputData, 0, "Postcode");
            fileData_LandlinePhone      = ReadExcelFile.readSpecificCell(inputData, 0, "LandlinePhone");
            fileData_MobilePhone        = ReadExcelFile.readSpecificCell(inputData, 0, "MobilePhone");
            fileData_Email              = ReadExcelFile.readSpecificCell(inputData, 0, "Email");
            fileData_ConfirmEmail       = ReadExcelFile.readSpecificCell(inputData, 0, "ConfirmEmail");
            fileData_Password           = ReadExcelFile.readSpecificCell(inputData, 0, "Password");
            fileData_ConfirmPassword    = ReadExcelFile.readSpecificCell(inputData, 0, "ConfirmPassword");
        }


        public void getRegistrationInputDataFromDataSet(DataSet inputDataSet, int rowToRead)
        {
            //This is for use when you want to use multiple rows of input data.
            //The full input file will be read into a dataset prior to calling this method
            //and then passed to this method as a parameter. This avoids the file being read
            //on each iteration.
            //The calling method will call this method within a loop and pass in a different rowToRead
            //on each iteration. 

            //Read specific cells of that dataset into variables 
            fileData_LowellRefNo        = ReadExcelFile.readSpecificCell(inputDataSet, rowToRead, "LowellRefNo");
            fileData_DOB                = ReadExcelFile.readSpecificCell(inputDataSet, rowToRead, "DOB");
            fileData_Postcode           = ReadExcelFile.readSpecificCell(inputDataSet, rowToRead, "Postcode");
            fileData_LandlinePhone      = ReadExcelFile.readSpecificCell(inputDataSet, rowToRead, "LandlinePhone");
            fileData_MobilePhone        = ReadExcelFile.readSpecificCell(inputDataSet, rowToRead, "MobilePhone");
            fileData_Email              = ReadExcelFile.readSpecificCell(inputDataSet, rowToRead, "Email");
            fileData_ConfirmEmail       = ReadExcelFile.readSpecificCell(inputDataSet, rowToRead, "ConfirmEmail");
            fileData_Password           = ReadExcelFile.readSpecificCell(inputDataSet, rowToRead, "Password");
            fileData_ConfirmPassword    = ReadExcelFile.readSpecificCell(inputDataSet, rowToRead, "ConfirmPassword");
        }

        public void populateRegistrationFieldsFromFile(string inputFileName)
        {
            //Use this version of the method if you are just reading one line of input data
            ObjectRepository.writer.WriteToLog("This Budget Calculator dependants page is being completed");

            getRegistrationInputDataFromFile(inputFileName);

            enterLowellRefNo(fileData_LowellRefNo);
            enterDOB(fileData_DOB);
            enterPostCode(fileData_Postcode);
            enterLandlinePhone(fileData_LandlinePhone);
            enterMobilePhone(fileData_MobilePhone);
            enterEmail(fileData_Email);
            enterConfirmEmail(fileData_ConfirmEmail);
            enterPassword(fileData_Password);
            enterConfirmPassword(fileData_ConfirmPassword);
        }


        public void populateRegistrationFieldsFromDataSet(DataSet inputDataSet, int rowToRead, string frequency)
        {
            //This can be used with tests where the input dataset is populated with multiple rows
            //and this method is called once for each row

            //Reads specific cells of that dataset into variables 
            getRegistrationInputDataFromDataSet(inputDataSet, rowToRead);

            enterLowellRefNo(fileData_LowellRefNo);
            enterDOB(fileData_DOB);
            enterPostCode(fileData_Postcode);
            enterLandlinePhone(fileData_LandlinePhone);
            enterMobilePhone(fileData_MobilePhone);
            enterEmail(fileData_Email);
            enterConfirmEmail(fileData_ConfirmEmail);
            enterConfirmPassword(fileData_ConfirmPassword);
        }



        //These methods are used to send the data to the webpage.
        public void enterLowellRefNo(string input)
        {
            DataEntryHelper.EnterText(input, LowellRefNo);
        }


        public void enterDate(DateTime input)
        {
            string dateAsString = input.ToString("dd/MM/yyyy");
            DataEntryHelper.EnterText(dateAsString, DOB);   
        }

        public void enterDOB(string input)
        {
            DataEntryHelper.EnterText(input, DOB);
        }

        public void enterPostCode(string input)
        {
            DataEntryHelper.EnterText(input, Postcode);
        }

        public void enterLandlinePhone(string input)
        {
            DataEntryHelper.EnterText(input, LandlinePhone);
        }

        public void enterMobilePhone(string input)
        {
            DataEntryHelper.EnterText(input, MobilePhone);
        }

        public void enterEmail(string input)
        {
            DataEntryHelper.EnterText(input, Email);
        }

        public void enterConfirmEmail(string input)
        {
            DataEntryHelper.EnterText(input, ConfirmEmail);
        }

        public void enterPassword(string input)
        {
            DataEntryHelper.EnterText(input,Password);
        }

        public void enterConfirmPassword(string input)
        {
            DataEntryHelper.EnterText(input, ConfirmPassword);
        }

        //Click the various buttons, this means they are accessible from outside of the page
        public void clickContinueButton()
        {
            DataEntryHelper.ButtonClick(ContinueButton);
        }

        public void clickFinishButton()
        {
            DataEntryHelper.ButtonClick(FinishButton);
        }

        //Looks like this is inherited from NavigationBar. See if removing it causes problems.         
        //public void refresh()
        //{
        //    driver.Navigate().Refresh();
        //}
        #endregion
    }
}
