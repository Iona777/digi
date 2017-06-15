using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Digital.BaseClasses;
using Digital.ComponentHelper;
using Digital.Settings;
using Digital.Logging;

namespace Digital.PageObject
{
    public class digitalNavigationBarPage : PageBase
    {
        private IWebDriver driver;
        
        //This is only available when the user is not logged in
        public const string NavbarHomeButtonLocator         = "//*/a[text()='Home']";
        //This is only available when the user is logged in.
        public const string NavbarMyAccountButtonLocator    = "//*/li/a[@href='/my-accounts']";

        public const string NavbarPaymentOptionsLocator     = "//*/li/a[@href='/payment-options']";
        public const string NavbarAboutUsLocator            = "//*/a[@href='/about-us']";
        public const string NavbarFAQsLocator               = "//*/a[@href='/about-us']";
        public const string NavbarContactUsLocator          = "//*/a[@href='/contact-us']";
        public const string NavbarRegisterLocator           = "//*/li/a[@href='/register']";
        public const string NavbarLoginLocator              = "//*/li/a[@href='/login']";
        public const string NavbarLogoutLocator             = "//*/a[@href='/Logout']";
        //Need to clear cookies out completely for this to be available
        public const string CookieTermsContinueButtonLocator = "//*[@class='eupopup-button eupopup-button_1']";

        //Error message(s)
        public const string LoginFailedErrorMsgLocator = "//*[@class='validation-summary-errors']/ul/li";

        //This should be on the login page
        public const string NavbarForgotPasswordLocator = "//*/a[@href='/forgotten-your-password/']";

        #region WebElement
        [FindsBy(How = How.XPath, Using = NavbarHomeButtonLocator)]
        private IWebElement NavbarHomeButton;

        [FindsBy(How = How.XPath, Using = NavbarMyAccountButtonLocator)]
        private IWebElement NavbarMyAccountButton;

        [FindsBy(How = How.XPath, Using = NavbarPaymentOptionsLocator)]
        private IWebElement NavbarPaymentOptions;

        [FindsBy(How = How.XPath, Using = NavbarAboutUsLocator)]
        private IWebElement NavbarAboutUs;

        [FindsBy(How = How.XPath, Using = NavbarFAQsLocator)]
        private IWebElement NavbarFAQs;

        [FindsBy(How = How.XPath, Using = NavbarContactUsLocator)]
        private IWebElement NavbarContactUs;

        [FindsBy(How = How.XPath, Using = NavbarRegisterLocator)]
        private IWebElement NavbarRegister;

        [FindsBy(How = How.XPath, Using = NavbarLoginLocator)]
        private IWebElement NavbarLogin;

        //May remove this to the login pae later
        [FindsBy(How = How.XPath, Using = NavbarForgotPasswordLocator)]
        private IWebElement NavbarForgottenPassword;

        [FindsBy(How = How.XPath, Using = NavbarLogoutLocator)]
        private IWebElement NavbarLogout;

        [FindsBy(How = How.XPath, Using = CookieTermsContinueButtonLocator)]
        private IWebElement CookieTermsContinueButton;

        #endregion


        public digitalNavigationBarPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Navigation

        public void refresh()
        {
            driver.Navigate().Refresh();
        }

        public void acceptCookieTerms()
        {
            //If the element is not present, the timeout exception will be handled
            //by IsElementClickable()
            if (GenericHelper.IsElementClickable(CookieTermsContinueButton))
            {
                DataEntryHelper.ButtonClick(CookieTermsContinueButton);
            }
            
            //Thread.Sleep(1500);
            //if (CookieTermsContinueButton.Displayed)
            //{
            //    DataEntryHelper.ButtonClick(CookieTermsContinueButton);
            //}
            //else
            //{
            //    return;
            //}   
        }


       //Need to change these methods to return the new versions of the page objects
       //as they get written
        public digitalHome goToHomePage()
        {
            DataEntryHelper.ButtonClick(NavbarHomeButton);
            return new digitalHome(driver);
        }

        public digitalMyAccountPage goToMyAccountPage() //new page object
        {
            DataEntryHelper.ButtonClick(NavbarMyAccountButton);
            return new digitalMyAccountPage(driver);
        }

        public digital_LO_PaymentOptionsPage1 goToPaymentOptionsPage()
        {
            DataEntryHelper.ButtonClick(NavbarPaymentOptions);
            return new digital_LO_PaymentOptionsPage1(driver);
        }

        public digitalAboutUs goToAboutUsPage()
        {
            DataEntryHelper.ButtonClick(NavbarAboutUs);
            return new digitalAboutUs(driver);
        }

        public digitalFAQ goToFAQsPage()
        {
            DataEntryHelper.ButtonClick(NavbarFAQs);
            return new digitalFAQ(driver);
        }

        public digitalContactUs goToContactUsPage()
        {
            DataEntryHelper.ButtonClick(NavbarContactUs);
            return new digitalContactUs(driver);
        }

        public digitalRegisterPage goToRegistrationPage() // new page object
        {
            DataEntryHelper.ButtonClick(NavbarRegister);
            return new digitalRegisterPage(driver);
        }

        public digitalLogin gotToLogInPage()
        {
            DataEntryHelper.ButtonClick(NavbarLogin);
            return new digitalLogin(driver);
        }

        public digitalHome logout()
        {
            DataEntryHelper.ButtonClick(NavbarLogout);
  
            ObjectRepository.writer.WriteToLog("User is Logged out and test is complete \n\n");
            ObjectRepository.writer.FlushLog();
            return new digitalHome(driver);
        }

        #endregion
    }
}
