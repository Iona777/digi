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
    public class verifoneSavedCardPayPage : digitalNavigationBar
    {
        private IWebDriver driver;

        public const string CardHolderNameLocator = "//*[@id=\"txt_CardHoldersName\"]";
        public const string AddressLine1Locator = "//*[@id=\"txt_CardHoldersAddressLine1\"]";
        public const string AddressLine2Locator = "//*[@id=\"txt_CardHoldersAddressLine2\"]";
        public const string TownLocator = "//*[@id=\"txt_CardHoldersTown\"]";
        public const string CountyLocator = "//*[@id=\"txt_CardHoldersCounty\"]";
        public const string CountryLocator = "//*[@id=\"txt_CardHoldersCountry\"]";
        public const string PostcodeLocator = "//*[@id=\"txt_CardHoldersPostCode\"]";
        public const string EmailLocator = "//*[@id=\"txt_CardHoldersEmail\"]";
        public const string CSCLocator = "//*[@id=\"txt_TokenCSC\"]";
        public const string CancelButtonLocator = "//*[@id=\"btn_merch_Cancel\"]";
        public const string ContinueButtonLocator = "//*[@id=\"btn_merch_Proceed\"]";        
        
        #region WebElement

        [FindsBy(How = How.XPath, Using = CardHolderNameLocator)]
        private IWebElement CardHolderName;

        [FindsBy(How = How.XPath, Using = AddressLine1Locator)]
        private IWebElement AddressLine1;

        [FindsBy(How = How.XPath, Using = AddressLine2Locator)]
        private IWebElement AddressLine2;

        [FindsBy(How = How.XPath, Using = TownLocator)]
        private IWebElement Town;

        [FindsBy(How = How.XPath, Using = CountyLocator)]
        private IWebElement County;

        [FindsBy(How = How.XPath, Using = CountryLocator)]
        private IWebElement Country;

        [FindsBy(How = How.XPath, Using = PostcodeLocator)]
        private IWebElement Postcode;

        [FindsBy(How = How.XPath, Using = EmailLocator)]
        private IWebElement Email;

        [FindsBy(How = How.XPath, Using = CSCLocator)]
        private IWebElement CSC;

        [FindsBy(How = How.XPath, Using = CancelButtonLocator)]
        private IWebElement CancelButton;

        [FindsBy(How = How.XPath, Using = ContinueButtonLocator)]
        private IWebElement ContinueButton;

        #endregion

        public verifoneSavedCardPayPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions

        public digitalPaymentConfirmation completePayment()
        {
            if (ObjectRepository.areTokensEnabled)
            {
                DataEntryHelper.WaitForElementByXpath(CardHolderNameLocator);
                CardHolderName.Clear();
                CardHolderName.SendKeys("Automated TestAccount");
                AddressLine1.Clear();
                AddressLine1.SendKeys("10");
                AddressLine2.Clear();
                AddressLine2.SendKeys("test");
                Town.Clear();
                Town.SendKeys("Leeds");
                County.Clear();
                County.SendKeys("West Yorkshire");
                Country.Clear();
                Country.SendKeys("United Kingdom");
                Postcode.Clear();
                Postcode.SendKeys("ME156LH");
                Email.Clear();
                Email.SendKeys("dcplantest@dcplantest.com");                
                CSC.Click();
                Thread.Sleep(2000);
                DataEntryHelper.WaitForElementByXpath(CSCLocator);
                CSC.SendKeys("000");
                ContinueButton.Click();
                return new digitalPaymentConfirmation(driver);
            }
            else
            {
                return (new verifonePayPage(this.driver)).completePaymentStep1();
            }
            
        }

        #endregion
    }
}
