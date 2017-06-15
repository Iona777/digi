using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Digital.Settings;
using Digital.PageObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Digital.StepDefinition
{
    [Binding]
    public sealed class Digital_LO_OneOffPaymentSteps
    {
        //Class constructor
        public Digital_LO_OneOffPaymentSteps()
        {
            ObjectRepository.digitalHomePage                    = new digitalHome(ObjectRepository.Driver);
            ObjectRepository.theDigital_LO_PaymentOptionsPage1  = new digital_LO_PaymentOptionsPage1(ObjectRepository.Driver);
            ObjectRepository.theDigital_LO_PaymentOptionsPage2  = new digital_LO_PaymentOptionsPage2(ObjectRepository.Driver);
            ObjectRepository.theDigital_LO_OneOffPaymentPage1   = new digital_LO_OneOffPaymentPage1(ObjectRepository.Driver);
            ObjectRepository.theDigital_LO_PaymentOptionsPage2_Review = new digital_LO_OneOffPaymentPage2_Review(ObjectRepository.Driver);
            ObjectRepository.verifonePayPage                    = new verifonePayPage(ObjectRepository.Driver);
            ObjectRepository.theDigital_LO_PaymentConfirmation  = new digital_LO_PaymentConfirmation(ObjectRepository.Driver);
            ObjectRepository.digitalNavigationBar               = new digitalNavigationBar(ObjectRepository.Driver);
            ObjectRepository.digitalTermsAndConditions          = new digitalTermsAndConditions(ObjectRepository.Driver);
            ObjectRepository.theDigital_LO_DirectDebitPlanPage1  = new digital_LO_DirectDebitPlanPage1(ObjectRepository.Driver);
            ObjectRepository.theDigital_LO_DirectDebitPage2_ReviewPage = new digital_LO_DirectDebitPage2_Review(ObjectRepository.Driver);
            ObjectRepository.theDigital_LO_DDConfirmationPage   = new digital_LO_DDConfirmation(ObjectRepository.Driver);

        }
        //Class variables
        decimal DiscountAvailableValue      = 0;
        decimal NewDiscountAvailableValue   = 0;



        [When(@"I click on the Payment Options bubble icon")]
        public void WhenIClickOnThePaymentOptionsBubbleIcon()
        {
            ObjectRepository.digitalHomePage.gotToPaymentOptionsPage();
        }

        [When(@"I select Payment Options radio button")]
        public void WhenISelectPaymentOptionsRadioButton()
        {
            ObjectRepository.theDigital_LO_PaymentOptionsPage1.clickPaymentOptionsRadioBtn();
        }


        [When(@"I complete Anonymous Login using '(.*)', '(.*)' and '(.*)' through data from feature file")]
        public void WhenICompleteAnonymousLoginUsingAndThroughDataFromFeatureFile(string RefNo, string DOB, string Postcode)
        {
            ObjectRepository.theDigital_LO_PaymentOptionsPage1.enterAnonAccessDetails(RefNo, DOB, Postcode);

            ObjectRepository.theDigital_LO_PaymentOptionsPage1.clickContinueBtn();
        }

        [When(@"I select Make a one off payment radio button and click on Continue")]
        public void WhenISelectMakeAOneOffPaymentRadioButtonAndClickOnContinue()
        {
            ObjectRepository.theDigital_LO_PaymentOptionsPage2.clickOneOffPaymentRadioBtn();
            ObjectRepository.theDigital_LO_PaymentOptionsPage2.clickContinueBtn();
        }

        [When(@"I complete the Logged Off One Off payment Step1 screen using '(.*)' through data from feature file and click on Continue")]
        public void WhenICompleteTheLoggedOffOneOffPaymentStepScreenUsingThroughDataFromFeatureFileAndClickOnContinue(string PaymentAmount)
        {
            ObjectRepository.theDigital_LO_OneOffPaymentPage1.enterPaymentAmount(PaymentAmount);
            ObjectRepository.theDigital_LO_OneOffPaymentPage1.tickTermsAndConditionsCheckBox();
            ObjectRepository.theDigital_LO_OneOffPaymentPage1.clickContinueBtn();
        }

        [Then(@"the Logged Off One Off payment Step2 -Review screen displays the payment amount '(.*)'")]
        public void ThenTheLoggedOffOneOffPaymentStep_ReviewScreenDisplaysThePaymentAmount(Decimal PaymentAmout)
        {
            decimal displayedAmount = ObjectRepository.theDigital_LO_PaymentOptionsPage2_Review.getDisplayedPaymentAmount();
            Assert.AreEqual(PaymentAmout, displayedAmount, "Compare amount displayed in Review page to amount entered");
        }

        [Then(@"I click on Continue and Complete the Verifone Payment page with valid data using '(.*)' through data from feature file and click Continue")]
        public void ThenIClickOnContinueAndCompleteTheVerifonePaymentPageWithValidDataUsingThroughDataFromFeatureFileAndClickContinue(string cardNumber)
        {
            ObjectRepository.theDigital_LO_PaymentOptionsPage2_Review.clickContinueBtn();
            ObjectRepository.verifonePayPage.completePaymentStep1(cardNumber);   
        }

        [Then(@"I click on the Finish button in the Logged out Payment confirmation page")]
        public void ThenIClickOnTheFinishButtonInTheLoggedOutPaymentConfirmationPage()
        {
            ObjectRepository.theDigital_LO_PaymentConfirmation.clickOnFinishBtn();
        }

        [Then(@"PaymentOptionsPage(.*) screen is displayed")]
        public void ThenPaymentOptionsPageScreenIsDisplayed(int p0)
        {
            string requiredScreenTitle = ObjectRepository.theDigital_LO_PaymentOptionsPage1.Title;
            string actualScreenTitle = ObjectRepository.Driver.Title;
             
            Assert.AreEqual(requiredScreenTitle,actualScreenTitle, "Check we are on PaymentOptionsPage1 screen");
        }


        [Then(@"I click on the Back button in the the Logged Off One Off payment Step2 -Review screen")]
        public void ThenIClickOnTheBackButtonInTheTheLoggedOffOneOffPaymentStep_ReviewScreen()
        {
            ObjectRepository.theDigital_LO_PaymentOptionsPage2_Review.clickBackBtn();
        }

        [Then(@"the Logged Off One Off payment Step2 screen is displayed")]
        public void ThenTheLoggedOffOneOffPaymentStepScreenIsDisplayed()
        {
            string requiredScreenTitle = ObjectRepository.theDigital_LO_OneOffPaymentPage1.Title;
            string actualScreenTitle = ObjectRepository.Driver.Title;

            Assert.AreEqual(requiredScreenTitle,actualScreenTitle, "Checking that we are on the OneOffPaymentPage1 screen");
        }

        [When(@"I click on the Terms and Conditions link in the Logged Off One Off payment Step1 screen")]
        public void WhenIClickOnTheTermsAndConditionsLinkInTheLoggedOffOneOffPaymentStepScreen()
        {
            ObjectRepository.theDigital_LO_OneOffPaymentPage1.clickTermsAndConditionsLink();
        }

        [Then(@"the user is redirected to the Terms and Conditions page")]
        public void ThenTheUserIsRedirectedToTheTermsAndConditionsPage()
        {
            Assert.IsTrue(ObjectRepository.digitalTermsAndConditions.isThePageTermsAndConditionsPage());
        }

        [When(@"I note the value of the discount amount in green bar")]
        public void WhenINoteTheValueOfTheDiscountAmountInGreenBar()
        {
            DiscountAvailableValue = 
            ObjectRepository.theDigital_LO_PaymentOptionsPage2.getDiscountAvailableValue();
        }


        [Then(@"I verify that the discount amount in green bar has not changed")]
        public void ThenIVerifyThatTheDiscountAmountInGreenBarHasNotChanged()
        {
            NewDiscountAvailableValue =
            ObjectRepository.theDigital_LO_PaymentOptionsPage2.getDiscountAvailableValue();

            Assert.AreEqual(DiscountAvailableValue, NewDiscountAvailableValue,"Verify discount available value has NOT changed");
        }

        [Then(@"I verify that the Payment Amount field is NOT pre-populated")]
        public void ThenIVerifyThatThePaymentAmountFieldIsNOTPre_Populated()
        {
            Assert.IsTrue(
            ObjectRepository.theDigital_LO_OneOffPaymentPage1.isPaymentAmountEmpty(), 
            "Checking that payment amount field not pre-populated");
        }

        [When(@"I complete the Logged Off One Off payment Step1 screen using '(.*)' through data from feature file")]
        public void WhenICompleteTheLoggedOffOneOffPaymentStepScreenUsingThroughDataFromFeatureFile(string PaymentAmount)
        {
            ObjectRepository.theDigital_LO_OneOffPaymentPage1.enterPaymentAmount(PaymentAmount);
            ObjectRepository.theDigital_LO_OneOffPaymentPage1.tickTermsAndConditionsCheckBox();
        }

        [When(@"I click on the Back button in the Logged Off One Off payment Step1 screen")]
        public void WhenIClickOnTheBackButtonInTheLoggedOffOneOffPaymentStepScreen()
        {
            ObjectRepository.theDigital_LO_OneOffPaymentPage1.clickBackBtn();
        }


    }
}
