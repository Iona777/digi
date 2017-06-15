using System;
using System.Net;
using System.Threading;
using TechTalk.SpecFlow;
using Digital.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Digital.ComponentHelper;

namespace Digital
{
    [Binding]
    public class DigitalMyAccountTestsSteps
    {
        public const string DirectDebitPlan = "Direct Debit Plan";
        public const string PayInFull = "Pay in full";
        public const string OneOffPayment = "One off payment";
        public string pdfURL;

        [Then(@"All the payment options should be available")]
        public void ThenAllThePaymentOptionsShouldBeAvailable()
        {
            try
            {
                string availablePaymentOptions = ObjectRepository.digitalMyAccountPage.getAllThePaymentOptionsAvailable();
                Assert.IsTrue(availablePaymentOptions.Contains(DirectDebitPlan) && availablePaymentOptions.Contains(PayInFull) && availablePaymentOptions.Contains(OneOffPayment));
                ObjectRepository.writer.WriteToLog("Payment Options available for account - " + ObjectRepository.testAccount + " are " + DirectDebitPlan + ", " + PayInFull + " and " + OneOffPayment);
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog("All the payment options should be available test has failed");
                ObjectRepository.writer.WriteToLog(e.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("Payment Options should be available test has failed due to exception", e);
            }            
        }

        [Then(@"Discount details should be shown below the payment plan table")]
        public void ThenDiscountDetailsShouldBeShownBelowThePaymentPlanTable()
        {
            try
            {
                string paymentPlanDetails = ObjectRepository.digitalMyAccountPage.getPaymentPlanDetails();                
                string acceptedDiscount = ObjectRepository.digitalMyAccountPage.getAcceptedDiscount();
                ObjectRepository.writer.WriteToLog("PaymentPlan details are - InstalmentAmount = " + (paymentPlanDetails.Split(':'))[0] + " and PaymentFrequency = " + (paymentPlanDetails.Split(':'))[1] + " and PaymentMethod = " + (paymentPlanDetails.Split(':'))[2]);
                ObjectRepository.writer.WriteToLog("Accepted Discount on the plan is £" + acceptedDiscount);
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog("Discount details should be shown below the payment plan table test has failed");
                ObjectRepository.writer.WriteToLog(e.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("Discount details should be shown below the payment plan table test has failed due to exception", e);
            }            
        }

        [Then(@"For an account with closed status payment options should not be shown")]
        public void ThenForAnAccountWithClosedStatusPaymentOptionsShouldNotBeShown()
        {
            try
            {
                string accountStatus = ObjectRepository.digitalMyAccountPage.getAccountStatus();
                string paymentOptions = ObjectRepository.digitalMyAccountPage.getAllThePaymentOptionsAvailable();
                Assert.IsTrue(paymentOptions.Equals(""));
                ObjectRepository.writer.WriteToLog("There are no payment options available for the closed account");
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog("For an account with closed status payment options should not be shown test has failed");
                ObjectRepository.writer.WriteToLog(e.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("For an account with closed status payment options should not be shown test has failed due to exception", e);
            }            
        }

        [Then(@"If existing plan is DD then plan button should not be shown or else it should be shown")]
        public void ThenIfExistingPlanIsDDThenPlanButtonShouldNotBeShownOrElseItShouldBeShown()
        {
            try
            {                
                string paymentMethod = (ObjectRepository.digitalMyAccountPage.getPaymentPlanDetails()).Split(':')[2];
                string availablePaymentOptions = ObjectRepository.digitalMyAccountPage.getAllThePaymentOptionsAvailable();
                string acceptedDiscount = ObjectRepository.digitalMyAccountPage.getAcceptedDiscount();
                if (paymentMethod.Trim().Equals("Direct Debit"))
                {
                    Assert.IsTrue(!availablePaymentOptions.Contains(DirectDebitPlan) && availablePaymentOptions.Contains(PayInFull) && availablePaymentOptions.Contains(OneOffPayment));
                    ObjectRepository.writer.WriteToLog("Payment Options available for account - " + ObjectRepository.testAccount + " are " + PayInFull + " and " + OneOffPayment);
                    ObjectRepository.writer.WriteToLog("Accepted Discount on the plan is £" + acceptedDiscount);
                }
                else
                {
                    Assert.IsTrue(availablePaymentOptions.Contains(DirectDebitPlan) && availablePaymentOptions.Contains(PayInFull) && availablePaymentOptions.Contains(OneOffPayment));
                    ObjectRepository.writer.WriteToLog("Payment Options available for account - " + ObjectRepository.testAccount + " are " + DirectDebitPlan + ", " + PayInFull + " and " + OneOffPayment);
                    ObjectRepository.writer.WriteToLog("Accepted Discount on the plan is £" + acceptedDiscount);
                }                
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog("Discount details should be shown below the payment plan table test has failed");
                ObjectRepository.writer.WriteToLog(e.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("Discount details should be shown below the payment plan table test has failed due to exception", e);
            }
        }

        [When(@"User navigates to statements page and searches for payments between dates '(.*)' to '(.*)'")]
        public void WhenUserNavigatesToStatementsPageAndSearchesForPaymentsBetweenDatesTo(string p0, string p1)
        {
            try
            {
                ObjectRepository.writer.WriteToLog("Navigating to Statements page and searching for a transaction");
                ObjectRepository.digitalStatements = ObjectRepository.digitalMyAccountPage.navigateToStatementsPage();
                ObjectRepository.digitalStatements.searchTransactionsBetweenDates(p0, p1);
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog("User navigates to statements page and searches for the payment");
                ObjectRepository.writer.WriteToLog(e.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
            }
        }

        [When(@"I download the pdf")]
        public void WhenIDownloadThePdf()
        {
            pdfURL = ObjectRepository.digitalStatements.getDownloadPdfUrl();
            ObjectRepository.digitalStatements.downloadPdf();
            Thread.Sleep(1000);
        }

        [Then(@"Pdf should be downloaded and closed")]
        public void ThenPdfShouldBeDownloadedAndClosed()
        {
            try
            {
                ObjectRepository.Driver.SwitchTo().Window(ObjectRepository.Driver.WindowHandles[1]);
                string embeddedPdfXpath = "//embed[@src=\"" + pdfURL + "\"]";
                DataEntryHelper.WaitForElementByXpath(embeddedPdfXpath);
                string newUrl = ObjectRepository.Driver.Url;
                ObjectRepository.Driver.Close();
                ObjectRepository.Driver.SwitchTo().Window(ObjectRepository.Driver.WindowHandles[0]);
                Assert.IsTrue(pdfURL.Equals(newUrl));
            }
            catch (Exception e)
            {
                ObjectRepository.Driver.Close();
                ObjectRepository.Driver.SwitchTo().Window(ObjectRepository.Driver.WindowHandles[0]);
                ObjectRepository.writer.WriteToLog("Pdf should be downloaded and closed test has failed");
                ObjectRepository.writer.WriteToLog(e.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("Pdf should be downloaded and closed test has failed due to exception", e);
            }
        }
    }
}
