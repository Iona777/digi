using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
//Will need to change the namespace of this to digital once settings has been understood
//I think we need to include this for the page object declaration
using Digital.Settings;
//And I think that we need this for the page object definition. Both are required to instantiate.
using Digital.PageObject;

namespace Digital.StepDefinition
{
    [Binding]
    public sealed class DigitalRegisterSteps
    {
        //class constructor
        public DigitalRegisterSteps()
        {
            //We will generally do away with page objects being created by navigation
            //links. Instead, they will be instantiated in the class constructor of
            //the stepdefinition class that is using them.
            ObjectRepository.newDigitalNavigationBarPage    = new digitalNavigationBarPage(ObjectRepository.Driver);   
        }

        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        [Given(@"I have navigated to the Register page")]
        public void GivenIHaveNavigatedToTheRegisterPage()
        {
            //We will generally do away with this way of creating page objects.
            //The exception being page objects that are created by navigating 
            //to them from the NavigationBarPage 
            ObjectRepository.newDigitalRegisterPage =
            ObjectRepository.newDigitalNavigationBarPage.goToRegistrationPage();
        }

        [When(@"I enter registration details from the '(.*)' file")]
        public void WhenIEnterRegistrationDetailsFromTheFile(string inputFile)
        {
            ObjectRepository.newDigitalRegisterPage.populateRegistrationFieldsFromFile(inputFile);
            Thread.Sleep(1000); //Pause to give user change to enter captcha details in debug mode
            ObjectRepository.newDigitalRegisterPage.clickContinueButton();
            ObjectRepository.newDigitalRegisterPage.clickFinishButton();
        }

    }
}
