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
    public class digitalPrivacyPolicy : digitalNavigationBar
    {
        private IWebDriver driver;

        public const string PrivacyPolicyContentLocator = "/html/body/div[3]/div";

        #region WebElement
        [FindsBy(How = How.XPath, Using = PrivacyPolicyContentLocator)]
        private IWebElement PrivacyPolicyContent;
        #endregion


        public digitalPrivacyPolicy(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        
    }
}
