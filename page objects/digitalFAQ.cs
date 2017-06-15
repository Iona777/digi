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
    public class digitalFAQ : digitalNavigationBar
    {
        private IWebDriver driver;

        public const string BudgetCalcRadiobuttonLocator = "//*[@id='radiodiv']/label[1]";

        #region WebElement
        [FindsBy(How = How.XPath, Using = BudgetCalcRadiobuttonLocator)]
        private IWebElement BudgetCalcRadiobutton;
        #endregion

        public digitalFAQ(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }
    }
}
