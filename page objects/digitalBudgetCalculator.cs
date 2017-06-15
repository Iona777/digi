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
using OpenQA.Selenium.Support.UI;


namespace Digital.PageObject
{
    public class digitalBudgetCalculator : digitalNavigationBar
    {
        private IWebDriver driver;

        public const string HouseholdSalaryLocator = "//*[@id=\"budget_Salary\"]";
        public const string HouseholdSalaryFrequencyLocator = "//*[@name=\"budget.SalarySourceModel\"]";
        public const string IncomeSupportLocator = "//*[@id=\"budget_IncomeSupport\"]";
        public const string IncomeSupportFrequencyLocator = "//*[@name=\"budget.IncomeSupportSourceModel\"]";
        public const string ChildBenefitLocator = "//*[@id=\"budget_ChildBenefit\"]";
        public const string ChildBenefitFrequencyLocator = "//*[@name=\"budget.ChildBenefitSourceModel\"]";
        public const string JobSeekerAllowanceLocator = "//*[@id=\"budget_JobSeekersAllowance\"]";
        public const string JobSeekerAllowanceFrequencyLocator = "//*[@name=\"budget.JobSeekersAllowanceSourceModel\"]";
        public const string PensionLocator = "//*[@id=\"budget_Pension\"]";
        public const string PensionFrequencyLocator = "//*[@name=\"budget.PensionSourceModel\"]";
        public const string ChildOrWorkingTaxCreditLocator = "//*[@id=\"budget_ChildorWorking\"]";
        public const string ChildOrWorkingTaxCreditFrequencyLocator = "//*[@name=\"budget.ChildorWorkingSourceModel\"]";
        public const string OtherIncomeLocator = "//*[@id=\"budget_Other\"]";
        public const string OtherIncomeFrequencyLocator = "//*[@name=\"budget.OtherSourceModel\"]";
        public const string TotalIncomeLocator = "//*[@id=\"layout-main\"]/div/div/form/div/div/div[8]/div";
        public const string ContinueButton1Locator = "//*[@id=\"next\"]";
        public const string DependentAdultsLocator = "//*[@id=\"dependants_Adults\"]";
        public const string Dependent14to18ChildrenLocator = "//*[@id=\"dependants_Child14to18\"]";
        public const string DependentUnder14ChildLocator = "//*[@id=\"dependants_ChildUnder14\"]";
        public const string TotalDependentsLocator = "//*[@id=\"dependenciesDisplay\"]";
        public const string ContinueButton2Locator = "//*[@id=\"layout-main\"]/div/form/button[2]";
        public const string BackButton2Locator = "//*[@id=\"layout-main\"]/div/form/button[1]";
        public const string MortgageOrRentLocator = "//*[@id=\"bills_Rent\"]";
        public const string MortgageOrRentFrequencyLocator = "//*[@name=\"bills.RentSourceModel\"]";
        public const string GasBillLocator = "//*[@id=\"bills_Gas\"]";
        public const string GasBillFrequencyLocator = "//*[@name=\"bills.GasSourceModel\"]";
        public const string ElectricityBillLocator = "//*[@id=\"bills_Electricity\"]";
        public const string ElectricityBillFrequencyLocator = "//*[@name=\"bills.ElectricitySourceModel\"]";
        public const string WaterBillLocator = "//*[@id=\"bills_Water\"]";
        public const string WaterBillFrequencyLocator = "//*[@name=\"bills.WaterSourceModel\"]";
        public const string CouncilTaxLocator = "//*[@id=\"bills_CouncilTax\"]";
        public const string CouncilTaxFrequencyLocator = "//*[@name=\"bills.CouncilTaxSourceModel\"]";
        public const string ChildCareBillLocator = "//*[@id=\"bills_ChildCare\"]";
        public const string ChildCareBillFrequencyLocator = "//*[@name=\"bills.ChildCareSourceModel\"]";
        public const string LoanOrCreditCardBillLocator = "//*[@id=\"bills_Loan\"]";
        public const string LoanOrCreditCardBillFrequencyLocator = "//*[@name=\"bills.LoanSourceModel\"]";
        public const string InsuranceBillLocator = "//*[@id=\"bills_Insurance\"]";
        public const string InsuranceBillFrequencyLocator = "//*[@name=\"bills.InsuranceSourceModel\"]";
        public const string MobileBillLocator = "//*[@id=\"bills_Mobile\"]";
        public const string MobileBillFrequencyLocator = "//*[@name=\"bills.MobileSourceModel\"]";
        public const string TVLicenseBillLocator = "//*[@id=\"bills_TVLicence\"]";
        public const string TVLicenseBillFrequencyLocator = "//*[@name=\"bills.TVLicenceSourceModel\"]";
        public const string FoodBillLocator = "//*[@id=\"bills_Food\"]";
        public const string FoodBillFrequencyLocator = "//*[@name=\"bills.FoodSourceModel\"]";
        public const string TelephoneBillLocator = "//*[@id=\"bills_Telephone\"]";
        public const string TelephoneBillFrequencyLocator = "//*[@name=\"bills.TelephoneSourceModel\"]";
        public const string TravelBillsLocator = "//*[@id=\"bills_Travel\"]";
        public const string TravelBillsFrequencyLocator = "//*[@name=\"bills.TravelSourceModel\"]";
        public const string ClothingBillsLocator = "//*[@id=\"bills_Clothing\"]";
        public const string ClothingBillsFrequencyLocator = "//*[@name=\"bills.ClothingSourceModel\"]";
        public const string OtherExpenditureLocator = "//*[@id=\"bills_Expenditure\"]";
        public const string OtherExpenditureFrequencyLocator = "//*[@name=\"bills.ExpenditureSourceModel\"]";
        public const string TotalExpenditureLocator = "//*[@id=\"expenditureDisplay\"]";
        public const string ContinueButton3Locator = "//*[@id=\"layout-main\"]/div/form/button[2]";
        public const string BackButton3Locator = "//*[@id=\"layout-main\"]/div/form/button[1]";
        public const string MonthlyIncomeLocator = "//*[@id=\"content\"]/div/div/div[1]/p[2]/span[2]";
        public const string PriorityHouseholdBillsLocator = "//*[@id=\"content\"]/div/div/div[1]/p[3]/span[2]";
        public const string MonthlyDisposableIncomeLocator = "//*[@id=\"content\"]/div/div/div[1]/p[7]/span[1]";
        public const string MyAccountButtonLocator = "//*[@id=\"next\"]";
        public const string BackButton4Locator = "//*[@id=\"content\"]/div/form/button[1]";

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
        private IWebElement TelephoneBill;

        [FindsBy(How = How.XPath, Using = TelephoneBillFrequencyLocator)]
        private IWebElement TelephoneBillFrequency;

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

        #endregion

        public digitalBudgetCalculator(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions

        public void refresh()
        {
            driver.Navigate().Refresh();
        }

        public void selectMonth(IWebElement freqElement)
        {
            (new SelectElement(freqElement)).SelectByIndex(4);
        }

        public void selectFourWeekly(IWebElement freqElement)
        {
            (new SelectElement(freqElement)).SelectByIndex(3);
        }

        public void selectFortnightly(IWebElement freqElement)
        {
            (new SelectElement(freqElement)).SelectByIndex(2);
        }

        public void selectWeekly(IWebElement freqElement)
        {
            (new SelectElement(freqElement)).SelectByIndex(1);
        }

        public digitalMyAccount completeBCWithMonthlyFrequency(int salaryAmount)
        {
            ObjectRepository.writer.WriteToLog("This Budget Calculator is being completed with Monthly frequency");
            HouseholdSalary.SendKeys(salaryAmount.ToString());            
            selectMonth(HouseholdSalaryFrequency);
            IncomeSupport.SendKeys("200");
            selectMonth(IncomeSupportFrequency);
            ChildBenefit.SendKeys("50");
            selectMonth(ChildBenefitFrequency);
            JobSeekerAllowance.SendKeys("100");
            selectMonth(JobSeekerAllowanceFrequency);
            Pension.SendKeys("50");
            selectMonth(PensionFrequency);
            ChildOrWorkingTaxCredit.SendKeys("100");
            selectMonth(ChildOrWorkingTaxCreditFrequency);
            OtherIncome.SendKeys("75");
            selectMonth(OtherIncomeFrequency);
            ObjectRepository.writer.WriteToLog("New Total Income is :- "+TotalIncome.GetAttribute("innerText"));
            DataEntryHelper.ButtonClick(ContinueButton1);
            DependentAdults.SendKeys("2");
            Dependent14to18Children.SendKeys("1");
            DependentUnder14Child.SendKeys("1");
            ObjectRepository.writer.WriteToLog("New Total number of dependents are :- " + TotalDependents.GetAttribute("innerText"));
            DataEntryHelper.ButtonClick(ContinueButton2);            
            MortgageOrRent.SendKeys("2100");
            selectMonth(MortgageOrRentFrequency);
            GasBill.SendKeys("350");
            selectMonth(GasBillFrequency);
            ElectricityBill.SendKeys("300");
            selectMonth(ElectricityBillFrequency);
            WaterBill.SendKeys("250");
            selectMonth(WaterBillFrequency);
            CouncilTax.SendKeys("100");
            selectMonth(CouncilTaxFrequency);
            ChildCareBill.SendKeys("200");
            selectMonth(ChildCareBillFrequency);
            LoanOrCreditCardBill.SendKeys("150");
            selectMonth(LoanOrCreditCardBillFrequency);
            InsuranceBill.SendKeys("100");
            selectMonth(InsuranceBillFrequency);
            MobileBill.SendKeys("50");
            selectMonth(MobileBillFrequency);
            TVLicenseBill.SendKeys("75");
            selectMonth(TVLicenseBillFrequency);
            FoodBill.SendKeys("50");
            selectMonth(FoodBillFrequency);
            TelephoneBill.SendKeys("125");
            selectMonth(TelephoneBillFrequency);
            TravelBills.SendKeys("150");
            selectMonth(TravelBillsFrequency);
            ClothingBills.SendKeys("50");
            selectMonth(ClothingBillsFrequency);
            OtherExpenditure.SendKeys("250");
            selectMonth(OtherExpenditureFrequency);
            ObjectRepository.writer.WriteToLog("New Total Expenditure is :- " + TotalExpenditure.GetAttribute("innerText"));
            DataEntryHelper.ButtonClick(ContinueButton3);            
            ObjectRepository.writer.WriteToLog("New Total Monthly Income is :- " + MonthlyIncome.GetAttribute("innerText"));
            ObjectRepository.writer.WriteToLog("New Priority household bills are :- " + PriorityHouseholdBills.GetAttribute("innerText"));
            ObjectRepository.writer.WriteToLog("New Monthly Disposable Income is :- " + MonthlyDisposableIncome.GetAttribute("innerText"));
            ObjectRepository.digitalNavigationBar.gotToMyAccountPage();
            return new digitalMyAccount(driver);
        }

        public digitalMyAccount completeBCWithFourWeeklyFrequency(int salaryAmount)
        {
            ObjectRepository.writer.WriteToLog("This Budget Calculator is being completed with Four Weekly frequency");
            HouseholdSalary.SendKeys(salaryAmount.ToString());
            selectFourWeekly(HouseholdSalaryFrequency);
            IncomeSupport.SendKeys("200");
            selectFourWeekly(IncomeSupportFrequency);
            ChildBenefit.SendKeys("50");
            selectFourWeekly(ChildBenefitFrequency);
            JobSeekerAllowance.SendKeys("100");
            selectFourWeekly(JobSeekerAllowanceFrequency);
            Pension.SendKeys("50");
            selectFourWeekly(PensionFrequency);
            ChildOrWorkingTaxCredit.SendKeys("100");
            selectFourWeekly(ChildOrWorkingTaxCreditFrequency);
            OtherIncome.SendKeys("75");
            selectFourWeekly(OtherIncomeFrequency);
            ObjectRepository.writer.WriteToLog("New Total Income is :- " + TotalIncome.GetAttribute("innerText"));
            DataEntryHelper.ButtonClick(ContinueButton1);            
            DependentAdults.SendKeys("2");
            Dependent14to18Children.SendKeys("1");
            DependentUnder14Child.SendKeys("1");
            ObjectRepository.writer.WriteToLog("New Total number of dependents are :- " + TotalDependents.GetAttribute("innerText"));
            DataEntryHelper.ButtonClick(ContinueButton2);            
            MortgageOrRent.SendKeys("2100");
            selectFourWeekly(MortgageOrRentFrequency);
            GasBill.SendKeys("350");
            selectFourWeekly(GasBillFrequency);
            ElectricityBill.SendKeys("300");
            selectFourWeekly(ElectricityBillFrequency);
            WaterBill.SendKeys("250");
            selectFourWeekly(WaterBillFrequency);
            CouncilTax.SendKeys("100");
            selectFourWeekly(CouncilTaxFrequency);
            ChildCareBill.SendKeys("200");
            selectFourWeekly(ChildCareBillFrequency);
            LoanOrCreditCardBill.SendKeys("150");
            selectFourWeekly(LoanOrCreditCardBillFrequency);
            InsuranceBill.SendKeys("100");
            selectFourWeekly(InsuranceBillFrequency);
            MobileBill.SendKeys("50");
            selectFourWeekly(MobileBillFrequency);
            TVLicenseBill.SendKeys("75");
            selectFourWeekly(TVLicenseBillFrequency);
            FoodBill.SendKeys("50");
            selectFourWeekly(FoodBillFrequency);
            TelephoneBill.SendKeys("125");
            selectFourWeekly(TelephoneBillFrequency);
            TravelBills.SendKeys("150");
            selectFourWeekly(TravelBillsFrequency);
            ClothingBills.SendKeys("50");
            selectFourWeekly(ClothingBillsFrequency);
            OtherExpenditure.SendKeys("250");
            selectFourWeekly(OtherExpenditureFrequency);
            ObjectRepository.writer.WriteToLog("New Total Expenditure is :- " + TotalExpenditure.GetAttribute("innerText"));
            DataEntryHelper.ButtonClick(ContinueButton3);            
            ObjectRepository.writer.WriteToLog("New Total Monthly Income is :- " + MonthlyIncome.GetAttribute("innerText"));
            ObjectRepository.writer.WriteToLog("New Priority household bills are :- " + PriorityHouseholdBills.GetAttribute("innerText"));
            ObjectRepository.writer.WriteToLog("New Monthly Disposable Income is :- " + MonthlyDisposableIncome.GetAttribute("innerText"));
            ObjectRepository.digitalNavigationBar.gotToMyAccountPage();
            return new digitalMyAccount(driver);
        }

        public digitalMyAccount completeBCWithFortnightlyFrequency(int salaryAmount)
        {
            ObjectRepository.writer.WriteToLog("This Budget Calculator is being completed with Fortnightly frequency");
            HouseholdSalary.SendKeys(salaryAmount.ToString());
            selectFortnightly(HouseholdSalaryFrequency);
            IncomeSupport.SendKeys("200");
            selectFortnightly(IncomeSupportFrequency);
            ChildBenefit.SendKeys("50");
            selectFortnightly(ChildBenefitFrequency);
            JobSeekerAllowance.SendKeys("100");
            selectFortnightly(JobSeekerAllowanceFrequency);
            Pension.SendKeys("50");
            selectFortnightly(PensionFrequency);
            ChildOrWorkingTaxCredit.SendKeys("100");
            selectFortnightly(ChildOrWorkingTaxCreditFrequency);
            OtherIncome.SendKeys("75");
            selectFortnightly(OtherIncomeFrequency);
            ObjectRepository.writer.WriteToLog("New Total Income is :- " + TotalIncome.GetAttribute("innerText"));
            DataEntryHelper.ButtonClick(ContinueButton1);            
            DependentAdults.SendKeys("2");
            Dependent14to18Children.SendKeys("1");
            DependentUnder14Child.SendKeys("1");
            ObjectRepository.writer.WriteToLog("New Total number of dependents are :- " + TotalDependents.GetAttribute("innerText"));
            DataEntryHelper.ButtonClick(ContinueButton2);            
            MortgageOrRent.SendKeys("2100");
            selectFortnightly(MortgageOrRentFrequency);
            GasBill.SendKeys("350");
            selectFortnightly(GasBillFrequency);
            ElectricityBill.SendKeys("300");
            selectFortnightly(ElectricityBillFrequency);
            WaterBill.SendKeys("250");
            selectFortnightly(WaterBillFrequency);
            CouncilTax.SendKeys("100");
            selectFortnightly(CouncilTaxFrequency);
            ChildCareBill.SendKeys("200");
            selectFortnightly(ChildCareBillFrequency);
            LoanOrCreditCardBill.SendKeys("150");
            selectFortnightly(LoanOrCreditCardBillFrequency);
            InsuranceBill.SendKeys("100");
            selectFortnightly(InsuranceBillFrequency);
            MobileBill.SendKeys("50");
            selectFortnightly(MobileBillFrequency);
            TVLicenseBill.SendKeys("75");
            selectFortnightly(TVLicenseBillFrequency);
            FoodBill.SendKeys("50");
            selectFortnightly(FoodBillFrequency);
            TelephoneBill.SendKeys("125");
            selectFortnightly(TelephoneBillFrequency);
            TravelBills.SendKeys("150");
            selectFortnightly(TravelBillsFrequency);
            ClothingBills.SendKeys("50");
            selectFortnightly(ClothingBillsFrequency);
            OtherExpenditure.SendKeys("250");
            selectFortnightly(OtherExpenditureFrequency);
            ObjectRepository.writer.WriteToLog("New Total Expenditure is :- " + TotalExpenditure.GetAttribute("innerText"));
            DataEntryHelper.ButtonClick(ContinueButton3);            
            ObjectRepository.writer.WriteToLog("New Total Monthly Income is :- " + MonthlyIncome.GetAttribute("innerText"));
            ObjectRepository.writer.WriteToLog("New Priority household bills are :- " + PriorityHouseholdBills.GetAttribute("innerText"));
            ObjectRepository.writer.WriteToLog("New Monthly Disposable Income is :- " + MonthlyDisposableIncome.GetAttribute("innerText"));
            ObjectRepository.digitalNavigationBar.gotToMyAccountPage();
            return new digitalMyAccount(driver);
        }

        public digitalMyAccount completeBCWithFortnightlyFrequency(int salary, int incomeSupport, int childBenefit, int jobSeekerAllowance, int pension, int childOrWorkingTaxCredit, int anyOtherIncome, int adults,
            int childs14to18, int childsUnder14, int mortgageOrRent, int Gas, int electricity, int Water, int councilTax, int maintenanceOrChildCare, int loansOrCreditCards, int insurance, int mobilePhone, int tvLicence, int Food, int homePhone,
            int transport, int clothing, int other)
        {
            ObjectRepository.writer.WriteToLog("This Budget Calculator is being completed with Fortnightly frequency");
            HouseholdSalary.SendKeys(salary.ToString());
            selectFortnightly(HouseholdSalaryFrequency);
            IncomeSupport.SendKeys(incomeSupport.ToString());
            selectFortnightly(IncomeSupportFrequency);
            ChildBenefit.SendKeys(childBenefit.ToString());
            selectFortnightly(ChildBenefitFrequency);
            JobSeekerAllowance.SendKeys(jobSeekerAllowance.ToString());
            selectFortnightly(JobSeekerAllowanceFrequency);
            Pension.SendKeys(pension.ToString());
            selectFortnightly(PensionFrequency);
            ChildOrWorkingTaxCredit.SendKeys(childOrWorkingTaxCredit.ToString());
            selectFortnightly(ChildOrWorkingTaxCreditFrequency);
            OtherIncome.SendKeys(anyOtherIncome.ToString());
            selectFortnightly(OtherIncomeFrequency);
            ObjectRepository.writer.WriteToLog("New Total Income is :- " + TotalIncome.GetAttribute("innerText"));
            DataEntryHelper.ButtonClick(ContinueButton1);
            DependentAdults.SendKeys(adults.ToString());
            Dependent14to18Children.SendKeys(childs14to18.ToString());
            DependentUnder14Child.SendKeys(childsUnder14.ToString());
            ObjectRepository.writer.WriteToLog("New Total number of dependents are :- " + TotalDependents.GetAttribute("innerText"));
            DataEntryHelper.ButtonClick(ContinueButton2);
            MortgageOrRent.SendKeys(mortgageOrRent.ToString());
            selectFortnightly(MortgageOrRentFrequency);
            GasBill.SendKeys(Gas.ToString());
            selectFortnightly(GasBillFrequency);
            ElectricityBill.SendKeys(electricity.ToString());
            selectFortnightly(ElectricityBillFrequency);
            WaterBill.SendKeys(Water.ToString());
            selectFortnightly(WaterBillFrequency);
            CouncilTax.SendKeys(councilTax.ToString());
            selectFortnightly(CouncilTaxFrequency);
            ChildCareBill.SendKeys(maintenanceOrChildCare.ToString());
            selectFortnightly(ChildCareBillFrequency);
            LoanOrCreditCardBill.SendKeys(loansOrCreditCards.ToString());
            selectFortnightly(LoanOrCreditCardBillFrequency);
            InsuranceBill.SendKeys(insurance.ToString());
            selectFortnightly(InsuranceBillFrequency);
            MobileBill.SendKeys(mobilePhone.ToString());
            selectFortnightly(MobileBillFrequency);
            TVLicenseBill.SendKeys(tvLicence.ToString());
            selectFortnightly(TVLicenseBillFrequency);
            FoodBill.SendKeys(Food.ToString());
            selectFortnightly(FoodBillFrequency);
            TelephoneBill.SendKeys(homePhone.ToString());
            selectFortnightly(TelephoneBillFrequency);
            TravelBills.SendKeys(transport.ToString());
            selectFortnightly(TravelBillsFrequency);
            ClothingBills.SendKeys(clothing.ToString());
            selectFortnightly(ClothingBillsFrequency);
            OtherExpenditure.SendKeys(other.ToString());
            selectFortnightly(OtherExpenditureFrequency);
            ObjectRepository.writer.WriteToLog("New Total Expenditure is :- " + TotalExpenditure.GetAttribute("innerText"));
            DataEntryHelper.ButtonClick(ContinueButton3);
            ObjectRepository.writer.WriteToLog("New Total Monthly Income is :- " + MonthlyIncome.GetAttribute("innerText"));
            ObjectRepository.writer.WriteToLog("New Priority household bills are :- " + PriorityHouseholdBills.GetAttribute("innerText"));
            ObjectRepository.writer.WriteToLog("New Monthly Disposable Income is :- " + MonthlyDisposableIncome.GetAttribute("innerText"));
            ObjectRepository.digitalNavigationBar.gotToMyAccountPage();
            return new digitalMyAccount(driver);
        }

        public digitalMyAccount completeBCWithWeeklyFrequency(int salary, int incomeSupport, int childBenefit, int jobSeekerAllowance, int pension, int childOrWorkingTaxCredit, int anyOtherIncome, int adults,
            int childs14to18, int childsUnder14, int mortgageOrRent, int Gas, int electricity, int Water, int councilTax, int maintenanceOrChildCare, int loansOrCreditCards, int insurance, int mobilePhone, int tvLicence, int Food, int homePhone,
            int transport, int clothing, int other)
        {
            ObjectRepository.writer.WriteToLog("This Budget Calculator is being completed with Weekly frequency");
            HouseholdSalary.SendKeys(salary.ToString());
            selectWeekly(HouseholdSalaryFrequency);
            IncomeSupport.SendKeys(incomeSupport.ToString());
            selectWeekly(IncomeSupportFrequency);
            ChildBenefit.SendKeys(childBenefit.ToString());
            selectWeekly(ChildBenefitFrequency);
            JobSeekerAllowance.SendKeys(jobSeekerAllowance.ToString());
            selectWeekly(JobSeekerAllowanceFrequency);
            Pension.SendKeys(pension.ToString());
            selectWeekly(PensionFrequency);
            ChildOrWorkingTaxCredit.SendKeys(childOrWorkingTaxCredit.ToString());
            selectWeekly(ChildOrWorkingTaxCreditFrequency);
            OtherIncome.SendKeys(anyOtherIncome.ToString());
            selectWeekly(OtherIncomeFrequency);
            ObjectRepository.writer.WriteToLog("New Total Income is :- " + TotalIncome.GetAttribute("innerText"));
            DataEntryHelper.ButtonClick(ContinueButton1);
            DependentAdults.SendKeys(adults.ToString());
            Dependent14to18Children.SendKeys(childs14to18.ToString());
            DependentUnder14Child.SendKeys(childsUnder14.ToString());
            ObjectRepository.writer.WriteToLog("New Total number of dependents are :- " + TotalDependents.GetAttribute("innerText"));
            DataEntryHelper.ButtonClick(ContinueButton2);
            MortgageOrRent.SendKeys(mortgageOrRent.ToString());
            selectWeekly(MortgageOrRentFrequency);
            GasBill.SendKeys(Gas.ToString());
            selectWeekly(GasBillFrequency);
            ElectricityBill.SendKeys(electricity.ToString());
            selectWeekly(ElectricityBillFrequency);
            WaterBill.SendKeys(Water.ToString());
            selectWeekly(WaterBillFrequency);
            CouncilTax.SendKeys(councilTax.ToString());
            selectWeekly(CouncilTaxFrequency);
            ChildCareBill.SendKeys(maintenanceOrChildCare.ToString());
            selectWeekly(ChildCareBillFrequency);
            LoanOrCreditCardBill.SendKeys(loansOrCreditCards.ToString());
            selectWeekly(LoanOrCreditCardBillFrequency);
            InsuranceBill.SendKeys(insurance.ToString());
            selectWeekly(InsuranceBillFrequency);
            MobileBill.SendKeys(mobilePhone.ToString());
            selectWeekly(MobileBillFrequency);
            TVLicenseBill.SendKeys(tvLicence.ToString());
            selectWeekly(TVLicenseBillFrequency);
            FoodBill.SendKeys(Food.ToString());
            selectWeekly(FoodBillFrequency);
            TelephoneBill.SendKeys(homePhone.ToString());
            selectWeekly(TelephoneBillFrequency);
            TravelBills.SendKeys(transport.ToString());
            selectWeekly(TravelBillsFrequency);
            ClothingBills.SendKeys(clothing.ToString());
            selectWeekly(ClothingBillsFrequency);
            OtherExpenditure.SendKeys(other.ToString());
            selectWeekly(OtherExpenditureFrequency);
            ObjectRepository.writer.WriteToLog("New Total Expenditure is :- " + TotalExpenditure.GetAttribute("innerText"));
            DataEntryHelper.ButtonClick(ContinueButton3);
            ObjectRepository.writer.WriteToLog("New Total Monthly Income is :- " + MonthlyIncome.GetAttribute("innerText"));
            ObjectRepository.writer.WriteToLog("New Priority household bills are :- " + PriorityHouseholdBills.GetAttribute("innerText"));
            ObjectRepository.writer.WriteToLog("New Monthly Disposable Income is :- " + MonthlyDisposableIncome.GetAttribute("innerText"));
            ObjectRepository.digitalNavigationBar.gotToMyAccountPage();
            return new digitalMyAccount(driver);
        }

        public digitalMyAccount completeBCWithFourWeeklyFrequency(int salary, int incomeSupport, int childBenefit, int jobSeekerAllowance, int pension, int childOrWorkingTaxCredit, int anyOtherIncome, int adults,
            int childs14to18, int childsUnder14, int mortgageOrRent, int Gas, int electricity, int Water, int councilTax, int maintenanceOrChildCare, int loansOrCreditCards, int insurance, int mobilePhone, int tvLicence, int Food, int homePhone,
            int transport, int clothing, int other)
        {
            ObjectRepository.writer.WriteToLog("This Budget Calculator is being completed with FourWeekly frequency");
            HouseholdSalary.SendKeys(salary.ToString());
            selectFourWeekly(HouseholdSalaryFrequency);
            IncomeSupport.SendKeys(incomeSupport.ToString());
            selectFourWeekly(IncomeSupportFrequency);
            ChildBenefit.SendKeys(childBenefit.ToString());
            selectFourWeekly(ChildBenefitFrequency);
            JobSeekerAllowance.SendKeys(jobSeekerAllowance.ToString());
            selectFourWeekly(JobSeekerAllowanceFrequency);
            Pension.SendKeys(pension.ToString());
            selectFourWeekly(PensionFrequency);
            ChildOrWorkingTaxCredit.SendKeys(childOrWorkingTaxCredit.ToString());
            selectFourWeekly(ChildOrWorkingTaxCreditFrequency);
            OtherIncome.SendKeys(anyOtherIncome.ToString());
            selectFourWeekly(OtherIncomeFrequency);
            ObjectRepository.writer.WriteToLog("New Total Income is :- " + TotalIncome.GetAttribute("innerText"));
            DataEntryHelper.ButtonClick(ContinueButton1);
            DependentAdults.SendKeys(adults.ToString());
            Dependent14to18Children.SendKeys(childs14to18.ToString());
            DependentUnder14Child.SendKeys(childsUnder14.ToString());
            ObjectRepository.writer.WriteToLog("New Total number of dependents are :- " + TotalDependents.GetAttribute("innerText"));
            DataEntryHelper.ButtonClick(ContinueButton2);
            MortgageOrRent.SendKeys(mortgageOrRent.ToString());
            selectFourWeekly(MortgageOrRentFrequency);
            GasBill.SendKeys(Gas.ToString());
            selectFourWeekly(GasBillFrequency);
            ElectricityBill.SendKeys(electricity.ToString());
            selectFourWeekly(ElectricityBillFrequency);
            WaterBill.SendKeys(Water.ToString());
            selectFourWeekly(WaterBillFrequency);
            CouncilTax.SendKeys(councilTax.ToString());
            selectFourWeekly(CouncilTaxFrequency);
            ChildCareBill.SendKeys(maintenanceOrChildCare.ToString());
            selectFourWeekly(ChildCareBillFrequency);
            LoanOrCreditCardBill.SendKeys(loansOrCreditCards.ToString());
            selectFourWeekly(LoanOrCreditCardBillFrequency);
            InsuranceBill.SendKeys(insurance.ToString());
            selectFourWeekly(InsuranceBillFrequency);
            MobileBill.SendKeys(mobilePhone.ToString());
            selectFourWeekly(MobileBillFrequency);
            TVLicenseBill.SendKeys(tvLicence.ToString());
            selectFourWeekly(TVLicenseBillFrequency);
            FoodBill.SendKeys(Food.ToString());
            selectFourWeekly(FoodBillFrequency);
            TelephoneBill.SendKeys(homePhone.ToString());
            selectFourWeekly(TelephoneBillFrequency);
            TravelBills.SendKeys(transport.ToString());
            selectFourWeekly(TravelBillsFrequency);
            ClothingBills.SendKeys(clothing.ToString());
            selectFourWeekly(ClothingBillsFrequency);
            OtherExpenditure.SendKeys(other.ToString());
            selectFourWeekly(OtherExpenditureFrequency);
            ObjectRepository.writer.WriteToLog("New Total Expenditure is :- " + TotalExpenditure.GetAttribute("innerText"));
            DataEntryHelper.ButtonClick(ContinueButton3);
            ObjectRepository.writer.WriteToLog("New Total Monthly Income is :- " + MonthlyIncome.GetAttribute("innerText"));
            ObjectRepository.writer.WriteToLog("New Priority household bills are :- " + PriorityHouseholdBills.GetAttribute("innerText"));
            ObjectRepository.writer.WriteToLog("New Monthly Disposable Income is :- " + MonthlyDisposableIncome.GetAttribute("innerText"));
            ObjectRepository.digitalNavigationBar.gotToMyAccountPage();
            return new digitalMyAccount(driver);
        }

        public digitalMyAccount completeBCWithMonthlyFrequency(int salary, int incomeSupport, int childBenefit, int jobSeekerAllowance, int pension, int childOrWorkingTaxCredit, int anyOtherIncome, int adults,
            int childs14to18, int childsUnder14, int mortgageOrRent, int Gas, int electricity, int Water, int councilTax, int maintenanceOrChildCare, int loansOrCreditCards, int insurance, int mobilePhone, int tvLicence, int Food, int homePhone,
            int transport, int clothing, int other)
        {
            ObjectRepository.writer.WriteToLog("This Budget Calculator is being completed with Monthly frequency");
            HouseholdSalary.SendKeys(salary.ToString());
            selectMonth(HouseholdSalaryFrequency);
            IncomeSupport.SendKeys(incomeSupport.ToString());
            selectMonth(IncomeSupportFrequency);
            ChildBenefit.SendKeys(childBenefit.ToString());
            selectMonth(ChildBenefitFrequency);
            JobSeekerAllowance.SendKeys(jobSeekerAllowance.ToString());
            selectMonth(JobSeekerAllowanceFrequency);
            Pension.SendKeys(pension.ToString());
            selectMonth(PensionFrequency);
            ChildOrWorkingTaxCredit.SendKeys(childOrWorkingTaxCredit.ToString());
            selectMonth(ChildOrWorkingTaxCreditFrequency);
            OtherIncome.SendKeys(anyOtherIncome.ToString());
            selectMonth(OtherIncomeFrequency);
            ObjectRepository.writer.WriteToLog("New Total Income is :- " + TotalIncome.GetAttribute("innerText"));
            DataEntryHelper.ButtonClick(ContinueButton1);
            DependentAdults.SendKeys(adults.ToString());
            Dependent14to18Children.SendKeys(childs14to18.ToString());
            DependentUnder14Child.SendKeys(childsUnder14.ToString());
            ObjectRepository.writer.WriteToLog("New Total number of dependents are :- " + TotalDependents.GetAttribute("innerText"));
            DataEntryHelper.ButtonClick(ContinueButton2);
            MortgageOrRent.SendKeys(mortgageOrRent.ToString());
            selectMonth(MortgageOrRentFrequency);
            GasBill.SendKeys(Gas.ToString());
            selectMonth(GasBillFrequency);
            ElectricityBill.SendKeys(electricity.ToString());
            selectMonth(ElectricityBillFrequency);
            WaterBill.SendKeys(Water.ToString());
            selectMonth(WaterBillFrequency);
            CouncilTax.SendKeys(councilTax.ToString());
            selectMonth(CouncilTaxFrequency);
            ChildCareBill.SendKeys(maintenanceOrChildCare.ToString());
            selectMonth(ChildCareBillFrequency);
            LoanOrCreditCardBill.SendKeys(loansOrCreditCards.ToString());
            selectMonth(LoanOrCreditCardBillFrequency);
            InsuranceBill.SendKeys(insurance.ToString());
            selectMonth(InsuranceBillFrequency);
            MobileBill.SendKeys(mobilePhone.ToString());
            selectMonth(MobileBillFrequency);
            TVLicenseBill.SendKeys(tvLicence.ToString());
            selectMonth(TVLicenseBillFrequency);
            FoodBill.SendKeys(Food.ToString());
            selectMonth(FoodBillFrequency);
            TelephoneBill.SendKeys(homePhone.ToString());
            selectMonth(TelephoneBillFrequency);
            TravelBills.SendKeys(transport.ToString());
            selectMonth(TravelBillsFrequency);
            ClothingBills.SendKeys(clothing.ToString());
            selectMonth(ClothingBillsFrequency);
            OtherExpenditure.SendKeys(other.ToString());
            selectMonth(OtherExpenditureFrequency);
            ObjectRepository.writer.WriteToLog("New Total Expenditure is :- " + TotalExpenditure.GetAttribute("innerText"));
            DataEntryHelper.ButtonClick(ContinueButton3);
            ObjectRepository.writer.WriteToLog("New Total Monthly Income is :- " + MonthlyIncome.GetAttribute("innerText"));
            ObjectRepository.writer.WriteToLog("New Priority household bills are :- " + PriorityHouseholdBills.GetAttribute("innerText"));
            ObjectRepository.writer.WriteToLog("New Monthly Disposable Income is :- " + MonthlyDisposableIncome.GetAttribute("innerText"));
            ObjectRepository.digitalNavigationBar.gotToMyAccountPage();
            return new digitalMyAccount(driver);
        }

        public digitalMyAccount completeBCWithWeeklyFrequency(int salaryAmount)
        {
            ObjectRepository.writer.WriteToLog("This Budget Calculator is being completed with Weekly frequency");
            HouseholdSalary.SendKeys(salaryAmount.ToString());
            selectWeekly(HouseholdSalaryFrequency);
            IncomeSupport.SendKeys("200");
            selectWeekly(IncomeSupportFrequency);
            ChildBenefit.SendKeys("50");
            selectWeekly(ChildBenefitFrequency);
            JobSeekerAllowance.SendKeys("100");
            selectWeekly(JobSeekerAllowanceFrequency);
            Pension.SendKeys("50");
            selectWeekly(PensionFrequency);
            ChildOrWorkingTaxCredit.SendKeys("100");
            selectWeekly(ChildOrWorkingTaxCreditFrequency);
            OtherIncome.SendKeys("75");
            selectWeekly(OtherIncomeFrequency);
            ObjectRepository.writer.WriteToLog("New Total Income is :- " + TotalIncome.GetAttribute("innerText"));
            DataEntryHelper.ButtonClick(ContinueButton1);            
            DependentAdults.SendKeys("2");
            Dependent14to18Children.SendKeys("1");
            DependentUnder14Child.SendKeys("1");
            ObjectRepository.writer.WriteToLog("New Total number of dependents are :- " + TotalDependents.GetAttribute("innerText"));
            DataEntryHelper.ButtonClick(ContinueButton2);            
            MortgageOrRent.SendKeys("2100");
            selectWeekly(MortgageOrRentFrequency);
            GasBill.SendKeys("350");
            selectWeekly(GasBillFrequency);
            ElectricityBill.SendKeys("300");
            selectWeekly(ElectricityBillFrequency);
            WaterBill.SendKeys("250");
            selectWeekly(WaterBillFrequency);
            CouncilTax.SendKeys("100");
            selectWeekly(CouncilTaxFrequency);
            ChildCareBill.SendKeys("200");
            selectWeekly(ChildCareBillFrequency);
            LoanOrCreditCardBill.SendKeys("150");
            selectWeekly(LoanOrCreditCardBillFrequency);
            InsuranceBill.SendKeys("100");
            selectWeekly(InsuranceBillFrequency);
            MobileBill.SendKeys("50");
            selectWeekly(MobileBillFrequency);
            TVLicenseBill.SendKeys("75");
            selectWeekly(TVLicenseBillFrequency);
            FoodBill.SendKeys("50");
            selectWeekly(FoodBillFrequency);
            TelephoneBill.SendKeys("125");
            selectWeekly(TelephoneBillFrequency);
            TravelBills.SendKeys("150");
            selectWeekly(TravelBillsFrequency);
            ClothingBills.SendKeys("50");
            selectWeekly(ClothingBillsFrequency);
            OtherExpenditure.SendKeys("250");
            selectWeekly(OtherExpenditureFrequency);
            ObjectRepository.writer.WriteToLog("New Total Expenditure is :- " + TotalExpenditure.GetAttribute("innerText"));
            DataEntryHelper.ButtonClick(ContinueButton3);            
            ObjectRepository.writer.WriteToLog("New Total Monthly Income is :- " + MonthlyIncome.GetAttribute("innerText"));
            ObjectRepository.writer.WriteToLog("New Priority household bills are :- " + PriorityHouseholdBills.GetAttribute("innerText"));
            ObjectRepository.writer.WriteToLog("New Monthly Disposable Income is :- " + MonthlyDisposableIncome.GetAttribute("innerText"));
            ObjectRepository.digitalNavigationBar.gotToMyAccountPage();
            return new digitalMyAccount(driver);
        }

        #endregion
    }
}
