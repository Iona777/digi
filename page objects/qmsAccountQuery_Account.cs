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
    public class qmsAccountQuery_Account : PageBase
    {
        private IWebDriver driver;

        #region WebElement
        [FindsBy(How = How.XPath, Using = ".//*[@id='CFLoggedInViewDiv']/div/span/span")]
        private IWebElement UserLongNameText;

        [FindsBy(How = How.XPath, Using = ".//*[@id='CFLoggedInViewDiv']/div/span/button")]
        private IWebElement LogoutBtn;

        [FindsBy(How = How.Id, Using = "QMSAccountSearch")]
        private IWebElement AccountTextBox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQueryControlsDiv']/div/div/div/div[1]/button")]
        private IWebElement SearchBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQueryControlsDiv']/div/div/div/div[2]/div/button[1]")]
        private IWebElement BackBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQueryControlsDiv']/div/div/div/div[2]/div/button[2]")]
        private IWebElement LogQueryBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQueryControlsDiv']/div/div/div/div[2]/div/button[3]")]
        private IWebElement SaveBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQueryControlsDiv']/div/div/div/div[2]/div/button[4]")]
        private IWebElement PartialSaveBtn;

        [FindsBy(How = How.Id, Using = "butEditControls")]
        private IWebElement EditBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQueryControlsDiv']/div/div/div/div[2]/div/button[6]")]
        private IWebElement UpdateQueryBtn;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQueryControlsDiv']/div/div/div/div[2]/div/button[7]")]
        private IWebElement CancelBtn;

        #endregion

        public qmsAccountQuery_Account(IWebDriver _driver) : base(_driver)
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

        #endregion
    }
}
