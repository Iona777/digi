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
    public class digital_LO_PaymentOptionsPage2 : digitalNavigationBar
    {
        private IWebDriver driver;

        public const string PayInFullRadiobuttonLocator     = "[id='PaymentOption'][value='FullPayment']";
        public const string OneOffPaymentRadiobuttonLocator = "[id='PaymentOption'][value='PartialPayment']";
        public const string DirectDebitRadiobuttonLocator    = "[id='PaymentOption'][value='DirectDebitPaymentPlan']";
        public const string DiscountElementLocator          = "[class='discount']";
        public const string ContinueBtnLocator              = "[value='Continue'][type='submit']";

        #region WebElement
        [FindsBy(How = How.CssSelector, Using = PayInFullRadiobuttonLocator)]
        private IWebElement PayInFullRadiobutton;

        [FindsBy(How = How.CssSelector, Using = OneOffPaymentRadiobuttonLocator)]
        private IWebElement OneOffPaymentRadiobutton;

        [FindsBy(How = How.CssSelector, Using = DirectDebitRadiobuttonLocator)]
        private IWebElement DirectDebitRadiobutton;

        [FindsBy(How = How.CssSelector, Using = DiscountElementLocator)]
        private IWebElement DiscountElement;

        [FindsBy(How = How.CssSelector, Using = ContinueBtnLocator)]
        private IWebElement ContinueBtn;

        #endregion

        //Constructor
        public digital_LO_PaymentOptionsPage2(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;

        }

        #region Actions
        public void clickPayInFullBtn()
        {
            DataEntryHelper.ButtonClick(PayInFullRadiobutton);
        }

        public void clickOneOffPaymentRadioBtn()
        {
            DataEntryHelper.ButtonClick(OneOffPaymentRadiobutton);
        }

        public void clickDirectDebitRadioBtn()
        {
            DataEntryHelper.ButtonClick(DirectDebitRadiobutton);
        }

        public void clickContinueBtn()
        {
            DataEntryHelper.ButtonClick(ContinueBtn);
        }


        public decimal getDiscountAvailableValue()
        {
            string text             = DiscountElement.Text;
            int poundSymbolIndex    = text.IndexOf('£');

            string newText = text.Substring(poundSymbolIndex+1,(text.Length-(poundSymbolIndex+1)));
            int availableIndex = newText.IndexOf('a');
            string discountValueText = newText.Substring(0,availableIndex);
            decimal discountValue = decimal.Parse(discountValueText);

            return discountValue;
        }
        #endregion

    }
}
