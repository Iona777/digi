using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Digital.BaseClasses;
using Digital.ComponentHelper;
using Digital.Settings;
using Excel;

namespace Digital.PageObject
{
    public class digital_LO_DirectDebitPlanPage1 : digitalNavigationBar
    {
        private IWebDriver driver;

        private string fileData_AccountHolderName;


        //NOTE: these 2 should NOT be displayed for logged out journeys. Locator included for tests that check for absence of these elements
        public const string DiscountedBalanceButtonLocator = "[id='DiscountedPaymentSelected'][value='True']";
        public const string FullBalanceButtonLocator = "[id='DiscountedPaymentSelected'][value='False']";
        
        
        public const string RepaymentAmountLocator      = "[id='PaymentAmount']";
        public const string FrequencyDropdownLocator    = "[id='PaymentFrequency']";
        public const string StartDateLocator            = "[id='DDStartDate']";
        public const string AccountHolderNameLocator    = "[id='AccountHolderName']";
        public const string AccountNumberLocator        = "[id='AccountNumber']";
        public const string SortCodeLocator             = "[id='SortCode']";
        public const string DDGuaranteeCheckboxLocator  = "[name='DDConfirm'][id='DDConfirm']";        
        public const string TermsCheckBoxLocator        = "[id='CheckTerms']";
        public const string EmailAddressLocator         = "[id='Email']";
        public const string RetypeEmailLocator          = "[id='ConfirmEmail']";
        public const string ContinueButtonLocator       = "[value='Continue'][type='submit']";
        public const string BackButtonLocator           = "[value='Back'][type='button']";
        public const string DDGuaranteeLinkLocator      = "a[href='/media/1057/dd.pdf']";
        public const string DiscountButtonLocator       = "[id='DiscountedPaymentSelected'][value='True']";
        public const string NoDiscountButtonLocator     = "[id='DiscountedPaymentSelected'][value='False']";


        //Error messages
        public const string AccountHolderNameErrorLocator = "[id='AccountHolderName-error']";
        public const string AccountNoErrorMsgLocator    = "[data-valmsg-for= 'AccountNumber']";
        public const string SortCodeErroMsgLocator      = "[id='SortCode-error']";
        public const string ModulusErrorMsgLocator      = "//*[@id='layout-main']/div/div/form/div/div/div[1]/div/ul/li";

        //Constant data
        public const string EmailAddressInput = "autoTestLO@test.com";


        #region WebElements
        [FindsBy(How = How.CssSelector, Using = RepaymentAmountLocator)]
        private IWebElement RepaymentAmount;

        [FindsBy(How = How.CssSelector, Using = FrequencyDropdownLocator)]
        private IWebElement FrequencyDropdown;

        [FindsBy(How = How.CssSelector, Using = StartDateLocator)]
        private IWebElement StartDate;

        [FindsBy(How = How.CssSelector, Using = AccountHolderNameLocator)]
        private IWebElement AccountHolderName;

        [FindsBy(How = How.CssSelector, Using = AccountNumberLocator)]
        private IWebElement AccountNumber;

        [FindsBy(How = How.CssSelector, Using = SortCodeLocator)]
        private IWebElement SortCode;

        [FindsBy(How = How.CssSelector, Using = DDGuaranteeCheckboxLocator)]
        private IWebElement DDGuaranteeCheckbox;

        [FindsBy(How = How.CssSelector, Using = TermsCheckBoxLocator)]
        private IWebElement TermsCheckBox;

        [FindsBy(How = How.CssSelector, Using = EmailAddressLocator)]
        private IWebElement EmailAddress;

        [FindsBy(How = How.CssSelector, Using = RetypeEmailLocator)]
        private IWebElement RetypeEmail;

        [FindsBy(How = How.CssSelector, Using = DDGuaranteeLinkLocator)]
        private IWebElement DDGuaranteeLink;


        [FindsBy(How = How.CssSelector, Using = ContinueButtonLocator)]
        private IWebElement ContinueButton;

        [FindsBy(How = How.CssSelector, Using = BackButtonLocator)]
        private IWebElement BackButton;

        [FindsBy(How = How.CssSelector, Using = AccountHolderNameErrorLocator)]
        private IWebElement AccountHolderNameError;

        [FindsBy(How = How.CssSelector, Using = AccountNoErrorMsgLocator)]
        private IWebElement AccountNoErrorMsg;

        [FindsBy(How = How.CssSelector, Using = SortCodeErroMsgLocator)]
        private IWebElement SortCodeErrorMsg;

        [FindsBy(How = How.XPath, Using = ModulusErrorMsgLocator)]
        private IWebElement ModulusErrorMsg;

        //These elements are not displayed. Just included for tests that confirm absence.
        [FindsBy(How = How.CssSelector, Using = DiscountButtonLocator)]
        private IWebElement DiscountButton;

        [FindsBy(How = How.CssSelector, Using = NoDiscountButtonLocator)]
        private IWebElement NoDiscountButton;

        #endregion

        //Constructor
        public digital_LO_DirectDebitPlanPage1(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions
        public void setupDDplan(decimal paymentAmount, string frequency, 
            string accountHolderName, string accountNumber, string sortCode, string emailAddress)
        {
            DataEntryHelper.WaitForElementByCSS(RepaymentAmountLocator);
            RepaymentAmount.SendKeys(paymentAmount.ToString("0.00"));
            
            DataEntryHelper.SelectFreqByText(frequency, FrequencyDropdown);
            /*uncomment the following line when caseflow date is correct date rather than in future or in past*/
            //StartDate.Clear();            
            //StartDate.SendKeys((DateTime.Now.AddDays(14)).ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
            
            //Accept default Start Date
            AccountHolderName.SendKeys(accountHolderName);
            AccountNumber.SendKeys(accountNumber);
            SortCode.SendKeys(sortCode);
            enterEmailAddress(emailAddress);
            enterRetypeEmailAddress(emailAddress);
            tickDDGuaranteeCheckbox();
            tickTermsCheckbox();
        }

               
        public string  getAccountHolderErrorMsg()
        {
            try
            {
                DataEntryHelper.WaitForElementByXpath(AccountHolderNameErrorLocator);
                return AccountHolderNameError.GetAttribute("textContent");
            }
            catch (Exception e)
            {

                return "no error message shown";
            }
        }

    
        public string getAccountNoErrorMsg()
        {
            try
            {
                DataEntryHelper.WaitForElementByCSS(AccountNoErrorMsgLocator);
                return AccountNoErrorMsg.GetAttribute("textContent");
            }
            catch (Exception)
            {

                return "no error msessage shown";
            }
        }

        public string getSortCodeErrorMsg()
        {
            try
            {
                DataEntryHelper.WaitForElementByCSS(SortCodeErroMsgLocator);
                return SortCodeErrorMsg.GetAttribute("textContent");
            }
            catch (Exception)
            {

                return "no error msessage shown";
            }
        }

        public string getModulusErrorMsg()
        {
            try
            {
                DataEntryHelper.WaitForElementByXpath(ModulusErrorMsgLocator);
                return ModulusErrorMsg.GetAttribute("textContent");
            }
            catch (Exception)
            {

                return "no error msessage shown";
            }

        }


        //If using the following methods to enter the data from a file, will need to create more fileData_ fields
        //for the other fields to be entered
        public DataSet readInputDataFromFile(string filetoUse, IExcelDataReader reader)
        {
            DataSet inputData;
            int numberofInputRows;

            //Reads data from file into a dataset that is declared above
            inputData = ReadExcelFile.xlsxReadFile(reader, filetoUse, true);

            //Return number of rows in dataset to calling method so it knows how many times to loop
            DataTable tableOfData = new DataTable();
            tableOfData = inputData.Tables[0];
            //            numberofInputRows = table.Rows.Count;

            return inputData;
        }

        public void getInputDataFromDataSet(DataSet inputData, int rowToRead, string colName)
        {
            //Read specific cells of that dataset into variables . This can be expanded to read data
            //for more fields as necessary. See the digitalBudgetCalculatorPage for example of
            //how to do this.
            fileData_AccountHolderName = ReadExcelFile.readSpecificCell(inputData, rowToRead, colName);   
        }

        

        public void enterAccountHolderName(string input)
        {
            DataEntryHelper.EnterText(input, AccountHolderName);
        }

        public void enterAccountHolderNameFromFile()
        {
            DataEntryHelper.EnterText(fileData_AccountHolderName, AccountHolderName);
        }

        public void clearAccountHolderName()
        {
            AccountHolderName.Clear();
        }

        public void tickTermsCheckbox()
        {
            DataEntryHelper.ButtonClick(TermsCheckBox);
        }

        public void tickDDGuaranteeCheckbox()
        {
            DataEntryHelper.ButtonClick(DDGuaranteeCheckbox);
        }
        
        public void enterEmailAddress(string input)
        {
            DataEntryHelper.EnterText(input,EmailAddress);
        }


        public void enterRetypeEmailAddress(string input)
        {
            DataEntryHelper.EnterText(input,RetypeEmail);
        }


        public string clickDDGuaranteeLink()
        {
            string ddURL = DDGuaranteeLink.GetAttribute("href");
            DataEntryHelper.ButtonClick(DDGuaranteeLink);

            return ddURL;
        }


        public void clickContinueButton()
        {
            DataEntryHelper.ButtonClick(ContinueButton);
        }

        public void clickBackButton()
        {
            DataEntryHelper.ButtonClick(BackButton);
        }

        
        public string getInputtedStartDate()
        {
            return StartDate.GetAttribute("value");
        }

        public bool discountButtonsNotDisplayed()
        {
            //Check for presence of Continue button to check that page has loaded
            GenericHelper.IsElementClickable(ContinueButton);

            //Check that NEITHER of the buttons are displayed. If either is displayed
            //then we get a displayed = true, which then returns a false

            try
            {
                return !(DiscountButton.Displayed);
            }
            catch (OpenQA.Selenium.NoSuchElementException)
            {

                //Continue. The DiscountButton not displayed, now check for NoDiscountButton
            }
            try
            {
                return !(NoDiscountButton.Displayed);
            }
            catch (OpenQA.Selenium.NoSuchElementException)
            {

                return true;
            }

        }

        public bool isRepaymentAmountEmpty()
        {
            bool RepaymentAmountEmpty = false;

            if (RepaymentAmount.Text.Length == 0)
                RepaymentAmountEmpty = true;

            return RepaymentAmountEmpty;
        }


        #endregion
    }
}
