using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Digital.Interfaces;
using Digital.PageObject;
using Digital.PageObject;
using Digital.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Digital.Settings
{
    public class ObjectRepository
    {
        public static IConfig Config { get; set; }
        public static IWebDriver Driver { get; set; }

        public static qmsAccountQuery_Login loginPage;
        public static qmsAccountQuery_Account accountPage;
        public static qmsAccountQuery_Account_dddddddd resulltPage;

        public static digitalHome digitalHomePage;
        public static digitalLogin digitalLoginPage;
        public static digitalNavigationBar digitalNavigationBar;
        public static digitalRegister digitalRegister;
        public static digitalMyAccount digitalMyAccountPage;
        public static digitalOneOffPayment digitalOneOffJourney;
        public static digitalPayInFull digitalPayInFullJourney;
        public static digitalDirectDebitPlan digitalDirectDebitJourney;
        public static digitalDebitCardPlan digitalDebitCardPlan;
        public static digitalBudgetCalculator digitalBudgetCalculator;
        public static digitalStatements digitalStatements;
        public static digitalDDGuarantee theDigitalDDGuaranteePage;

        //New pages
        public static digitalBudgetCalculatorPage       theDigitalBudgetCalculatorPage;
        public static digitalBudgetCalc_DependantsPage  theDigitalBudgetCalc_DependantsPage;
        public static digitalBudgetCalc_ExpenditurePage theDigitalBudgetCalc_ExpenditurePage;
        public static digitalBudgetCalc_IncomePage      theDigitalBudgetCalc_IncomePage;
        public static digitalBudgetCalc_Step4Page       theDigitalBudgetCalc_Step4Page;
        public static digitalMyAccountPage              newDigitalMyAccountPage;
        public static digitalNavigationBarPage          newDigitalNavigationBarPage;
        public static digitalRegisterPage               newDigitalRegisterPage;

        //Logged out journey pages
        public static digital_LO_OneOffPaymentPage1     theDigital_LO_OneOffPaymentPage1;
        public static digital_LO_PaymentOptionsPage1    theDigital_LO_PaymentOptionsPage1;
        public static digital_LO_PaymentOptionsPage2    theDigital_LO_PaymentOptionsPage2;
        public static digital_LO_OneOffPaymentPage2_Review theDigital_LO_PaymentOptionsPage2_Review;
        public static digital_LO_PaymentConfirmation    theDigital_LO_PaymentConfirmation;
        public static digital_LO_DirectDebitPlanPage1    theDigital_LO_DirectDebitPlanPage1;
        public static digital_LO_DirectDebitPage2_Review theDigital_LO_DirectDebitPage2_ReviewPage;
        public static digital_LO_DDConfirmation         theDigital_LO_DDConfirmationPage;
        public static digital_LO_PayInFullPage1         theDigital_LO_PayInFullPage1;

        //


        public static verifonePayPage verifonePayPage;        
        public static verifoneSavedCardPayPage verifoneSavedCardPayPage;
        public static verifonePlanPage verifonePlanPage;
        public static digitalPaymentConfirmation digitalPaymentConfirmation;
        public static digitalPaymentCancellation digitalPaymentCancellation;
        public static digitalPaymentError digitalPaymentError;
        public static digitalPlanConfirmation digitalPlanConfirmation;
        public static digitalTermsAndConditions digitalTermsAndConditions;
        public static Logger writer;
        public static bool isDiscountAvailable;
        public static bool areTokensEnabled = false; //change this value to enable tokens tests, if tokens are not enabled then enabling this will fail the tests.

        //Umbraco page
        public static digitalUmbracoLogin digitalUmbracoLogin;
        public static digitalUmbracoHome digitalUmbracoHome;
        public static digitalUmbracoMemberDetails digitalUmbracoMemberDetails;        

        public static string testAccount;
        public static string testAccountNumber;
        public static string accountStatus;

        public static TestContext digitalTestContext;

        public static Boolean acceptedCookieTerms;        
    }
}
