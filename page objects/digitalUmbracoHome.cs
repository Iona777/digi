using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Digital.BaseClasses;
using Digital.ComponentHelper;

namespace Digital.PageObject
{
    public class digitalUmbracoHome : PageBase
    {
        private IWebDriver driver;

        public const string SearchBoxLocator = "//*[@id='search-field']";
        public const string SearchResultLocator = "//*[@id='search-results']/ul/li/ul/li/div/a[1]";

        #region WebElement
        [FindsBy(How = How.XPath, Using = SearchBoxLocator)]
        private IWebElement SearchBox;

        [FindsBy(How = How.XPath, Using = SearchResultLocator)]
        private IWebElement SearchResult;
        #endregion

        public digitalUmbracoHome(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions
        public digitalUmbracoMemberDetails searchForAMember(string searchString)
        {
            DataEntryHelper.WaitForElementByXpath(SearchBoxLocator);
            SearchBox.SendKeys(searchString);
            SearchResult.Click();
            return new digitalUmbracoMemberDetails(driver);
        }

        public void refresh()
        {
            driver.Navigate().Refresh();
        }

        #endregion
    }
}
