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
    public class digitalContactUsPage : digitalNavigationBar
    {
        private IWebDriver driver;

        public const string ContactUsTelephoneLocator = "//*[@id='layout-main']/div/div[1]/div[2]";
        public const string ContactUsEmailLocator = "//*[@id='layout-main']/div/div[2]/div[2]";
        public const string ContactUsPostalAddressLocator = "//*[@id='layout-main']/div/div[3]/div[2]";

        #region WebElement
        [FindsBy(How = How.XPath, Using = ContactUsTelephoneLocator)]
        private IWebElement ContactUsTelephone;

        [FindsBy(How = How.XPath, Using = ContactUsEmailLocator)]
        private IWebElement ContactUsEmail;

        [FindsBy(How = How.XPath, Using = ContactUsPostalAddressLocator)]
        private IWebElement ContactUsPostalAddress;

        #endregion

        public digitalContactUsPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }
    }
}
