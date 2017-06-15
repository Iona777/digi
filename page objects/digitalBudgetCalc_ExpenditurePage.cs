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
    public class digitalBudgetCalc_ExpenditurePage : digitalNavigationBar
    {
        private IWebDriver driver;

        #region fileData fields
        //Input data fields from file
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
        public const string CreditCardBillLocator           = "//*[@id='bills_Loan']";
        public const string CreditCardBillFrequencyLocator  = "//*[@name='bills.LoanSourceModel']";
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
        public const string ContinueButtonLocator           = "//*[@value='Continue']";
        public const string BackButtonLocator               = "//*[@value='Back']";

        //Error messages - these locators use CSSSelectors 
        public const string MortgageOrRentErrorMsgLocator       = "[data-valmsg-for='bills.Rent]";
        public const string GasBillErrorMsgLocator              = "[data-valmsg-for='bills.Gas']";
        public const string ElectricityBillErrorMsgLocator      = "[data-valmsg-for='bills.Electricity']";
        public const string WaterBillErrorMsgLocator            = "[data-valmsg-for='bills.Water']";
        public const string CouncilTaxErrorMsgLocator           = "[data-valmsg-for='bills.CouncilTax']";
        public const string ChildcareBillErrorMsgLocator        = "[data-valmsg-for='bills.ChildCare]";
        public const string CreditCardBillErrorMsgLocator       = "[data-valmsg-for='bills.Loan']";
        public const string InsuranceBillErrorMsgLocator        = "[data-valmsg-for='bills.Insurance']";
        public const string MobileBillErrorMsgLocator           = "[data-valmsg-for='bills.Mobile']";
        public const string TVLicenseBillErrorMsgLocator        = "[data-valmsg-for='bills.TVLicence']";
        public const string FoodBillErrorMsgLocator             = "[data-valmsg-for='bills.Food']";
        public const string TelephoneBillErrorMsgLocator        = "[data-valmsg-for='bills.Telephone']";
        public const string TravelBillsErrorMsgLocator          = "[data-valmsg-for='bills.Travel']";
        public const string ClothingBillsErrorMsgLocator        = "[data-valmsg-for='bills.Clothing']";
        public const string OtherExpenditureErrorMsgLocator     = "[data-valmsg-for='bills.Expenditure']";
        #endregion

        #region WebElement
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

        [FindsBy(How = How.XPath, Using = CreditCardBillLocator)]
        private IWebElement CreditCardBill;

        [FindsBy(How = How.XPath, Using = CreditCardBillFrequencyLocator)]
        private IWebElement CreditCardBillFrequency;

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

        [FindsBy(How = How.XPath, Using = ContinueButtonLocator)]
        private IWebElement ContinueButton;

        [FindsBy(How = How.XPath, Using = BackButtonLocator)]
        private IWebElement BackButton;

        
        //Error Messages
        [FindsBy(How = How.CssSelector, Using = MortgageOrRentErrorMsgLocator)]
        private IWebElement MortgageOrRentErrorMsg;

        [FindsBy(How = How.CssSelector, Using = GasBillErrorMsgLocator)]
        private IWebElement GasBillErrorMsg;

        [FindsBy(How = How.CssSelector, Using = ElectricityBillErrorMsgLocator)]
        private IWebElement ElectricityBillErrorMsg;

        [FindsBy(How = How.CssSelector, Using = WaterBillErrorMsgLocator)]
        private IWebElement WaterBillErrorMsg;

        [FindsBy(How = How.CssSelector, Using = CouncilTaxErrorMsgLocator)]
        private IWebElement CouncilTaxErrorMsg;

        [FindsBy(How = How.CssSelector, Using = ChildcareBillErrorMsgLocator)]
        private IWebElement ChildcareBillErrorMsg;

        [FindsBy(How = How.CssSelector, Using = CreditCardBillErrorMsgLocator)]
        private IWebElement CreditCardBillErrorMsg;

        [FindsBy(How = How.CssSelector, Using = InsuranceBillErrorMsgLocator)]
        private IWebElement InsuranceBillErrorMsg;

        [FindsBy(How = How.CssSelector, Using = MobileBillErrorMsgLocator)]
        private IWebElement MobileBillErrorMsg;

        [FindsBy(How = How.CssSelector, Using = TVLicenseBillErrorMsgLocator)]
        private IWebElement TVLicenseBillErrorMsg;

        [FindsBy(How = How.CssSelector, Using = FoodBillErrorMsgLocator)]
        private IWebElement FoodBillErrorMsg;

        [FindsBy(How = How.CssSelector, Using = TelephoneBillErrorMsgLocator)]
        private IWebElement TelephoneBillErrorMsg;

        [FindsBy(How = How.CssSelector, Using = TravelBillsErrorMsgLocator)]
        private IWebElement TravelBillsErrorMsg;

        [FindsBy(How = How.CssSelector, Using = ClothingBillsErrorMsgLocator)]
        private IWebElement ClothingBillsErrorMsg;

        [FindsBy(How = How.CssSelector, Using = OtherExpenditureErrorMsgLocator)]
        private IWebElement OtherExpenditureErrorMsg;
        #endregion

        //I tried to change this to use PAGEFACTORY.INITELEMENTS(), but base page uses PageFactory, so no need?
        public digitalBudgetCalc_ExpenditurePage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Actions

        public bool AllExpenditureErrorMsgsDisplayed()
        //If any of the error messages are missing, the WaitForElement will timeout and
        //return an exception. This will then cause this method to return false
        {
            try
            {
                DataEntryHelper.WaitForElementByCSS(MortgageOrRentErrorMsgLocator);                 
                DataEntryHelper.WaitForElementByCSS(GasBillErrorMsgLocator);
                DataEntryHelper.WaitForElementByCSS(ElectricityBillErrorMsgLocator);
                DataEntryHelper.WaitForElementByCSS(WaterBillErrorMsgLocator);
                DataEntryHelper.WaitForElementByCSS(CouncilTaxErrorMsgLocator);
                DataEntryHelper.WaitForElementByCSS(ChildcareBillErrorMsgLocator);
                DataEntryHelper.WaitForElementByCSS(CreditCardBillErrorMsgLocator);
                DataEntryHelper.WaitForElementByCSS(MobileBillErrorMsgLocator);
                DataEntryHelper.WaitForElementByCSS(TVLicenseBillErrorMsgLocator);
                DataEntryHelper.WaitForElementByCSS(FoodBillErrorMsgLocator);
                DataEntryHelper.WaitForElementByCSS(TelephoneBillErrorMsgLocator);
                DataEntryHelper.WaitForElementByCSS(TravelBillsErrorMsgLocator);
                DataEntryHelper.WaitForElementByCSS(ClothingBillsErrorMsgLocator);
                DataEntryHelper.WaitForElementByCSS(OtherExpenditureErrorMsgLocator);
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

        public void getExpenditureInputDataFromFile(string fileToUse)
        { 
            //This is for use when you only want to use one row of input data.

            //Reads data from input file into a dataset 
            DataSet inputData = readFileIntoDataSet(fileToUse);

            //Read specic cells of that dataset into variables 
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

        public void getExpenditureInputDataFromDataSet(DataSet inputDataSet, int rowToRead)
        {
            //This is for use when you want to use multiple rows of input data.
            //The full input file will be read into a dataset prior to calling this method
            //and then passed to this method as a parameter. This avoids the file being read
            //on each iteration.
            //The calling method will call this method within a loop and pass in a different rowToRead
            //on each iteration. 

            //Read specific cells of that dataset into variables 
            fileData_MortgageOrRent     = ReadExcelFile.readSpecificCell(inputDataSet, rowToRead, "Mortgage or Rent");
            fileData_GasBill            = ReadExcelFile.readSpecificCell(inputDataSet, rowToRead, "Gas Bill");
            fileData_ElectricityBill    = ReadExcelFile.readSpecificCell(inputDataSet, rowToRead, "Electricity Bill");
            fileData_WaterBill          = ReadExcelFile.readSpecificCell(inputDataSet, rowToRead, "Water Bill");
            fileData_CouncilTaxBill     = ReadExcelFile.readSpecificCell(inputDataSet, rowToRead, "Council Tax Bill");
            fileData_ChildCare          = ReadExcelFile.readSpecificCell(inputDataSet, rowToRead, "Child Care");
            fileData_CreditCards        = ReadExcelFile.readSpecificCell(inputDataSet, rowToRead, "Credit Cards");
            fileData_Insurance          = ReadExcelFile.readSpecificCell(inputDataSet, rowToRead, "Insurance");
            fileData_MobilePhone        = ReadExcelFile.readSpecificCell(inputDataSet, rowToRead, "Mobile Phone");
            fileData_TVLicence          = ReadExcelFile.readSpecificCell(inputDataSet, rowToRead, "TV Licence");
            fileData_Food               = ReadExcelFile.readSpecificCell(inputDataSet, rowToRead, "Food");
            fileData_HomePhone          = ReadExcelFile.readSpecificCell(inputDataSet, rowToRead, "Home Phone");
            fileData_Travel             = ReadExcelFile.readSpecificCell(inputDataSet, rowToRead, "Travel");
            fileData_Clothing           = ReadExcelFile.readSpecificCell(inputDataSet, rowToRead, "Clothing");
            fileData_OtherExpenditure   = ReadExcelFile.readSpecificCell(inputDataSet, rowToRead, "Other Expenditure");
        }

        public void populateExpenditureFieldsFromFile(string inputFileName, string frequency)
        {
            //Use this version of the method if you are just reading one line of input data
            ObjectRepository.writer.WriteToLog("This Budget Calculator dependants page is being completed");

            getExpenditureInputDataFromFile(inputFileName);

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

        public void populateExpenditureFieldsFromDataSet(DataSet inputDataSet, int rowToRead, string frequency)
        {
            //This can be used with tests where the input dataset is populated with multiple rows
            //and this method is called once for each row

            //Reads specific cells of that dataset into variables 
            getExpenditureInputDataFromDataSet(inputDataSet, rowToRead);

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


        //These methods are used to send the data to the webpage.

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
            DataEntryHelper.EnterText(input, CreditCardBill);
        }

        public void selectCreditCardFreq(string frequency)
        {
            DataEntryHelper.SelectFreqByValue(frequency,CreditCardBillFrequency);
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
        public void clickContinueButton()
        {
            DataEntryHelper.ButtonClick(ContinueButton);
        }

        public void clickBackButton()
        {
            DataEntryHelper.ButtonClick(BackButton);
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
                            decimal.Parse(CreditCardBill.GetAttribute("value")) +
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
                            decimal.Parse(CreditCardBill.GetAttribute("value")) +
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
                            decimal.Parse(CreditCardBill.GetAttribute("value")) +
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
                            decimal.Parse(CreditCardBill.GetAttribute("value")) +
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

        public string GetTotalExpenditureOnScreen()
        {
            return TotalExpenditure.GetAttribute("textContent").Trim();
        }

        //Looks like this is inherited from NavigationBar. See if removing it causes problems. 
        //public void refresh()
        //{
        //    driver.Navigate().Refresh();
        //}
        #endregion
    }
}
