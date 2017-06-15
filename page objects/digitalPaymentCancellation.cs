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
    public class digitalPaymentCancellation : digitalNavigationBar
    {
        private IWebDriver driver;

        public digitalPaymentCancellation(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions

        public void refresh()
        {
            driver.Navigate().Refresh();
        }

        public digitalMyAccount navigateToMyAccount()
        {
            return this.gotToMyAccountPage();
        }

        #endregion
    }
}
