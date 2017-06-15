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
    public class qmsAccountQuery_Account_dddddddd : qmsAccountQuery_Account
    {
        private IWebDriver driver;

        #region WebElement
        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQuerySection1']/div/div[1]/div/div[1]/div[1]/span")]
        private IWebElement AccountValue;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQuerySection1']/div/div[1]/div/div[1]/div[2]/span")]
        private IWebElement BrandValue;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQuerySection1']/div/div[1]/div/div[1]/div[3]/span")]
        private IWebElement ClientValue;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQuerySection1']/div/div[1]/div/div[1]/div[4]/span")]
        private IWebElement PriNameValue;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQuerySection1']/div/div[1]/div/div[1]/div[5]/span")]
        private IWebElement PriAddressValue;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQuerySection1']/div/div[1]/div/div[2]/div[1]/span")]
        private IWebElement PortfolioValue;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQuerySection1']/div/div[1]/div/div[2]/div[2]/span")]
        private IWebElement ClientRefValue;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQuerySection1']/div/div[1]/div/div[2]/div[3]/span")]
        private IWebElement AccountStatusValue;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQuerySection1']/div/div[1]/div/div[2]/div[4]/span")]
        private IWebElement SecNameValue;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQuerySection1']/div/div[1]/div/div[2]/div[5]/span")]
        private IWebElement SecAddressValue;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQuerySection1']/div/div[1]/div/div[3]/div[1]/span")]
        private IWebElement PlansWithPaymentsValue;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQuerySection1']/div/div[1]/div/div[3]/div[2]/span")]
        private IWebElement InstalmentAmountValue;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQuerySection1']/div/div[1]/div/div[3]/div[3]/span")]
        private IWebElement PlanStartDateValue;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQuerySection1']/div/div[1]/div/div[3]/div[4]/span")]
        private IWebElement PaidOnPlanValue;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQuerySection1']/div/div[1]/div/div[3]/div[5]/span")]
        private IWebElement PaymentMethodValue;

        [FindsBy(How = How.Id, Using = "tHelpPeriodEndDate")]
        private IWebElement HelpPeriodValue;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQuerySection1']/div/div[1]/div/div[4]/div[1]/span")]
        private IWebElement LastPaymentDate;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQuerySection1']/div/div[1]/div/div[4]/div[2]/span")]
        private IWebElement LastPaymentAmountValue;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQuerySection1']/div/div[1]/div/div[4]/div[3]/span")]
        private IWebElement RecourseForValue;

        [FindsBy(How = How.Id, Using = "tRecourseEndDate")]
        private IWebElement RecourseEndDateValue;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQuerySection1']/div/div[1]/div/div[4]/div[5]/span")]
        private IWebElement RepCodeValue;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQuerySection1']/div/div[1]/div/div[4]/div[6]/span")]
        private IWebElement DCAValue;

        [FindsBy(How = How.Id, Using = "tDeterminationDate")]
        private IWebElement DeterminationDateValue;

        [FindsBy(How = How.Id, Using = "tCCARecourseEndDate")]
        private IWebElement CCARecourseEndDateValue;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountQuerySection1']/div/div[1]/div/div[5]/div[3]/span")]
        private IWebElement BalanceValue;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountInfoQueriesCountGrid']/div[2]/table")]
        private IWebElement QueriesTable;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountInfoLabelsGrid']/div[2]/table")]
        private IWebElement AdditionalInformationTable;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountInfoDocGrid']/div[2]/table")]
        private IWebElement DocumentTable;

        [FindsBy(How = How.XPath, Using = ".//*[@id='QMSAccountInfoFinancialsGrid']/div[2]/table")]
        private IWebElement FinancialsTable;

        #endregion

        public qmsAccountQuery_Account_dddddddd(IWebDriver _driver)
            : base(_driver)
        {
            this.driver = _driver;
        }

       

        #region Navigation

        #endregion
    }
}
