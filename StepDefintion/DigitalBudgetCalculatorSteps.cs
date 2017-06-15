using System;
using System.Data;
using TechTalk.SpecFlow;
using Digital.Settings;
using Digital.ComponentHelper;
using Digital.ComponentHelper;
using System.Threading;
using Digital.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Digital.PageObject;

namespace Digital
{
    [Binding]
    public class DigitalBudgetCalculatorSteps
    {
        //Class variables
        int totalIncome;

        string budgetCalcPage_TotalIncome;
        string myAccountPage_TotalIncome;
        string frequencyOfBC;

        //Class constructor
        public DigitalBudgetCalculatorSteps()
        {
           
            ObjectRepository.theDigitalBudgetCalc_DependantsPage    = new digitalBudgetCalc_DependantsPage(ObjectRepository.Driver);
            ObjectRepository.theDigitalBudgetCalc_ExpenditurePage   = new digitalBudgetCalc_ExpenditurePage(ObjectRepository.Driver);
            ObjectRepository.theDigitalBudgetCalc_IncomePage        = new digitalBudgetCalc_IncomePage(ObjectRepository.Driver);
            ObjectRepository.theDigitalBudgetCalc_Step4Page         = new digitalBudgetCalc_Step4Page(ObjectRepository.Driver);

 
        }


        [When(@"Complete a Budget Calculator journey with Monthly Frequency")]
        public void WhenCompleteABudgetCalculatorJourneyWithMonthlyFrequency()
        {
            try
            {
                totalIncome = ObjectRepository.digitalMyAccountPage.getTotalIncome();
                if (totalIncome == 0)
                {
                    totalIncome = 5000;
                }
                else
                {
                    totalIncome = totalIncome/100 + 1000;
                }
                frequencyOfBC = "Monthly";
                ObjectRepository.writer.WriteToLog("The journey is --- Complete a Budget Calculator journey with Monthly Frequency");
                ObjectRepository.digitalBudgetCalculator = ObjectRepository.digitalMyAccountPage.navigateToBudgetCalculator();
                ObjectRepository.digitalMyAccountPage = ObjectRepository.digitalBudgetCalculator.completeBCWithMonthlyFrequency(totalIncome);                
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("Complete a Budget Calculator journey with Monthly Frequency test has failed", e);
                //BaseClasses.BaseClass.TearDown();
            }
        }

        [When(@"Complete a Budget Calculator journey with FourWeekly Frequency")]
        public void WhenCompleteABudgetCalculatorJourneyWithFourWeeklyFrequency()
        {
            try
            {
                totalIncome = ObjectRepository.digitalMyAccountPage.getTotalIncome();
                if (totalIncome == 0)
                {
                    totalIncome = 5000;
                }
                else
                {
                    totalIncome = totalIncome / 100 + 1000;
                }
                frequencyOfBC = "FourWeekly";
                ObjectRepository.writer.WriteToLog("The journey is --- Complete a Budget Calculator journey with FourWeekly Frequency");
                ObjectRepository.digitalBudgetCalculator = ObjectRepository.digitalMyAccountPage.navigateToBudgetCalculator();
                ObjectRepository.digitalMyAccountPage = ObjectRepository.digitalBudgetCalculator.completeBCWithFourWeeklyFrequency(totalIncome);
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("Complete a Budget Calculator journey with FourWeekly Frequency test has failed", e);
                //BaseClasses.BaseClass.TearDown();
            }
        }

        [When(@"Complete a Budget Calculator journey with Fortnightly Frequency")]
        public void WhenCompleteABudgetCalculatorJourneyWithFortnightlyFrequency()
        {
            try
            {
                totalIncome = ObjectRepository.digitalMyAccountPage.getTotalIncome();
                if (totalIncome == 0)
                {
                    totalIncome = 5000;
                }
                else
                {
                    totalIncome = totalIncome / 100 + 1000;
                }
                frequencyOfBC = "FortNightly";
                ObjectRepository.writer.WriteToLog("The journey is --- Complete a Budget Calculator journey with Fortnightly Frequency");
                ObjectRepository.digitalBudgetCalculator = ObjectRepository.digitalMyAccountPage.navigateToBudgetCalculator();
                ObjectRepository.digitalMyAccountPage = ObjectRepository.digitalBudgetCalculator.completeBCWithFortnightlyFrequency(totalIncome);
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("Complete a Budget Calculator journey with Fortnightly Frequency test has failed", e);
               // BaseClasses.BaseClass.TearDown();
            }
        }

        [When(@"Complete a Budget Calculator journey with Weekly Frequency")]
        public void WhenCompleteABudgetCalculatorJourneyWithWeeklyFrequency()
        {
            try
            {
                totalIncome = ObjectRepository.digitalMyAccountPage.getTotalIncome();
                if (totalIncome == 0)
                {
                    totalIncome = 5000;
                }
                else
                {
                    totalIncome = totalIncome / 100 + 1000;
                }
                frequencyOfBC = "Weekly";
                ObjectRepository.writer.WriteToLog("The journey is --- Complete a Budget Calculator journey with Weekly Frequency");
                ObjectRepository.digitalBudgetCalculator = ObjectRepository.digitalMyAccountPage.navigateToBudgetCalculator();
                ObjectRepository.digitalMyAccountPage = ObjectRepository.digitalBudgetCalculator.completeBCWithWeeklyFrequency(totalIncome);
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("Complete a Budget Calculator journey with Weekly Frequency test has failed", e);
                //BaseClasses.BaseClass.TearDown();
            }
        }

        [When(@"I complete BC using '(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)' using Fortnightly frequency")]
        public void WhenICompleteBCUsingUsingFortnightlyFrequency(int p0, int p1, int p2, int p3, int p4, int p5, int p6, int p7, int p8, int p9, int p10, int p11, int p12, int p13, int p14, int p15, int p16, int p17, string p18)
        {
            frequencyOfBC = "Fortnightly";
            ObjectRepository.writer.WriteToLog("The journey is --- Complete a Budget Calculator journey with Fortnightly Frequency");
            ObjectRepository.digitalBudgetCalculator = ObjectRepository.digitalMyAccountPage.navigateToBudgetCalculator();
            ObjectRepository.digitalMyAccountPage = ObjectRepository.digitalBudgetCalculator.completeBCWithFortnightlyFrequency(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, int.Parse((p18.Split(';'))[0]), int.Parse((p18.Split(';'))[1]), int.Parse((p18.Split(';'))[2]), int.Parse((p18.Split(';'))[3]), int.Parse((p18.Split(';'))[4]), int.Parse((p18.Split(';'))[5]), int.Parse((p18.Split(';'))[6]));
        }

        [When(@"I complete a Budget Calculator using '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' using weekly frequency")]
        public void WhenICompleteABudgetCalculatorUsingUsingWeeklyFrequency(int p0, int p1, int p2, int p3, int p4, int p5, int p6, int p7, int p8, int p9, int p10, int p11, int p12, int p13, int p14, int p15, int p16, int p17, string p18)
        {
            frequencyOfBC = "Weekly";
            ObjectRepository.writer.WriteToLog("The journey is --- Complete a Budget Calculator journey with Weekly Frequency");
            ObjectRepository.digitalBudgetCalculator = ObjectRepository.digitalMyAccountPage.navigateToBudgetCalculator();
            ObjectRepository.digitalMyAccountPage = ObjectRepository.digitalBudgetCalculator.completeBCWithWeeklyFrequency(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, int.Parse((p18.Split(';'))[0]), int.Parse((p18.Split(';'))[1]), int.Parse((p18.Split(';'))[2]), int.Parse((p18.Split(';'))[3]), int.Parse((p18.Split(';'))[4]), int.Parse((p18.Split(';'))[5]), int.Parse((p18.Split(';'))[6]));
        }

        [When(@"I complete a Budget Calculator using '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' using FourWeekly frequency")]
        public void WhenICompleteABudgetCalculatorUsingUsingFourWeeklyFrequency(int p0, int p1, int p2, int p3, int p4, int p5, int p6, int p7, int p8, int p9, int p10, int p11, int p12, int p13, int p14, int p15, int p16, int p17, string p18)
        {
            frequencyOfBC = "FourWeekly";
            ObjectRepository.writer.WriteToLog("The journey is --- Complete a Budget Calculator journey with FourWeekly Frequency");
            ObjectRepository.digitalBudgetCalculator = ObjectRepository.digitalMyAccountPage.navigateToBudgetCalculator();
            ObjectRepository.digitalMyAccountPage = ObjectRepository.digitalBudgetCalculator.completeBCWithFourWeeklyFrequency(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, int.Parse((p18.Split(';'))[0]), int.Parse((p18.Split(';'))[1]), int.Parse((p18.Split(';'))[2]), int.Parse((p18.Split(';'))[3]), int.Parse((p18.Split(';'))[4]), int.Parse((p18.Split(';'))[5]), int.Parse((p18.Split(';'))[6]));
        }

        [When(@"I complete a Budget Calculator using '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' using Monthly frequency")]
        public void WhenICompleteABudgetCalculatorUsingUsingMonthlyFrequency(int p0, int p1, int p2, int p3, int p4, int p5, int p6, int p7, int p8, int p9, int p10, int p11, int p12, int p13, int p14, int p15, int p16, int p17, string p18)
        {
            frequencyOfBC = "Monthly";
            ObjectRepository.writer.WriteToLog("The journey is --- Complete a Budget Calculator journey with Monthly Frequency");
            ObjectRepository.digitalBudgetCalculator = ObjectRepository.digitalMyAccountPage.navigateToBudgetCalculator();
            ObjectRepository.digitalMyAccountPage = ObjectRepository.digitalBudgetCalculator.completeBCWithMonthlyFrequency(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, int.Parse((p18.Split(';'))[0]), int.Parse((p18.Split(';'))[1]), int.Parse((p18.Split(';'))[2]), int.Parse((p18.Split(';'))[3]), int.Parse((p18.Split(';'))[4]), int.Parse((p18.Split(';'))[5]), int.Parse((p18.Split(';'))[6]));
        }



        [Then(@"Income field in Budget Planner in MyAccount screen should be updated")]
        public void ThenIncomeFieldInBudgetPlannerInMyAccountScreenShouldBeUpdated()
        {
            //ObjectRepository.theDigitalBudgetCalculatorPage.GetNewdigitalMyAccountPage();
            myAccountPage_TotalIncome = ObjectRepository.newDigitalMyAccountPage.getTotalIncomeAsString(); ;

            Assert.IsTrue(CheckBudgetCalcIncomeAndMyAccountIncome());
        }
        public bool CheckBudgetCalcIncomeAndMyAccountIncome()
        {

            try
            {
                //string budgetCalcIncome = ObjectRepository.theDigitalBudgetCalculatorPage.GetTotalIncome();
                //string myAccountIncome  = ObjectRepository.newDigitalMyAccountPage.getTotalIncome().ToString();



                ObjectRepository.newDigitalMyAccountPage.refresh();
                int refreshcount = 0;

                while (!(budgetCalcPage_TotalIncome == myAccountPage_TotalIncome) && (refreshcount < 3))
                {
                    Thread.Sleep(2000);
                    ObjectRepository.newDigitalMyAccountPage.refresh();
                    myAccountPage_TotalIncome = ObjectRepository.newDigitalMyAccountPage.getTotalIncome().ToString();
                    refreshcount++;
                }

                if (budgetCalcPage_TotalIncome == myAccountPage_TotalIncome)
                {
                    ObjectRepository.writer.WriteToLog("CheckBudgetCalcIncomeAndMyAccountIncome completed successfully on account :- " + ObjectRepository.testAccount);
                    ObjectRepository.writer.WriteToLog("The account number is" + ObjectRepository.testAccountNumber);
                    return true;
                }
                else
                {
                    ObjectRepository.writer.WriteToLog("CheckBudgetCalcIncomeAndMyAccountIncome failed on account :- " + ObjectRepository.testAccount);
                    ObjectRepository.writer.WriteToLog("The account number is" + ObjectRepository.testAccountNumber);
                    return false;
                }


            }
            catch (Exception e)
            {

                ObjectRepository.writer.WriteToLog(e.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("Budget Planner in MyAccount screen should be updated test has failed", e);
            }
            
        }

        
        [Then(@"Budget Planner in MyAccount screen should be updated")]
        public void ThenBudgetPlannerInMyAccountScreenShouldBeUpdated()
        {
            try
            {
                ObjectRepository.digitalMyAccountPage.refresh();
                int refreshcount = 0;
                int newIncome = ObjectRepository.digitalMyAccountPage.getTotalIncome();
                while ((totalIncome == newIncome) && (refreshcount < 3))
                {
                    Thread.Sleep(2000);
                    ObjectRepository.digitalMyAccountPage.refresh();
                    newIncome = ObjectRepository.digitalMyAccountPage.getTotalIncome();
                    refreshcount++;
                }

                if (totalIncome != newIncome)
                {
                    switch (frequencyOfBC)
                    {
                        case "Monthly":
                            if (newIncome != 575 + totalIncome)
                            {
                                ObjectRepository.writer.WriteToLog("*********The calculation of Total Monthly Income is wrong********");
                            }
                            else
                            {
                                ObjectRepository.writer.WriteToLog("*********Total Monthly Income is calculated correctly********");
                            }
                            break;

                        case "FourWeekly":
                            if (newIncome != (575 * 1.08) + (totalIncome * 1.08 ))
                            {
                                ObjectRepository.writer.WriteToLog("*********The calculation of Total FourWeekly Income is wrong********");
                            }
                            else
                            {
                                ObjectRepository.writer.WriteToLog("*********Total FourWeekly Income is calculated correctly********");
                            }
                            break;

                        case "FortNightly":
                            if (newIncome != (575 * 2.17) + (totalIncome * 2.17))
                            {
                                ObjectRepository.writer.WriteToLog("*********The calculation of Total FortNightly Income is wrong********");
                            }
                            else
                            {
                                ObjectRepository.writer.WriteToLog("*********Total FortNightly Income is calculated correctly********");
                            }
                            break;

                        case "Weekly":
                            if (newIncome != (575 * 4.33) + (totalIncome * 4.33))
                            {
                                ObjectRepository.writer.WriteToLog("*********The calculation of Total Weekly Income is wrong********");
                            }
                            else
                            {
                                ObjectRepository.writer.WriteToLog("*********Total Weekly Income is calculated correctly********");
                            }
                            break;
                    }
                    ObjectRepository.writer.WriteToLog("Budget Calculator is completed successfully on account :- " + ObjectRepository.testAccount);
                    ObjectRepository.writer.WriteToLog("The account number is" + ObjectRepository.testAccountNumber);
                }
                else
                {
                    ObjectRepository.writer.WriteToLog("Budget Calculator setup has failed on account :- " + ObjectRepository.testAccount);
                    ObjectRepository.writer.WriteToLog("The account number is" + ObjectRepository.testAccountNumber);
                }
            }
            catch (Exception e)
            {
                ObjectRepository.writer.WriteToLog(e.InnerException.Message);
                ObjectRepository.writer.WriteToLog(e.StackTrace);
                ObjectRepository.digitalNavigationBar.logout();
                throw new AssertFailedException("Budget Planner in MyAccount screen should be updated test has failed", e);
                //BaseClasses.BaseClass.TearDown();
            }
        }


        [When(@"I navigate to the Budget Calculator Page")]
        public void WhenINavigateToTheBudgetCalculatorPage()
        {
            ObjectRepository.newDigitalMyAccountPage.navigateToBudgetCalcIncomePage();
        }


        //This version takes in the frequency as a parameter
        [When(@"Populate the Budget Calculator Income Page for '(.*)' Frequency using data from file '(.*)'")]
        public void WhenPopulateTheBudgetCalculatorIncomePageForFrequencyUsingDataFromFile(string frequency, string dataInputFile)
        {
            ObjectRepository.newDigitalMyAccountPage.navigateToBudgetCalcIncomePage();
            ObjectRepository.theDigitalBudgetCalc_IncomePage.populateIncomeFieldsFromFile(dataInputFile, frequency);

        }

        //This version takes in the frequency as a parameter
        [Then(@"Total Income is calculated correctly for '(.*)'")]
        public void ThenTotalIncomeIsCalculatedCorrectlyFor(string frequency)
        {
            Assert.IsTrue(ObjectRepository.theDigitalBudgetCalc_IncomePage.CalculateTotalIncome(frequency)
              == ObjectRepository.theDigitalBudgetCalc_IncomePage.GetTotalIncomeOnScreen(), "Checking total income");

            budgetCalcPage_TotalIncome = ObjectRepository.theDigitalBudgetCalc_IncomePage.CalculateTotalIncome(frequency);
            ObjectRepository.theDigitalBudgetCalc_IncomePage.clickContinueButton();
        }

        //This version takes in the frequency as a parameter
        [When(@"I populate the Budget Calculator Dependents and Expenditure Pages for '(.*)' Frequency using data from file '(.*)'")]
        public void WhenIPopulateTheBudgetCalculatorDependentsAndExpenditurePagesForFrequencyUsingDataFromFile(string frequency, string dataInputFile)
        {
            ObjectRepository.theDigitalBudgetCalc_DependantsPage.populateDependantsFieldsFromFile(dataInputFile);
            ObjectRepository.theDigitalBudgetCalc_DependantsPage.clickContinueButton();

            ObjectRepository.theDigitalBudgetCalc_ExpenditurePage.populateExpenditureFieldsFromFile(dataInputFile, frequency);
        }


        //This version takes the frequency ans a parameter
        [Then(@"Total Expenditure calculated correctly for '(.*)' Frequency")]
        public void ThenTotalExpenditureCalculatedCorrectlyForFrequency(string frequency)
        {
            Assert.IsTrue(ObjectRepository.theDigitalBudgetCalc_ExpenditurePage.CalculateTotalExpenditure(frequency)
               == ObjectRepository.theDigitalBudgetCalc_ExpenditurePage.GetTotalExpenditureOnScreen(), "Checking total expenditure");

            ObjectRepository.theDigitalBudgetCalc_ExpenditurePage.clickContinueButton();
            ObjectRepository.theDigitalBudgetCalc_Step4Page.clickContinueButton();

        }


    }
}
