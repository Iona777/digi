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
    public class digital_LO_PaymentOptionsPage1 : digitalNavigationBar
    {
        private IWebDriver driver;

        //Old versions using long generated Xpath - keep this as backup for now
        //public const string BudgetCalcRadiobuttonLocator    = "//*[@id='radiodiv']/label[1]";
        //public const string PaymentOptsRadiobuttonLocator   = "//*[@id='radiodiv']/label[2]";
        //public const string PaymentOptsLowellRefNumLocator  = "//*[@id='LowellReferenceNumber']";
        //public const string PaymentOptsDOBLocator           = "//*[@id='DateOfBirth']";
        //public const string PaymentOptsPostCodeLocator      = "//*[@id='PostCode']";
        //public const string PaymentOptsContinueBtnLocator   = "/html/body/div[3]/div[2]/form/div/button";

        public const string BudgetCalcRadiobuttonLocator    = "[id='IsNavigateToBudget'][value='True']";
        public const string PaymentOptsRadiobuttonLocator   = "[id='IsNavigateToBudget'][value='False']";
        

        //NOTE: these ids are not unique, but there are hidden and displayed versions. We assume for now that we will only
        //access the displayed versions which is the first encountered
        public const string PaymentOptsLowellRefNumLocator  = "//*[@id='LowellReferenceNumber']";
        public const string PaymentOptsDOBLocator           = "//*[@id='DateOfBirth']";
        public const string PaymentOptsPostCodeLocator      = "//*[@id='PostCode']";
        public const string PaymentOptsContinueBtnLocator   = "[value='Continue'][type='submit']";


        #region WebElement
        [FindsBy(How = How.CssSelector, Using = BudgetCalcRadiobuttonLocator)]
        private IWebElement BudgetCalcRadiobutton;

        [FindsBy(How = How.CssSelector, Using = PaymentOptsRadiobuttonLocator)]
        private IWebElement PaymentOptsRadiobutton;

        [FindsBy(How = How.XPath, Using = PaymentOptsLowellRefNumLocator)]
        private IWebElement PaymentOptsLowellRefNum;

        [FindsBy(How = How.XPath, Using = PaymentOptsDOBLocator)]
        private IWebElement PaymentOptsDOB;

        [FindsBy(How = How.XPath, Using = PaymentOptsPostCodeLocator)]
        private IWebElement PaymentOptsPostCode;

        [FindsBy(How = How.CssSelector, Using = PaymentOptsContinueBtnLocator)]
        private IWebElement PaymentOptsContinueBtn;
        #endregion

        //Constructor
        public digital_LO_PaymentOptionsPage1(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions
        public void clickBudgetCalcRadioBtn()
        {
            DataEntryHelper.ButtonClick(BudgetCalcRadiobutton);
        }

        public void clickPaymentOptionsRadioBtn()
        {
            DataEntryHelper.ButtonClick(PaymentOptsRadiobutton);
        }

        public void enterLowellRefNo(string input)
        {
            DataEntryHelper.EnterText(input, PaymentOptsLowellRefNum);
        }

        public void enterDOB(string input)
        {
            DataEntryHelper.EnterText(input,PaymentOptsDOB);
        }

        public void enterPostCode(string input)
        {
            DataEntryHelper.EnterText(input, PaymentOptsPostCode);
        }


        public void clickContinueBtn()
        {
            DataEntryHelper.ButtonClick(PaymentOptsContinueBtn);
        }

        public void enterAnonAccessDetails(string refNo, string DOB, string postcode)
        {
            enterLowellRefNo(refNo);
            enterDOB(DOB);
            enterPostCode(postcode);
        }
        #endregion

        
    }
}
