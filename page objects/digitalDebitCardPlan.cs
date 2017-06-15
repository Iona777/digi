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
using OpenQA.Selenium.Support.UI;
using Digital.Logging;
using System.Globalization;

namespace Digital.PageObject
{
    public class digitalDebitCardPlan : digitalNavigationBar
    {
        private IWebDriver driver;

        public const string DiscountedBalanceLocator = "//*[@id='DiscountedPaymentGroup']/div[2]/div/label";
        public const string FullBalanceButtonLocator = "//*[@id='FullPaymentGroup']/div[2]/div[1]/label";
        public const string InstallmentAmountLocator = "//*[@id='PaymentPlan_PaymentPlanPaymentDetails_PaymentAmount']";
        public const string FrequencyWeeklyLocator = "//*[@id='PaymentPlan_PaymentPlanPaymentDetails_PaymentFrequency']/option[2]";
        public const string FrequencyFortnightlyLocator = "//*[@id='PaymentPlan_PaymentPlanPaymentDetails_PaymentFrequency']/option[3]";
        public const string FrequencyFourWeeklyLocator = "//*[@id='PaymentPlan_PaymentPlanPaymentDetails_PaymentFrequency']/option[4]";
        public const string FrequencyMonthlyLocator = "//*[@id='PaymentPlan_PaymentPlanPaymentDetails_PaymentFrequency']/option[5]";
        public const string DCPlanStartDateLocator = "//*[@id='DCStartDate']";
        public const string DCCardsDropdownLocator = "//*[@id='PaymentPlan_PaymentPlanPaymentDetails_CardGUID']";
        public const string TermsCheckboxLocator = "//*[@id='PaymentPlan_PaymentPlanPaymentDetails_CheckTerms']";
        public const string ContinueButtonLocator = "//*[@id='layout-main']/div/div/form/div/button[2]";
        public const string ContinueButton2Locator = "//*[@value=\"Continue\" and @name=\"buttonName\" and @type=\"submit\"]";
        public const string BackButtonLocator = "//*[@id='layout-main']/div/div/form/div/button[1]";
        public const string BackButton2Locator = "//*[@id='form']/button[1]";

        #region WebElement

        [FindsBy(How = How.XPath, Using = DiscountedBalanceLocator)]
        private IWebElement DiscountedBalanceButton;

        [FindsBy(How = How.XPath, Using = FullBalanceButtonLocator)]
        private IWebElement FullBalanceButton;

        [FindsBy(How = How.XPath, Using = InstallmentAmountLocator)]
        private IWebElement InstallmentAmount;

        [FindsBy(How = How.XPath, Using = FrequencyWeeklyLocator)]
        private IWebElement FrequencyWeekly;

        [FindsBy(How = How.XPath, Using = FrequencyFortnightlyLocator)]
        private IWebElement FrequencyFortnightly;

        [FindsBy(How = How.XPath, Using = FrequencyFourWeeklyLocator)]
        private IWebElement FrequencyFourWeekly;

        [FindsBy(How = How.XPath, Using = FrequencyMonthlyLocator)]
        private IWebElement FrequencyMonthly;

        [FindsBy(How = How.XPath, Using = DCPlanStartDateLocator)]
        private IWebElement DCPlanStartDate;

        [FindsBy(How = How.XPath, Using = DCCardsDropdownLocator)]
        private IWebElement DCCardsDropdown;

        [FindsBy(How = How.XPath, Using = TermsCheckboxLocator)]
        private IWebElement TermsCheckbox;

        [FindsBy(How = How.XPath, Using = ContinueButtonLocator)]
        private IWebElement ContinueButton;

        [FindsBy(How = How.XPath, Using = ContinueButton2Locator)]
        private IWebElement ContinueButton2;

        [FindsBy(How = How.XPath, Using = BackButtonLocator)]
        private IWebElement BackButton;

        [FindsBy(How = How.XPath, Using = BackButton2Locator)]
        private IWebElement BackButton2;

        #endregion

        #region Actions

        public digitalDebitCardPlan(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        public void refresh()
        {
            driver.Navigate().Refresh();
        }

        public verifonePlanPage discountedDCPlanSetupUsingNewCard(double paymentAmount)
        {
            ObjectRepository.writer.WriteToLog("This discounted Debit Card plan is being setup using a new card");
            DataEntryHelper.ButtonClick(DiscountedBalanceButton);            
            InstallmentAmount.SendKeys(paymentAmount.ToString("0.00"));
            //This code does'nt work when there is a bank holiday in the next 14 days, the field is autopopulated.
            /*uncomment the following line when caseflow date is corret date rather than in future or in past*/
            //DCPlanStartDate.Clear();
            //DCPlanStartDate.SendKeys((DateTime.Now.AddDays(14)).ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));            
            DataEntryHelper.ButtonClick(FrequencyMonthly);
            DataEntryHelper.ButtonClick(TermsCheckbox);
            DataEntryHelper.ButtonClick(ContinueButton);
            DataEntryHelper.ButtonClick(ContinueButton2);
            return new verifonePlanPage(driver);
        }

        public digitalPlanConfirmation discountedDCPlanSetupUsingSavedCard(double paymentAmount)
        {
            ObjectRepository.writer.WriteToLog("This discounted Debit Card plan is being setup using a saved card");
            DataEntryHelper.ButtonClick(DiscountedBalanceButton);            
            InstallmentAmount.SendKeys(paymentAmount.ToString("0.00"));
            //This code does'nt work when there is a bank holiday in the next 14 days, the field is autopopulated.
            /*uncomment the following line when caseflow date is corret date rather than in future or in past*/
            //DCPlanStartDate.Clear();
            //DCPlanStartDate.SendKeys((DateTime.Now.AddDays(14)).ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));            
            SelectElement cardsSelect = new SelectElement(DCCardsDropdown);
            if (cardsSelect.Options.Count() > 1)
            {
                (cardsSelect).SelectByIndex(1);
            }
            DataEntryHelper.ButtonClick(FrequencyMonthly);
            DataEntryHelper.ButtonClick(TermsCheckbox);
            DataEntryHelper.ButtonClick(ContinueButton);
            DataEntryHelper.ButtonClick(ContinueButton2);
            return new digitalPlanConfirmation(driver);
        }

        public verifonePlanPage fullDCPlanSetupUsingNewCard(double paymentAmount)
        {
            ObjectRepository.writer.WriteToLog("This Debit Card plan is being setup using a new card");
            DataEntryHelper.WaitForElementByXpath(InstallmentAmountLocator);
            if (ObjectRepository.isDiscountAvailable)
            {
                FullBalanceButton.Click();
            }            
            InstallmentAmount.SendKeys(paymentAmount.ToString("0.00"));
            //This code does'nt work when there is a bank holiday in the next 14 days, the field is autopopulated.
            /*uncomment the following line when caseflow date is corret date rather than in future or in past*/
            //DCPlanStartDate.Clear();
            //DCPlanStartDate.SendKeys((DateTime.Now.AddDays(14)).ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
            DataEntryHelper.ButtonClick(FrequencyMonthly);
            DataEntryHelper.ButtonClick(TermsCheckbox);
            DataEntryHelper.ButtonClick(ContinueButton);
            DataEntryHelper.ButtonClick(ContinueButton2);            
            return new verifonePlanPage(driver);
        }

        public digitalPlanConfirmation fullDCPlanSetupUsingSavedCard(double paymentAmount)
        {
            ObjectRepository.writer.WriteToLog("This Debit Card plan is being setup using a saved card");
            DataEntryHelper.WaitForElementByXpath(InstallmentAmountLocator);
            if (ObjectRepository.isDiscountAvailable)
            {
                FullBalanceButton.Click();
            }            
            InstallmentAmount.SendKeys(paymentAmount.ToString("0.00"));
            //This code does'nt work when there is a bank holiday in the next 14 days, the field is autopopulated.
            /*uncomment the following line when caseflow date is corret date rather than in future or in past*/
            //DCPlanStartDate.Clear();
            //DCPlanStartDate.SendKeys((DateTime.Now.AddDays(14)).ToString("d",CultureInfo.CreateSpecificCulture("en-NZ")));            
            SelectElement cardsSelect = new SelectElement(DCCardsDropdown);
            if (cardsSelect.Options.Count() > 1)
            {
                (cardsSelect).SelectByIndex(1);
            }
            DataEntryHelper.ButtonClick(FrequencyMonthly);
            DataEntryHelper.ButtonClick(TermsCheckbox);
            DataEntryHelper.ButtonClick(ContinueButton);
            DataEntryHelper.ButtonClick(ContinueButton2);            
            return new digitalPlanConfirmation(driver);
        }


        #endregion
    }
}
