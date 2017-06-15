using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Digital.BaseClasses;
using Digital.ComponentHelper;
using Digital.Settings;

namespace Digital.PageObject
{
    public class digitalRegister : digitalNavigationBar
    {
        private IWebDriver driver;

        public const string RegisterLowellRefNumLocator = "//*[@id='Register_LowellReference']";
        public const string RegisterDOBLocator = "//*[@id='Register_DateOfBirth']";
        public const string RegisterPostCodeLocator = "//*[@id='Register_PostCode']";
        public const string RegisterLandlinePhoneLocator = "//*[@id='Register_LandlinePhone']";
        public const string RegisterMobilePhoneLocator = "//*[@id='Register_MobilePhone']";
        public const string RegisterEmailLocator = "//*[@id='Register_Email']";
        public const string RegisterConfirmEmailLocator = "//*[@id='Register_ConfirmEmail']";
        public const string RegisterPasswordLocator = "//*[@id='Register_Password']";
        public const string RegisterConfirnPasswordLocator = "//*[@id='Register_ConfirmPassword']";
        public const string RegisterContinueBtnLocator = "//*[@id='Register']";
        public const string RegisterFinishBtnLocator = "//*/a[text()='Finish']";

        #region WebElement
        [FindsBy(How = How.XPath, Using = RegisterLowellRefNumLocator)]
        private IWebElement RegisterLowellRefNum;

        [FindsBy(How = How.XPath, Using = RegisterDOBLocator)]
        private IWebElement RegisterDOB;

        [FindsBy(How = How.XPath, Using = RegisterPostCodeLocator)]
        private IWebElement RegisterPostCode;

        [FindsBy(How = How.XPath, Using = RegisterLandlinePhoneLocator)]
        private IWebElement RegisterLandlinePhone;

        [FindsBy(How = How.XPath, Using = RegisterMobilePhoneLocator)]
        private IWebElement RegisterMobilePhone;

        [FindsBy(How = How.XPath, Using = RegisterEmailLocator)]
        private IWebElement RegisterEmail;

        [FindsBy(How = How.XPath, Using = RegisterConfirmEmailLocator)]
        private IWebElement RegisterConfirnEmail;

        [FindsBy(How = How.XPath, Using = RegisterPasswordLocator)]
        private IWebElement RegisterPassword;

        [FindsBy(How = How.XPath, Using = RegisterConfirnPasswordLocator)]
        private IWebElement RegisterConfirnPassword;

        [FindsBy(How = How.XPath, Using = RegisterContinueBtnLocator)]
        private IWebElement RegisterContinueBtn;

        #endregion

        public digitalRegister(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions

        public void refresh()
        {
            driver.Navigate().Refresh();
        }


        public void registerAnAccount(string lowellRefNumber, string dob, string postCode, string landline, string mobile, string emailAddress, string password)
        {
            DataEntryHelper.EnterText(lowellRefNumber, RegisterLowellRefNum);
            DataEntryHelper.EnterText(dob, RegisterDOB);
            DataEntryHelper.EnterText(postCode, RegisterPostCode);
            DataEntryHelper.EnterText(landline, RegisterLandlinePhone);
            DataEntryHelper.EnterText(mobile, RegisterMobilePhone);
            DataEntryHelper.EnterText(emailAddress, RegisterEmail);
            DataEntryHelper.EnterText(emailAddress, RegisterConfirnEmail);
            DataEntryHelper.EnterText(password, RegisterPassword);
            DataEntryHelper.EnterText(password, RegisterConfirnPassword);
            Thread.Sleep(3000);
            DataEntryHelper.ButtonClick(RegisterContinueBtn);
        }

        #endregion

        #region Navigation

        #endregion
    }
}

