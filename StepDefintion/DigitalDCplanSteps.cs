using System;
using TechTalk.SpecFlow;
using Digital.Settings;
using System.Threading;
using Digital.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Digital
{
    [Binding]
    public class DigitalDCplanSteps
    {
        double initialBalance;
        double paymentAmount;        

        [When(@"I setup a Discounted Debit Card plan using a new card")]
        public void WhenISetupADiscountedDebitCardPlanUsingANewCard()
        {
            try
            {
                initialBalance = ObjectRepository.digitalMyAccountPage.getDiscountedBalance();
                paymentAmount = getPaymentAmount(initialBalance);
                ObjectRepository.writer.WriteToLog("The journey is --- I setup a Discounted Debit Card plan using a new card");
                ObjectRepository.digitalDebitCardPlan = ObjectRepository.digitalMyAccountPage.navigateToDebitCardPlan();
                ObjectRepository.verifonePlanPage = ObjectRepository.digitalDebitCardPlan.discountedDCPlanSetupUsingNewCard(paymentAmount);
                ObjectRepository.digitalPlanConfirmation = ObjectRepository.verifonePlanPage.completePlanSetup();
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);                
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("I setup a Discounted Debit Card plan using a new card test has failed", e);
                //BaseClasses.BaseClass.TearDown();
            }            
        }

        [When(@"I setup a Discounted Debit Card plan using a saved card")]
        public void WhenISetupADiscountedDebitCardPlanUsingASavedCard()
        {
            try
            {
                initialBalance = ObjectRepository.digitalMyAccountPage.getDiscountedBalance();
                paymentAmount = getPaymentAmount(initialBalance);
                ObjectRepository.writer.WriteToLog("The journey is --- I setup a Discounted Debit Card plan using a saved card");
                ObjectRepository.digitalDebitCardPlan = ObjectRepository.digitalMyAccountPage.navigateToDebitCardPlan();
                ObjectRepository.digitalPlanConfirmation = ObjectRepository.digitalDebitCardPlan.discountedDCPlanSetupUsingSavedCard(paymentAmount);
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("I setup a Discounted Debit Card plan using a saved card test has failed", e);
                //BaseClasses.BaseClass.TearDown();
            }            
        }

        [When(@"I setup a Full Debit Card plan using a new card")]
        public void WhenISetupAFullDebitCardPlanUsingANewCard()
        {
            try
            {
                initialBalance = ObjectRepository.digitalMyAccountPage.getTotalOutstandingBalance();
                paymentAmount = getPaymentAmount(initialBalance);
                ObjectRepository.writer.WriteToLog("The journey is --- I setup a Full Debit Card plan using a new card");
                ObjectRepository.digitalDebitCardPlan = ObjectRepository.digitalMyAccountPage.navigateToDebitCardPlan();
                ObjectRepository.verifonePlanPage = ObjectRepository.digitalDebitCardPlan.fullDCPlanSetupUsingNewCard(paymentAmount);
                ObjectRepository.digitalPlanConfirmation = ObjectRepository.verifonePlanPage.completePlanSetup();
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("I setup a Full Debit Card plan using a new card test has failed", e);
                //BaseClasses.BaseClass.TearDown();
            }            
        }

        [When(@"I setup a Full Debit Card plan using a saved card")]
        public void WhenISetupAFullDebitCardPlanUsingASavedCard()
        {
            try
            {
                initialBalance = ObjectRepository.digitalMyAccountPage.getTotalOutstandingBalance();
                paymentAmount = getPaymentAmount(initialBalance);
                ObjectRepository.writer.WriteToLog("The journey is --- I setup a Full Debit Card plan using a saved card");
                ObjectRepository.digitalDebitCardPlan = ObjectRepository.digitalMyAccountPage.navigateToDebitCardPlan();
                ObjectRepository.digitalPlanConfirmation = ObjectRepository.digitalDebitCardPlan.fullDCPlanSetupUsingSavedCard(paymentAmount);
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("I setup a Full Debit Card plan using a saved card test has failed", e);
                //BaseClasses.BaseClass.TearDown();
            }            
        }

        [Then(@"MyAccount page should show plan details")]
        public void ThenMyAccountPageShouldShowPlanDetails()
        {
            try
            {
                ObjectRepository.digitalMyAccountPage = ObjectRepository.digitalPlanConfirmation.navigateToMyAccount();
                //Thread.Sleep(2000);
                ObjectRepository.digitalMyAccountPage.refresh();
                String planDetails = ObjectRepository.digitalMyAccountPage.getPlanDetails();
                int refreshcount = 0;
                while ((planDetails.Equals("None")) && refreshcount < 3)
                {
                    //Thread.Sleep(2000);
                    ObjectRepository.digitalMyAccountPage.refresh();
                    planDetails = ObjectRepository.digitalMyAccountPage.getPlanDetails();
                    refreshcount++;
                }


                if (planDetails.Equals("None"))
                {
                    ObjectRepository.writer.WriteToLog("Plan setup is not successful on account " + ObjectRepository.testAccount);
                    ObjectRepository.writer.WriteToLog("with account number " + ObjectRepository.testAccountNumber);
                    ObjectRepository.digitalNavigationBar.logout();
                    Assert.Fail("MyAccount page should show plan details, test has failed");
                }
                else
                {
                    String[] details = planDetails.Split(',');
                    ObjectRepository.writer.WriteToLog("Plan setup is successfull on account " + ObjectRepository.testAccount);
                    ObjectRepository.writer.WriteToLog("with account number " + ObjectRepository.testAccountNumber);
                    ObjectRepository.writer.WriteToLog("Plan Details are as follows");
                    ObjectRepository.writer.WriteToLog("Plan Type is - " + details[2]);
                    ObjectRepository.writer.WriteToLog("Plan Frequency is - " + details[1]);
                    ObjectRepository.writer.WriteToLog("Installment Amount is - " + details[0]);
                }
            }catch(Exception e){
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("MyAccount page should show plan details, test has failed", e);
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
                
    }
}
