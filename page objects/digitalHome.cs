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
    public class digitalHome : digitalNavigationBar
    {
        private IWebDriver driver;

        //Old versions using long generated Xpath - keep this as backup for now
        //public const string BubbleRegisterLocator = "//*[@id='layout-featured']/div/div/div/div[2]/div[1]/div/div/div/a";
        //public const string BubblePaymentOptionsLocator = "//*[@id='layout-featured']/div/div/div/div[2]/div[2]/div/div/a";
        //public const string BubbleBudgetCalculatorLocator = "//*[@id='layout-featured']/div/div/div/div[2]/div[3]/div/div/a";
        //public const string BubbleLoginLocator = "//*[@id='layout-featured']/div/div/div/div[2]/div[4]/div/div/div/a";
        //public const string HeaderHomeLocator = "//*[@id='main-menu']/div/div/ul/li[1]/a";
        //public const string HeaderPaymentOptionsLocator = "//*[@id='main-menu']/div/div/ul/li[2]/a";
        //public const string HeaderAboutUsLocator = "//*[@id='main-menu']/div/div/ul/li[3]/a";
        //public const string HeaderFAQsLocator = "//*[@id='main-menu']/div/div/ul/li[4]/a";
        //public const string HeaderContactUsLocator = "//*[@id='main-menu']/div/div/ul/li[5]/a";
        //public const string HeaderRegisterLocator = "//*[@id='main-menu']/div/div/ul/li[6]/a";
        //public const string HeaderLoginLocator = "//*[@id='main-menu']/div/div/ul/li[7]/a";
        //public const string TermsAndConditionsLinkLocator = "/html/body/footer/div/div/div[1]/p[1]/strong/a[1]";
        //public const string PrivacyPolicyLinkLocator = "/html/body/footer/div/div/div[1]/p[1]/strong/a[2]";

        public const string BubbleRegisterLocator           = "[class='circletext'][href='/register']";
        public const string BubblePaymentOptionsLocator     = "[class='circletext'][href='/payment-options']";
        public const string BubbleBudgetCalculatorLocator   = "[class='circletext'][href='/budget-calculator']";
        public const string BubbleLoginLocator              = "[class='circletext'][href='/login']";
        public const string HeaderHomeLocator               = "//a[@href='/'][text()='Home']"; 
        public const string HeaderPaymentOptionsLocator     = "//li/a[@href='/payment-options'][text()='Payment Options']"; 
        public const string HeaderAboutUsLocator            = "//a[@href='/about-us'][text()='About Us']"; 
        public const string HeaderFAQsLocator               = "//a[@href='/faqs'][text()='FAQs']"; 
        public const string HeaderContactUsLocator          = "//a[@href='/contact-us'][text()='Contact Us']";
        public const string HeaderRegisterLocator           = "//li/a[@href='/register'][text()='Register']"; 
        public const string HeaderLoginLocator              = "//li/a[@href='/login'][text()='Login']"; 
        public const string TermsAndConditionsLinkLocator   = "//a[@href='https://testdigital.lowellgroup.co.uk/terms-and-conditions/'][text()='Terms and Conditions']";
        public const string PrivacyPolicyLinkLocator        = "//a[@href='https://testdigital.lowellgroup.co.uk/privacy-policy/'][text()='Privacy Policy']";

        #region WebElement
        [FindsBy(How = How.CssSelector, Using = BubbleRegisterLocator)]
        private IWebElement BubbleRegister;

        [FindsBy(How = How.CssSelector, Using = BubblePaymentOptionsLocator)]
        private IWebElement BubblePaymentOptions;

        [FindsBy(How = How.CssSelector, Using = BubbleBudgetCalculatorLocator)]
        private IWebElement BubbleBudgetCalculator;

        [FindsBy(How = How.CssSelector, Using = BubbleLoginLocator)]
        private IWebElement BubbleLogin;

        [FindsBy(How = How.XPath, Using = HeaderHomeLocator)]
        private IWebElement HeaderHome;

        [FindsBy(How = How.XPath, Using = HeaderPaymentOptionsLocator)]
        private IWebElement HeaderPaymentOptions;

        [FindsBy(How = How.XPath, Using = HeaderAboutUsLocator)]
        private IWebElement HeaderAboutUs;

        [FindsBy(How = How.XPath, Using = HeaderFAQsLocator)]
        private IWebElement HeaderFAQs;

        [FindsBy(How = How.XPath, Using = HeaderContactUsLocator)]
        private IWebElement HeaderContactUs;

        [FindsBy(How = How.XPath, Using = HeaderRegisterLocator)]
        private IWebElement HeaderRegister;

        [FindsBy(How = How.XPath, Using = HeaderLoginLocator)]
        private IWebElement HeaderLogin;

        [FindsBy(How = How.XPath, Using = TermsAndConditionsLinkLocator)]
        private IWebElement TermsAndConditionsLink;

        [FindsBy(How = How.XPath, Using = PrivacyPolicyLinkLocator)]
        private IWebElement PrivacyPolicyLink;

        #endregion

        public digitalHome(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }


        #region Navigation
        public digitalRegister gotToRegistrationPage()
        {
            DataEntryHelper.ButtonClick(BubbleRegister);
            return new digitalRegister(driver);
        }

        public digital_LO_PaymentOptionsPage1 gotToPaymentOptionsPage()
        {
            DataEntryHelper.ButtonClick(BubblePaymentOptions);
            return new digital_LO_PaymentOptionsPage1(driver);
        }

        public digitalBudgetCalculator gotToBudgetCalculatorPage()
        {
            DataEntryHelper.ButtonClick(BubbleBudgetCalculator);
            return new digitalBudgetCalculator(driver);
        }

        public digitalLogin gotToLogInPage()
        {
            DataEntryHelper.ButtonClick(BubbleLogin);
            return new digitalLogin(driver);
        }

        
        public digitalLogin gotToTermsAndConditions()
        {
            DataEntryHelper.ButtonClick(TermsAndConditionsLink);
            return new digitalLogin(driver);
        }

        public digitalLogin gotToPrivacyPolicy()
        {
            DataEntryHelper.ButtonClick(PrivacyPolicyLink);
            return new digitalLogin(driver);
        }

        #endregion
    }
}
