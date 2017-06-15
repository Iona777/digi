using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Digital.BaseClasses;
using Digital.ComponentHelper;

namespace Digital.PageObject
{
    public class digitalUmbracoLogin : PageBase
    {
        private IWebDriver driver;

        public const string LoginUsernameLocator = "//*[@name='username']";
        public const string LoginPasswordLocator = "//*[@name='password']";
        public const string LoginBtnLocator = "//*[@id='login']/div/button";

        #region WebElement
        [FindsBy(How = How.XPath, Using = LoginUsernameLocator)]
        private IWebElement LoginUsername;

        [FindsBy(How = How.XPath, Using = LoginPasswordLocator)]
        private IWebElement LoginPassword;

        [FindsBy(How = How.XPath, Using = LoginBtnLocator)]
        private IWebElement LoginBtn;
        #endregion

        public digitalUmbracoLogin(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions
        public digitalUmbracoHome Login(string username, string password)
        {
            DataEntryHelper.WaitForElementByXpath(LoginUsernameLocator);
            LoginUsername.SendKeys(username);
            LoginPassword.SendKeys(password);
            LoginBtn.Click();
            return new digitalUmbracoHome(driver);
        }

        public digitalUmbracoHome ReadDataFromFile_Login(string username, string password)
        {
            LoginUsername.SendKeys(username);
            LoginPassword.SendKeys(password);
            LoginBtn.Click();
            return new digitalUmbracoHome(driver);
        }

        public void refresh()
        {
            driver.Navigate().Refresh();
        }

        #endregion
    }
}
