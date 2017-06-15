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
    public class qmsCFAdministration : PageBase
    {
        private IWebDriver driver;

        #region WebElement
        [FindsBy(How = How.Id, Using = "tabUsers")]
        private IWebElement UsersTab;

        [FindsBy(How = How.Id, Using = "tabUsersGroups")]
        private IWebElement GroupsTab;

        [FindsBy(How = How.Id, Using = "tabApplications")]
        private IWebElement ApplicationsTab;

        [FindsBy(How = How.Id, Using = "tabServices")]
        private IWebElement ServicesTab;

        [FindsBy(How = How.Id, Using = "tabGeneral")]
        private IWebElement GeneralSettingsTab;

        #endregion

        public qmsCFAdministration(IWebDriver _driver)
            : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions
        public void CheckUrl(string Url)
        {
            AssertHelper.AreEqual(Url, BrowserHelper.GetUrl());
        }

        #endregion

        #region Navigation
        public qmsCFAdministration NavigateToUsersTab()
        {
            UsersTab.Click();
            return new qmsCFAdministration(driver);
        }
        #endregion
    }
}
