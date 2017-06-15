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
    public class digitalLogin : digitalNavigationBar
    {
        private IWebDriver driver;

        public const string LoginEmailAddressLocator = "//*[@id='Login_EmailAddress']";
        public const string LoginPasswordLocator = "//*[@id='Login_Password']";
        public const string LoginBtnLocator = "//*[@id='Register']";

        #region WebElement
        [FindsBy(How = How.XPath, Using = LoginEmailAddressLocator)]
        private IWebElement LoginEmailAddress;

        [FindsBy(How = How.XPath, Using = LoginPasswordLocator)]
        private IWebElement LoginPassword;

        [FindsBy(How = How.XPath, Using = LoginBtnLocator)]
        private IWebElement LoginBtn;
        #endregion

        public digitalLogin(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions
        public digitalMyAccount Login(string username, string password)
        {
            LoginEmailAddress.SendKeys(username);
            LoginPassword.SendKeys(password);
            LoginBtn.Click();
            return new digitalMyAccount(driver);
        }

        public digitalMyAccountPage ReadDataFromFile_Login(string username, string password)
        {
            LoginEmailAddress.SendKeys(username);
            LoginPassword.SendKeys(password);
            LoginBtn.Click();
            return new digitalMyAccountPage(driver);
        }

        public void refresh()
        {
            driver.Navigate().Refresh();
        }

        #endregion
    }
}
