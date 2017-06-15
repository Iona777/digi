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
    public class digital_LO_PaymentConfirmation : digitalPaymentConfirmation
    {
        private IWebDriver driver;


        public digital_LO_PaymentConfirmation(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region fields
        public const string FinishButtonLocator     = "button[value='Finish']";
        public const string RegisterButtonLocator   = "button[value='Register']";

        [FindsBy(How = How.CssSelector, Using = FinishButtonLocator)]
        IWebElement FinishBtn;

        [FindsBy(How = How.CssSelector, Using = RegisterButtonLocator)]
        IWebElement RegisterBtn;
        #endregion



        #region Actions
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
