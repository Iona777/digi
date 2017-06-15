using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Digital.ComponentHelper;


namespace Digital.PageObject
{
    public class digital_LO_DirectDebitPage2_Review: digitalNavigationBar
    {

        private IWebDriver driver;

        //Constructor
        public digital_LO_DirectDebitPage2_Review(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        
        #region Fields
        public const string LowellRefLocator        = "//*[@id='form']/div/div/div[1]/div[2]";        
        public const string PaymentAmountLocator    = "//*[@id='form']/div/div/div[2]/div[2]";
        public const string FrequencyLocator        = "//*[@id='form']/div/div/div[3]/div[2]";
        public const string StartDateLocator        = "//*[@id='form']/div/div/div[4]/div[2]";
        public const string RepaymentMethodLocator  = "//*[@id='form']/div/div/div[5]/div[2]";
        public const string AccountHolderLocator    = "//*[@id='form']/div/div/div[6]/div[2]";
        public const string AccountNumberLocator    = "//*[@id='form']/div/div/div[7]/div[2]";
        
        public const string SortCodeLocator         = "//*[@id='form']/div/div/div[8]/div[2]";
        public const string EmailAddressLocator     = "//*[@id='form']/div/div/div[9]/div[2]";
        public const string BackButtonLocator       = "[value='Back'][type='submit']";
        public const string ContinueButtonLocator   = "[value='Continue'][type='submit']";


        [FindsBy(How = How.XPath, Using = LowellRefLocator)]
        IWebElement LowellRef;

        [FindsBy(How = How.XPath, Using = PaymentAmountLocator)]
        IWebElement PaymentAmount;

        [FindsBy(How = How.XPath, Using = FrequencyLocator)]
        IWebElement Frequency;

        [FindsBy(How = How.XPath, Using = StartDateLocator)]
        IWebElement StartDate;

        [FindsBy(How = How.XPath, Using = RepaymentMethodLocator)]
        IWebElement RepaymentMethod;

        [FindsBy(How = How.XPath, Using = AccountHolderLocator)]
        IWebElement AccountHolder;

        [FindsBy(How = How.XPath, Using = AccountNumberLocator)]
        IWebElement AccountNumber;

        [FindsBy(How = How.XPath, Using = SortCodeLocator)]
        IWebElement SortCode;

        [FindsBy(How = How.XPath, Using = EmailAddressLocator)]
        IWebElement EmailAddress;

        [FindsBy(How = How.CssSelector, Using = BackButtonLocator)]
        IWebElement BackButton;

        [FindsBy(How = How.CssSelector, Using = ContinueButtonLocator)]
        IWebElement ContinueButton;
        #endregion
        
        #region Methods
        public void clickBackBtn()
        {
            DataEntryHelper.ButtonClick(BackButton);
        }

        public void clickContinueBtn()
        {
            DataEntryHelper.ButtonClick(ContinueButton);
        }


        //Use this when comparing the entered values with the values displayed in 
        //Review screen
        public string getDisplayedLowellRef()
        {
            return LowellRef.Text;
        }

        public decimal getDisplayedPaymentAmount()
        {
            string amount = (GenericHelper.GetValueAfterPoundSymbol(PaymentAmount.Text));
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

        
        public bool doDisplayedFieldsMatchInput(string RefNo, decimal PaymentAmount, string Frequency, string AccouuntNo, string SortCode)
        {
            bool fieldsMatch = true;

            if (StartDate.Text != getDisplayedStartDate() || PaymentAmount != getDisplayedPaymentAmount() || Frequency != getDisplayedFrequency()
                || AccouuntNo != getDisplayedAccountNumber() || SortCode != getDisplayedSortCode()) 
            {
                fieldsMatch = false;
            }

            return fieldsMatch;

        }
        #endregion
    }
}
