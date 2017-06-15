using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Digital.ComponentHelper;


namespace Digital.PageObject
{
    public class digital_LO_OneOffPaymentPage2_Review: digitalNavigationBar
    {

        private IWebDriver driver;

        //Constructor
        public digital_LO_OneOffPaymentPage2_Review(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        
        #region Fields
        public const string LowellRefLocator         = "//*[@id='layout-main']/form/div/div/div/div[1]/div[2]";
        public const string OriginalCompanyLocator  = "//*[@id='layout-main']/form/div/div/div/div[2]/div[2]";
        public const string PaymentAmountLocator    = "//*[@id='layout-main']/form/div/div/div/div[3]/div[2]";
        public const string BackButtonLocator       = "[value='Back'][type='submit']";
        public const string ContinueButtonLocator   = "[value='Continue'][type='submit']";


        [FindsBy(How = How.XPath, Using = LowellRefLocator)]
        IWebElement LowellRef;

        [FindsBy(How = How.XPath, Using = OriginalCompanyLocator)]
        IWebElement OriginalCompany;

        [FindsBy(How = How.XPath, Using = PaymentAmountLocator)]
        IWebElement PaymentAmount;

        [FindsBy(How = How.CssSelector, Using = BackButtonLocator)]
        IWebElement BackButton;

        [FindsBy(How = How.CssSelector, Using = ContinueButtonLocator)]
        IWebElement ContinueButton;
        #endregion

        
        #region Methods
        public void clickBackBtn()
        {
            DataEntryHelper.ButtonClick(BackButton);
        }

        public void clickContinueBtn()
        {
            DataEntryHelper.ButtonClick(ContinueButton);
        }


        //Use this when comparing the entered amount with the value displayed in 
        //Review screen
        public decimal getDisplayedPaymentAmount()
        {
            string amount = (GenericHelper.GetValueAfterPoundSymbol(PaymentAmount.Text));
            return decimal.Parse(amount);
        }

        #endregion
    }
}
