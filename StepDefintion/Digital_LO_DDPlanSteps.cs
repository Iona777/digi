using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digital.Settings;
using Digital.PageObject;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Digital.StepDefinition
{
    
    [Binding]
    public class Digital_LO_DDPlanSteps
    {

        //Class constructor
        public Digital_LO_DDPlanSteps()
        {

            ObjectRepository.digitalHomePage                    = new digitalHome(ObjectRepository.Driver);
            ObjectRepository.theDigital_LO_PaymentOptionsPage2  = new digital_LO_PaymentOptionsPage2(ObjectRepository.Driver);
            ObjectRepository.theDigital_LO_DirectDebitPlanPage1 = new digital_LO_DirectDebitPlanPage1(ObjectRepository.Driver);
            ObjectRepository.theDigitalDDGuaranteePage          = new digitalDDGuarantee(ObjectRepository.Driver);


            
        }
        //Class Variables
        string DDPlanStartDate = null;
        string DDGuaranteeURL = null;

        [When(@"I select Setup a Direct Debit radio button and click on Continue")]
        public void WhenISelectSetupADirectDebitRadioButtonAndClickOnContinue()
        {
            ObjectRepository.theDigital_LO_PaymentOptionsPage2.clickDirectDebitRadioBtn();
            ObjectRepository.theDigital_LO_PaymentOptionsPage2.clickContinueBtn();
        }

        //Same as above, but specflow refused to recognise it so had to create another.
        [Then(@"I select Setup a Direct Debit radio button again and click on Continue")]
        public void ThenISelectSetupADirectDebitRadioButtonAgainAndClickOnContinue()
        {
            ObjectRepository.theDigital_LO_PaymentOptionsPage2.clickDirectDebitRadioBtn();
            ObjectRepository.theDigital_LO_PaymentOptionsPage2.clickContinueBtn();
        }




        [When(@"I click on the Back button in the Direct Debit Plan Step1 screen")]
        public void WhenIClickOnTheBackButtonInTheDirectDebitPlanStep1Screen()
        {
            ObjectRepository.theDigital_LO_DirectDebitPlanPage1.clickBackButton();
        }

        [When(@"I complete the Logged Off Direct Debit Plan Step1 screen using '(.*)',  '(.*)', '(.*)', '(.*)', '(.*)' and '(.*)'  through data from feature file")]
        public void WhenICompleteTheLoggedOffDirectDebitPlanStepScreenUsingAndThroughDataFromFeatureFile(Decimal DDAmount, string Frequency, string AccountHolder, string AccountNo, string SortCode, string Email)
        {
            ObjectRepository.theDigital_LO_DirectDebitPlanPage1.setupDDplan(DDAmount, Frequency, AccountHolder, AccountNo, SortCode, Email);
        }


        [When(@"I note the value of the Start Date and click on Continue")]
        public void WhenINoteTheValueOfTheStartDateAndClickOnContinue()
        {
            DDPlanStartDate = ObjectRepository.theDigital_LO_DirectDebitPlanPage1.getInputtedStartDate();
            ObjectRepository.theDigital_LO_DirectDebitPlanPage1.clickContinueButton();
        }

        [Then(@"the Logged Off Direct Debit Plan Step2 -Review screen displays the values entered '(.*)', '(.*)', '(.*)','(.*)','(.*)', '(.*)', '(.*)'")]
        public void ThenTheLoggedOffDirectDebitPlanStep_ReviewScreenDisplaysTheValuesEntered(string RefNo, Decimal PaymentAmount, string Frequency, string AccountHolder, string AccountNo, string SortCode, string EmailAddress)
                                                                       //'<RefNo>', '<PaymentAmount>', '<Frequency>','<AcccountHolder>','<AccountNo>', '<SortCode>', '<EmailAddress>'  
        {
            string displayedRefNo = ObjectRepository.theDigital_LO_DirectDebitPage2_ReviewPage.getDisplayedLowellRef();
            decimal displayedAmount = ObjectRepository.theDigital_LO_DirectDebitPage2_ReviewPage.getDisplayedPaymentAmount();
            string displayedFreq = ObjectRepository.theDigital_LO_DirectDebitPage2_ReviewPage.getDisplayedFrequency();
            string displayedAccNo = ObjectRepository.theDigital_LO_DirectDebitPage2_ReviewPage.getDisplayedAccountNumber();
            string displayedSortCd = ObjectRepository.theDigital_LO_DirectDebitPage2_ReviewPage.getDisplayedSortCode();

            Assert.AreEqual(RefNo, displayedRefNo, "Compare Lowell ref no displayed in DD Review page to the value entered");
            Assert.AreEqual(PaymentAmount, displayedAmount, "Compare payment amount displayed in DD Review page with the value entered");
            Assert.AreEqual(Frequency, displayedFreq, "Compare frequency displayed in DD Review page with the value entered");
            Assert.AreEqual(AccountNo, displayedAccNo, "Compare account no displayed in DD Review page with the value entered");
            Assert.AreEqual(SortCode, displayedSortCd, "Compare sort code displayed in DD Review page with the value entered");
        }


        [Then(@"the Logged Off Direct Debit Plan Step2 -Review screen displays the other values entered: Start Date, Repayment Method")]
        public void ThenTheLoggedOffDirectDebitPlanStep_ReviewScreenDisplaysTheOtherValuesEnteredStartDateRepaymentMethod()
        {
            string displayedStartDate = ObjectRepository.theDigital_LO_DirectDebitPage2_ReviewPage.getDisplayedStartDate();

            Assert.AreEqual(DDPlanStartDate, displayedStartDate, "Compare Start Date displayed in DD Review page to value entered");
            Assert.IsTrue(ObjectRepository.theDigital_LO_DirectDebitPage2_ReviewPage.getDisplayedRepaymentMethod()=="Direct Debit", 
                "Check Repayment Method in DD Review screen displayed correctly");
        }


        [When(@"I click on the Continue button in the Logged Off Direct Debit Plan Step1 screen")]
        public void WhenIClickOnTheContinueButtonInTheLoggedOffDirectDebitPlanStepScreen()
        {
            ObjectRepository.theDigital_LO_DirectDebitPlanPage1.clickContinueButton();
        }


        [Then(@"I click on the Continue button in the Logged Off Direct Debit Plan Step2 -Review screen")]
        public void ThenIClickOnTheContinueButtonInTheLoggedOffDirectDebitPlanStep_ReviewScreen()
        {
            ObjectRepository.theDigital_LO_DirectDebitPage2_ReviewPage.clickContinueBtn();
        }

       
        [Then(@"the Logged Off Direct Debit Plan Confirmation screen displays the values entered '(.*)', '(.*)', '(.*)','(.*)', '(.*)'")]
        public void ThenTheLoggedOffDirectDebitPlanConfirmationScreenDisplaysTheValuesEntered(string RefNo, decimal PaymentAmount, string Frequency, string AccountNo, string SortCode)
        {
            string displayedRefNo = ObjectRepository.theDigital_LO_DDConfirmationPage.getDisplayedLowellRef();
            decimal displayedAmount = ObjectRepository.theDigital_LO_DDConfirmationPage.getDisplayedPaymentAmount();
            string displayedFreq = ObjectRepository.theDigital_LO_DDConfirmationPage.getDisplayedFrequency();
            string displayedAccNo = ObjectRepository.theDigital_LO_DDConfirmationPage.getDisplayedAccountNumber();
            string displayedSortCd = ObjectRepository.theDigital_LO_DDConfirmationPage.getDisplayedSortCode();

            Assert.AreEqual(RefNo, displayedRefNo, "Compare Lowell ref no displayed in DD Confirmation page to the value entered");
            Assert.AreEqual(PaymentAmount, displayedAmount, "Compare payment amount displayed in DD Confirmation page with the value entered");
            Assert.AreEqual(Frequency, displayedFreq, "Compare frequency displayed in DD Confirmation page with the value entered");
            Assert.AreEqual(AccountNo, displayedAccNo, "Compare account no displayed in DD Confirmation page with the value entered");
            Assert.AreEqual(SortCode, displayedSortCd, "Compare sort code displayed in DD Confirmation page with the value entered");
        }


        [Then(@"the Logged Off Direct Debit Plan Confirmation screen displays the other values entered: Start Date, Repayment Method, Account Holder and Email Address")]
        public void ThenTheLoggedOffDirectDebitPlanConfirmationScreenDisplaysTheOtherValuesEnteredStartDateRepaymentMethodAccountHolderAndEmailAddress()
        {
            string displayedStartDate = ObjectRepository.theDigital_LO_DDConfirmationPage.getDisplayedStartDate();

            Assert.AreEqual(DDPlanStartDate, displayedStartDate, "Compare Start Date displayed in DD Confirmation page to value entered");
            Assert.IsTrue(ObjectRepository.theDigital_LO_DDConfirmationPage.getDisplayedRepaymentMethod() == "Direct Debit",
                "Check Repayment Method in DD Confirmation screen displayed correctly");
        }


        [Then(@"the non-existent account number error message:  '(.*)' is displayed in the Logged Off Direct Debit Plan Step1 screen")]
        public void ThenTheNon_ExistentAccountNumberErrorMessageIsDisplayedInTheLoggedOffDirectDebitPlanStepScreen(string accountNoErrorMsg)
        {
            Assert.AreEqual(accountNoErrorMsg, ObjectRepository.theDigital_LO_DirectDebitPlanPage1.getAccountNoErrorMsg(), "Checking the the non-existent account number error message");   
        }


        [Then(@"the modulus error message:  '(.*)' is displayed in the Logged Off Direct Debit Plan Step1 screen")]
        public void ThenTheModulusErrorMessageIsDisplayedInTheLoggedOffDirectDebitPlanStepScreen(string modulusErrorMsg)
        {
            Assert.AreEqual(modulusErrorMsg, ObjectRepository.theDigital_LO_DirectDebitPlanPage1.getModulusErrorMsg(), "Checking the the modulus error message");
        }


        [Then(@"the sort code error message:  '(.*)' is displayed in the Logged Off Direct Debit Plan Step1 screen")]
        public void ThenTheSortCodeErrorMessageIsDisplayedInTheLoggedOffDirectDebitPlanStepScreen(string sortcodeErrorMsg)
        {
            Assert.AreEqual(sortcodeErrorMsg, ObjectRepository.theDigital_LO_DirectDebitPlanPage1.getSortCodeErrorMsg(), "Checking the the sort code error message");
        }


        [Then(@"the account number error message:  '(.*)' is displayed in the Logged Off Direct Debit Plan Step1 screen")]
        public void ThenTheAccountNumberErrorMessageIsDisplayedInTheLoggedOffDirectDebitPlanStepScreen(string accountNumberErrorMsg)
        {
            Assert.AreEqual(accountNumberErrorMsg, ObjectRepository.theDigital_LO_DirectDebitPlanPage1.getAccountNoErrorMsg(), "Checking the account number error messages");
        }

        [Then(@"the Discounted DD Amount buttons are NOT displayed")]
        public void ThenTheDiscountedDDAmountButtonsAreNOTDisplayed()
        {
            Assert.IsTrue(ObjectRepository.theDigital_LO_DirectDebitPlanPage1.discountButtonsNotDisplayed());
        
        }


        [Then(@"I click on the Back button in the the Direct Debit Plan Step2 -Review screen")]
        public void ThenIClickOnTheBackButtonInTheTheDirectDebitPlanStep_ReviewScreen()
        {
            ObjectRepository.theDigital_LO_DirectDebitPage2_ReviewPage.clickBackBtn();
        }


        [Then(@"the Logged Off Direct Debit Plan Step1 screen is displayed")]
        public void ThenTheLoggedOffDirectDebitPlanStepScreenIsDisplayed()
        {
            string requiredScreenTitle = ObjectRepository.theDigital_LO_DirectDebitPlanPage1.Title;
            string actualScreenTitle = ObjectRepository.Driver.Title;

            Assert.AreEqual(requiredScreenTitle, actualScreenTitle, "Checking that we are on the DirectDebitPlanStep1 screen");
        }


        [When(@"I click on the DD Guarantee link in the logged Off Direct Debit Plan Step1 screen")]
        public void WhenIClickOnTheDDGuaranteeLinkInTheLoggedOffDirectDebitPlanStepScreen()
        {
            DDGuaranteeURL  = ObjectRepository.theDigital_LO_DirectDebitPlanPage1.clickDDGuaranteeLink();
        }

        [Then(@"the DD Guarantee PDF is displayed")]
        public void ThenTheDDGuaranteePDFIsDisplayed()
        {
            Assert.IsTrue(ObjectRepository.theDigitalDDGuaranteePage.isThePageDDGuaranteePage(DDGuaranteeURL), 
                "Checking that logged out DD Guarantee link works");
            
        }

        [Then(@"I click on the Terms and Conditions link in the logged Off Direct Debit Plan Step1 screen")]
        public void ThenIClickOnTheTermsAndConditionsLinkInTheLoggedOffDirectDebitPlanStepScreen()
        {
            //This method is inherited frm the digitalNavigationBar
            ObjectRepository.theDigital_LO_DirectDebitPlanPage1.goToTermsAndConditionsPage();

        }

        [Then(@"I verify that the Repayment Amount field is NOT pre-populated")]
        public void ThenIVerifyThatTheRepaymentAmountFieldIsNOTPre_Populated()
        {
            Assert.IsTrue(
            ObjectRepository.theDigital_LO_DirectDebitPlanPage1.isRepaymentAmountEmpty(),
            "Checking that DD Repayment amount field not pre-populated");
        }


    }
}
