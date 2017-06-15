using System;
using TechTalk.SpecFlow;
using Digital.ComponentHelper;
using Digital.PageObject;
using Digital.Settings;
using System.Threading;
using Digital.BaseClasses;
using Digital.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Digital
{
    [Binding]
    public class DigitalUserRegistrationSteps
    {
        [Given(@"I have clicked on Register button and navigated to the Register page")]
        public void GivenIHaveClickedOnRegisterButtonAndNavigatedToTheRegisterPage()
        {
            ObjectRepository.digitalRegister = ObjectRepository.digitalNavigationBar.gotToRegistrationPage();
        }


        [When(@"I enter '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' in relevant fields and register")]
        public void WhenIEnterInRelevantFieldsAndRegister(string referenceNumber, string dob, string postCode, string landline, string mobile, string email, string password)
        {
            ObjectRepository.digitalRegister.registerAnAccount(referenceNumber, dob, postCode, landline, mobile, email, password);
        }

        [When(@"I have Logged in to Umbraco using '(.*)' '(.*)' and activated the '(.*)' in Umbraco")]
        public void WhenIHaveLoggedInToUmbracoUsingAndActivatedTheInUmbraco(string p0, string p1, string p2)
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetUmbracoUrl());
            ObjectRepository.digitalUmbracoLogin = new digitalUmbracoLogin(ObjectRepository.Driver);
            ObjectRepository.digitalUmbracoHome = ObjectRepository.digitalUmbracoLogin.Login(p0,p1);            
            ObjectRepository.digitalUmbracoMemberDetails = ObjectRepository.digitalUmbracoHome.searchForAMember(p2);
            ObjectRepository.digitalUmbracoMemberDetails.approveRegisteredUser();
            ObjectRepository.digitalUmbracoMemberDetails.logout();
        }
       
    }
}
