using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Digital.BaseClasses;
using Digital.ComponentHelper;
using Digital.Settings;

namespace Digital.PageObject
{
    public class digital_LO_DDConfirmation : digitalPaymentConfirmation
    {
        private IWebDriver driver;


        public digital_LO_DDConfirmation(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region fields
        public const string LowellRefLocator        = "//*[@id='layout-main']/div/div/div[1]/div[2]";
        public const string RepaymentAmountLocator  = "//*[@id='layout-main']/div/div/div[2]/div[2]";
        public const string FrequencyLocator        = "//*[@id='layout-main']/div/div/div[3]/div[2]";
        public const string StartDateLocator        = "//*[@id='layout-main']/div/div/div[4]/div[2]";
        public const string RepaymentMethodLocator  = "//*[@id='layout-main']/div/div/div[5]/div[2]";
        public const string AccountHolderLocator    = "//*[@id='layout-main']/div/div/div[6]/div[2]";
        public const string AccountNumberLocator    = "//*[@id='layout-main']/div/div/div[7]/div[2]";
        public const string SortCodeLocator         = "//*[@id='layout-main']/div/div/div[8]/div[2]";
        public const string EmailAddressLocator     = "//*[@id='layout-main']/div/div/div[9]/div[2]";

        public const string FinishButtonLocator     = "button[value='Continue']";
        public const string RegisterButtonLocator   = "button[value='Register']";

        [FindsBy(How = How.XPath, Using = LowellRefLocator)]
        private IWebElement LowellRef;
        [FindsBy(How = How.XPath, Using = RepaymentAmountLocator)]
        private IWebElement RepaymentAmount;
        [FindsBy(How = How.XPath, Using = FrequencyLocator)]
        private IWebElement Frequency;
        [FindsBy(How = How.XPath, Using = StartDateLocator)]
        private IWebElement StartDate;
        [FindsBy(How = How.XPath, Using = RepaymentMethodLocator)]
        private IWebElement RepaymentMethod;
        [FindsBy(How = How.XPath, Using = AccountHolderLocator)]
        private IWebElement AccountHolder;
        [FindsBy(How = How.XPath, Using = AccountNumberLocator)]
        private IWebElement AccountNumber;
        [FindsBy(How = How.XPath, Using = SortCodeLocator)]
        private IWebElement SortCode;
        [FindsBy(How = How.XPath, Using = EmailAddressLocator)]
        private IWebElement EmailAddress;
        [FindsBy(How = How.CssSelector, Using = FinishButtonLocator)]
        private IWebElement FinishBtn;
        [FindsBy(How = How.CssSelector, Using = RegisterButtonLocator)]
        private IWebElement RegisterBtn;
        #endregion



        #region Actions
        public string getDisplayedLowellRef()
        {
            return LowellRef.Text;
        }

        public decimal getDisplayedPaymentAmount()
        {
            string amount = (GenericHelper.GetValueAfterPoundSymbol(RepaymentAmount.Text));
            return decimal.Parse(amount);
        }

        public string getDisplayedFrequency()
        {
            return Frequency.Text;
        }

        public string getDisplayedStartDate()
        {
            return StartDate.Text;
        }

        public string getDisplayedRepaymentMethod()
        {
            return RepaymentMethod.Text;
        }

        public string getDisplayedAccountHolder()
        {
            return AccountHolder.Text;
        }

        public string getDisplayedAccountNumber()
        {
            return AccountNumber.Text;
        }

        public string getDisplayedSortCode()
        {
            return SortCode.Text;
        }

        public string getDisplayedEmailAddress()
        {
            return EmailAddress.Text;
        }

        public void clickOnFinishBtn()
        {
            DataEntryHelper.ButtonClick(FinishBtn);
        }

        public void clickOnRegisterBtn()
        {
            DataEntryHelper.ButtonClick(RegisterBtn);
        }
        #endregion

    }
}
