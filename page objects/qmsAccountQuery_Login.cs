using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Digital.BaseClasses;
using Digital.ComponentHelper;
using Digital.Settings;

namespace Digital.PageObject
{
    public class qmsAccountQuery_Login : PageBase
    {
        private IWebDriver driver;

        #region WebElement
        [FindsBy(How = How.Id, Using = "CFUserLogincEmailAddress")]
        private IWebElement EmailAddressTextBox;

        [FindsBy(How = How.Id, Using = "CFUserLogincPassword")]
        private IWebElement PasswordTextBox;

        [FindsBy(How = How.Id, Using = "CFUserLoginLoginButton")]
        private IWebElement LoginBtn;

        [FindsBy(How = How.Id, Using = "CFUserLoginResetPassword")]
        private IWebElement ResetPasswordCheckBox;

        #endregion

        public qmsAccountQuery_Login(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions


        #endregion

        #region Navigation
        public qmsAccountQuery_Account Login(string email, string password)
        {
            EmailAddressTextBox.Clear();
            EmailAddressTextBox.SendKeys(email);
            Thread.Sleep(100);
            PasswordTextBox.SendKeys(password);
            Thread.Sleep(100);
            LoginBtn.Click();
            Thread.Sleep(100);
            return new qmsAccountQuery_Account(driver);
        }

        #endregion
    }
}
