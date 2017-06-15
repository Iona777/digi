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
    public class verifonePayPage : digitalNavigationBar
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
        public const string CardNumberLocator = "//*[@id=\"txt_CardNumber\"]";
        public const string IssueNoLocator = "//*[@id=\"txt_CardNumber\"]";
        public const string CSCLocator = "//*[@id=\"txt_CSC\"]";
        public const string ExpiryMonthSelectLocator = "//*[@id=\"ddl_ExpiryMonth\"]";
        public const string ExpiryYearSelectLocator = "//*[@id=\"ddl_ExpiryYear\"]";
        public const string StartMonthSelectLocator = "//*[@id=\"ddl_StartMonth\"]";
        public const string StartYearSelectLocator = "//*[@id=\"ddl_StartYear\"]";
        public const string CancelButtonLocator = "//*[@id=\"btn_merch_Cancel\"]";
        public const string ContinueButtonLocator = "//*[@id=\"btn_merch_Proceed\"]";
        public const string PayerAuthSubmitLocator = "//input[@type='submit']";
        
        public const string verifoneErrorRetryButtonLocator = "//*[@id=\"btn_merch_Retry\"]";
        public const string verifoneErrorCancelButtonLocator = "//*[@id=\"btn_merch_Cancel\"]";

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

        [FindsBy(How = How.XPath, Using = CardNumberLocator)]
        private IWebElement CardNumber;

        [FindsBy(How = How.XPath, Using = IssueNoLocator)]
        private IWebElement IssueNo;

        [FindsBy(How = How.XPath, Using = CSCLocator)]
        private IWebElement CSC;

        [FindsBy(How = How.XPath, Using = ExpiryMonthSelectLocator)]
        private IWebElement ExpiryMonthSelect;

        [FindsBy(How = How.XPath, Using = ExpiryYearSelectLocator)]
        private IWebElement ExpiryYearSelect;

        [FindsBy(How = How.XPath, Using = StartMonthSelectLocator)]
        private IWebElement StartMonthSelect;

        [FindsBy(How = How.XPath, Using = StartYearSelectLocator)]
        private IWebElement StartYearSelect;

        [FindsBy(How = How.XPath, Using = CancelButtonLocator)]
        private IWebElement CancelButton;

        [FindsBy(How = How.XPath, Using = ContinueButtonLocator)]
        private IWebElement ContinueButton;

        //[FindsBy(How = How.XPath, Using = "/html/body/form/table/tbody/tr/td/table/tbody/tr[4]/td/input[1]")]
        [FindsBy(How = How.XPath, Using = PayerAuthSubmitLocator)]
        private IWebElement PayerAuthSubmit;

        [FindsBy(How = How.XPath, Using = verifoneErrorRetryButtonLocator)]
        private IWebElement verifoneErrorRetryButton;

        [FindsBy(How = How.XPath, Using = verifoneErrorCancelButtonLocator)]
        private IWebElement verifoneErrorCancelButton;

        #endregion

        public verifonePayPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions

        public digitalPaymentCancellation cancelPayment()
        {
            CancelButton.Click();
            return new digitalPaymentCancellation(driver);
        }

        public digitalPaymentConfirmation completePaymentStep1(string cardNumber)
        {
            DataEntryHelper.WaitForElementByXpath(CardHolderNameLocator);

            CardHolderName.Clear();
            AddressLine1.Clear();
            AddressLine2.Clear();
            Town.Clear();
            County.Clear();
            Country.Clear();
            Postcode.Clear();
            Email.Clear();

            CardHolderName.SendKeys("Automated TestAccount");
            AddressLine1.SendKeys("10 Test Street");
            AddressLine2.SendKeys("Test Place ");
            Town.SendKeys("Leeds");
            County.SendKeys("West Yorkshire");
            Country.SendKeys("United Kingdom");
            Postcode.SendKeys("ME156LH");
            
            Email.SendKeys("LogOutOneOffTest@test.com");
            CardNumber.SendKeys(cardNumber);
            CSC.Click();            
            Thread.Sleep(2000);
            CSC.SendKeys("000");
            ExpiryMonthSelect.FindElement(By.CssSelector("option[value='07']")).Click();
            ExpiryYearSelect.FindElement(By.CssSelector("option[value='2021']")).Click();
            ContinueButton.Click();
            Thread.Sleep(2000);            
            return new digitalPaymentConfirmation(driver);
        }


        public digitalPaymentError createPaymentErrorUsingInvalidData()
        {
            int retrycount = 0;
            fillInPaymentDataAndClickOnContinue("111");            
            while (DataEntryHelper.isElementVisible(verifoneErrorRetryButtonLocator,10) && retrycount < 3)
            {
                DataEntryHelper.ButtonClick(verifoneErrorRetryButton);                
                fillInPaymentDataAndClickOnContinue("111");                
            }
            DataEntryHelper.ButtonClick(verifoneErrorCancelButton);
            return new digitalPaymentError(driver);
        }

        public void fillInPaymentDataAndClickOnContinue(string csc)
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
            CardNumber.SendKeys("4012001038443335");
            CSC.Click();
            Thread.Sleep(2000);
            CSC.SendKeys(csc);
            ExpiryMonthSelect.FindElement(By.CssSelector("option[value='07']")).Click();
            ExpiryYearSelect.FindElement(By.CssSelector("option[value='2021']")).Click();
            ContinueButton.Click();
        }

        public digitalPaymentConfirmation completePaymentStep1()
        {
            /*DataEntryHelper.WaitForElementByXpath(CardHolderNameLocator);
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
            CardNumber.SendKeys("4012001038443335");
            CSC.Click();            
            Thread.Sleep(2000);
            CSC.SendKeys("000");
            ExpiryMonthSelect.FindElement(By.CssSelector("option[value='07']")).Click();
            ExpiryYearSelect.FindElement(By.CssSelector("option[value='2021']")).Click();
            ContinueButton.Click();*/
            //Thread.Sleep(4000);            
            fillInPaymentDataAndClickOnContinue("000");
            return new digitalPaymentConfirmation(driver);
        }



        public void complete3dSecurity()
        {
            DataEntryHelper.WaitForElementByXpath(PayerAuthSubmitLocator);
            driver.SwitchTo().Frame("paframe");
            PayerAuthSubmit.Click();
        }

        #endregion

    }
}
