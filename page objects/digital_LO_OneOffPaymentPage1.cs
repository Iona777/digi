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
    public class digital_LO_OneOffPaymentPage1 : digitalNavigationBar
    {
        private IWebDriver driver;

        public const string PaymentAmountLocator                = "[id='PaymentAmount']";
        public const string TermsAndConditionsTickBoxLocator    = "[id='CheckTerms']";
        public const string TermsAndConditionsLinkLocator       = "[title='Terms and Conditions']";
        public const string ContinueBtnLocator                  = "[value='Continue'][type='submit']";
        public const string BackBtnLocator                      = "[value='Back'][type='submit']";
        

        #region WebElement
        [FindsBy(How = How.CssSelector, Using = PaymentAmountLocator)]
        private IWebElement PaymentAmount;

        [FindsBy(How = How.CssSelector, Using = TermsAndConditionsTickBoxLocator)]
        private IWebElement TermsAndConditionsTickBox;

        [FindsBy(How = How.CssSelector, Using = TermsAndConditionsLinkLocator)]
        private IWebElement TermsAndConditionsLink;

        [FindsBy(How = How.CssSelector, Using = ContinueBtnLocator)]
        private IWebElement ContinueBtn;

        [FindsBy(How = How.CssSelector, Using = BackBtnLocator)]
        private IWebElement BackBtn;
        #endregion

        //Constructor
        public digital_LO_OneOffPaymentPage1(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions
        public void enterPaymentAmount(string input)
        {
            DataEntryHelper.EnterText(input,PaymentAmount);
        }

        public void tickTermsAndConditionsCheckBox()
        {
            DataEntryHelper.ButtonClick(TermsAndConditionsTickBox);
        }

        public void clickTermsAndConditionsLink()
        {
            DataEntryHelper.ButtonClick(TermsAndConditionsLink);
        }

        public void clickContinueBtn()
        {
            DataEntryHelper.ButtonClick(ContinueBtn);
        }

        public void clickBackBtn()
        {
            DataEntryHelper.ButtonClick(BackBtn);
        }

        public bool isPaymentAmountEmpty()
        {
            bool PaymentAmountEmpty = false;

            if (PaymentAmount.Text.Length == 0)
                PaymentAmountEmpty = true;

            return PaymentAmountEmpty;
        }


        #endregion

    }
}
