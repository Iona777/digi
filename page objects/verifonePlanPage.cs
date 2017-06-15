using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Digital.BaseClasses;
using Digital.ComponentHelper;
using Digital.Settings;


namespace Digital.PageObject
{
    public class verifonePlanPage : digitalNavigationBar
    {
        private IWebDriver driver;

        public const string CardNumberLocator = "//*[@id='txt_CardNumber']";
        public const string ExpiryMonthSelectLocator = "//*[@id='ddl_ExpiryMonth']";
        public const string ExpiryYearSelectLocator = "//*[@id=\"ddl_ExpiryYear\"]";
        public const string ContinueButtonLocator = "//*[@id='btn_merch_Proceed']";
        public const string CancelButtonLocator = "//*[@id='btn_merch_Cancel']";

        #region WebElement

        [FindsBy(How = How.XPath, Using = "//*[@id='txt_CardNumber']")]
        private IWebElement CardNumber;

        [FindsBy(How = How.XPath, Using = "//*[@id='ddl_ExpiryMonth']")]
        private IWebElement ExpiryMonthSelect;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"ddl_ExpiryYear\"]")]        
        private IWebElement ExpiryYearSelect;

        [FindsBy(How = How.XPath, Using = "//*[@id='btn_merch_Proceed']")]
        private IWebElement ContinueButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='btn_merch_Cancel']")]
        private IWebElement CancelButton;
                
        #endregion

        public verifonePlanPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions
        public digitalPlanConfirmation completePlanSetup()
        {
            DataEntryHelper.WaitForElementByXpath(CardNumberLocator);
            CardNumber.SendKeys("4539791001730106");
            //Thread.Sleep(1000);
            DataEntryHelper.WaitForElementByXpath(ExpiryMonthSelectLocator);
            ExpiryMonthSelect.FindElement(By.CssSelector("option[value='07']")).Click();
            //Thread.Sleep(1000);
            DataEntryHelper.WaitForElementByXpath(ExpiryYearSelectLocator);
            ExpiryYearSelect.FindElement(By.CssSelector("option[value='2021']")).Click();
            ContinueButton.Click();
            return new digitalPlanConfirmation(driver);
        }

        #endregion

    }
}
