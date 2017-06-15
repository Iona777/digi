using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using Digital.ComponentHelper;
using Digital.PageObject;
using Digital.Settings;
using Digital.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Digital.BaseClasses;

namespace Digital
{    
    [Binding]    
    public class DigitalLoginAndLogoutSteps
    {        
        
        [Given(@"I have opened Digital in Chrome")]
        public void GivenIHaveOpenedDigitalInChrome()
        {            
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetUrl());                    
            ObjectRepository.digitalNavigationBar = new digitalNavigationBar(ObjectRepository.Driver);
            if (ObjectRepository.acceptedCookieTerms == false)
            {
                ObjectRepository.digitalNavigationBar.acceptCookieTerms();
                ObjectRepository.acceptedCookieTerms = true;
            }            
            ObjectRepository.digitalNavigationBar.refresh();
            ObjectRepository.writer = Logger.Instance;
        }


        [Given(@"I have opened new Digital in Chrome")]
        public void GivenIHaveOpenedNewDigitalInChrome()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetUrl());
            ObjectRepository.newDigitalNavigationBarPage = new digitalNavigationBarPage(ObjectRepository.Driver);
            if (ObjectRepository.acceptedCookieTerms == false)
            {
                ObjectRepository.newDigitalNavigationBarPage.acceptCookieTerms();
                ObjectRepository.acceptedCookieTerms = true;
            }
            ObjectRepository.newDigitalNavigationBarPage.refresh();
            ObjectRepository.writer = Logger.Instance;
        }


        [Given(@"I have navigated to Login page")]
        public void GivenIHaveNavigatedToLoginPage()
        {
            ObjectRepository.digitalLoginPage = ObjectRepository.digitalNavigationBar.gotToLogInPage();
        }

        [When(@"I Login to Digital using '(.*)' and '(.*)' through data from feature file")]
        public void WhenILoginToDigitalUsingAndThroughDataFromFeatureFile(string p0, string p1)
        {
            try
            {                
                ObjectRepository.testAccount = p0;
                ObjectRepository.digitalMyAccountPage = ObjectRepository.digitalLoginPage.Login(p0, p1);
                ObjectRepository.accountStatus = ObjectRepository.digitalMyAccountPage.getAccountStatus();
                ObjectRepository.testAccountNumber = ObjectRepository.digitalMyAccountPage.getLowellReferenceNumber();
                ObjectRepository.isDiscountAvailable = ObjectRepository.digitalMyAccountPage.isDiscountAvailable();
                ObjectRepository.writer.WriteToLog("Logged In test user is " + p0);
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                throw new AssertFailedException("Login has failed due to exception", e);
            }
        }

        [Then(@"I should see this error message '(.*)' in place of payment options")]
        public void ThenIShouldSeeThisErrorMessageInPlaceOfPaymentOptions(string p0)
        {
            try
            {
                Assert.AreEqual(p0, ObjectRepository.digitalMyAccountPage.getPaymentOptionsErrorMessage());            
            }
            catch (AssertFailedException e)
            {
                ObjectRepository.writer.WriteToLog("Excluded error message test has failed");
                ObjectRepository.writer.WriteToLog(e.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException();
            }
        }


        [When(@"I Login using (.*)")]
        public void WhenILogin(String userCredentials)
        {
            try
            {
            String[] cred = userCredentials.Split('/');
            ObjectRepository.testAccount = cred[0];
            ObjectRepository.digitalMyAccountPage = ObjectRepository.digitalLoginPage.Login(cred[0], cred[1]);
            ObjectRepository.accountStatus = ObjectRepository.digitalMyAccountPage.getAccountStatus();
            ObjectRepository.testAccountNumber = ObjectRepository.digitalMyAccountPage.getLowellReferenceNumber();
            ObjectRepository.isDiscountAvailable = ObjectRepository.digitalMyAccountPage.isDiscountAvailable();
            ObjectRepository.writer.WriteToLog("Logged In test user is " + cred[0]);
        }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                throw new AssertFailedException("Login has failed due to exception", e);
            }
        }

        [When(@"I read data from a file and Login using (.*)")]
        public void WhenIReadDataFromAFileAndLoginUsing(string userCredentials)
        {
            //This does not read data from file, rather it uses methods from newDigitalMyAccountPage
            //instead of the old DigitalMyAccountPage since the newDigitalMyAccountPage is used in the
            //feature for reading input data from a file.
            String[] cred = userCredentials.Split('/');
            ObjectRepository.testAccount = cred[0];
            ObjectRepository.newDigitalMyAccountPage = ObjectRepository.digitalLoginPage.ReadDataFromFile_Login(cred[0], cred[1]);
            
            ObjectRepository.testAccountNumber = ObjectRepository.newDigitalMyAccountPage.getLowellReferenceNumber();
            ObjectRepository.isDiscountAvailable = ObjectRepository.newDigitalMyAccountPage.isDiscountAvailable();
            ObjectRepository.writer.WriteToLog("Logged In test user is " + cred[0]);
        }

        public void WhenIAmReadingDataFromAFileAndLoginUsingAutomationTest_ComBolder(string userCredentials)
        {
            try
            {
            String[] cred = userCredentials.Split('/');
            ObjectRepository.testAccount = cred[0];
            ObjectRepository.newDigitalMyAccountPage = ObjectRepository.digitalLoginPage.ReadDataFromFile_Login(cred[0], cred[1]);

            ObjectRepository.testAccountNumber = ObjectRepository.digitalMyAccountPage.getLowellReferenceNumber();
            ObjectRepository.isDiscountAvailable = ObjectRepository.digitalMyAccountPage.isDiscountAvailable();                    
            ObjectRepository.writer.WriteToLog("Logged In test user is " + cred[0]);
        }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);                
                throw new AssertFailedException("Login has failed due to exception", e);
            }
            
        }


        [Then(@"I should see account details and Logout")]
        public void ThenIShouldSeeAccountDetailsAndLogout()
        {
            ObjectRepository.digitalNavigationBar.logout();
        }


        [Then(@"User is logged out and navigated to home page")]
        public void Userisloggedoutandnavigatedtohomepage()
        {
            ObjectRepository.digitalNavigationBar.logout();
            ObjectRepository.digitalNavigationBar.gotToHomePage();
        }

        [Then(@"User is navigated to home page")]
        public void ThenUserIsNavigatedToHomePage()
        {
            ObjectRepository.digitalNavigationBar.gotToHomePage();
        }

    }
}
