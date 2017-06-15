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
using System.Threading;

namespace Digital.PageObject
{
    public class digitalMyAccount : digitalNavigationBar
    {
        private IWebDriver driver;
        private Boolean isAccountDetailsDivExpanded;


        public const string MyAccountsTableLocator = "//*[@id=\"layout-before-main\"]/div/article[1]/div/div[3]/div/table/tbody";
        public const string MyAccountDetailsRow1Locator = "//*[@id=\"layout-before-main\"]/div/article[1]/div/div[3]/div/table/tbody/tr[1]";
        public const string AccountDetailsDivLocator = "//*[@id=\"1\"]";
        public const string MyAccountLowellReference1Locator = "//*[@id=\"layout-before-main\"]/div/article[1]/div/div[3]/div/table/tbody/tr[1]/td[1]";
        public const string MyAccountOrigianlClient1Locator = "//*[@id=\"layout-before-main\"]/div/article[1]/div/div[3]/div/table/tbody/tr[1]/td[2]";
        public const string MyAccountOutstandingBalance1Locator = "//*[@id=\"layout-before-main\"]/div/article[1]/div/div[3]/div/table/tbody/tr[1]/td[3]";
        public const string MyAccountRegularPaymentAmt1Locator = "//*[@id=\"layout-before-main\"]/div/article[1]/div/div[3]/div/table/tbody/tr[1]/td[4]";
        public const string MyAccountStatus1Locator = "//*[@id=\"layout-before-main\"]/div/article[1]/div/div[3]/div/table/tbody/tr[1]/td[5]";
        //public const string DDPlanButtonLocator = "//*[@id=\"ddplan\"]";
        public const string DDPlanButtonLocator = "//*[@class=\"paymentplanoption paymentoptionbtn\"]";
        public const string DCPlanButtonLocator = "//*[@id=\"dcplan\"]";
        //public const string PayInFullButtonLocator = "//*[@id=\"fullpayment\"]";
        public const string PayInFullButtonLocator = "//*[@class=\"payinfulloption paymentoptionbtn\"]";
        //public const string OneOffPaymentButtonLocator = "//*[@id=\"partial\"]";
        public const string OneOffPaymentButtonLocator = "//*[@class=\"partialpaymentoption paymentoptionbtn\"]";
        public const string BudgetCalculatorButton1Locator = "//*[@class=\"budgetcalculatoroption paymentoptionbtn\"]";
        public const string RegularPaymentAmountLocator = "//*[@id=\"1\"]/div[2]/div/div/table/tbody/tr/td[1]";
        public const string PaymentFrequencyLocator = "//*[@id=\"1\"]/div[2]/div/div/table/tbody/tr/td[2]";
        public const string PaymentMethodLocator = "//*[@id=\"1\"]/div[2]/div/div/table/tbody/tr/td[3]";
        public const string LastPaymentDateLocator = "//*[@id=\"1\"]/div[2]/div/div/table/tbody/tr/td[4]";
        public const string acceptedDiscountLocator = "//*[@id=\"1\"]/div[2]/div/div/div/text()";
        public const string discountDetailsRowLocator = "//*[@id=\"layout-before-main\"]/div/article[1]/div/div[3]/div[1]/table/tbody/tr[2]";
        public const string discountMessageLocator = "//*[@id=\"layout-before-main\"]/div/article[1]/div/div[3]/div[1]/table/tbody/tr[2]/td";
        public const string BudgetCalculatorButton2Locator = "//*[@id=\"layout-before-main\"]/div/article[2]/div/div[3]/a";
        public const string TotalIncomeLocator = "//*[@id=\"layout-before-main\"]/div/article[2]/div/div[2]/ul/li[2]";
        public const string ViewAllTransactionsLocator = "//*[@id='1']/div[3]/div/div/a";
        public const string PaymentOptionsLocator = "//*[@id='1']/div[1]/form/div[2]/*";
        public const string PaymentPlanTablePaymentAmountLocator = "//*[@id='1']/div[2]/div/div/table/tbody/tr/td[1]";
        public const string PaymentPlanTablePaymentFrequencyLocator = "//*[@id='1']/div[2]/div/div/table/tbody/tr/td[2]";
        public const string PaymentPlanTablePaymentMethodLocator = "//*[@id='1']/div[2]/div/div/table/tbody/tr/td[3]";
        public const string PaymentPlanTableLastPaymentDateLocator = "//*[@id='1']/div[2]/div/div/table/tbody/tr/td[4]";
        public const string AcceptedDiscountLocator = "//*[@id='1']/div[2]/div/div/div[2]";
        
        public const string TotalExpenditureLocator = "//*[@id=\"layout-before-main\"]/div/article[2]/div/div[2]/ul/li[3]";
        public const string TotalDisposableIncomeLocator = "//*[@id=\"layout-before-main\"]/div/article[2]/div/div[2]/ul/li[4]";
        public const string BudgetPlannerMessageLocator = "//*[@id=\"layout-before-main\"]/div/article[2]/div/p";

        public const string PaymentOptionsErrorMsgLocator = "//*[@id='1']/div[1]/div/div/div";


        #region WebElement
                
        [FindsBy(How = How.XPath, Using = MyAccountsTableLocator)]
        private IWebElement MyAccountsTable;
        
        [FindsBy(How = How.XPath, Using = MyAccountDetailsRow1Locator)]
        private IWebElement MyAccountDetailsRow1;

        [FindsBy(How = How.XPath, Using = AccountDetailsDivLocator)]
        private IWebElement AccountDetailsDiv;

        [FindsBy(How = How.XPath, Using = MyAccountLowellReference1Locator)]
        private IWebElement MyAccountLowellReference1;

        [FindsBy(How = How.XPath, Using = MyAccountOrigianlClient1Locator)]
        private IWebElement MyAccountOrigianlClient1;

        [FindsBy(How = How.XPath, Using = MyAccountOutstandingBalance1Locator)]
        private IWebElement MyAccountOutstandingBalance1;

        [FindsBy(How = How.XPath, Using = MyAccountRegularPaymentAmt1Locator)]
        private IWebElement MyAccountRegularPaymentAmt1;

        [FindsBy(How = How.XPath, Using = MyAccountStatus1Locator)]
        private IWebElement MyAccountStatus1;

        [FindsBy(How = How.XPath, Using = DDPlanButtonLocator)]
        private IWebElement DDPlanButton;

        [FindsBy(How = How.XPath, Using = DCPlanButtonLocator)]
        private IWebElement DCPlanButton;

        [FindsBy(How = How.XPath, Using = PayInFullButtonLocator)]
        private IWebElement PayInFullButton;

        [FindsBy(How = How.XPath, Using = OneOffPaymentButtonLocator)]
        private IWebElement OneOffPaymentButton;

        [FindsBy(How = How.XPath, Using = BudgetCalculatorButton1Locator)]
        private IWebElement BudgetCalculatorButton1;

        [FindsBy(How = How.XPath, Using = RegularPaymentAmountLocator)]
        private IWebElement RegularPaymentAmount;

        [FindsBy(How = How.XPath, Using = PaymentFrequencyLocator)]
        private IWebElement PaymentFrequency;

        [FindsBy(How = How.XPath, Using = PaymentMethodLocator)]
        private IWebElement PaymentMethod;

        [FindsBy(How = How.XPath, Using = LastPaymentDateLocator)]
        private IWebElement LastPaymentDate;

        [FindsBy(How = How.XPath, Using = acceptedDiscountLocator)]
        private IWebElement acceptedDiscountValue;

        [FindsBy(How = How.XPath, Using = discountDetailsRowLocator)]
        private IWebElement discountDetailsRow;

        [FindsBy(How = How.XPath, Using = discountMessageLocator)]
        private IWebElement discountMessage;

        [FindsBy(How = How.XPath, Using = BudgetCalculatorButton2Locator)]
        private IWebElement BudgetCalculatorButton2;

        [FindsBy(How = How.XPath, Using = TotalIncomeLocator)]
        private IWebElement TotalIncome;

        [FindsBy(How = How.XPath, Using = TotalExpenditureLocator)]
        private IWebElement TotalExpenditure;

        [FindsBy(How = How.XPath, Using = TotalDisposableIncomeLocator)]
        private IWebElement TotalDisposableIncome;

        [FindsBy(How = How.XPath, Using = BudgetPlannerMessageLocator)]
        private IWebElement BudgetPlannerMessage;
              
        [FindsBy(How = How.XPath, Using = PaymentOptionsErrorMsgLocator)]
        private IWebElement PaymentOptionsErrorMsg;

        [FindsBy(How = How.XPath, Using = ViewAllTransactionsLocator)]
        private IWebElement ViewAllTransactionsButton;

        [FindsBy(How = How.XPath, Using = PaymentPlanTablePaymentAmountLocator)]
        private IWebElement PaymentPlanTablePaymentAmount;

        [FindsBy(How = How.XPath, Using = PaymentPlanTablePaymentFrequencyLocator)]
        private IWebElement PaymentPlanTablePaymentFrequency;

        [FindsBy(How = How.XPath, Using = PaymentPlanTablePaymentMethodLocator)]
        private IWebElement PaymentPlanTablePaymentMethod;

        [FindsBy(How = How.XPath, Using = PaymentPlanTableLastPaymentDateLocator)]
        private IWebElement PaymentPlanTableLastPaymentDate;

        [FindsBy(How = How.XPath, Using = AcceptedDiscountLocator)]
        private IWebElement AcceptedDiscount;
              
        #endregion

        public digitalMyAccount(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions
        
        public void refresh()
        {
            driver.Navigate().Refresh();
            isAccountDetailsDivExpanded = false;
        }

        public string getAllThePaymentOptionsAvailable()
        {
            expandAccountDetailsDiv();
            IReadOnlyList<IWebElement> childs = driver.FindElements(By.XPath(PaymentOptionsLocator));
            string elementLable="";
            foreach(IWebElement i in childs)
            {
                elementLable = elementLable + ":" + ((i.FindElements(By.XPath("./*"))).ElementAt(1)).GetAttribute("value");
            }
            return elementLable;
            }

        public digitalOneOffPayment navigateToOneOffPayment(){
            expandAccountDetailsDiv();
            DataEntryHelper.ButtonClick(OneOffPaymentButton);
            isAccountDetailsDivExpanded = false;
            return new digitalOneOffPayment(driver);
        }

        public digitalPayInFull navigateToFullPayment(){
            expandAccountDetailsDiv();
            DataEntryHelper.ButtonClick(PayInFullButton);
            isAccountDetailsDivExpanded = false;
            return new digitalPayInFull(driver);
        }

        public digitalDirectDebitPlan navigateToDirectDebitPlan(){
            expandAccountDetailsDiv();
            DataEntryHelper.ButtonClick(DDPlanButton);
            isAccountDetailsDivExpanded = false;
            return new digitalDirectDebitPlan(driver);
        }

        public digitalDebitCardPlan navigateToDebitCardPlan()
        {
            expandAccountDetailsDiv();
            DataEntryHelper.ButtonClick(DCPlanButton);
            isAccountDetailsDivExpanded = false;
            return new digitalDebitCardPlan(driver);
        }

        public digitalBudgetCalculator navigateToBudgetCalculator()
        {
            expandAccountDetailsDiv();
            DataEntryHelper.ButtonClick(BudgetCalculatorButton1);
            isAccountDetailsDivExpanded = false;
            return new digitalBudgetCalculator(driver);
        }

        public bool isViewAllTransactionsButtonAvailable()
        {
            expandAccountDetailsDiv();
            return DataEntryHelper.isElementVisible(ViewAllTransactionsLocator, 5);
        }

        public digitalStatements navigateToStatementsPage()
        {
            expandAccountDetailsDiv();
            DataEntryHelper.ButtonClick(ViewAllTransactionsButton);
            isAccountDetailsDivExpanded = false;
            return new digitalStatements(driver);
        }

        public string getPaymentPlanDetails()
        {
            expandAccountDetailsDiv();
            DataEntryHelper.WaitForElementByXpath(PaymentPlanTablePaymentAmountLocator);
            return PaymentPlanTablePaymentAmount.GetAttribute("innerText") + " : " + PaymentPlanTablePaymentFrequency.GetAttribute("innerText") + " : " + PaymentPlanTablePaymentMethod.GetAttribute("innerText");
        }

        public string getAcceptedDiscount()
        {
            expandAccountDetailsDiv();
            DataEntryHelper.WaitForElementByXpath(AcceptedDiscountLocator);
            return AcceptedDiscount.GetAttribute("innerText");
        }

        public string getPaymentOptionsErrorMessage()
        {
            expandAccountDetailsDiv();
            return PaymentOptionsErrorMsg.GetAttribute("innerText");
        }

        public void expandAccountDetailsDiv()
        {
            if (!isAccountDetailsDivExpanded)
            {
                DataEntryHelper.ButtonClick(MyAccountDetailsRow1);
                isAccountDetailsDivExpanded = true;
            }
        }

        public string getBudgetDetails(){
            string budgetDetails = "Total Income:- " + TotalIncome.GetAttribute("innerText") + " : Total Expenditure:- " + TotalExpenditure.GetAttribute("innerText")
                                    + "Total Disposable Income:- " + TotalDisposableIncome.GetAttribute("innerText");
            return budgetDetails;
        }

        public bool areBudgetDetailsPresent()
        {
            DataEntryHelper.WaitForElementByXpath(BudgetPlannerMessageLocator);
            if (BudgetPlannerMessage.GetAttribute("innerText").Contains("You have not yet completed a budget calculator"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int getTotalIncome()
        {
            DataEntryHelper.WaitForElementByXpath(TotalIncomeLocator);
            if(!areBudgetDetailsPresent()){
                return 0;
            }
            return GenericHelper.getNumberFromString(TotalIncome.GetAttribute("innerText"))/100;
        }

        public int getTotalExpenditure()
        {
            DataEntryHelper.WaitForElementByXpath(TotalExpenditureLocator);
            if(!areBudgetDetailsPresent())
            {
                return 0;
            }
            return GenericHelper.getNumberFromString(TotalExpenditure.GetAttribute("innerText"))/100;
        }

        public int getTotalDisposableIncome()
        {
            DataEntryHelper.WaitForElementByXpath(TotalDisposableIncomeLocator);
            if(!areBudgetDetailsPresent())
            {
                return 0;
            }
            return GenericHelper.getNumberFromString(TotalDisposableIncome.GetAttribute("innerText"))/100;
        }

        public string getCompanyName()
        {
            DataEntryHelper.WaitForElementByXpath(MyAccountOrigianlClient1Locator);
            return MyAccountOrigianlClient1.GetAttribute("innerText");
        }

        public string getAccountDetails()
        {
            DataEntryHelper.WaitForElementByXpath(MyAccountDetailsRow1Locator);
            return MyAccountDetailsRow1.GetAttribute("innerText");
        }

        public string getAccountStatus()
        {
            DataEntryHelper.WaitForElementByXpath(MyAccountStatus1Locator);
            return MyAccountStatus1.GetAttribute("innerText");
        }

        public double getTotalOutstandingBalance()
        {
            DataEntryHelper.WaitForElementByXpath(MyAccountOutstandingBalance1Locator);
            return double.Parse((MyAccountOutstandingBalance1.GetAttribute("innerText").Replace("£","")).Replace(",",""));
        }

        public String getLowellReferenceNumber()
        {
            return MyAccountLowellReference1.GetAttribute("innerText");
        }

        public String getPlanDetails()
        {
            DataEntryHelper.WaitForElementByXpath(MyAccountRegularPaymentAmt1Locator);
            String plandetails;
            plandetails = MyAccountRegularPaymentAmt1.GetAttribute("innerText").Replace("£","").Replace(",","");
            if (!plandetails.Equals("None"))
            {
                plandetails = plandetails + "," + PaymentFrequency.GetAttribute("innerText") + "," + PaymentMethod.GetAttribute("innerText");
            }
            return plandetails;
        }

        public bool isDiscountAvailable()
        {
            DataEntryHelper.WaitForElementByXpath(discountDetailsRowLocator);
            if (!discountDetailsRow.GetAttribute("innerText").Equals(""))
            {
                return true;
            }
            return false;
        }

        public double getDiscountedBalance()
        {            
            if (ObjectRepository.isDiscountAvailable)
            {
                string discMessage = discountMessage.GetAttribute("innerText");
                string discBalance = discMessage.Substring(discMessage.IndexOf("pay £") + 5, discMessage.LastIndexOf(".") - (discMessage.IndexOf("pay £") + 5));
                return double.Parse(discBalance);
            }
            return 0;
        }

        /*public string getDiscountPercentage()
        {
            if (ObjectRepository.isDiscountAvailable)
            {
                string discMessage = discountMessage.GetAttribute("innerText");
                string discPerc = discMessage.Substring(discMessage.IndexOf("(") + 1, discMessage.LastIndexOf(")") - (discMessage.IndexOf("(") + 1));
                return discPerc;
            }
            return null;
        }*/

        public double getDiscountAmount()
        {
            if (ObjectRepository.isDiscountAvailable)
            {
                string discMessage = discountMessage.GetAttribute("innerText");
                string discAmount = discMessage.Substring(discMessage.IndexOf("£") + 1, discMessage.LastIndexOf(" is") - (discMessage.IndexOf("£") + 1));
                return double.Parse(discAmount);
            }
            return 0;
        }

        /*public Boolean areThereLinkedAccounts()
        {
            if (MyAccountsNumberOfLinkedAccounts != null && MyAccountsNumberOfLinkedAccounts.Count() > 1)
            {
                return true;
            }else{
                return false;
            }
        }

        public int getTotalNumberOfLinkedAccounts()
        {
            if (MyAccountsNumberOfLinkedAccounts != null && MyAccountsNumberOfLinkedAccounts.Count() == 1)
            {
                return 0;
            }
            else if (MyAccountsNumberOfLinkedAccounts != null && MyAccountsNumberOfLinkedAccounts.Count() > 1)
            {
                return MyAccountsNumberOfLinkedAccounts.Count() - 1;
            }
            else
            {
                return 0;
            }            
        }*/

        //Code should be added to handle linked accounts
        /*public List<> getLinkedAccountPageObjects(){
            if (MyAccountsNumberOfLinkedAccounts != null && MyAccountsNumberOfLinkedAccounts.Count() > 1)
            {
                return MyAccountsNumberOfLinkedAccounts.Count() - 1;
            }
        }*/



        #endregion
    }
}
