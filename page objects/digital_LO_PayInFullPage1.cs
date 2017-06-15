using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Digital.BaseClasses;
using Digital.ComponentHelper;
using Digital.Settings;
using OpenQA.Selenium.Support.UI;
using Digital.Logging;

namespace Digital.PageObject
{
    public class digital_LO_PayInFullPage1 : digitalNavigationBar
    {
        private IWebDriver driver;
        

        // May be required for checking the absence of elements
        public const string DiscountedPaymentButtonLocator = "//*[@id='DiscountedPaymentGroup']/div[2]/div/label";
        public const string DiscountedBalanceLocator = "//*[@id=\"DiscountedOutstandingBalanceFormatted\"]";
        public const string FullPaymentButtonLocator = "//*[@id='FullPaymentGroup']/div[2]/div[1]/label";
        public const string FullBalanceLocator = "//*[@id=\"PaymentAmountFormatted\"]";
        public const string DiscountExpiryDateLocator = "//*[@id='AccountExpiresOnGroup']/div/p/span";
        //
        public const string PaymentAmountLocator            = "[id='PaymentAmountFormatted']";
        public const string EmailAddressLocator             = "[id='Email']";
        public const string ConfirmEmailAddressLocator      = "[id='ConfirmEmail']";
        public const string TermsCheckboxLocator            = "[id='CheckTerms']";
        public const string TermsandConditionsLinkLocator   = "a[href='https://testdigital.lowellgroup.co.uk/terms-and-conditions/']";
        public const string ContinueButtonLocator           = "[value='Continue'][type='submit']"; 
        public const string BackButtonLocator               = "[value='Back'][type='submit']";
        public const string PayInFullStep1HeaderContentLocator = "//*[@id='layout-main']/p";
        
        #region WebElement

        [FindsBy(How = How.XPath, Using = DiscountedPaymentButtonLocator)]
        private IWebElement DiscountedPaymentButton;

        [FindsBy(How = How.XPath, Using = DiscountedBalanceLocator)]
        private IWebElement DiscountedBalance;

        [FindsBy(How = How.XPath, Using = FullPaymentButtonLocator)]
        private IWebElement FullPaymentButton;

        [FindsBy(How = How.XPath, Using = FullBalanceLocator)]
        private IWebElement FullBalance;


        [FindsBy(How = How.CssSelector, Using = EmailAddressLocator)]
        private IWebElement EmailAddress;

        [FindsBy(How = How.CssSelector, Using = ConfirmEmailAddressLocator)]
        private IWebElement ConfirmEmailAddress;

        [FindsBy(How = How.CssSelector, Using = TermsCheckboxLocator)]
        private IWebElement TermsCheckbox;

        [FindsBy(How = How.CssSelector, Using = TermsandConditionsLinkLocator)]
        private IWebElement TermsandConditionsLink;

        [FindsBy(How = How.CssSelector, Using = ContinueButtonLocator)]
        private IWebElement ContinueButton;

        [FindsBy(How = How.CssSelector, Using = BackButtonLocator)]
        private IWebElement BackButton;

        [FindsBy(How = How.XPath, Using = PayInFullStep1HeaderContentLocator)]
        private IWebElement PayInFullStep1HeaderContent;
        #endregion

        //Constructor
        public digital_LO_PayInFullPage1(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }
        //Constants
        private const string pageTitle = "Payment Options";


        #region Actions

        public string getPageTitle()
        {
            return pageTitle;
        }

        public string getHeaderContent()
        {
            DataEntryHelper.WaitForElementByXpath(PayInFullStep1HeaderContentLocator);
            return PayInFullStep1HeaderContent.GetAttribute("innerText");
        }

        public double getDiscountedBalance()
        {
            DataEntryHelper.WaitForElementByXpath(DiscountedBalanceLocator);
            return double.Parse(DiscountedBalance.GetAttribute("value"));
        }

        public double getFullBalance()
        {
            DataEntryHelper.WaitForElementByXpath(FullBalanceLocator);
            return double.Parse(FullBalance.GetAttribute("value"));
        }

        public void enterEmailAddress(string input)
        {
            DataEntryHelper.EnterText(input, EmailAddress);
        }

        public void enterConfirmEmailAddress(string input)
        {
            DataEntryHelper.EnterText(input, ConfirmEmailAddress);
        }

        
        public void clickOnTermsAndConditionsLink()
        {
            DataEntryHelper.ButtonClick(TermsandConditionsLink);
        }


        public void clickContinueButton()
        {
            DataEntryHelper.ButtonClick(ContinueButton);
        }

        public void clickBackButton()
        {
            DataEntryHelper.ButtonClick(BackButton);
        }

        #endregion
    }
}
