using System;
using TechTalk.SpecFlow;
using Digital.Settings;
using System.Threading;
using Digital.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Digital
{
    [Binding]
    public class DigitalDDPlanSteps
    {
        double initialBalance;
        double paymentAmount;

        [When(@"I setup a Discounted Direct Debit plan on an account")]
        public void WhenISetupADiscountedDirectDebitPlanOnAnAccount()
        {
            try
            {
                initialBalance = ObjectRepository.digitalMyAccountPage.getTotalOutstandingBalance();
                paymentAmount = initialBalance / 100;
                if (paymentAmount == 0)
                {
                    paymentAmount = 0.01;
                }
                ObjectRepository.writer.WriteToLog("The journey is --- I setup a Discounted Direct Debit plan on an account");
                ObjectRepository.digitalDirectDebitJourney = ObjectRepository.digitalMyAccountPage.navigateToDirectDebitPlan();
                ObjectRepository.digitalPlanConfirmation = ObjectRepository.digitalDirectDebitJourney.setupDDplanWithDiscount(paymentAmount);
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("I setup a Discounted Direct Debit plan on an account test has failed", e);
                //BaseClasses.BaseClass.TearDown();
            }            
        }

        [When(@"I setup a Full Direct Debit plan on an account")]
        public void WhenISetupAFullDirectDebitPlanOnAnAccount()
        {
            try
            {
                initialBalance = ObjectRepository.digitalMyAccountPage.getTotalOutstandingBalance();
                paymentAmount = initialBalance / 100;
                if (paymentAmount == 0)
                {
                    paymentAmount = 0.01;
                }
                ObjectRepository.writer.WriteToLog("The journey is --- I setup a Full Direct Debit plan on an account");
                ObjectRepository.digitalDirectDebitJourney = ObjectRepository.digitalMyAccountPage.navigateToDirectDebitPlan();
                ObjectRepository.digitalPlanConfirmation = ObjectRepository.digitalDirectDebitJourney.setupDDplanWithoutDiscount(paymentAmount);
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("I setup a Full Direct Debit plan on an account test has failed", e);
            }            
        }

        [When(@"I setup a '(.*)' Direct Debit plan using '(.*)' '(.*)' '(.*)' and '(.*)'on an account")]
        public void WhenISetupADirectDebitPlanUsingAndOnAnAccount(string typeOfPlan, string planFrequency, string accountHolderName, int accountNumber, string sortCode)
        {
            initialBalance = ObjectRepository.digitalMyAccountPage.getTotalOutstandingBalance();
            paymentAmount = initialBalance / 100;
            if (paymentAmount == 0)
            {
                paymentAmount = 0.01;
            }            
            ObjectRepository.digitalDirectDebitJourney = ObjectRepository.digitalMyAccountPage.navigateToDirectDebitPlan();
            if (typeOfPlan.Equals("Discounted"))
            {
                ObjectRepository.writer.WriteToLog("The journey is --- I setup a Discounted Direct Debit plan on an account");
                ObjectRepository.digitalPlanConfirmation = ObjectRepository.digitalDirectDebitJourney.setupDDplanWithDiscount(paymentAmount, planFrequency, accountHolderName, accountNumber, sortCode.Replace("'",""));
            }
            else
            {
                ObjectRepository.writer.WriteToLog("The journey is --- I setup a Full Direct Debit plan on an account");
                ObjectRepository.digitalPlanConfirmation = ObjectRepository.digitalDirectDebitJourney.setupDDplanWithoutDiscount(paymentAmount, planFrequency, accountHolderName, accountNumber, sortCode.Replace("'", ""));
            }
            
        }


    }
}
