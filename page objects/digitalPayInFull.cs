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
using OpenQA.Selenium.Support.UI;
using Digital.Logging;

namespace Digital.PageObject
{
    public class digitalPayInFull : digitalNavigationBar
    {
        private IWebDriver driver;

        public const string DiscountedPaymentButtonLocator = "//*[@id='DiscountedPaymentGroup']/div[2]/div/label";
        public const string DiscountedBalanceLocator = "//*[@id=\"DiscountedOutstandingBalanceFormatted\"]";
        public const string FullPaymentButtonLocator = "//*[@id='FullPaymentGroup']/div[2]/div[1]/label";
        public const string FullBalanceLocator = "//*[@id=\"PaymentAmountFormatted\"]";
        public const string DiscountExpiryDateLocator = "//*[@id='AccountExpiresOnGroup']/div/p/span";
        public const string SavedCardsDropdownLocator = "//*[@id='PayToday_PaymentDetails_CardGUID']";
        public const string TermsCheckboxLocator = "//*[@id='CheckTerms']";
        public const string TermsandConditionsLinkLocator = "//*[@id='CheckTermsGroup']/div/p/a";
        public const string ContinueButtonLocator = "//*[@value=\"Continue\" and @name=\"buttonName\" and @type=\"submit\"]";
        public const string ContinueButton2Locator = "//*[@value=\"Continue\" and @name=\"buttonName\" and @type=\"submit\"]";
        public const string BackButtonLocator = "//*[@value=\"Back\" and @name=\"buttonName\" and @type=\"submit\"]";
        public const string BackButton2Locator = "//*[@value=\"Back\" and @name=\"buttonName\" and @type=\"submit\"]";

        public const string PayInFullStep1HeaderContentLocator = "//*[@id='layout-main']/p";
        
        #region WebElement

        [FindsBy(How = How.XPath, Using = DiscountedPaymentButtonLocator)]
        private IWebElement DiscountedPaymentButton;

        [FindsBy(How = How.XPath, Using = DiscountedBalanceLocator)]
        private IWebElement DiscountedBalance;

        [FindsBy(How = How.XPath, Using = FullPaymentButtonLocator)]
        private IWebElement FullPaymentButton;

        [FindsBy(How = How.XPath, Using = FullBalanceLocator)]
        private IWebElement FullBalance;

        [FindsBy(How = How.XPath, Using = SavedCardsDropdownLocator)]
        private IWebElement savedCardsDropdown;

        [FindsBy(How = How.XPath, Using = TermsCheckboxLocator)]
        private IWebElement TermsCheckbox;

        [FindsBy(How = How.XPath, Using = TermsandConditionsLinkLocator)]
        private IWebElement TermsandConditionsLink;

        [FindsBy(How = How.XPath, Using = ContinueButtonLocator)]
        private IWebElement ContinueButton;

        [FindsBy(How = How.XPath, Using = ContinueButton2Locator)]
        private IWebElement ContinueButton2;

        [FindsBy(How = How.XPath, Using = BackButtonLocator)]
        private IWebElement BackButton;

        [FindsBy(How = How.XPath, Using = BackButton2Locator)]
        private IWebElement BackButton2;

        [FindsBy(How = How.XPath, Using = PayInFullStep1HeaderContentLocator)]
        private IWebElement PayInFullStep1HeaderContent;

        private SelectElement cardsSelect;
        
        #endregion

        public digitalPayInFull(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions

        public void refresh()
        {
            driver.Navigate().Refresh();
        }

        public string getHeaderContent()
        {
            DataEntryHelper.WaitForElementByXpath(PayInFullStep1HeaderContentLocator);
            return PayInFullStep1HeaderContent.GetAttribute("innerText");
        }

        public double getDiscountedBalance()
        {
            DataEntryHelper.WaitForElementByXpath(DiscountedBalanceLocator);
            return double.Parse(DiscountedBalance.GetAttribute("value"));
        }

        public double getFullBalance()
        {
            DataEntryHelper.WaitForElementByXpath(FullBalanceLocator);
            return double.Parse(FullBalance.GetAttribute("value"));
        }

        public verifonePayPage payDiscountedAmountUsingNewCard()
        {
            ObjectRepository.writer.WriteToLog("This full discounted payment is done using a new card");
            DataEntryHelper.ButtonClick(DiscountedPaymentButton);
            //DiscountedPaymentButton.Click();
            DataEntryHelper.ButtonClick(TermsCheckbox);
            DataEntryHelper.ButtonClick(ContinueButton);
            DataEntryHelper.ButtonClick(ContinueButton2);            
            return new verifonePayPage(driver);
        }

        public digitalMyAccount clickBackButtonInFirstPage()
        {
            DataEntryHelper.ButtonClick(BackButton);
            return ObjectRepository.digitalMyAccountPage;
        }

        public digitalMyAccount navigateToSecondPageAndBackToMyAccount()
        {
            if (ObjectRepository.isDiscountAvailable)
            {
                DataEntryHelper.ButtonClick(DiscountedPaymentButton);
            }
            DataEntryHelper.ButtonClick(TermsCheckbox);
            DataEntryHelper.ButtonClick(ContinueButton);
            DataEntryHelper.ButtonClick(BackButton2);
            DataEntryHelper.ButtonClick(BackButton);
            return ObjectRepository.digitalMyAccountPage;
        }

        public digitalTermsAndConditions clickOnTermsAndConditionsLink()
        {
            ObjectRepository.writer.WriteToLog("This payment is done using a saved card");
            DataEntryHelper.WaitForElementByXpath(TermsandConditionsLinkLocator);
            DataEntryHelper.ButtonClick(TermsandConditionsLink);
            return new digitalTermsAndConditions(driver);
        }

        public verifoneSavedCardPayPage payDiscountedAmountUsingSavedCard()
        {
            ObjectRepository.writer.WriteToLog("This full discounted payment is done using a saved card");
            DataEntryHelper.ButtonClick(DiscountedPaymentButton);
            //DiscountedPaymentButton.Click();
            if (ObjectRepository.areTokensEnabled)
            {
                cardsSelect = new SelectElement(savedCardsDropdown);                
                if (cardsSelect.Options.Count() > 1)
                {
                    (cardsSelect).SelectByIndex(1);
                }
            }
            DataEntryHelper.ButtonClick(TermsCheckbox);
            DataEntryHelper.ButtonClick(ContinueButton);
            DataEntryHelper.ButtonClick(ContinueButton2);            
            return new verifoneSavedCardPayPage(driver);
        }

        public verifonePayPage payFullAmountUsingNewCard()
        {
            ObjectRepository.writer.WriteToLog("This full payment is done using a new card");
            if (ObjectRepository.isDiscountAvailable)
            {                
                DataEntryHelper.ButtonClick(FullPaymentButton);
                //FullPaymentButton.Click();
            }
            DataEntryHelper.ButtonClick(TermsCheckbox);
            DataEntryHelper.ButtonClick(ContinueButton);
            DataEntryHelper.ButtonClick(ContinueButton2);
            return new verifonePayPage(driver);
        }

        public verifoneSavedCardPayPage payFullAmountUsingSavedCard()
        {
            ObjectRepository.writer.WriteToLog("This full payment is done using a saved card");
            if (ObjectRepository.isDiscountAvailable)
            {
                DataEntryHelper.ButtonClick(FullPaymentButton);
                //FullPaymentButton.Click();
            }
            if (ObjectRepository.areTokensEnabled)
            {
                cardsSelect = new SelectElement(savedCardsDropdown);
                DataEntryHelper.WaitForElementByXpath(SavedCardsDropdownLocator);
                if (cardsSelect.Options.Count() > 1)
                {
                    (cardsSelect).SelectByIndex(1);
                }
            }
            DataEntryHelper.ButtonClick(TermsCheckbox);
            DataEntryHelper.ButtonClick(ContinueButton);
            DataEntryHelper.ButtonClick(ContinueButton2);
            return new verifoneSavedCardPayPage(driver);
        }

        #endregion
    }
}
