using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using Digital.BaseClasses;
using Digital.ComponentHelper;
using Digital.Settings;
using Digital.Logging;

namespace Digital.PageObject
{
    public class digitalOneOffPayment : digitalNavigationBar
    {
        private IWebDriver driver;

        public const string OneOffPaymentAmountLocator = "//*[@id=\"PaymentAmount\"]";
        public const string TermsandConditionsCheckboxLocator = "//*[@id=\"CheckTerms\"]";
        public const string TermsandConditionsLinkLocator = "//*[@id='CheckTermsGroup']/div/p/a";
        public const string ContinueButton1Locator = "//*[@value=\"Continue\" and @name=\"buttonName\" and @type=\"submit\"]";
        public const string BackButton1Locator = "//*[@value=\"Back\" and @name=\"buttonName\" and @type=\"submit\"]";
        public const string ContinueButton2Locator = "//*[@value=\"Continue\" and @name=\"buttonName\" and @type=\"submit\"]";
        public const string BackButton2Locator = "//*[@value=\"Back\" and @name=\"buttonName\" and @type=\"submit\"]";
        public const string savedCardsDropdownLocator = "//*[@id='PayToday_PaymentDetails_CardGUID']";
        public const string saveCardDetailsOptionLocator = "//*[@value='CardHolderSaveDetails']";
        public const string dontSaveCardDetailsOptionLocator = "//*[@value='CardHolderDontSave']";
        public const string paymentAmountErrorMessageLocator = "//*[@id='PaymentAmountGroup']/div/span";
        public const string lowellReferenceInSecondPageLocator = "//*[@id='layout-main']/form/div/div/div/div[1]/div[2]";
        public const string originalClientInSecondPageLocator = "//*[@id='layout-main']/form/div/div/div/div[2]/div[2]";
        public const string paymentAmountInSecondPageLocator = "//*[@id='layout-main']/form/div/div/div/div[3]/div[2]";
        
        #region WebElement

        [FindsBy(How = How.XPath, Using = OneOffPaymentAmountLocator)]
        private IWebElement OneOffPaymentAmount;

        [FindsBy(How = How.XPath, Using = TermsandConditionsCheckboxLocator)]
        private IWebElement TermsandConditionsCheckbox;

        [FindsBy(How = How.XPath, Using = TermsandConditionsLinkLocator)]
        private IWebElement TermsandConditionsLink;

        [FindsBy(How = How.XPath, Using = ContinueButton1Locator)]
        private IWebElement ContinueButton1;

        [FindsBy(How = How.XPath, Using = BackButton1Locator)]
        private IWebElement BackButton1;

        [FindsBy(How = How.XPath, Using = ContinueButton2Locator)]
        private IWebElement ContinueButton2;

        [FindsBy(How = How.XPath, Using = BackButton2Locator)]
        private IWebElement BackButton2;

        [FindsBy(How = How.XPath, Using = savedCardsDropdownLocator)]
        private IWebElement savedCardsDropdown;

        [FindsBy(How = How.XPath, Using = saveCardDetailsOptionLocator)]
        private IWebElement saveCardDetailsOption;

        [FindsBy(How = How.XPath, Using = dontSaveCardDetailsOptionLocator)]
        private IWebElement dontSaveCardDetailsOption;

        [FindsBy(How = How.XPath, Using = paymentAmountErrorMessageLocator)]
        private IWebElement paymentAmountErrorMessage;

        [FindsBy(How = How.XPath, Using = lowellReferenceInSecondPageLocator)]
        private IWebElement lowellReferenceInSecondPage;

        [FindsBy(How = How.XPath, Using = originalClientInSecondPageLocator)]
        private IWebElement originalClientInSecondPage;

        [FindsBy(How = How.XPath, Using = paymentAmountInSecondPageLocator)]
        private IWebElement paymentAmountInSecondPage;
        
        #endregion

        public digitalOneOffPayment(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions

        public void refresh()
        {
            driver.Navigate().Refresh();
        }

        public string getLowellReferenceInSecondPage()
        {
            DataEntryHelper.WaitForElementByXpath(lowellReferenceInSecondPageLocator);
            return lowellReferenceInSecondPage.GetAttribute("innerText");
        }

        public string getOriginalClientInSecondPage()
        {
            DataEntryHelper.WaitForElementByXpath(originalClientInSecondPageLocator);
            return originalClientInSecondPage.GetAttribute("innerText");
        }

        public string getPaymentAmountInSecondPage()
        {
            DataEntryHelper.WaitForElementByXpath(paymentAmountInSecondPageLocator);
            return paymentAmountInSecondPage.GetAttribute("innerText");
        }

        public verifonePayPage completePaymentUsingNewCard(double paymentAmount)
        {
            ObjectRepository.writer.WriteToLog("This payment is done using a new card and saving the card details");
            DataEntryHelper.WaitForElementByXpath(OneOffPaymentAmountLocator);
            OneOffPaymentAmount.SendKeys(paymentAmount.ToString("0.00"));
            if (ObjectRepository.areTokensEnabled)
            {
                saveCardDetailsOption.Click();
            }
            DataEntryHelper.ButtonClick(TermsandConditionsCheckbox);
            DataEntryHelper.ButtonClick(ContinueButton1);
            DataEntryHelper.ButtonClick(ContinueButton2);
            return new verifonePayPage(driver);
        }

        public verifonePayPage completePaymentWithoutSavingCard(double paymentAmount)
        {
            ObjectRepository.writer.WriteToLog("This payment is done using without saving the card details.");
            DataEntryHelper.WaitForElementByXpath(OneOffPaymentAmountLocator);
            OneOffPaymentAmount.SendKeys(paymentAmount.ToString("0.00"));
            if (ObjectRepository.areTokensEnabled)
            {
                dontSaveCardDetailsOption.Click();
            }
            DataEntryHelper.ButtonClick(TermsandConditionsCheckbox);
            DataEntryHelper.ButtonClick(ContinueButton1);
            DataEntryHelper.ButtonClick(ContinueButton2);            
            return new verifonePayPage(driver);
        }

        public string payAnInvalidPaymentAmount(string paymentAmount)
        {
            string errMsg;
            ObjectRepository.writer.WriteToLog("This step is trying to pay an invalid payment amount");
            DataEntryHelper.WaitForElementByXpath(OneOffPaymentAmountLocator);
            OneOffPaymentAmount.SendKeys(paymentAmount);
            if (ObjectRepository.areTokensEnabled)
            {
                dontSaveCardDetailsOption.Click();
            }
            DataEntryHelper.ButtonClick(TermsandConditionsCheckbox);
            DataEntryHelper.ButtonClick(ContinueButton1);
            DataEntryHelper.WaitForElementByXpath(paymentAmountErrorMessageLocator);
            errMsg = paymentAmountErrorMessage.GetAttribute("innerText");
            return errMsg;            
        }

        public verifoneSavedCardPayPage completePaymentUsingSavedCard(double paymentAmount)
        {
            ObjectRepository.writer.WriteToLog("This payment is done using a saved card");
            DataEntryHelper.WaitForElementByXpath(OneOffPaymentAmountLocator);
            OneOffPaymentAmount.SendKeys(paymentAmount.ToString("0.00"));
            if (ObjectRepository.areTokensEnabled)
            {
                SelectElement cardsSelect = new SelectElement(savedCardsDropdown);
                if (cardsSelect.Options.Count() > 1)
                {
                    (cardsSelect).SelectByIndex(1);
                }   
            }
            DataEntryHelper.ButtonClick(TermsandConditionsCheckbox);
            DataEntryHelper.ButtonClick(ContinueButton1);
            DataEntryHelper.ButtonClick(ContinueButton2);            
            return new verifoneSavedCardPayPage(driver);
        }

        public digitalTermsAndConditions clickOnTermsAndConditionsLink()
        {
            ObjectRepository.writer.WriteToLog("This payment is done using a saved card");
            DataEntryHelper.WaitForElementByXpath(TermsandConditionsLinkLocator);
            DataEntryHelper.ButtonClick(TermsandConditionsLink);
            return new digitalTermsAndConditions(driver);
        }
        public digitalMyAccount clickOnBackButtonInFirstPage()
        {
            DataEntryHelper.ButtonClick(BackButton1);            
            return ObjectRepository.digitalMyAccountPage;
        }

        public digitalMyAccount clickOnBackButtonInSecondPage(double paymentAmount)
        {            
            DataEntryHelper.WaitForElementByXpath(OneOffPaymentAmountLocator);
            OneOffPaymentAmount.SendKeys(paymentAmount.ToString("0.00"));
            if (ObjectRepository.areTokensEnabled)
            {
                dontSaveCardDetailsOption.Click();
            }
            DataEntryHelper.ButtonClick(TermsandConditionsCheckbox);
            DataEntryHelper.ButtonClick(ContinueButton1);
            DataEntryHelper.ButtonClick(BackButton2);            
            return this.clickOnBackButtonInFirstPage();
        }

        public void fillInOneOffPaymentDetailsInFirstPageAndReachSecondPage(double paymentAmount)
        {
            DataEntryHelper.WaitForElementByXpath(OneOffPaymentAmountLocator);
            OneOffPaymentAmount.SendKeys(paymentAmount.ToString("0.00"));
            if (ObjectRepository.areTokensEnabled)
            {
                dontSaveCardDetailsOption.Click();
            }
            DataEntryHelper.ButtonClick(TermsandConditionsCheckbox);
            DataEntryHelper.ButtonClick(ContinueButton1);
        }

        #endregion
    }
}
