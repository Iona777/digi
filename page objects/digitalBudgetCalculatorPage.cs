using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Digital.BaseClasses;
using Digital.ComponentHelper;
using Digital.Settings;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Digital.PageObject
{
    public class digitalBudgetCalculatorPage : digitalNavigationBar
    {
        private IWebDriver driver;

        #region fileData fields
        //Input data fields from file
        private string fileData_Salary;
        private string fileData_IncomeSupport;
        private string fileData_ChildBenefit;
        private string fileData_JobSeekers;
        private string fileData_Pension;
        private string fileData_TaxCredit;
        private string fileData_AnyOtherIncome;
        private string fileData_DependentAdults;
        private string fileData_DependentChild14to18;
        private string fileData_DependentChildUnder14;
        private string fileData_MortgageOrRent;
        private string fileData_GasBill;
        private string fileData_ElectricityBill;
        private string fileData_WaterBill;
        private string fileData_CouncilTaxBill;
        private string fileData_ChildCare;
        private string fileData_CreditCards;
        private string fileData_Insurance;
        private string fileData_MobilePhone;
        private string fileData_TVLicence;
        private string fileData_Food;
        private string fileData_HomePhone;
        private string fileData_Travel;
        private string fileData_Clothing;
        private string fileData_OtherExpenditure;

        #endregion

        #region element locators

        //NEED TO CHANGE THESE TO USE PROPER IDS 

        //BudgetCalculator_Income
        public const string HouseholdSalaryLocator = "//*[@id='budget_Salary']";
        public const string HouseholdSalaryFrequencyLocator = "//*[@name='budget.SalarySourceModel']";
        public const string IncomeSupportLocator = "//*[@id='budget_IncomeSupport']";
        public const string IncomeSupportFrequencyLocator = "//*[@name='budget.IncomeSupportSourceModel']";
        public const string ChildBenefitLocator = "//*[@id='budget_ChildBenefit']";
        public const string ChildBenefitFrequencyLocator = "//*[@name='budget.ChildBenefitSourceModel']";
        public const string JobSeekerAllowanceLocator = "//*[@id='budget_JobSeekersAllowance']";
        public const string JobSeekerAllowanceFrequencyLocator = "//*[@name='budget.JobSeekersAllowanceSourceModel']";
        public const string PensionLocator = "//*[@id='budget_Pension']";
        public const string PensionFrequencyLocator = "//*[@name='budget.PensionSourceModel']";
        public const string ChildOrWorkingTaxCreditLocator = "//*[@id='budget_ChildorWorking']";
        public const string ChildOrWorkingTaxCreditFrequencyLocator = "//*[@name='budget.ChildorWorkingSourceModel']";
        public const string OtherIncomeLocator = "//*[@id='budget_Other']";
        public const string OtherIncomeFrequencyLocator = "//*[@name='budget.OtherSourceModel']";
        public const string TotalIncomeLocator = "//*[@id='incomeDisplay']";
        public const string ContinueButton1Locator = "//*[@id='next']";

        //BugetCalculator_Dependants
        public const string DependentAdultsLocator = "//*[@id='dependants_Adults']";
        public const string Dependent14to18ChildrenLocator = "//*[@id='dependants_Child14to18']";
        public const string DependentUnder14ChildLocator = "//*[@id='dependants_ChildUnder14']";
        public const string TotalDependentsLocator = "//*[@id='dependenciesDisplay']";
        //OLD VERSION public const string ContinueButton2Locator = "//*[@id=\"layout-main\"]/div/form/button[2]";
        public const string ContinueButton2Locator = "//*[@value='Continue']";
        //OLD VERSION public const string BackButton2Locator = "//*[@id=\"layout-main\"]/div/form/button[1]";
        public const string BackButton2Locator = "//*[@value='Back']";

        //BudgetCalculator_Expenditure
        public const string MortgageOrRentLocator           = "//*[@id='bills_Rent']";
        public const string MortgageOrRentFrequencyLocator  = "//*[@name='bills.RentSourceModel']";
        public const string GasBillLocator                  = "//*[@id='bills_Gas']";
        public const string GasBillFrequencyLocator         = "//*[@name='bills.GasSourceModel']";
        public const string ElectricityBillLocator          = "//*[@id='bills_Electricity']";
        public const string ElectricityBillFrequencyLocator = "//*[@name='bills.ElectricitySourceModel']";
        public const string WaterBillLocator                = "//*[@id='bills_Water']";
        public const string WaterBillFrequencyLocator       = "//*[@name='bills.WaterSourceModel']";
        public const string CouncilTaxLocator               = "//*[@id='bills_CouncilTax']";
        public const string CouncilTaxFrequencyLocator      = "//*[@name='bills.CouncilTaxSourceModel']";
        public const string ChildCareBillLocator            = "//*[@id='bills_ChildCare']";
        public const string ChildCareBillFrequencyLocator   = "//*[@name='bills.ChildCareSourceModel']";
        public const string LoanOrCreditCardBillLocator     = "//*[@id='bills_Loan']";
        public const string LoanOrCreditCardBillFrequencyLocator = "//*[@name='bills.LoanSourceModel']";
        public const string InsuranceBillLocator            = "//*[@id='bills_Insurance']";
        public const string InsuranceBillFrequencyLocator   = "//*[@name='bills.InsuranceSourceModel']";
        public const string MobileBillLocator               = "//*[@id='bills_Mobile']";
        public const string MobileBillFrequencyLocator      = "//*[@name='bills.MobileSourceModel']";
        public const string TVLicenseBillLocator            = "//*[@id='bills_TVLicence']";
        public const string TVLicenseBillFrequencyLocator   = "//*[@name='bills.TVLicenceSourceModel']";
        public const string FoodBillLocator                 = "//*[@id='bills_Food']";
        public const string FoodBillFrequencyLocator        = "//*[@name='bills.FoodSourceModel']";
        public const string TelephoneBillLocator            = "//*[@id='bills_Telephone']";
        public const string TelephoneBillFrequencyLocator   = "//*[@name='bills.TelephoneSourceModel']";
        public const string TravelBillsLocator              = "//*[@id='bills_Travel']";
        public const string TravelBillsFrequencyLocator     = "//*[@name='bills.TravelSourceModel']";
        public const string ClothingBillsLocator            = "//*[@id='bills_Clothing']";
        public const string ClothingBillsFrequencyLocator   = "//*[@name='bills.ClothingSourceModel']";
        public const string OtherExpenditureLocator         = "//*[@id='bills_Expenditure']";
        public const string OtherExpenditureFrequencyLocator = "//*[@name='bills.ExpenditureSourceModel']";
        public const string TotalExpenditureLocator         = "//*[@id='expenditureDisplay']";
        //OLD VERSION public const string ContinueButton3Locator          = "//*[@id='layout-main\"]/div/form/button[2]";
        public const string ContinueButton3Locator          = "//*[@value='Continue']";
        //OLD VERSION public const string BackButton3Locator = "//*[@id=\"layout-main\"]/div/form/button[1]";
        public const string BackButton3Locator              = "//*[@value='Back']";

        //BudgetCalculator_Step4
        public const string MonthlyIncomeLocator            = "//*[@id='content']/div/div/div[1]/p[2]/span[2]";
        public const string PriorityHouseholdBillsLocator   = "//*[@id='content']/div/div/div[1]/p[3]/span[2]";
        //OLD VERSION public const string MonthlyDisposableIncomeLocator  = "//*[@id='content']/div/div/div[1]/p[8]/span[2]";
        public const string MonthlyDisposableIncomeLocator  = "//*[@id='content']/div/div/div[1]/p[4]/span[2]";
        
        //This is the Payment Options button if you access Budget Calculator anonymously.
        public const string MyAccountButtonLocator          = "//*[@id='next']";
        public const string BackButton4Locator              = "//*[@id='content']/div/form/button[1]";

        //BudgetCalculator_Step4 - payment predictor, may not be required?
        public const string PaymentPredictor_MonthlyLocator     = "//*[@value='Monthly'][@type='radio']";
        public const string PaymentPredictor_FourWeeklyLocator  = "//*[@value='FourWeekly'][@type='radio']";
        public const string PaymentPredictor_FortnightlyLocator = "//*[@value='Fortnightly'][@type='radio']";
        public const string PaymentPredictor_WeeklyLocator      = "//*[@value='Weekly'][@type='radio']";
        public const string PaymentPredictor_BalanceLocator     = "//*[@id='balance']";
        public const string PaymentPredictor_InstalmentsLocator = "//*[@id='time']";
        public const string PaymentPredictor_AmountLocator      = "//*[@id='amount']";
        public const string PaymentPredictor_InstalDisplayLocator = "//*[@id='timeDisplay']";
        public const string PaymentPredictor_AmountDisplayLocator = "//*[@id='amountDisplay']";

        //Error messages - these locators use CSSSelectors 
        public const string HouseholdSalaryErroMsgLocator    = "[data-valmsg-for='budget.Salary']";
        public const string IncomeSupportErroMsgLocator      = "[data-valmsg-for='budget.IncomeSupport']";
        public const string ChildBenefitErrorMsgLocator      = "[data-valmsg-for='budget.ChildBenefit']";
        public const string JobSeekerAllowanceErrorMsgLocator= "[data-valmsg-for='budget.JobSeekersAllowance']";
        public const string PensionErrorMsgLocator           = "[data-valmsg-for='budget.Pension']";
        public const string ChildOrWorkingTaxCreditErrorMsgLocator = "[data-valmsg-for='budget.ChildorWorking']";
        public const string OtherIncomeErrorMsgLocator      = "[data-valmsg-for='budget.Other']";


        #endregion

        #region WebElement
        [FindsBy(How = How.XPath, Using = HouseholdSalaryLocator)]
        private IWebElement HouseholdSalary;

        [FindsBy(How = How.XPath, Using = HouseholdSalaryFrequencyLocator)]
        private IWebElement HouseholdSalaryFrequency;

        [FindsBy(How = How.XPath, Using = IncomeSupportLocator)]
        private IWebElement IncomeSupport;

        [FindsBy(How = How.XPath, Using = IncomeSupportFrequencyLocator)]
        private IWebElement IncomeSupportFrequency;

        [FindsBy(How = How.XPath, Using = ChildBenefitLocator)]
        private IWebElement ChildBenefit;

        [FindsBy(How = How.XPath, Using = ChildBenefitFrequencyLocator)]
        private IWebElement ChildBenefitFrequency;

        [FindsBy(How = How.XPath, Using = JobSeekerAllowanceLocator)]
        private IWebElement JobSeekerAllowance;

        [FindsBy(How = How.XPath, Using = JobSeekerAllowanceFrequencyLocator)]
        private IWebElement JobSeekerAllowanceFrequency;

        [FindsBy(How = How.XPath, Using = PensionLocator)]
        private IWebElement Pension;

        [FindsBy(How = How.XPath, Using = PensionFrequencyLocator)]
        private IWebElement PensionFrequency;

        [FindsBy(How = How.XPath, Using = ChildOrWorkingTaxCreditLocator)]
        private IWebElement ChildOrWorkingTaxCredit;

        [FindsBy(How = How.XPath, Using = ChildOrWorkingTaxCreditFrequencyLocator)]
        private IWebElement ChildOrWorkingTaxCreditFrequency;

        [FindsBy(How = How.XPath, Using = OtherIncomeLocator)]
        private IWebElement OtherIncome;

        [FindsBy(How = How.XPath, Using = OtherIncomeFrequencyLocator)]
        private IWebElement OtherIncomeFrequency;

        [FindsBy(How = How.XPath, Using = TotalIncomeLocator)]
        private IWebElement TotalIncome;        

        [FindsBy(How = How.XPath, Using = ContinueButton1Locator)]
        private IWebElement ContinueButton1;

        [FindsBy(How = How.XPath, Using = DependentAdultsLocator)]
        private IWebElement DependentAdults;

        [FindsBy(How = How.XPath, Using = Dependent14to18ChildrenLocator)]
        private IWebElement Dependent14to18Children;

        [FindsBy(How = How.XPath, Using = DependentUnder14ChildLocator)]
        private IWebElement DependentUnder14Child;

        [FindsBy(How = How.XPath, Using = TotalDependentsLocator)]
        private IWebElement TotalDependents;

        [FindsBy(How = How.XPath, Using = ContinueButton2Locator)]
        private IWebElement ContinueButton2;

        [FindsBy(How = How.XPath, Using = BackButton2Locator)]
        private IWebElement BackButton2;

        [FindsBy(How = How.XPath, Using = MortgageOrRentLocator)]
        private IWebElement MortgageOrRent;

        [FindsBy(How = How.XPath, Using = MortgageOrRentFrequencyLocator)]
        private IWebElement MortgageOrRentFrequency;

        [FindsBy(How = How.XPath, Using = GasBillLocator)]
        private IWebElement GasBill;

        [FindsBy(How = How.XPath, Using = GasBillFrequencyLocator)]
        private IWebElement GasBillFrequency;

        [FindsBy(How = How.XPath, Using = ElectricityBillLocator)]
        private IWebElement ElectricityBill;

        [FindsBy(How = How.XPath, Using = ElectricityBillFrequencyLocator)]
        private IWebElement ElectricityBillFrequency;

        [FindsBy(How = How.XPath, Using = WaterBillLocator)]
        private IWebElement WaterBill;

        [FindsBy(How = How.XPath, Using = WaterBillFrequencyLocator)]
        private IWebElement WaterBillFrequency;

        [FindsBy(How = How.XPath, Using = CouncilTaxLocator)]
        private IWebElement CouncilTax;

        [FindsBy(How = How.XPath, Using = CouncilTaxFrequencyLocator)]
        private IWebElement CouncilTaxFrequency;

        [FindsBy(How = How.XPath, Using = ChildCareBillLocator)]
        private IWebElement ChildCareBill;

        [FindsBy(How = How.XPath, Using = ChildCareBillFrequencyLocator)]
        private IWebElement ChildCareBillFrequency;

        [FindsBy(How = How.XPath, Using = LoanOrCreditCardBillLocator)]
        private IWebElement LoanOrCreditCardBill;

        [FindsBy(How = How.XPath, Using = LoanOrCreditCardBillFrequencyLocator)]
        private IWebElement LoanOrCreditCardBillFrequency;

        [FindsBy(How = How.XPath, Using = InsuranceBillLocator)]
        private IWebElement InsuranceBill;

        [FindsBy(How = How.XPath, Using = InsuranceBillFrequencyLocator)]
        private IWebElement InsuranceBillFrequency;

        [FindsBy(How = How.XPath, Using = MobileBillLocator)]
        private IWebElement MobileBill;

        [FindsBy(How = How.XPath, Using = MobileBillFrequencyLocator)]
        private IWebElement MobileBillFrequency;

        [FindsBy(How = How.XPath, Using = TVLicenseBillLocator)]
        private IWebElement TVLicenseBill;

        [FindsBy(How = How.XPath, Using = TVLicenseBillFrequencyLocator)]
        private IWebElement TVLicenseBillFrequency;

        [FindsBy(How = How.XPath, Using = FoodBillLocator)]
        private IWebElement FoodBill;

        [FindsBy(How = How.XPath, Using = FoodBillFrequencyLocator)]
        private IWebElement FoodBillFrequency;

        [FindsBy(How = How.XPath, Using = TelephoneBillLocator)]
        private IWebElement HomePhoneBill;

        [FindsBy(How = How.XPath, Using = TelephoneBillFrequencyLocator)]
        private IWebElement HomePhoneBillFrequency;

        [FindsBy(How = How.XPath, Using = TravelBillsLocator)]
        private IWebElement TravelBills;

        [FindsBy(How = How.XPath, Using = TravelBillsFrequencyLocator)]
        private IWebElement TravelBillsFrequency;

        [FindsBy(How = How.XPath, Using = ClothingBillsLocator)]
        private IWebElement ClothingBills;

        [FindsBy(How = How.XPath, Using = ClothingBillsFrequencyLocator)]
        private IWebElement ClothingBillsFrequency;

        [FindsBy(How = How.XPath, Using = OtherExpenditureLocator)]
        private IWebElement OtherExpenditure;

        [FindsBy(How = How.XPath, Using = OtherExpenditureFrequencyLocator)]
        private IWebElement OtherExpenditureFrequency;

        [FindsBy(How = How.XPath, Using = TotalExpenditureLocator)]
        private IWebElement TotalExpenditure;

        [FindsBy(How = How.XPath, Using = ContinueButton3Locator)]
        private IWebElement ContinueButton3;

        [FindsBy(How = How.XPath, Using = BackButton3Locator)]
        private IWebElement BackButton3;

        [FindsBy(How = How.XPath, Using = MonthlyIncomeLocator)]
        private IWebElement MonthlyIncome;

        [FindsBy(How = How.XPath, Using = PriorityHouseholdBillsLocator)]
        private IWebElement PriorityHouseholdBills;

        [FindsBy(How = How.XPath, Using = MonthlyDisposableIncomeLocator)]
        private IWebElement MonthlyDisposableIncome;

        [FindsBy(How = How.XPath, Using = MyAccountButtonLocator)]
        private IWebElement MyAccountButton;

        [FindsBy(How = How.XPath, Using = BackButton4Locator)]
        private IWebElement BackButton4;


        //Payment Predictor
        [FindsBy(How = How.XPath, Using = PaymentPredictor_MonthlyLocator)]
        private IWebElement PaymentPredictor_Monthly;

        [FindsBy(How = How.XPath, Using = PaymentPredictor_FourWeeklyLocator)]
        private IWebElement PaymentPredictor_FourWeekly;

        [FindsBy(How = How.XPath, Using = PaymentPredictor_FortnightlyLocator)]
        private IWebElement PaymentPredictor_Fortnightly;

        [FindsBy(How = How.XPath, Using = PaymentPredictor_WeeklyLocator)]
        private IWebElement PaymentPredictor_Weekly;

        [FindsBy(How = How.XPath, Using = PaymentPredictor_BalanceLocator)]
        private IWebElement PaymentPredictor_Balance;

        [FindsBy(How = How.XPath, Using = PaymentPredictor_InstalmentsLocator)]
        private IWebElement PaymentPredictor_InstalmentsSlider;

        [FindsBy(How = How.XPath, Using = PaymentPredictor_AmountLocator)]
        private IWebElement PaymentPredictor_AmountSlider;

        [FindsBy(How = How.XPath, Using = PaymentPredictor_InstalDisplayLocator)]
        private IWebElement PaymentPredictor_InstalmentsDisplay;

        [FindsBy(How = How.XPath, Using = PaymentPredictor_AmountDisplayLocator)]
        private IWebElement PaymentPredictor_AmountDisplay;
        
        

        //Error Messages
        [FindsBy(How = How.CssSelector, Using = HouseholdSalaryErroMsgLocator)]
        private IWebElement HouseholdSalaryErrorMsg;

        [FindsBy(How = How.CssSelector, Using = IncomeSupportErroMsgLocator)]
        private IWebElement IncomeSupportErrorMsg;

        [FindsBy(How = How.CssSelector, Using = ChildBenefitErrorMsgLocator)]
        private IWebElement ChildBenefitErrorMsg;

        [FindsBy(How = How.CssSelector, Using = JobSeekerAllowanceErrorMsgLocator)]
        private IWebElement JobSeekersAllowanceErrorMsg;

        [FindsBy(How = How.CssSelector, Using = PensionErrorMsgLocator)]
        private IWebElement PensionErrorMsg;

        [FindsBy(How = How.CssSelector, Using = ChildOrWorkingTaxCreditErrorMsgLocator)]
        private IWebElement ChildOrWorkingTaxCreditErrorMsg;

        [FindsBy(How = How.CssSelector, Using = OtherIncomeErrorMsgLocator)]
        private IWebElement OtherIncomeErrorMsg;



        #endregion

        //I tried to change this to use PAGEFACTORY.INITELEMENTS(), but base page uses PageFactory, so no need?
        public digitalBudgetCalculatorPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions

        public bool AllIncomeErrorMsgsDisplayed()
        //If any of the error messages are missing, the WaitForElement will timeout and
        //return an exception. This will then cause this method to return false
        {
            try
            {
                DataEntryHelper.WaitForElementByCSS(HouseholdSalaryErroMsgLocator);
                DataEntryHelper.WaitForElementByCSS(IncomeSupportErroMsgLocator);
                DataEntryHelper.WaitForElementByCSS(ChildBenefitErrorMsgLocator);
                DataEntryHelper.WaitForElementByCSS(JobSeekerAllowanceErrorMsgLocator);
                DataEntryHelper.WaitForElementByCSS(PensionErrorMsgLocator);
                DataEntryHelper.WaitForElementByCSS(ChildOrWorkingTaxCreditErrorMsgLocator);
                DataEntryHelper.WaitForElementByCSS(OtherIncomeErrorMsgLocator);
            }
            catch (Exception e)
            {

                return false;
            }
            return true;
        }

        public DataSet readFileIntoDataSet(string fileToUse)
        {
            DataSet inputData;

            //Reads data from file into a dataset that is declared above
            inputData = ReadExcelFile.xlsxReadFile(fileToUse, true);
            return inputData;
        }


        public void getInputDataFromFile(string fileToUse)
        { 
            //This is for use when you only want to use one row of input data.

            //Reads data from input file into a dataset 
            DataSet inputData = readFileIntoDataSet(fileToUse);

            //Read specic cells of that dataset into variables 
            fileData_Salary             = ReadExcelFile.readSpecificCell(inputData,0,"Household Salary");
            fileData_IncomeSupport      = ReadExcelFile.readSpecificCell(inputData,0,"Income Support");
            fileData_ChildBenefit       = ReadExcelFile.readSpecificCell(inputData,0,"Child Benefit");
            fileData_JobSeekers         = ReadExcelFile.readSpecificCell(inputData,0,"Job Seekers Allowance");
            fileData_Pension            = ReadExcelFile.readSpecificCell(inputData,0,"Pension");
            fileData_TaxCredit          = ReadExcelFile.readSpecificCell(inputData,0,"Tax Credit");
            fileData_AnyOtherIncome     = ReadExcelFile.readSpecificCell(inputData,0,"Any other income");
            fileData_DependentAdults    = ReadExcelFile.readSpecificCell(inputData,0,"Dependent Adults");
            fileData_DependentChild14to18 = ReadExcelFile.readSpecificCell(inputData,0,"Dependent Child 14 to 18");
            fileData_DependentChildUnder14 = ReadExcelFile.readSpecificCell(inputData,0,"Dependent Child under 14");
            fileData_MortgageOrRent     = ReadExcelFile.readSpecificCell(inputData,0,"Mortgage or Rent");
            fileData_GasBill            = ReadExcelFile.readSpecificCell(inputData,0,"Gas Bill");
            fileData_ElectricityBill    = ReadExcelFile.readSpecificCell(inputData,0,"Electricity Bill");
            fileData_WaterBill          = ReadExcelFile.readSpecificCell(inputData,0,"Water Bill");
            fileData_CouncilTaxBill     = ReadExcelFile.readSpecificCell(inputData,0,"Council Tax Bill");
            fileData_ChildCare          = ReadExcelFile.readSpecificCell(inputData,0, "Child Care");
            fileData_CreditCards        = ReadExcelFile.readSpecificCell(inputData,0,"Credit Cards");
            fileData_Insurance          = ReadExcelFile.readSpecificCell(inputData,0,"Insurance");
            fileData_MobilePhone        = ReadExcelFile.readSpecificCell(inputData,0,"Mobile Phone");
            fileData_TVLicence          = ReadExcelFile.readSpecificCell(inputData,0,"TV Licence");
            fileData_Food               = ReadExcelFile.readSpecificCell(inputData,0,"Food");
            fileData_HomePhone          = ReadExcelFile.readSpecificCell(inputData,0,"Home Phone");
            fileData_Travel             = ReadExcelFile.readSpecificCell(inputData,0,"Travel");
            fileData_Clothing           = ReadExcelFile.readSpecificCell(inputData,0,"Clothing");
            fileData_OtherExpenditure   = ReadExcelFile.readSpecificCell(inputData,0,"Other Expenditure");
        }

        
        public void getInputDataFromFile(string fileToUse, int rowToRead)
        {
            //This is for use when you want to use multiple rows of input data.
            //The calling method will call this within a loop and pass in a different rowToRead
            //on each iteration. The the full input file will be read on each interation.


            //Reads data from input file into a dataset
            DataSet inputData = readFileIntoDataSet(fileToUse);

            //Read specic cells of that dataset into variables 
            fileData_Salary = ReadExcelFile.readSpecificCell        (inputData, rowToRead, "Household Salary");
            fileData_IncomeSupport = ReadExcelFile.readSpecificCell (inputData, rowToRead, "Income Support");
            fileData_ChildBenefit = ReadExcelFile.readSpecificCell  (inputData, rowToRead, "Child Benefit");
            fileData_JobSeekers = ReadExcelFile.readSpecificCell    (inputData, rowToRead, "Job Seekers Allowance");
            fileData_Pension = ReadExcelFile.readSpecificCell       (inputData, rowToRead, "Pension");
            fileData_TaxCredit = ReadExcelFile.readSpecificCell     (inputData, rowToRead, "Tax Credit");
            fileData_AnyOtherIncome = ReadExcelFile.readSpecificCell(inputData, rowToRead, "Any other income");
            fileData_DependentAdults = ReadExcelFile.readSpecificCell(inputData, rowToRead, "Dependent Adults");
            fileData_DependentChild14to18 = ReadExcelFile.readSpecificCell(inputData, rowToRead, "Dependent Child 14 to 18");
            fileData_DependentChildUnder14 = ReadExcelFile.readSpecificCell(inputData, rowToRead, "Dependent Child under 14");
            fileData_MortgageOrRent = ReadExcelFile.readSpecificCell(inputData, rowToRead, "Mortgage or Rent");
            fileData_GasBill = ReadExcelFile.readSpecificCell       (inputData, rowToRead, "Gas Bill");
            fileData_ElectricityBill = ReadExcelFile.readSpecificCell(inputData, rowToRead, "Electricity Bill");
            fileData_WaterBill = ReadExcelFile.readSpecificCell     (inputData, rowToRead, "Water Bill");
            fileData_CouncilTaxBill = ReadExcelFile.readSpecificCell(inputData, rowToRead, "Council Tax Bill");
            fileData_ChildCare = ReadExcelFile.readSpecificCell     (inputData, rowToRead, "Child Care");
            fileData_CreditCards = ReadExcelFile.readSpecificCell   (inputData, rowToRead, "Credit Cards");
            fileData_Insurance = ReadExcelFile.readSpecificCell     (inputData, rowToRead, "Insurance");
            fileData_MobilePhone = ReadExcelFile.readSpecificCell   (inputData, rowToRead, "Mobile Phone");
            fileData_TVLicence = ReadExcelFile.readSpecificCell     (inputData, rowToRead, "TV Licence");
            fileData_Food = ReadExcelFile.readSpecificCell          (inputData, rowToRead, "Food");
            fileData_HomePhone = ReadExcelFile.readSpecificCell     (inputData, rowToRead, "Home Phone");
            fileData_Travel = ReadExcelFile.readSpecificCell        (inputData, rowToRead, "Travel");
            fileData_Clothing = ReadExcelFile.readSpecificCell      (inputData, rowToRead, "Clothing");
            fileData_OtherExpenditure = ReadExcelFile.readSpecificCell(inputData, rowToRead, "Other Expenditure");
        }

        //These methods are used to send the data to the webpage.

        //Populate Salary
        public void enterSalary(string input)
        {
            DataEntryHelper.EnterText(input, HouseholdSalary);
        }

        public void selectSalaryFreq(string frequency)
        {
            DataEntryHelper.SelectFreqByValue(frequency, HouseholdSalaryFrequency);
        }

        //Populate Income Support
        public void enterIncomeSupport(string input)
        {
            DataEntryHelper.EnterText(input, IncomeSupport);
        }

        public void selectIncomeSupportFreq(string frequency)
        {
            DataEntryHelper.SelectFreqByValue(frequency, IncomeSupportFrequency);
        }

        //Populate Child Benefit
        public void enterChildBenefit(string input)
        {
            DataEntryHelper.EnterText(input,ChildBenefit);
        }

        public void selectChildBenefitFreq(string frequency)
        {
            DataEntryHelper.SelectFreqByValue(frequency,ChildBenefitFrequency);
        }

        //Populate Job Seeker's Allowance
        public void enterJobSeekers(string input)
        {
            DataEntryHelper.EnterText(input, JobSeekerAllowance);
        }

        public void selectJobSeekersFreq(string frequency)
        {
            DataEntryHelper.SelectFreqByValue(frequency,JobSeekerAllowanceFrequency);
        }

        //Populate Pension
        public void enterPension(string input)
        {
            DataEntryHelper.EnterText(input, Pension);
        }

        public void selectPensionFreq(string frequency)
        {
            DataEntryHelper.SelectFreqByValue(frequency, PensionFrequency);
        }

        //Populate Child or working Tax Credit
        public void  enterTaxCredit(string input)
        {
            DataEntryHelper.EnterText(input,ChildOrWorkingTaxCredit);
        }

        public void selectTaxCreditFreq(string frequency)
        {
            DataEntryHelper.SelectFreqByValue(frequency,ChildOrWorkingTaxCreditFrequency);
        }


        //Populate Any other income  
        public void enterAnyOtherIncome(string input)
        {
            DataEntryHelper.EnterText(input, OtherIncome);
        }

        public void selectAnyOtherIncomeFreq(string frequency)
        {
            DataEntryHelper.SelectFreqByValue(frequency, OtherIncomeFrequency);
        }

        //Populate Dependents
        public void enterDependentAdults(string input)
        {
            DataEntryHelper.EnterText(input,DependentAdults);

        }

        public void enterDependentChild14to18(string input)
        {
            DataEntryHelper.EnterText(input,Dependent14to18Children);
        }

        public void enterDependendChildUnder14(string input)
        {
            DataEntryHelper.EnterText(input,DependentUnder14Child);
        }
 
        //Populate Mortgage or Rent
        public void enterMortgageOrRent(string input)
        {
            DataEntryHelper.EnterText(input, MortgageOrRent);
        }

        public void selectMortgageOrRentFreq(string frequency)
        {
            DataEntryHelper.SelectFreqByValue(frequency,MortgageOrRentFrequency);
        }

        //Populate Gas Bill
        public void enterGasBill(string input)
        {
            DataEntryHelper.EnterText(input, GasBill);
        }

        public void selectGasBillFreq(string frequency)
        {
            DataEntryHelper.SelectFreqByValue(frequency, GasBillFrequency);
        }

        //Populate Electricity Bill
        public void enterElectricityBill(string input)
        {
            DataEntryHelper.EnterText(input,ElectricityBill);
        }

        public void selectElectricityBillFreq(string frequency)
        {
            DataEntryHelper.SelectFreqByValue(frequency, ElectricityBillFrequency);
        }

        //Populate Water Bill
        public void enterWaterBill(string input)
        {
            DataEntryHelper.EnterText(input, WaterBill);
        }

        public void selectWaterBillFreq(string frequency)
        {
            DataEntryHelper.SelectFreqByValue(frequency, WaterBillFrequency);
        }

        //Populate Council Tax Bill
        public void enterCouncilTaxBill(string input)
        {
            DataEntryHelper.EnterText(input, CouncilTax);
        }

        public void selectCouncilTaxBillFreq(string frequency)
        {
            DataEntryHelper.SelectFreqByValue(frequency, CouncilTaxFrequency);
        }

        //Populate Child Care
        public void enterChildCare(string input)
        {
            DataEntryHelper.EnterText(input, ChildCareBill);
        }

        public void selectChildCareFreq(string frequency)
        {
            DataEntryHelper.SelectFreqByValue(frequency, ChildCareBillFrequency);
        }

        //Populate Credit Cards
        public void enterCreditCards(string input)
        {
            DataEntryHelper.EnterText(input, LoanOrCreditCardBill);
        }

        public void selectCreditCardFreq(string frequency)
        {
            DataEntryHelper.SelectFreqByValue(frequency,LoanOrCreditCardBillFrequency);
        }

        //Populate Insurance
        public void enterInsurance(string input)
        {
            DataEntryHelper.EnterText(input, InsuranceBill);
        }

        public void selectInsuranceFreq(string frequency)
        {
            DataEntryHelper.SelectFreqByValue(frequency, InsuranceBillFrequency);
        }

        //Populate Mobile Phone
        public void enterMobilePhone(string input)
        {
            DataEntryHelper.EnterText(input, MobileBill);
        }

        public void selectMobileFreq(string frequency)
        {
            DataEntryHelper.SelectFreqByValue(frequency,MobileBillFrequency);
        }

        //Populate TV Licence 
        public void enterTVLicence(string input)
        {
            DataEntryHelper.EnterText(input,TVLicenseBill);
        }

        public void selectTVLicenceFreq(string frequency)
        {
            DataEntryHelper.SelectFreqByValue(frequency, TVLicenseBillFrequency);
        }

        //Populate Food
        public void enterFood(string input)
        {
            DataEntryHelper.EnterText(input, FoodBill);
        }

        public void selectFoodFreq(string frequency)
        {
            DataEntryHelper.SelectFreqByValue(frequency, FoodBillFrequency);
        }

        //Populate Home Phone
        public void enterHomePhone(string input)
        {
            DataEntryHelper.EnterText(input,HomePhoneBill);
        }

        public void selectHomePhoneFreq(string frequency)
        {
            DataEntryHelper.SelectFreqByValue(frequency, HomePhoneBillFrequency);
        }

        //Populate Travel
        public void enterTravel(string input)
        {
            DataEntryHelper.EnterText(input, TravelBills);
        }

        public void selectTravelFreq(string frequency)
        {
            DataEntryHelper.SelectFreqByValue(frequency, TravelBillsFrequency);
        }

        //Populate Clothing
        public void enterClothing(string input)
        {
            DataEntryHelper.EnterText(input, ClothingBills);
        }

        public void selectClothingFreq(string frequency)
        {
            DataEntryHelper.SelectFreqByValue(frequency, ClothingBillsFrequency);
        }

        //Populate Other Expenditure
        public void enterOtherExpenditure(string input)
        {
            DataEntryHelper.EnterText(input, OtherExpenditure);
        }

        public void selectOtherExpenditureFreq(string frequency)
        {
            DataEntryHelper.SelectFreqByValue(frequency, OtherExpenditureFrequency);
        }

        //Click the various buttons, this means they are accessible from outside of the page
        //These methods should be renamed once this is split into multiple page objects
        public void clickContinueButton1()
        {
            DataEntryHelper.ButtonClick(ContinueButton1);
        }

        public void clickContinueButton2()
        {
            DataEntryHelper.ButtonClick(ContinueButton2);
        }

        public void clickContinueButton3()
        {
            DataEntryHelper.ButtonClick(ContinueButton3);
        }

        public void clickBackButton2()
        {
            DataEntryHelper.ButtonClick(BackButton2);
        }

        public void clickBackButton3()
        {
            DataEntryHelper.ButtonClick(BackButton3);
        }

        public void clickBackButton4()
        {
            DataEntryHelper.ButtonClick(BackButton4);
        }


        public void PopulateBudgetCalculatorIncomePage(string inputFileName, string frequency)
        {
            //Use this version of the method if you are just reading one line of input data
            ObjectRepository.writer.WriteToLog("This Budget Calculator is being completed with "+ frequency+ " frequency");

            getInputDataFromFile(inputFileName);

            enterSalary(fileData_Salary.ToString());
            selectSalaryFreq(frequency);
            
            enterIncomeSupport(fileData_IncomeSupport.ToString());
            selectIncomeSupportFreq(frequency);

            enterChildBenefit(fileData_ChildBenefit.ToString());
            selectChildBenefitFreq(frequency);

            enterJobSeekers(fileData_JobSeekers.ToString());
            selectJobSeekersFreq(frequency);

            enterPension(fileData_Pension.ToString());
            selectPensionFreq(frequency);

            enterTaxCredit(fileData_TaxCredit.ToString());
            selectTaxCreditFreq(frequency);

            enterAnyOtherIncome(fileData_AnyOtherIncome.ToString());
            selectAnyOtherIncomeFreq(frequency);
        }


        public void populateIncomeFieldsFromDataSet(DataSet inputData, int rowToRead, string frequency)
        {
            //This can be used with tests where the input dataset is populated with multiple rows
            //and this method is called once for each row

            //Read specic cells of that dataset into variables 
            fileData_Salary = ReadExcelFile.readSpecificCell(inputData, rowToRead, "Household Salary");
            fileData_IncomeSupport = ReadExcelFile.readSpecificCell(inputData, rowToRead, "Income Support");
            fileData_ChildBenefit = ReadExcelFile.readSpecificCell(inputData, rowToRead, "Child Benefit");
            fileData_JobSeekers = ReadExcelFile.readSpecificCell(inputData, rowToRead, "Job Seekers Allowance");
            fileData_Pension = ReadExcelFile.readSpecificCell(inputData, rowToRead, "Pension");
            fileData_TaxCredit = ReadExcelFile.readSpecificCell(inputData, rowToRead, "Tax Credit");
            fileData_AnyOtherIncome = ReadExcelFile.readSpecificCell(inputData, rowToRead, "Any other income");

            enterSalary(fileData_Salary.ToString());
            selectSalaryFreq(frequency);

            enterIncomeSupport(fileData_IncomeSupport.ToString());
            selectIncomeSupportFreq(frequency);

            enterChildBenefit(fileData_ChildBenefit.ToString());
            selectChildBenefitFreq(frequency);

            enterJobSeekers(fileData_JobSeekers.ToString());
            selectJobSeekersFreq(frequency);

            enterPension(fileData_Pension.ToString());
            selectPensionFreq(frequency);

            enterTaxCredit(fileData_TaxCredit.ToString());
            selectTaxCreditFreq(frequency);

            enterAnyOtherIncome(fileData_AnyOtherIncome.ToString());
            selectAnyOtherIncomeFreq(frequency);
        }

        public string CalculateTotalIncome(string frequency)
        {
            decimal calculatedTotalIncome=0;
            switch (frequency)
            {
                case "Monthly":
                    {
                        calculatedTotalIncome =
                        decimal.Parse(HouseholdSalary.GetAttribute("value"))        +
                        decimal.Parse(IncomeSupport.GetAttribute("value"))          +
                        decimal.Parse(ChildBenefit.GetAttribute("value"))           +
                        decimal.Parse(JobSeekerAllowance.GetAttribute("value"))     +
                        decimal.Parse(Pension.GetAttribute("value"))                +
                        decimal.Parse(ChildOrWorkingTaxCredit.GetAttribute("value"))+
                        decimal.Parse(OtherIncome.GetAttribute("value"));
                        break;
                    }
                case "FourWeekly":
                    {
                        calculatedTotalIncome =
                        decimal.Parse(HouseholdSalary.GetAttribute("value")) +
                        decimal.Parse(IncomeSupport.GetAttribute("value")) +
                        decimal.Parse(ChildBenefit.GetAttribute("value")) +
                        decimal.Parse(JobSeekerAllowance.GetAttribute("value")) +
                        decimal.Parse(Pension.GetAttribute("value")) +
                        decimal.Parse(ChildOrWorkingTaxCredit.GetAttribute("value")) +
                        decimal.Parse(OtherIncome.GetAttribute("value"));
                        calculatedTotalIncome = calculatedTotalIncome * 1.08m;
                        break;
                    }
                case "Fortnightly":
                    {
                        calculatedTotalIncome =
                        decimal.Parse(HouseholdSalary.GetAttribute("value")) +
                        decimal.Parse(IncomeSupport.GetAttribute("value")) +
                        decimal.Parse(ChildBenefit.GetAttribute("value")) +
                        decimal.Parse(JobSeekerAllowance.GetAttribute("value")) +
                        decimal.Parse(Pension.GetAttribute("value")) +
                        decimal.Parse(ChildOrWorkingTaxCredit.GetAttribute("value")) +
                        decimal.Parse(OtherIncome.GetAttribute("value"));
                        calculatedTotalIncome = calculatedTotalIncome * 2.17m;
                        break;
                    }
                case "Weekly":
                    {
                        calculatedTotalIncome =
                        decimal.Parse(HouseholdSalary.GetAttribute("value")) +
                        decimal.Parse(IncomeSupport.GetAttribute("value")) +
                        decimal.Parse(ChildBenefit.GetAttribute("value")) +
                        decimal.Parse(JobSeekerAllowance.GetAttribute("value")) +
                        decimal.Parse(Pension.GetAttribute("value")) +
                        decimal.Parse(ChildOrWorkingTaxCredit.GetAttribute("value")) +
                        decimal.Parse(OtherIncome.GetAttribute("value"));
                        calculatedTotalIncome = calculatedTotalIncome * 4.33m;
                        break;
                    }
                default:
                    {
                        ObjectRepository.writer.WriteToLog("Invalid frequency value- " + frequency);
                        break;
                    }
            }
            return calculatedTotalIncome.ToString("#,#00.00");
        }


        public string CalculateTotalExpenditure(string frequency)
        {
            //string totalExpenditure;
            decimal calculatedTotalExpenditure = 0;
            switch (frequency)
            {
                case "Monthly":
                    {

                        calculatedTotalExpenditure =
                            decimal.Parse(MortgageOrRent.GetAttribute("value")) +
                            decimal.Parse(GasBill.GetAttribute("value")) +
                            decimal.Parse(ElectricityBill.GetAttribute("value")) +
                            decimal.Parse(WaterBill.GetAttribute("value")) +
                            decimal.Parse(CouncilTax.GetAttribute("value")) +
                            decimal.Parse(ChildCareBill.GetAttribute("value")) +
                            decimal.Parse(LoanOrCreditCardBill.GetAttribute("value")) +
                            decimal.Parse(InsuranceBill.GetAttribute("value")) +
                            decimal.Parse(MobileBill.GetAttribute("value")) +
                            decimal.Parse(TVLicenseBill.GetAttribute("value")) +
                            decimal.Parse(FoodBill.GetAttribute("value")) +
                            decimal.Parse(HomePhoneBill.GetAttribute("value")) +
                            decimal.Parse(TravelBills.GetAttribute("value")) +
                            decimal.Parse(ClothingBills.GetAttribute("value")) +
                            decimal.Parse(OtherExpenditure.GetAttribute("value"));
                        break;
                    }
                case "FourWeekly":
                    {
                        calculatedTotalExpenditure =
                            decimal.Parse(MortgageOrRent.GetAttribute("value")) +
                            decimal.Parse(GasBill.GetAttribute("value")) +
                            decimal.Parse(ElectricityBill.GetAttribute("value")) +
                            decimal.Parse(WaterBill.GetAttribute("value")) +
                            decimal.Parse(CouncilTax.GetAttribute("value")) +
                            decimal.Parse(ChildCareBill.GetAttribute("value")) +
                            decimal.Parse(LoanOrCreditCardBill.GetAttribute("value")) +
                            decimal.Parse(InsuranceBill.GetAttribute("value")) +
                            decimal.Parse(MobileBill.GetAttribute("value")) +
                            decimal.Parse(TVLicenseBill.GetAttribute("value")) +
                            decimal.Parse(FoodBill.GetAttribute("value")) +
                            decimal.Parse(HomePhoneBill.GetAttribute("value")) +
                            decimal.Parse(TravelBills.GetAttribute("value")) +
                            decimal.Parse(ClothingBills.GetAttribute("value")) +
                            decimal.Parse(OtherExpenditure.GetAttribute("value"));
                        calculatedTotalExpenditure = calculatedTotalExpenditure * 1.08m;
                        break;
                    }
                case "Fortnightly":
                    {
                        calculatedTotalExpenditure =
                            decimal.Parse(MortgageOrRent.GetAttribute("value")) +
                            decimal.Parse(GasBill.GetAttribute("value")) +
                            decimal.Parse(ElectricityBill.GetAttribute("value")) +
                            decimal.Parse(WaterBill.GetAttribute("value")) +
                            decimal.Parse(CouncilTax.GetAttribute("value")) +
                            decimal.Parse(ChildCareBill.GetAttribute("value")) +
                            decimal.Parse(LoanOrCreditCardBill.GetAttribute("value")) +
                            decimal.Parse(InsuranceBill.GetAttribute("value")) +
                            decimal.Parse(MobileBill.GetAttribute("value")) +
                            decimal.Parse(TVLicenseBill.GetAttribute("value")) +
                            decimal.Parse(FoodBill.GetAttribute("value")) +
                            decimal.Parse(HomePhoneBill.GetAttribute("value")) +
                            decimal.Parse(TravelBills.GetAttribute("value")) +
                            decimal.Parse(ClothingBills.GetAttribute("value")) +
                            decimal.Parse(OtherExpenditure.GetAttribute("value"));
                        calculatedTotalExpenditure = calculatedTotalExpenditure * 2.17m;
                        break;
                    }
                case "Weekly":
                    {
                        calculatedTotalExpenditure =
                            decimal.Parse(MortgageOrRent.GetAttribute("value")) +
                            decimal.Parse(GasBill.GetAttribute("value")) +
                            decimal.Parse(ElectricityBill.GetAttribute("value")) +
                            decimal.Parse(WaterBill.GetAttribute("value")) +
                            decimal.Parse(CouncilTax.GetAttribute("value")) +
                            decimal.Parse(ChildCareBill.GetAttribute("value")) +
                            decimal.Parse(LoanOrCreditCardBill.GetAttribute("value")) +
                            decimal.Parse(InsuranceBill.GetAttribute("value")) +
                            decimal.Parse(MobileBill.GetAttribute("value")) +
                            decimal.Parse(TVLicenseBill.GetAttribute("value")) +
                            decimal.Parse(FoodBill.GetAttribute("value")) +
                            decimal.Parse(HomePhoneBill.GetAttribute("value")) +
                            decimal.Parse(TravelBills.GetAttribute("value")) +
                            decimal.Parse(ClothingBills.GetAttribute("value")) +
                            decimal.Parse(OtherExpenditure.GetAttribute("value"));
                        calculatedTotalExpenditure = calculatedTotalExpenditure * 4.33m;
                        break;
                    }
                default:
                    {
                        ObjectRepository.writer.WriteToLog("Invalid frequency value- " + frequency);
                        break;
                    }
            }
            return calculatedTotalExpenditure.ToString("#,#00.00");
        }

        public string GetTotalIncome()
        {
           return TotalIncome.GetAttribute("textContent").Trim();
        }

        public string GetTotalExpenditure()
        {
            return TotalExpenditure.GetAttribute("textContent").Trim();
        }

        public void PopulateBudgetCalculatorDependentsExpenditurePages(string inputFileName, string frequency)
        {
            getInputDataFromFile(inputFileName);

            enterDependentAdults(fileData_DependentAdults.ToString());
            enterDependentChild14to18(fileData_DependentChild14to18.ToString());
            enterDependendChildUnder14(fileData_DependentChildUnder14.ToString());

            ObjectRepository.writer.WriteToLog("New Total number of dependents are :- " + TotalDependents.GetAttribute("innerText"));
            DataEntryHelper.ButtonClick(ContinueButton2);

            enterMortgageOrRent(fileData_MortgageOrRent.ToString());
            selectMortgageOrRentFreq(frequency);

            enterGasBill(fileData_GasBill.ToString());
            selectGasBillFreq(frequency);

            enterElectricityBill(fileData_ElectricityBill.ToString());
            selectElectricityBillFreq(frequency);

            enterWaterBill(fileData_WaterBill.ToString());
            selectWaterBillFreq(frequency);

            enterCouncilTaxBill(fileData_CouncilTaxBill.ToString());
            selectCouncilTaxBillFreq(frequency);

            enterChildCare(fileData_ChildCare.ToString());
            selectChildCareFreq(frequency);

            enterCreditCards(fileData_CreditCards.ToString());
            selectCreditCardFreq(frequency);

            enterInsurance(fileData_Insurance.ToString());
            selectInsuranceFreq(frequency);

            enterMobilePhone(fileData_MobilePhone.ToString());
            selectMobileFreq(frequency);

            enterTVLicence(fileData_TVLicence.ToString());
            selectTVLicenceFreq(frequency);

            enterFood(fileData_Food.ToString());
            selectFoodFreq(frequency);

            enterHomePhone(fileData_HomePhone.ToString());
            selectHomePhoneFreq(frequency);

            enterTravel(fileData_Travel.ToString());
            selectTravelFreq(frequency);

            enterClothing(fileData_Clothing.ToString());
            selectClothingFreq(frequency);

            enterOtherExpenditure(fileData_OtherExpenditure.ToString());
            selectOtherExpenditureFreq(frequency);
        }
        
        public void refresh()
        {
            driver.Navigate().Refresh();
        }

        #endregion
    }
}
