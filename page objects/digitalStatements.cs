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
    public class digitalStatements : digitalNavigationBar
    {
        private IWebDriver driver;

        public const string accountNumberSelectLocator = "//*[@id='StatementSearch_LowellReference']";
        public const string pdfDownloadLinkLocator = "//*[@class='text-right downloadPDF']/a";
        public const string numberOfEntriesSelectLocator = "//*[@id='DataTables_Table_0_length']/label/select";
        public const string searchBoxLocator = "//*[@id='DataTables_Table_0_filter']/label/input";
        public const string transactionsDatatableLocator = "//*[@id='DataTables_Table_0']";
        public const string previousButtonForDatatableLocator = "//*[@id='DataTables_Table_0_previous']";
        public const string nextButtonForDatatableLocator = "//*[@id='DataTables_Table_0_next']";
        public const string firstRowOfDatatableLocator = "//*[@id='DataTables_Table_0']/tbody/tr[1]";
        public const string fromDateSearchLocator = "//*[@id='StatementSearch_FromDate']";
        public const string toDateSearchLocator = "//*[@id='StatementSearch_ToDate']";
        public const string searchButtonLocator = "//*[@id='ss']/button";
        public const string backButtonLocator = "//*[@id='ss']/a";
        public const string statementsTopContentLocator = "//*[@id='layout-content']/div/div[2]/form/p[1]/label";

        #region WebElement

        [FindsBy(How = How.XPath, Using = accountNumberSelectLocator)]
        private IWebElement accountNumberSelect;

        [FindsBy(How = How.XPath, Using = pdfDownloadLinkLocator)]
        private IWebElement pdfDownloadLink;

        [FindsBy(How = How.XPath, Using = numberOfEntriesSelectLocator)]
        private IWebElement numberOfEntriesSelect;

        [FindsBy(How = How.XPath, Using = searchBoxLocator)]
        private IWebElement searchBox;

        [FindsBy(How = How.XPath, Using = transactionsDatatableLocator)]
        private IWebElement transactionsDatatable;

        [FindsBy(How = How.XPath, Using = previousButtonForDatatableLocator)]
        private IWebElement previousButtonForDatatable;

        [FindsBy(How = How.XPath, Using = nextButtonForDatatableLocator)]
        private IWebElement nextButtonForDatatable;

        [FindsBy(How = How.XPath, Using = firstRowOfDatatableLocator)]
        private IWebElement firstRowOfDatatable;

        [FindsBy(How = How.XPath, Using = fromDateSearchLocator)]
        private IWebElement fromDateSearch;

        [FindsBy(How = How.XPath, Using = toDateSearchLocator)]
        private IWebElement toDateSearch;

        [FindsBy(How = How.XPath, Using = searchButtonLocator)]
        private IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = backButtonLocator)]
        private IWebElement backButton;

        [FindsBy(How = How.XPath, Using = statementsTopContentLocator)]
        private IWebElement statementsTopContent;

        #endregion

        public digitalStatements(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions

        public void refresh()
        {
            driver.Navigate().Refresh();
        }

        public void searchTransactionsBetweenDates(string fromDate, string toDate)
        {
            DataEntryHelper.WaitForElementByXpath(fromDateSearchLocator);
            DataEntryHelper.WaitForElementByXpath(toDateSearchLocator);
            fromDateSearch.Clear();
            DataEntryHelper.EnterText(fromDate, fromDateSearch);
            toDateSearch.Clear();
            DataEntryHelper.EnterText(toDate, toDateSearch);
            DataEntryHelper.ButtonClick(searchButton);
        }

        public void searchForATransactionInSearchBox(string searchString)
        {
            DataEntryHelper.EnterText(searchString, searchBox);
        }

        public string getDataFromFirstRowOfDataTable()
        {
            DataEntryHelper.WaitForElementByXpath(firstRowOfDatatableLocator);
            return firstRowOfDatatable.GetAttribute("innerText");
        }

        public void downloadPdf()
        {
            DataEntryHelper.ButtonClick(pdfDownloadLink);
        }

        public string getDownloadPdfUrl()
        {
            DataEntryHelper.WaitForElementByXpath(pdfDownloadLinkLocator);
            return pdfDownloadLink.GetAttribute("href");
        }

        #endregion
    }
}
