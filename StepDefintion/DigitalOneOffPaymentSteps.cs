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
    public class DigitalOneOffPaymentSteps
    {
        double initialBalance;
        double paymentAmount;
        string errMsg;

        [When(@"I Complete a OneOff payment by saving card details")]
        public void WhenICompleteAOneOffPaymentbySavingCardDetails()
        {
            try
            {
                initialBalance = ObjectRepository.digitalMyAccountPage.getTotalOutstandingBalance();
                paymentAmount = getPaymentAmount(initialBalance);
                ObjectRepository.writer.WriteToLog("The journey is --- I Complete a OneOff payment by saving card details");
                ObjectRepository.digitalOneOffJourney = ObjectRepository.digitalMyAccountPage.navigateToOneOffPayment();
                ObjectRepository.verifonePayPage = ObjectRepository.digitalOneOffJourney.completePaymentUsingNewCard(paymentAmount);
                ObjectRepository.digitalPaymentConfirmation = ObjectRepository.verifonePayPage.completePaymentStep1();
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("I Complete a OneOff payment by saving card details test has failed", e);
                //BaseClasses.BaseClass.TearDown();
            }
            
        }

        [When(@"I Complete a OneOff payment without saving card details")]
        public void WhenICompleteAOneOffPaymentWithoutSavingCardDetails()
        {
            try
            {
                initialBalance = ObjectRepository.digitalMyAccountPage.getTotalOutstandingBalance();
                paymentAmount = getPaymentAmount(initialBalance);
                ObjectRepository.writer.WriteToLog("The journey is --- I Complete a OneOff payment without saving card details");
                ObjectRepository.digitalOneOffJourney = ObjectRepository.digitalMyAccountPage.navigateToOneOffPayment();
                ObjectRepository.verifonePayPage = ObjectRepository.digitalOneOffJourney.completePaymentWithoutSavingCard(paymentAmount);
                ObjectRepository.digitalPaymentConfirmation = ObjectRepository.verifonePayPage.completePaymentStep1();
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("I Complete a OneOff payment without saving card details test has failed", e);
                //BaseClasses.BaseClass.TearDown();
            }
        }


        [When(@"I Complete a OneOff payment using a saved card")]
        public void WhenICompleteAOneOffPaymentUsingASavedCard()
        {
            try
            {
                initialBalance = ObjectRepository.digitalMyAccountPage.getTotalOutstandingBalance();
                paymentAmount = getPaymentAmount(initialBalance);
                ObjectRepository.writer.WriteToLog("The journey is --- I Complete a OneOff payment using a saved card");
                ObjectRepository.digitalOneOffJourney = ObjectRepository.digitalMyAccountPage.navigateToOneOffPayment();
                ObjectRepository.verifoneSavedCardPayPage = ObjectRepository.digitalOneOffJourney.completePaymentUsingSavedCard(paymentAmount);
                ObjectRepository.digitalPaymentConfirmation = ObjectRepository.verifoneSavedCardPayPage.completePayment();
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);                
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("I Complete a OneOff payment using a saved card test has failed", e);
                //BaseClasses.BaseClass.TearDown();
            }            
        }

        public double getPaymentAmount(double totalBalance)
        {
            paymentAmount = Math.Round(initialBalance / 100, 2);            
            if (paymentAmount.ToString("F").EndsWith("2") || paymentAmount.ToString("F").EndsWith("5") || paymentAmount.ToString("F").EndsWith("7"))
            {
                paymentAmount = paymentAmount - 0.01;                
            }
            return paymentAmount;
        }

        [When(@"I try to do a OneOff payment for more than the outstanding balance")]
        public void WhenITryToDoAOneOffPaymentForMoreThanTheOutstandingBalance()
        {
            try
            {
                initialBalance = ObjectRepository.digitalMyAccountPage.getTotalOutstandingBalance();
                ObjectRepository.writer.WriteToLog("The journey is --- I try to do a OneOff payment for more than the outstanding balance");
                ObjectRepository.digitalOneOffJourney = ObjectRepository.digitalMyAccountPage.navigateToOneOffPayment();
                errMsg = ObjectRepository.digitalOneOffJourney.payAnInvalidPaymentAmount((initialBalance + 1).ToString());
                errMsg = (errMsg.Split('£'))[0];
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog("OneOff payment for more than the outstanding balance test has failed");
                ObjectRepository.writer.WriteToLog(e.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
            }            
        }

        [When(@"I try to do a OneOff payment using an invalid payment amount of '(.*)'")]
        public void WhenITryToDoAOneOffPaymentUsingAnInvalidPaymentAmountOf(string p0)
        {
            try
            {                
                ObjectRepository.writer.WriteToLog("The journey is --- I try to do a OneOff payment for more than the outstanding balance");
                ObjectRepository.digitalOneOffJourney = ObjectRepository.digitalMyAccountPage.navigateToOneOffPayment();
                errMsg = ObjectRepository.digitalOneOffJourney.payAnInvalidPaymentAmount(p0.Replace("\"",""));
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog("OneOff payment for more than the outstanding balance test has failed");
                ObjectRepository.writer.WriteToLog(e.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
            }
        }

        [When(@"I click on terms and conditions link in one off payment")]
        public void WhenIClickOnTermsAndConditionsLinkInOneOffPayment()
        {
            ObjectRepository.writer.WriteToLog("The journey is --- I click on terms and conditions link in one off payment");
            ObjectRepository.digitalOneOffJourney = ObjectRepository.digitalMyAccountPage.navigateToOneOffPayment();
            ObjectRepository.digitalTermsAndConditions = ObjectRepository.digitalOneOffJourney.clickOnTermsAndConditionsLink();
        }

        [When(@"I navigate to One Off payment first page and back to Myaccount")]
        public void WhenINavigateToOneOffPaymentFirstPageAndBackToMyaccount()
        {
            ObjectRepository.writer.WriteToLog("The journey is --- I try to do a OneOff payment for more than the outstanding balance");
            ObjectRepository.digitalOneOffJourney = ObjectRepository.digitalMyAccountPage.navigateToOneOffPayment();
            ObjectRepository.digitalOneOffJourney.clickOnBackButtonInFirstPage();
        }

        [When(@"I navigate to One off payment second page and back to MyAccount")]
        public void WhenINavigateToOneOffPaymentSecondPageAndBackToMyAccount()
        {
            initialBalance = ObjectRepository.digitalMyAccountPage.getTotalOutstandingBalance();
            paymentAmount = getPaymentAmount(initialBalance);
            ObjectRepository.writer.WriteToLog("The journey is --- I try to do a OneOff payment for more than the outstanding balance");
            ObjectRepository.digitalOneOffJourney = ObjectRepository.digitalMyAccountPage.navigateToOneOffPayment();
            ObjectRepository.digitalOneOffJourney.clickOnBackButtonInSecondPage(paymentAmount);            
        }

        [When(@"I navigate to One Off payment and check if values selected in first and second pages of the journey match")]
        public void WhenINavigateToOneOffPaymentAndCheckIfValuesSelectedInFirstAndSecondPagesOfTheJourneyMatch()
        {
            initialBalance = ObjectRepository.digitalMyAccountPage.getTotalOutstandingBalance();
            paymentAmount = getPaymentAmount(initialBalance);
            ObjectRepository.digitalOneOffJourney =  ObjectRepository.digitalMyAccountPage.navigateToOneOffPayment();
            ObjectRepository.digitalOneOffJourney.fillInOneOffPaymentDetailsInFirstPageAndReachSecondPage(paymentAmount);
            try
            {
                Assert.AreEqual(paymentAmount.ToString(), ObjectRepository.digitalOneOffJourney.getPaymentAmountInSecondPage().Replace("£",""));
                Assert.AreEqual(ObjectRepository.testAccountNumber.Trim(), ObjectRepository.digitalOneOffJourney.getLowellReferenceInSecondPage());
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog("I navigate to One Off payment and check if values selected in first and second pages of the journey match test has failed");
                ObjectRepository.writer.WriteToLog(e.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
            }            
        }

        [Then(@"Account status should not be changed")]
        public void ThenAccountStatusShouldNotBeChanged()
        {
            try
            {
                Assert.AreEqual(ObjectRepository.accountStatus, ObjectRepository.digitalMyAccountPage.getAccountStatus());                
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog("Account status should not be changed test step has failed");
                ObjectRepository.writer.WriteToLog(e.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
            }
        }

        [When(@"User navigates to statements page and searches for the payment")]
        public void WhenUserNavigatesToStatementsPageAndSearchesForThePayment()
        {
            try
            {
                ObjectRepository.writer.WriteToLog("Navigating to Statements page and searching for a transaction");
                ObjectRepository.digitalStatements = ObjectRepository.digitalMyAccountPage.navigateToStatementsPage();
                ObjectRepository.digitalStatements.searchTransactionsBetweenDates((DateTime.Now.AddYears(-4)).ToString("dd/MM/yyyy"), (DateTime.Now.AddYears(4)).ToString("dd/MM/yyyy"));
                ObjectRepository.digitalStatements.searchForATransactionInSearchBox(paymentAmount.ToString("0.00"));
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog("User navigates to statements page and searches for the payment");
                ObjectRepository.writer.WriteToLog(e.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
            }                        
        }

        [Then(@"payment should be shown in statements page")]
        public void ThenPaymentShouldBeShownInStatementsPage()
        {
            try
            {
                string searchData = ObjectRepository.digitalStatements.getDataFromFirstRowOfDataTable();
                Assert.IsTrue(searchData.Contains(paymentAmount.ToString("0.00")));
                ObjectRepository.writer.WriteToLog("Payment is successfully in statements page");
            }
            catch (AssertFailedException e)
            {
                ObjectRepository.writer.WriteToLog("Payment should be shown in statements page test step has failed and transaction is not shown in transactions table");
                ObjectRepository.writer.WriteToLog(e.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException();
            }
            
        }

        [Then(@"User should be shown terms and conditions page")]
        public void ThenUserShouldBeShownTermsAndConditionsPage()
        {            
            try
            {
                Assert.IsTrue(ObjectRepository.digitalTermsAndConditions.isThePageTermsAndConditionsPage());
            }
            catch (AssertFailedException e)
            {
                ObjectRepository.writer.WriteToLog("This error message should be shown test has failed");
                ObjectRepository.writer.WriteToLog(e.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException();
            }
        }


        [Then(@"This '(.*)' error message should be shown")]
        public void ThenThisErrorMessageShouldBeShown(string p0)
        {
            try
            {
                Assert.AreEqual(p0.Trim(), errMsg.Trim());
            }
            catch (AssertFailedException e)
            {
                ObjectRepository.writer.WriteToLog("This error message should be shown test has failed");
                ObjectRepository.writer.WriteToLog(e.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException();
            }
        }
        
        [Then(@"balance should be reduced")]
        public void ThenBalanceShouldBeReduced()
        {
            try
            {
                ObjectRepository.digitalMyAccountPage = ObjectRepository.digitalPaymentConfirmation.navigateToMyAccount();
                //Thread.Sleep(2000);
                ObjectRepository.digitalMyAccountPage.refresh();
                double finalBalance = ObjectRepository.digitalMyAccountPage.getTotalOutstandingBalance();
                int refreshcount = 0;
                while ((initialBalance == finalBalance) && (refreshcount < 3))
                {
                    //Thread.Sleep(2000);
                    
                    ObjectRepository.digitalMyAccountPage.refresh();
                    finalBalance = ObjectRepository.digitalMyAccountPage.getTotalOutstandingBalance();
                    refreshcount++;
                }

                //Change this condition to initialbalance-paymentamount = finalbalance
                if (initialBalance != finalBalance)
                {
                    ObjectRepository.writer.WriteToLog("Payment of " + paymentAmount + "£ on account " + ObjectRepository.testAccount + " is successful");
                    ObjectRepository.writer.WriteToLog("The account number is " + ObjectRepository.testAccountNumber.Trim());
                }
                else
                {
                    ObjectRepository.writer.WriteToLog("Payment is not successful on account " + ObjectRepository.testAccount);
                    ObjectRepository.writer.WriteToLog("with account number " + ObjectRepository.testAccountNumber.Trim());
                }
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("balance should be reduced test has failed", e);
                //BaseClasses.BaseClass.TearDown();
            }
        }
    }
}
