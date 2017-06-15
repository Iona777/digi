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
    public class digitalDirectDebitPlan : digitalNavigationBar
    {
        private IWebDriver driver;

        private string fileData_AccountHolderName;

        public const string DiscountedBalanceButtonLocator = "//*[@id=\"DiscountedPaymentGroup\"]/div[2]/div/label";
        public const string DiscountedBalanceLocator = "//*[@id=\"DiscountedOutstandingBalanceFormatted\"]";
        public const string FullBalanceButtonLocator = "//*[@id=\"FullPaymentGroup\"]/div[2]/div[1]/label";
        public const string FullBalanceLocator = "//*[@id=\"OutstandingBalanceFormatted\"]";
        public const string DiscountExpiryDateLocator = "//*[@id=\"AccountExpiresOnGroup\"]/div/p/span";
        public const string InstallmentAmountLocator = "//*[@id=\"PaymentAmount\"]";
        public const string FrequencyWeeklyLocator = "//*[@id=\"PaymentFrequency\"]/option[2]";
        public const string FrequencyFortnightlyLocator = "//*[@id=\"PaymentFrequency\"]/option[3]";
        public const string FrequencyFourWeeklyLocator = "//*[@id=\"PaymentFrequency\"]/option[4]";
        public const string FrequencyMonthlyLocator = "//*[@id=\"PaymentFrequency\"]/option[5]";
        public const string DDPlanStartDateLocator = "//*[@id=\"DDStartDate\"]";
        public const string AccountHolderNameLocator = "//*[@id='AccountHolderName']";
        public const string AccountNumberLocator = "//*[@id=\"AccountNumber\"]";
        public const string SsortCodeLocator = "//*[@id=\"SortCode\"]";
        public const string DDGauranteCheckboxLocator = "//*[@name=\"DDConfirm\" and @id=\"DDConfirm\"]";        
        public const string TermsCheckBoxLocator = "//*[@id=\"CheckTerms\"]";
        public const string ContinueButtonLocator  = "//*[@value=\"Continue\" and @name=\"buttonName\" and @type=\"submit\"]";
        public const string ContinueButton2Locator = "//*[@value=\"Continue\" and @name=\"buttonName\" and @type=\"submit\"]";
        public const string BackButtonLocator = "//*[@value=\"Back\" and @name=\"buttonName\" and @type=\"button\"]";
        public const string BackButton2Locator = "//*[@value=\"Back\" and @name=\"buttonName\" and @type=\"submit\"]";
        public const string GoToMyAccountLocator          = "//*[@id=\"layout-main\"]/div/a/button";
        public const string AccountHolderNameErrorLocator = "//*[@id='AccountHolderName-error']";

        #region WebElement

        [FindsBy(How = How.XPath, Using = DiscountedBalanceButtonLocator)]
        private IWebElement DdiscountedBalanceButton;

        [FindsBy(How = How.XPath, Using = DiscountedBalanceLocator)]
        private IWebElement DiscountedBalance;

        [FindsBy(How = How.XPath, Using = FullBalanceButtonLocator)]
        private IWebElement FullBalanceButton;

        [FindsBy(How = How.XPath, Using = FullBalanceLocator)]
        private IWebElement FullBalance;

        [FindsBy(How = How.XPath, Using = DiscountExpiryDateLocator)]
        private IWebElement DiscountExpiryDate;

        [FindsBy(How = How.XPath, Using = InstallmentAmountLocator)]
        private IWebElement InstallmentAmount;

        [FindsBy(How = How.XPath, Using = FrequencyWeeklyLocator)]
        private IWebElement FrequencyWeekly;

        [FindsBy(How = How.XPath, Using = FrequencyFortnightlyLocator)]
        private IWebElement FrequencyFortnightly;

        [FindsBy(How = How.XPath, Using = FrequencyFourWeeklyLocator)]
        private IWebElement FrequencyFourWeekly;
        
        [FindsBy(How = How.XPath, Using = FrequencyMonthlyLocator)]
        private IWebElement FrequencyMonthly;

        [FindsBy(How = How.XPath, Using = DDPlanStartDateLocator)]
        private IWebElement DDPlanStartDate;

        [FindsBy(How = How.XPath, Using = AccountHolderNameLocator)]
        private IWebElement AccountHolderName;

        [FindsBy(How = How.XPath, Using = AccountNumberLocator)]
        private IWebElement AccountNumber;

        [FindsBy(How = How.XPath, Using = SsortCodeLocator)]
        private IWebElement SsortCode;

        [FindsBy(How = How.XPath, Using = DDGauranteCheckboxLocator)]
        private IWebElement DDGauranteCheckbox;

        [FindsBy(How = How.XPath, Using = TermsCheckBoxLocator)]
        private IWebElement TermsCheckBox;

        [FindsBy(How = How.XPath, Using = ContinueButtonLocator)]
        private IWebElement ContinueButton;

        [FindsBy(How = How.XPath, Using = ContinueButton2Locator)]
        private IWebElement ContinueButton2;

        [FindsBy(How = How.XPath, Using = BackButtonLocator)]
        private IWebElement BackButton;

        [FindsBy(How = How.XPath, Using = BackButton2Locator)]
        private IWebElement BackButton2;

        [FindsBy(How = How.XPath, Using = GoToMyAccountLocator)]
        private IWebElement GoToMyAccount;

        [FindsBy(How = How.XPath, Using = AccountHolderNameErrorLocator)]
        private IWebElement AccountHolderNameError;

        #endregion

        public digitalDirectDebitPlan(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions

        public void refresh()
        {
            driver.Navigate().Refresh();
        }

        public double getDiscountedBalance()
        {
            return double.Parse(DiscountedBalance.GetAttribute("value"));
        }

        public double getFullBalance()
        {
            return double.Parse(FullBalance.GetAttribute("value"));
        }

        public digitalPlanConfirmation setupDDplanWithDiscount(double PaymentAmount)
        {
            DataEntryHelper.ButtonClick(DdiscountedBalanceButton);
            InstallmentAmount.SendKeys(PaymentAmount.ToString("0.00"));
            FrequencyMonthly.Click();            
            /*uncomment the following line when caseflow date is corret date rather than in future or in past*/
            //DDPlanStartDate.Clear();
            //DDPlanStartDate.SendKeys((DateTime.Now.AddDays(14)).ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));            
            AccountHolderName.SendKeys("Automated Discount Tester");
            AccountNumber.SendKeys("85093009");
            SsortCode.SendKeys("60-09-23");            
            DataEntryHelper.ButtonClick(TermsCheckBox);
            DataEntryHelper.ButtonClick(DDGauranteCheckbox);            
            DataEntryHelper.ButtonClick(ContinueButton);
            DataEntryHelper.ButtonClick(ContinueButton2);            
            return new digitalPlanConfirmation(driver);
        }

        public digitalPlanConfirmation setupDDplanWithoutDiscount(double PaymentAmount)
        {
            if (ObjectRepository.isDiscountAvailable)
            {
                DataEntryHelper.ButtonClick(FullBalanceButton);
            }
            DataEntryHelper.WaitForElementByXpath(InstallmentAmountLocator);
            InstallmentAmount.SendKeys(PaymentAmount.ToString("0.00"));
            FrequencyMonthly.Click();
            /*uncomment the following line when caseflow date is corret date rather than in future or in past*/
            //DDPlanStartDate.Clear();            
            //DDPlanStartDate.SendKeys((DateTime.Now.AddDays(14)).ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
            AccountHolderName.SendKeys("Automated Full Tester");
            AccountNumber.SendKeys("30539228");
            SsortCode.SendKeys("400900");
            DataEntryHelper.ButtonClick(TermsCheckBox);
            DataEntryHelper.ButtonClick(DDGauranteCheckbox);            
            DataEntryHelper.ButtonClick(ContinueButton);
            DataEntryHelper.ButtonClick(ContinueButton2);            

            return new digitalPlanConfirmation(driver);
        }

        public digitalPlanConfirmation setupDDplanWithDiscount(double PaymentAmount, string planFrequency, string accountHolderName, int accountNumber, string sortCode)
        {
            DataEntryHelper.ButtonClick(DdiscountedBalanceButton);
            InstallmentAmount.SendKeys(PaymentAmount.ToString("0.00"));
            switch (planFrequency)
            {
                case "Weekly":
                    FrequencyWeekly.Click();
                    break;

                case "Monthly":
                    FrequencyMonthly.Click();
                    break;

                case "FortNightly":
                    FrequencyFortnightly.Click();
                    break;

                case "FourWeekly":
                    FrequencyFourWeekly.Click();
                    break;

            }
            FrequencyMonthly.Click();
            /*uncomment the following line when caseflow date is corret date rather than in future or in past*/
            //DDPlanStartDate.Clear();
            //DDPlanStartDate.SendKeys((DateTime.Now.AddDays(14)).ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));            
            AccountHolderName.SendKeys(accountHolderName);
            AccountNumber.SendKeys(accountNumber.ToString());
            SsortCode.SendKeys(sortCode);
            DataEntryHelper.ButtonClick(TermsCheckBox);
            DataEntryHelper.ButtonClick(DDGauranteCheckbox);            
            DataEntryHelper.ButtonClick(ContinueButton);
            DataEntryHelper.ButtonClick(ContinueButton2);
            return new digitalPlanConfirmation(driver);
        }

        public digitalPlanConfirmation setupDDplanWithoutDiscount(double PaymentAmount, string planFrequency, string accountHolderName, int accountNumber, string sortCode)
        {
            if (ObjectRepository.isDiscountAvailable)
            {
                DataEntryHelper.ButtonClick(FullBalanceButton);
            }
            DataEntryHelper.WaitForElementByXpath(InstallmentAmountLocator);
            InstallmentAmount.SendKeys(PaymentAmount.ToString("0.00"));
            switch (planFrequency)
            {
                case "Weekly":
                    FrequencyWeekly.Click();
                    break;

                case "Monthly":
                    FrequencyMonthly.Click();
                    break;

                case "FortNightly":
                    FrequencyFortnightly.Click();
                    break;

                case "FourWeekly":
                    FrequencyFourWeekly.Click();
                    break;

            }
            /*uncomment the following line when caseflow date is corret date rather than in future or in past*/
            //DDPlanStartDate.Clear();            
            //DDPlanStartDate.SendKeys((DateTime.Now.AddDays(14)).ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
            AccountHolderName.SendKeys(accountHolderName);
            AccountNumber.SendKeys(accountNumber.ToString());
            SsortCode.SendKeys(sortCode);
            DataEntryHelper.ButtonClick(TermsCheckBox);
            DataEntryHelper.ButtonClick(DDGauranteCheckbox);            
            DataEntryHelper.ButtonClick(ContinueButton);
            DataEntryHelper.ButtonClick(ContinueButton2);

            return new digitalPlanConfirmation(driver);
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
            //Read specic cells of that dataset into variables . This can be expanded to read data
            //for more fields as necessary. See the digitalBudgetCalculatorPage for example of
            //how to do this.
            fileData_AccountHolderName = ReadExcelFile.readSpecificCell(inputData, rowToRead, colName);   
        }

        public string getFileData_AccountHolderName()
        {
            return fileData_AccountHolderName;
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

        public void clickContinueButton()
        {
            DataEntryHelper.ButtonClick(ContinueButton);
        }
        #endregion
    }
}
