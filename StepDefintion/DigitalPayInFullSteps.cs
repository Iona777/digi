using System;
using TechTalk.SpecFlow;
using Digital.Settings;
using System.Threading;
using Digital.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Digital
{
    [Binding]
    public class DigitalPayInFullSteps
    {
        bool isDiscounted;
        double outstandingBalance;

        [When(@"Complete a discounted pay in full using a new card")]
        public void WhenCompleteADiscountedPayInFullUsingANewCard()
        {
            try
            {
                outstandingBalance = ObjectRepository.digitalMyAccountPage.getDiscountedBalance();
                isDiscounted = true;
                oneoffPayforInvalidFullBalance(outstandingBalance);
                ObjectRepository.writer.WriteToLog("The journey is --- Complete a discounted pay in full using a new card");
                ObjectRepository.digitalPayInFullJourney = ObjectRepository.digitalMyAccountPage.navigateToFullPayment();
                ObjectRepository.verifonePayPage = ObjectRepository.digitalPayInFullJourney.payDiscountedAmountUsingNewCard();
                ObjectRepository.digitalPaymentConfirmation = ObjectRepository.verifonePayPage.completePaymentStep1();
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("Complete a discounted pay in full using a new card test has failed", e);
                //BaseClasses.BaseClass.TearDown();
            }            
        }
        
        [When(@"Complete a discounted pay in full using a saved card")]
        public void WhenCompleteADiscountedPayInFullUsingASavedCard()
        {
            try
            {
                outstandingBalance = ObjectRepository.digitalMyAccountPage.getDiscountedBalance();
                isDiscounted = true;
                oneoffPayforInvalidFullBalance(outstandingBalance);
                ObjectRepository.writer.WriteToLog("The journey is --- Complete a discounted pay in full using a saved card");
                ObjectRepository.digitalPayInFullJourney = ObjectRepository.digitalMyAccountPage.navigateToFullPayment();                
                ObjectRepository.verifoneSavedCardPayPage = ObjectRepository.digitalPayInFullJourney.payDiscountedAmountUsingSavedCard();
                ObjectRepository.digitalPaymentConfirmation = ObjectRepository.verifoneSavedCardPayPage.completePayment();
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("Complete a discounted pay in full using a saved card test has failed", e);
                //BaseClasses.BaseClass.TearDown();
            }            
        }

        [When(@"Complete a full pay in full using a new card")]
        public void WhenCompleteAFullPayInFullUsingANewCard()
        {
            try
            {
                outstandingBalance = ObjectRepository.digitalMyAccountPage.getTotalOutstandingBalance();
                isDiscounted = false;
                oneoffPayforInvalidFullBalance(outstandingBalance);
                ObjectRepository.writer.WriteToLog("The journey is --- Complete a full pay in full using a new card");
                ObjectRepository.digitalPayInFullJourney = ObjectRepository.digitalMyAccountPage.navigateToFullPayment();
                ObjectRepository.verifonePayPage = ObjectRepository.digitalPayInFullJourney.payFullAmountUsingNewCard();
                ObjectRepository.digitalPaymentConfirmation = ObjectRepository.verifonePayPage.completePaymentStep1();            
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("Complete a full pay in full using a new card test has failed", e);
                //BaseClasses.BaseClass.TearDown();
            }
        }


        [When(@"Complete a full pay in full using a saved card")]
        public void WhenCompleteAFullPayInFullUsingASavedCard()
        {
            try
            {
                outstandingBalance = ObjectRepository.digitalMyAccountPage.getTotalOutstandingBalance();
                isDiscounted = false;
                oneoffPayforInvalidFullBalance(outstandingBalance);
                ObjectRepository.writer.WriteToLog("The journey is --- Complete a full pay in full using a saved card");
                ObjectRepository.digitalPayInFullJourney = ObjectRepository.digitalMyAccountPage.navigateToFullPayment();
                ObjectRepository.verifoneSavedCardPayPage = ObjectRepository.digitalPayInFullJourney.payFullAmountUsingSavedCard();
                ObjectRepository.digitalPaymentConfirmation = ObjectRepository.verifoneSavedCardPayPage.completePayment();            
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("Complete a full pay in full using a saved card test has failed", e);
                //BaseClasses.BaseClass.TearDown();
            }            
        }

        
        [Then(@"Balance should be zero")]
        public void ThenBalanceShouldBeZero()
        {
            try
            {
                ObjectRepository.digitalMyAccountPage = ObjectRepository.digitalPaymentConfirmation.navigateToMyAccount();
                Thread.Sleep(2000);
                ObjectRepository.digitalMyAccountPage.refresh();
                double finalBalance = ObjectRepository.digitalMyAccountPage.getTotalOutstandingBalance();
                int refreshcount = 0;
                while ((finalBalance != 0) && (refreshcount < 3))
                {
                    Thread.Sleep(2000);
                    ObjectRepository.digitalMyAccountPage.refresh();
                    finalBalance = ObjectRepository.digitalMyAccountPage.getTotalOutstandingBalance();
                    refreshcount++;
                }

                string type = isDiscounted ? "Discounted Balance" : "Full Balance";
                if (finalBalance == 0)
                {
                    ObjectRepository.writer.WriteToLog("Full Payment of type " + type + " on account " + ObjectRepository.testAccount + " is successfull");
                    ObjectRepository.writer.WriteToLog("with account number " + ObjectRepository.testAccountNumber);
                }
                else
                {
                    ObjectRepository.writer.WriteToLog("Payment is unsuccessfull for Full Payment of type " + type + " on account " + ObjectRepository.testAccount);
                    ObjectRepository.writer.WriteToLog("with account number " + ObjectRepository.testAccountNumber);
                }
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("Balance should be zero test has failed", e);
                //BaseClasses.BaseClass.TearDown();
            }            
        }

        public void checkBalanceAndRefresh(double initalBalance)
        {
            int refreshcount = 0;
            double finalBalance;

            if (isDiscounted)
            {
                finalBalance = ObjectRepository.digitalMyAccountPage.getDiscountedBalance();
            }
            else
            {
                finalBalance = ObjectRepository.digitalMyAccountPage.getTotalOutstandingBalance();
            }
            while (initalBalance.Equals(finalBalance) && refreshcount < 3)
            {
                Thread.Sleep(2000);
                ObjectRepository.digitalPaymentConfirmation.refresh();
                if (isDiscounted)
                {
                    finalBalance = ObjectRepository.digitalMyAccountPage.getDiscountedBalance();
                }
                else
                {
                    finalBalance = ObjectRepository.digitalMyAccountPage.getTotalOutstandingBalance();
                }
                refreshcount++;
            }
            outstandingBalance = finalBalance;
        }

        public void oneoffPayforInvalidFullBalance(double outstandingBalance)
        {
            try
            {
                string pennies = outstandingBalance.ToString("F");
                pennies = pennies.Substring(pennies.IndexOf(".") + 1);
                if (pennies.EndsWith("2") || pennies.EndsWith("5") || pennies.EndsWith("7"))
                {
                    double PaymentAmount;
                    if (isDiscounted)
                    {
                        PaymentAmount = ObjectRepository.digitalMyAccountPage.getDiscountedBalance();
                        PaymentAmount = double.Parse(PaymentAmount.ToString().Substring(PaymentAmount.ToString().IndexOf("."))) - 0.01;
                    }
                    else
                    {
                        PaymentAmount = ObjectRepository.digitalMyAccountPage.getTotalOutstandingBalance();
                        PaymentAmount = double.Parse(PaymentAmount.ToString().Substring(PaymentAmount.ToString().IndexOf("."))) - 0.01;
                    }
                    ObjectRepository.digitalOneOffJourney = ObjectRepository.digitalMyAccountPage.navigateToOneOffPayment();
                    ObjectRepository.verifonePayPage = ObjectRepository.digitalOneOffJourney.completePaymentUsingNewCard(PaymentAmount);
                    ObjectRepository.digitalPaymentConfirmation = ObjectRepository.verifonePayPage.completePaymentStep1();
                    ObjectRepository.digitalPaymentConfirmation.navigateToMyAccount();
                    Thread.Sleep(2000);
                    ObjectRepository.digitalPaymentConfirmation.refresh();
                    checkBalanceAndRefresh(outstandingBalance);
                }
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("oneoffPay for Invalid FullBalance test has failed", e);
                //BaseClasses.BaseClass.TearDown();
            }
        }

        [Then(@"Acconunt status should not be '(.*)'")]
        public void ThenAcconuntStatusShouldNotBe(string planInPlace)
        {
            try
            {
                string accountStatus = ObjectRepository.digitalMyAccountPage.getAccountStatus();
                Assert.IsFalse(accountStatus.Equals(planInPlace));
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("Plan should be closed and plan details should not be shown", e);
            }
        }

        [When(@"I navigate to pay in full first page")]
        public void WhenINavigateToPayInFullFirstPage()
        {
            try
            {
                ObjectRepository.digitalPayInFullJourney =  ObjectRepository.digitalMyAccountPage.navigateToFullPayment();
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("I navigate to pay in full first page", e);
            }
        }

        [When(@"Click on Back button in first page")]
        public void WhenClickOnBackButtonInFirstPage()
        {
            try
            {
                ObjectRepository.digitalMyAccountPage = ObjectRepository.digitalPayInFullJourney.clickBackButtonInFirstPage();
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("I navigate to pay in full first page", e);
            }
        }

        [When(@"I navigate to pay in full second page and back to MyAccount")]
        public void WhenINavigateToPayInFullSecondPageAndBackToMyAccount()
        {
            try
            {
                ObjectRepository.writer.WriteToLog("The journey is --- Complete a full pay in full using a saved card");
                ObjectRepository.digitalPayInFullJourney = ObjectRepository.digitalMyAccountPage.navigateToFullPayment();
                ObjectRepository.digitalMyAccountPage = ObjectRepository.digitalPayInFullJourney.navigateToSecondPageAndBackToMyAccount();
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("I navigate to pay in full first page", e);
            }
        }


        [Then(@"Content '(.*)' warning Credit Cards are not accepted should be shown")]
        public void ThenContentWarningCreditCardsAreNotAcceptedShouldBeShown(string creditCardContentForHeader)
        {
            try
            {
                string headerContent = ObjectRepository.digitalPayInFullJourney.getHeaderContent();
                Assert.IsTrue(headerContent.Contains(creditCardContentForHeader));
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("I navigate to pay in full first page", e);
            }
        }

        [When(@"User navigates to statements page and searches for the full payment")]
        public void WhenUserNavigatesToStatementsPageAndSearchesForTheFullPayment()
        {
            try
            {
                
                ObjectRepository.writer.WriteToLog("Navigating to Statements page and searching for a transaction");                
                ObjectRepository.digitalStatements = ObjectRepository.digitalMyAccountPage.navigateToStatementsPage();
                ObjectRepository.digitalStatements.searchTransactionsBetweenDates((DateTime.Now.AddYears(-4)).ToString("dd/MM/yyyy"), (DateTime.Now.AddYears(4)).ToString("dd/MM/yyyy"));
                ObjectRepository.digitalStatements.searchForATransactionInSearchBox(outstandingBalance.ToString("0.00"));
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog("User navigates to statements page and searches for the payment");
                ObjectRepository.writer.WriteToLog(e.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
            }
        }

        [Then(@"Full payment should be shown in statements page")]
        public void ThenFullPaymentShouldBeShownInStatementsPage()
        {
            try
            {
                string searchData = ObjectRepository.digitalStatements.getDataFromFirstRowOfDataTable();
                Assert.IsTrue(searchData.Contains(outstandingBalance.ToString("0.00")));
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

        [When(@"I click on terms and conditions link in pay in full journey")]
        public void WhenIClickOnTermsAndConditionsLinkInPayInFullJourney()
        {
            ObjectRepository.writer.WriteToLog("The journey is --- I click on terms and conditions link in pay in full journey");
            ObjectRepository.digitalTermsAndConditions = ObjectRepository.digitalPayInFullJourney.clickOnTermsAndConditionsLink();
        }

        [When(@"I create payment errors in Verifone till the payment is failed")]
        public void WhenICreatePaymentErrorsInVerifoneTillThePaymentIsFailed()
        {
            try
            {
                outstandingBalance = ObjectRepository.digitalMyAccountPage.getTotalOutstandingBalance();
                ObjectRepository.digitalPayInFullJourney = ObjectRepository.digitalMyAccountPage.navigateToFullPayment();
                ObjectRepository.verifonePayPage = ObjectRepository.digitalPayInFullJourney.payFullAmountUsingNewCard();
                ObjectRepository.digitalPaymentError = ObjectRepository.verifonePayPage.createPaymentErrorUsingInvalidData();
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("Complete a full pay in full using a new card test has failed", e);
                //BaseClasses.BaseClass.TearDown();
            }
        }

        [Then(@"Balance should not be zero")]
        public void ThenBalanceShouldNotBeZero()
        {
            try
            {
                ObjectRepository.digitalMyAccountPage = ObjectRepository.digitalPaymentError.navigateToMyAccount();
                Thread.Sleep(2000);
                ObjectRepository.digitalMyAccountPage.refresh();
                double finalBalance = ObjectRepository.digitalMyAccountPage.getTotalOutstandingBalance();
                Assert.IsFalse(finalBalance == 0);                
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("Balance should not be zero test has failed", e);
                //BaseClasses.BaseClass.TearDown();
            }
        }

        [Then(@"Full payment should not be shown in statements page")]
        public void ThenFullPaymentShouldNotBeShownInStatementsPage()
        {
            try
            {
                string searchData = ObjectRepository.digitalStatements.getDataFromFirstRowOfDataTable();
                Assert.IsFalse(searchData.Contains(outstandingBalance.ToString("0.00")));
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

    }
}
