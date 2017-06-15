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
using CsvHelper;
using System.IO;

namespace Digital.PageObject
{
    public class digitalBudgetCalc_IncomePage : digitalNavigationBar
    {
        private IWebDriver driver;
        private TextReader myTextReader;
        
        private StreamWriter myStreamWriter = new StreamWriter("H:\\Notes\\Selenium\\errmsg.txt");
        //  File.CreateText();
        private IList<string> listOfErrorMsgs = new List<string>();

        #region fileData fields
        //Input data fields from file
        private string fileData_Salary;
        private string fileData_IncomeSupport;
        private string fileData_ChildBenefit;
        private string fileData_JobSeekers;
        private string fileData_Pension;
        private string fileData_TaxCredit;
        private string fileData_AnyOtherIncome;
        
        #endregion

        #region element locators
        //BudgetCalculator_Income
        public const string HouseholdSalaryLocator              = "//*[@id='budget_Salary']";
        public const string HouseholdSalaryFrequencyLocator     = "//*[@name='budget.SalarySourceModel']";
        public const string IncomeSupportLocator                = "//*[@id='budget_IncomeSupport']";
        public const string IncomeSupportFrequencyLocator       = "//*[@name='budget.IncomeSupportSourceModel']";
        public const string ChildBenefitLocator                 = "//*[@id='budget_ChildBenefit']";
        public const string ChildBenefitFrequencyLocator        = "//*[@name='budget.ChildBenefitSourceModel']";
        public const string JobSeekerAllowanceLocator           = "//*[@id='budget_JobSeekersAllowance']";
        public const string JobSeekerAllowanceFrequencyLocator  = "//*[@name='budget.JobSeekersAllowanceSourceModel']";
        public const string PensionLocator                      = "//*[@id='budget_Pension']";
        public const string PensionFrequencyLocator             = "//*[@name='budget.PensionSourceModel']";
        public const string TaxCreditLocator                    = "//*[@id='budget_ChildorWorking']";
        public const string TaxCreditFrequencyLocator           = "//*[@name='budget.ChildorWorkingSourceModel']";
        public const string OtherIncomeLocator                  = "//*[@id='budget_Other']";
        public const string OtherIncomeFrequencyLocator         = "//*[@name='budget.OtherSourceModel']";
        public const string TotalIncomeLocator                  = "//*[@id='incomeDisplay']";
        public const string ContinueButtonLocator               = "//*[@id='next']";

        //Error messages - these locators use CSSSelectors 
        public const string HouseholdSalaryErroMsgLocator       = "[data-valmsg-for='budget.Salary']";
        public const string IncomeSupportErroMsgLocator         = "[data-valmsg-for='budget.IncomeSupport']";
        public const string ChildBenefitErrorMsgLocator         = "[data-valmsg-for='budget.ChildBenefit']";
        public const string JobSeekerAllowanceErrorMsgLocator   = "[data-valmsg-for='budget.JobSeekersAllowance']";
        public const string PensionErrorMsgLocator              = "[data-valmsg-for='budget.Pension']";
        public const string TaxCreditErrorMsgLocator            = "[data-valmsg-for='budget.ChildorWorking']";
        public const string OtherIncomeErrorMsgLocator          = "[data-valmsg-for='budget.Other']";


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

        [FindsBy(How = How.XPath, Using = TaxCreditLocator)]
        private IWebElement TaxCredit;

        [FindsBy(How = How.XPath, Using = TaxCreditFrequencyLocator)]
        private IWebElement TaxCreditFrequency;

        [FindsBy(How = How.XPath, Using = OtherIncomeLocator)]
        private IWebElement OtherIncome;

        [FindsBy(How = How.XPath, Using = OtherIncomeFrequencyLocator)]
        private IWebElement OtherIncomeFrequency;

        [FindsBy(How = How.XPath, Using = TotalIncomeLocator)]
        private IWebElement TotalIncome;        

        [FindsBy(How = How.XPath, Using = ContinueButtonLocator)]
        private IWebElement ContinueButton;

        
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

        [FindsBy(How = How.CssSelector, Using = TaxCreditErrorMsgLocator)]
        private IWebElement TaxCreditErrorMsg;

        [FindsBy(How = How.CssSelector, Using = OtherIncomeErrorMsgLocator)]
        private IWebElement OtherIncomeErrorMsg;

        #endregion

        //I tried to change this to use PAGEFACTORY.INITELEMENTS(), but base page uses PageFactory, so no need?
        public digitalBudgetCalc_IncomePage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions


        public void WriteToCSV(TextWriter textwriter)
        {

            for (int i = 0; i < listOfErrorMsgs.Count; i++)
            {
                var x = listOfErrorMsgs[i];
                myStreamWriter.Write(listOfErrorMsgs[i]);
                myStreamWriter.Write("\r\n");
            }
            myStreamWriter.Close();
        }

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
                DataEntryHelper.WaitForElementByCSS(TaxCreditErrorMsgLocator);
                DataEntryHelper.WaitForElementByCSS(OtherIncomeErrorMsgLocator);

                
                listOfErrorMsgs.Add(HouseholdSalaryErrorMsg.Text);
                listOfErrorMsgs.Add(IncomeSupportErrorMsg.Text);


                WriteToCSV(myStreamWriter);
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

            //Reads data from file into a dataset that is declared above.
            //This is called by getIncomeInputDataFromFile
            inputData = ReadExcelFile.xlsxReadFile(fileToUse, true);
            return inputData;
        }


        public void getIncomeInputDataFromFile(string fileToUse)
        { 
            //This is for use when you only want to use one row of input data.

            //Reads data from input file into a dataset 
            DataSet inputData = readFileIntoDataSet(fileToUse);

            //Read specific cells of that dataset into variables 
            fileData_Salary             = ReadExcelFile.readSpecificCell(inputData,0,"Household Salary");
            fileData_IncomeSupport      = ReadExcelFile.readSpecificCell(inputData,0,"Income Support");
            fileData_ChildBenefit       = ReadExcelFile.readSpecificCell(inputData,0,"Child Benefit");
            fileData_JobSeekers         = ReadExcelFile.readSpecificCell(inputData,0,"Job Seekers Allowance");
            fileData_Pension            = ReadExcelFile.readSpecificCell(inputData,0,"Pension");
            fileData_TaxCredit          = ReadExcelFile.readSpecificCell(inputData,0,"Tax Credit");
            fileData_AnyOtherIncome     = ReadExcelFile.readSpecificCell(inputData,0,"Any other income");
        }

        
        public void getIncomeInputDataFromDataset(DataSet inputDataSet, int rowToRead)
        {
            //This is for use when you want to use multiple rows of input data.
            //The full input file will be read into a dataset prior to calling this method
            //and then passed to this method as a parameter. This avoids the file being read
            //on each iteration.
            //The calling method will call this method within a loop and pass in a different rowToRead
            //on each iteration. 

            //Read specic cells of that dataset into variables 
            fileData_Salary         = ReadExcelFile.readSpecificCell (inputDataSet, rowToRead, "Household Salary");
            fileData_IncomeSupport  = ReadExcelFile.readSpecificCell (inputDataSet, rowToRead, "Income Support");
            fileData_ChildBenefit   = ReadExcelFile.readSpecificCell (inputDataSet, rowToRead, "Child Benefit");
            fileData_JobSeekers     = ReadExcelFile.readSpecificCell (inputDataSet, rowToRead, "Job Seekers Allowance");
            fileData_Pension        = ReadExcelFile.readSpecificCell (inputDataSet, rowToRead, "Pension");
            fileData_TaxCredit      = ReadExcelFile.readSpecificCell (inputDataSet, rowToRead, "Tax Credit");
            fileData_AnyOtherIncome = ReadExcelFile.readSpecificCell (inputDataSet, rowToRead, "Any other income");
        }

        public void populateIncomeFieldsFromFile(string inputFileName, string frequency)
        {
            //Use this version of the method if you are just reading one line of input data
            ObjectRepository.writer.WriteToLog("This Budget Calculator is being completed with " + frequency + " frequency");

            getIncomeInputDataFromFile(inputFileName);

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


        public void populateIncomeFieldsFromDataSet(DataSet inputDataSet, int rowToRead, string frequency)
        {
            //This can be used with tests where the input dataset is populated with multiple rows
            //and this method is called once for each row

            //Reads specific cells of that dataset into variables 
            getIncomeInputDataFromDataset(inputDataSet, rowToRead);

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
            DataEntryHelper.EnterText(input,TaxCredit);
        }

        public void selectTaxCreditFreq(string frequency)
        {
            DataEntryHelper.SelectFreqByValue(frequency,TaxCreditFrequency);
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

        
        //Click the various buttons, this means they are accessible from outside of the page
        public void clickContinueButton()
        {
            DataEntryHelper.ButtonClick(ContinueButton);
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
                        decimal.Parse(TaxCredit.GetAttribute("value"))+
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
                        decimal.Parse(TaxCredit.GetAttribute("value")) +
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
                        decimal.Parse(TaxCredit.GetAttribute("value")) +
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
                        decimal.Parse(TaxCredit.GetAttribute("value")) +
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

        public string GetTotalIncomeOnScreen()
        {
           return TotalIncome.GetAttribute("textContent").Trim();
        }
        
        //Looks like this is inherited from NavigationBar. See if removing it causes problems.
        //public void refresh()
        //{
        //    driver.Navigate().Refresh();
        //}
        #endregion
    }
}
