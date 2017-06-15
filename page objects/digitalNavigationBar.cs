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
using Digital.Logging;

namespace Digital.PageObject
{
    public class digitalNavigationBar : PageBase
    {
        private IWebDriver driver;

        public const string NavbarHomeButtonLocator = "//*[@id=\"main-menu\"]/div/div/ul/li[1]/a";
        public const string NavbarMyAccountButtonLocator = "//*[@id=\"main-menu\"]/div/div/ul/li[1]/a";
        public const string NavbarPaymentOptionsLocator = "//*[@id=\"main-menu\"]/div/div/ul/li[2]/a";
        public const string NavbarAboutUsLocator = "//*[@id=\"main-menu\"]/div/div/ul/li[3]/a";
        public const string NavbarFAQsLocator = "//*[@id=\"main-menu\"]/div/div/ul/li[4]/a";
        public const string NavbarContactUsLocator = "//*[@id=\"main-menu\"]/div/div/ul/li[5]/a";
        public const string NavbarRegisterLocator = "//*[@id=\"main-menu\"]/div/div/ul/li[6]/a";
        public const string NavbarLoginLocator = "//*[@id=\"main-menu\"]/div/div/ul/li[7]/a";
        public const string NavbarChangePasswordLocator = "//*[@id=\"main-menu\"]/div/div/ul/li[5]/ul/li/a";
        public const string NavbarLogoutLocator = "//*[@id=\"main-menu\"]/div/div/ul/li[6]/a";
        public const string CookieTermsContinueButtonLocator = "/html/body/div[6]/div[3]/a[1]";
        public const string TermsAndConditionsFooterLinkLocator = "/html/body/footer/div/div/div[1]/p[1]/strong/a[1]";
        public const string PrivacyPolicyLinkLocator = "/html/body/footer/div/div/div[1]/p[1]/strong/a[2]";

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

        [FindsBy(How = How.XPath, Using = NavbarChangePasswordLocator)]
        private IWebElement NavbarChangePassword;

        [FindsBy(How = How.XPath, Using = NavbarLogoutLocator)]
        private IWebElement NavbarLogout;

        [FindsBy(How = How.XPath, Using = CookieTermsContinueButtonLocator)]
        private IWebElement CookieTermsContinueButton;

        [FindsBy(How = How.XPath, Using = TermsAndConditionsFooterLinkLocator)]
        private IWebElement TermsAndConditionsLink;

        [FindsBy(How = How.XPath, Using = PrivacyPolicyLinkLocator)]
        private IWebElement PrivacyPolicyLink;

        #endregion


        public digitalNavigationBar(IWebDriver _driver) : base(_driver)
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
            if (GenericHelper.IsElementDisplayed(By.XPath(CookieTermsContinueButtonLocator)))
            {
                CookieTermsContinueButton.Click();
            }
            else
            {
                return;
            }
            
        }

        public digitalHome gotToHomePage()
        {
            DataEntryHelper.ButtonClick(NavbarHomeButton);
            //NavbarHomeButton.Click();
            return new digitalHome(driver);
        }

        public digitalMyAccount gotToMyAccountPage()
        {
            DataEntryHelper.ButtonClick(NavbarMyAccountButton);
            //NavbarMyAccountButton.Click();
            return new digitalMyAccount(driver);
        }

        public digital_LO_PaymentOptionsPage1 gotToPaymentOptionsPage()
        {
            DataEntryHelper.ButtonClick(NavbarPaymentOptions);
            //NavbarPaymentOptions.Click();
            return new digital_LO_PaymentOptionsPage1(driver);

        }

        public digitalAboutUs gotToAboutUsPage()
        {
            DataEntryHelper.ButtonClick(NavbarAboutUs);
            //NavbarAboutUs.Click();
            return new digitalAboutUs(driver);

        }

        public digitalFAQ gotToFAQsPage()
        {
            DataEntryHelper.ButtonClick(NavbarFAQs);
            //NavbarFAQs.Click();
            return new digitalFAQ(driver);

        }

        public digitalContactUs gotToContactUsPage()
        {
            DataEntryHelper.ButtonClick(NavbarContactUs);
            //NavbarContactUs.Click();
            return new digitalContactUs(driver);

        }

        public digitalRegister gotToRegistrationPage()
        {
            DataEntryHelper.ButtonClick(NavbarRegister);
            //NavbarRegister.Click();
            return new digitalRegister(driver);

        }

        public digitalLogin gotToLogInPage()
        {
            DataEntryHelper.ButtonClick(NavbarLogin);
            //NavbarLogin.Click();
            return new digitalLogin(driver);
        }

        public digitalHome logout()
        {
            DataEntryHelper.ButtonClick(NavbarLogout);
            //NavbarLogout.Click();
            ObjectRepository.writer.WriteToLog("User is Logged out and test is complete \n\n");
            ObjectRepository.writer.FlushLog();
            return new digitalHome(driver);
        }

        public digitalTermsAndConditions goToTermsAndConditionsPage()
        {
            DataEntryHelper.ButtonClick(TermsAndConditionsLink);
            //TermsAndConditionsLink.Click();
            return new digitalTermsAndConditions(driver);
        }

        public void goToPrivacyPolicyPage()
        {
            DataEntryHelper.ButtonClick(PrivacyPolicyLink);
            //PrivacyPolicyLink.Click();
        }

        #endregion
    }
}
