using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using QMSAccountQuery.BaseClasses;
using QMSAccountQuery.ComponentHelper;
using QMSAccountQuery.Settings;

namespace Digital.PageObject
{
    public class digitalStatement : digitalNavigationBar
    {
        private IWebDriver driver;

        public const string AccountsDropdownLocator = "//*[@id=\"StatementSearch_LowellReference\"]";
        public const string PdfDownloadLinkLocator = "//*[@id=\"layout-content\"]/div/div[2]/form/p[2]/a";
        public const string SearchTextBoxLocator = "//*[@id=\"DataTables_Table_0_filter\"]/label/input";        
        public const string SelectForNumberOfRowsToShowLocator = "//*[@id=\"DataTables_Table_0_length\"]/label/select";
        public const string ShowPreviousResultsButtonLocator = "//*[@id=\"DataTables_Table_0_previous\"]";
        public const string ShowNextResultsButtonLocator = "//*[@id=\"DataTables_Table_0_next\"]";
        public const string FromDateForSearchLocator = "//*[@id=\"StatementSearch_FromDate\"]";
        public const string ToDateForSearchLocator = "//*[@id=\"StatementSearch_ToDate\"]";
        public const string BackButtonToMyAccountLocator = "//*[@id=\"ss\"]/a";
        public const string SearchButtonLocator = "//*[@id=\"ss\"]/button";

        public digitalStatement(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Navigation

        public void refresh()
        {
            driver.Navigate().Refresh();
        }
        #endregion
    }
}
