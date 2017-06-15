using System;
using TechTalk.SpecFlow;
using Digital.ComponentHelper;
using Digital.PageObject;
using Digital.Settings;

namespace Digital.StepDefinition
{
    [Binding]
    public class DigitalNavigateToAllPagesSteps
    {
        [Given(@"I am on Home")]
        public void GivenIAmOnHome()
        {
            ObjectRepository.digitalHomePage = ObjectRepository.digitalNavigationBar.gotToHomePage();
        }
        
        [When(@"I navigate between all the pages")]
        public void WhenINavigateBetweenAllThePages()
        {
            ObjectRepository.digitalLoginPage = ObjectRepository.digitalHomePage.gotToLogInPage();
            ObjectRepository.digitalMyAccountPage = ObjectRepository.digitalLoginPage.Login("hmm112@hmm112.com", "Bolder11");
            ObjectRepository.digitalNavigationBar.gotToHomePage();
            ObjectRepository.digitalNavigationBar.gotToPaymentOptionsPage();
            ObjectRepository.digitalNavigationBar.gotToAboutUsPage();
            ObjectRepository.digitalNavigationBar.gotToFAQsPage();
            ObjectRepository.digitalNavigationBar.gotToContactUsPage();
            ObjectRepository.digitalNavigationBar.gotToHomePage();
            ObjectRepository.digitalMyAccountPage.navigateToBudgetCalculator();
            ObjectRepository.digitalNavigationBar.logout();

        }
        
        [Then(@"There should be no errors thrown")]
        public void ThenThereShouldBeNoErrorsThrown()
        {
            //ObjectRepository.Driver.Quit();
            ObjectRepository.digitalNavigationBar.logout();
            ObjectRepository.digitalNavigationBar.gotToHomePage();
        }
    }
}
