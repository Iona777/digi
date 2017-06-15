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
    public class Digital_LO_PayInFullSteps
    {

        //Class constructor
        public Digital_LO_PayInFullSteps()
        {

            ObjectRepository.digitalHomePage                    = new digitalHome(ObjectRepository.Driver);
            ObjectRepository.theDigital_LO_PaymentOptionsPage2  = new digital_LO_PaymentOptionsPage2(ObjectRepository.Driver);
            ObjectRepository.theDigital_LO_PayInFullPage1       = new digital_LO_PayInFullPage1(ObjectRepository.Driver);
            
            
        }
        //Class Variables
        string DDPlanStartDate = null;
        string DDGuaranteeURL = null;


        [When(@"I select Pay in Full radio button and click on Continue")]
        public void WhenISelectPayInFullRadioButtonAndClickOnContinue()
        {
            ObjectRepository.theDigital_LO_PaymentOptionsPage2.clickPayInFullBtn();
            ObjectRepository.theDigital_LO_PaymentOptionsPage2.clickContinueBtn();
        }

        [Then(@"the Logged off Pay in Full Page1 screen is displayed")]
        public void ThenTheLoggedOffPayInFullPageScreenIsDisplayed()
        {
            Assert.IsTrue(ObjectRepository.theDigital_LO_PayInFullPage1.getPageTitle() == ObjectRepository.Driver.Title,
                "Checking that we are on Logged off Pay in Full Page1 screen");

        }

        [Then(@"I click on the Back button in the Logged off Pay in Full Page1 screen")]
        public void ThenIClickOnTheBackButtonInTheLoggedOffPayInFullPageScreen()
        {
            ObjectRepository.theDigital_LO_PayInFullPage1.clickBackButton();
        }


    }
}
