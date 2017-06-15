Feature: DigitalBudgetCalculator
	In order to see my monthly total income and expenditure 
	As a customer
	I want to enter details of my monthly income and bills 

@mytag
Scenario: Complete a Budget Calculator journey with Monthly Frequency using data from file
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I read data from a file and Login using automation13@test.com/Bolder@11
	And  Populate the Budget Calculator Income Page for 'Monthly' Frequency using data from file 'Data\\BudgetCalc_Input1.xlsx'	                                                             
	Then Total Income is calculated correctly for 'Monthly'
	When I populate the Budget Calculator Dependents and Expenditure Pages for 'Monthly' Frequency using data from file 'Data\\BudgetCalc_Input1.xlsx'
	Then Total Expenditure calculated correctly for 'Monthly' Frequency
	And User is logged out and navigated to home page



Scenario: Complete a Budget Calculator journey with Fortnightly Frequency using data from file
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I read data from a file and Login using automation13@test.com/Bolder@11
	And  Populate the Budget Calculator Income Page for 'Fortnightly' Frequency using data from file 'Data\\BudgetCalc_Input1.xlsx'
	Then Total Income is calculated correctly for 'Fortnightly'
	When I populate the Budget Calculator Dependents and Expenditure Pages for 'Fortnightly' Frequency using data from file 'Data\\BudgetCalc_Input1.xlsx'
	Then Total Expenditure calculated correctly for 'Fortnightly' Frequency
	And User is logged out and navigated to home page


Scenario: Complete a Budget Calculator journey with FourWeekly Frequency using data from file
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I read data from a file and Login using automation13@test.com/Bolder@11
	And  Populate the Budget Calculator Income Page for 'FourWeekly' Frequency using data from file 'Data\\BudgetCalc_Input1.xlsx'
	Then Total Income is calculated correctly for 'FourWeekly'
	When I populate the Budget Calculator Dependents and Expenditure Pages for 'FourWeekly' Frequency using data from file 'Data\\BudgetCalc_Input1.xlsx'
	Then Total Expenditure calculated correctly for 'FourWeekly' Frequency
	And User is logged out and navigated to home page

Scenario: Complete a Budget Calculator journey with Weekly Frequency using data from file
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I read data from a file and Login using automation13@test.com/Bolder@11
	And  Populate the Budget Calculator Income Page for 'Weekly' Frequency using data from file 'Data\\BudgetCalc_Input1.xlsx'
	Then Total Income is calculated correctly for 'Weekly'
	When I populate the Budget Calculator Dependents and Expenditure Pages for 'Weekly' Frequency using data from file 'Data\\BudgetCalc_Input1.xlsx'
	Then Total Expenditure calculated correctly for 'Weekly' Frequency
	And User is logged out and navigated to home page


Scenario: Complete a Budget Calculator journey with Monthly Frequency
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login using automation13@test.com/Bolder@11
	And Complete a Budget Calculator journey with Monthly Frequency
	Then Budget Planner in MyAccount screen should be updated
	And User is logged out and navigated to home page


Scenario: Complete a Budget Calculator journey with FourWeekly Frequency
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login using automation14@test.com/Bolder@11
	And Complete a Budget Calculator journey with FourWeekly Frequency
	Then Budget Planner in MyAccount screen should be updated
	And User is logged out and navigated to home page

Scenario: Complete a Budget Calculator journey with Fortnightly Frequency
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login using automation15@test.com/Bolder@11
	And Complete a Budget Calculator journey with Fortnightly Frequency
	Then Budget Planner in MyAccount screen should be updated
	And User is logged out and navigated to home page

Scenario: Complete a Budget Calculator journey with Weekly Frequency
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login using automation16@test.com/Bolder@11
	And Complete a Budget Calculator journey with Weekly Frequency
	Then Budget Planner in MyAccount screen should be updated
	And User is logged out and navigated to home page

Scenario Outline: Complete a Budget Calculator using multiple sets of data with Weekly Frequency
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login using automation16@test.com/Bolder@11
	And I complete a Budget Calculator using '<Salary>' '<Income Support>' '<Child Benefit>' '<Job Seeker Allowance>' '<Pension>' '<Child Or Working Tax Credit>' '<Any other income>' '<Adults>' '<Childs 14-18>' '<Childs under 14>' '<Mortgage or Rent>' '<Gas>' '<Electricity>' '<Water>' '<Council Tax>' '<Maintenance Or Child Care>' '<Loans Or Credit Cards>' '<Insurance>' '<Rest All>' using weekly frequency
	Then Budget Planner in MyAccount screen should be updated
	And User is logged out and navigated to home page
Examples:
| Salary | Income Support | Child Benefit | Job Seeker Allowance | Pension | Child Or Working Tax Credit | Any other income | Adults | Childs 14-18 | Childs under 14 | Mortgage or Rent | Gas | Electricity | Water | Council Tax | Maintenance Or Child Care | Loans Or Credit Cards | Insurance | Rest All |
| 5000   | 100            | 25            | 20                   | 20      | 25                          | 25               | 2      | 1            | 2               | 600              | 50  | 50          | 50    | 25          | 25                        | 25                    | 25        | 50;50;25;20;15;20;25      |
| 4500   | 50             | 20            | 25                   | 25      | 20                          | 20               | 2      | 2            | 1               | 700              | 35  | 50          | 25    | 20          | 20                        | 25                    | 35        | 50;50;25;50;40;40;35      |
| 3500   | 20             | 50            | 15                   | 40      | 30                          | 20               | 2      | 1            | 1               | 800              | 100 | 40          | 20    | 45          | 50                        | 50                    | 35        | 25;40;30;20;15;35;20      |
| 2500   | 100            | 25            | 20                   | 20      | 25                          | 25               | 2      | 1            | 2               | 400              | 20  | 40          | 30    | 25          | 20                        | 20                    | 20        | 100;20;30;30;30;40;40      |
| 1500   | 200            | 50            | 50                   | 30      | 20                          | 40               | 1      | 1            | 1               | 700              | 20  | 25          | 25    | 20          | 20                        | 20                    | 15        | 25;30;50;25;30;45;40      |
| 3000   | 150            | 50            | 20                   | 25      | 15                          | 30               | 1      | 2            | 2               | 900              | 50  | 45          | 25    | 20          | 50                        | 20                    | 15        | 30;40;50;20;30;20;50      |
| 4000   | 50             | 250           | 25                   | 25      | 20                          | 15               | 2      | 1            | 1               | 800              | 100 | 50          | 50    | 20          | 20                        | 50                    | 40        | 50;20;20;20;30;40;50      |

Scenario Outline: Complete a BC multiple times with FortnightlyFrequency
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login using automation17@test.com/Bolder@11
	And I complete BC using '<Salary>','<Income Support>','<Child Benefit>','<Job Seeker Allowance>','<Pension>','<Child Or Working Tax Credit>','<Any other income>','<Adults>','<Childs 14-18>','<Childs under 14>','<Mortgage or Rent>','<Gas>','<Electricity>','<Water>','<Council Tax>','<Maintenance Or Child Care>','<Loans Or Credit Cards>','<Insurance>','<Rest All>' using Fortnightly frequency
	Then Budget Planner in MyAccount screen should be updated
	And User is logged out and navigated to home page
Examples:
| Salary | Income Support | Child Benefit | Job Seeker Allowance | Pension | Child Or Working Tax Credit | Any other income | Adults | Childs 14-18 | Childs under 14 | Mortgage or Rent | Gas | Electricity | Water | Council Tax | Maintenance Or Child Care | Loans Or Credit Cards | Insurance | Rest All |
| 5000   | 100            | 25            | 20                   | 20      | 25                          | 25               | 2      | 1            | 2               | 600              | 50  | 50          | 50    | 25          | 25                        | 25                    | 25        | 50;50;25;20;15;20;25      |
| 4500   | 50             | 20            | 25                   | 25      | 20                          | 20               | 2      | 2            | 1               | 700              | 35  | 50          | 25    | 20          | 20                        | 25                    | 35        | 50;50;25;50;40;40;35      |
| 3500   | 20             | 50            | 15                   | 40      | 30                          | 20               | 2      | 1            | 1               | 800              | 100 | 40          | 20    | 45          | 50                        | 50                    | 35        | 25;40;30;20;15;35;20      |
| 2500   | 100            | 25            | 20                   | 20      | 25                          | 25               | 2      | 1            | 2               | 400              | 20  | 40          | 30    | 25          | 20                        | 20                    | 20        | 100;20;30;30;30;40;40      |
| 1500   | 200            | 50            | 50                   | 30      | 20                          | 40               | 1      | 1            | 1               | 700              | 20  | 25          | 25    | 20          | 20                        | 20                    | 15        | 25;30;50;25;30;45;40      |
| 3000   | 150            | 50            | 20                   | 25      | 15                          | 30               | 1      | 2            | 2               | 900              | 50  | 45          | 25    | 20          | 50                        | 20                    | 15        | 30;40;50;20;30;20;50      |
| 4000   | 50             | 250           | 25                   | 25      | 20                          | 15               | 2      | 1            | 1               | 800              | 100 | 50          | 50    | 20          | 20                        | 50                    | 40        | 50;20;20;20;30;40;50      |

Scenario Outline: Complete a Budget Calculator using multiple sets of data with FourWeekly Frequency
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login using automation18@test.com/Bolder@11
	And I complete a Budget Calculator using '<Salary>' '<Income Support>' '<Child Benefit>' '<Job Seeker Allowance>' '<Pension>' '<Child Or Working Tax Credit>' '<Any other income>' '<Adults>' '<Childs 14-18>' '<Childs under 14>' '<Mortgage or Rent>' '<Gas>' '<Electricity>' '<Water>' '<Council Tax>' '<Maintenance Or Child Care>' '<Loans Or Credit Cards>' '<Insurance>' '<Rest All>' using FourWeekly frequency
	Then Budget Planner in MyAccount screen should be updated
	And User is logged out and navigated to home page
Examples:
| Salary | Income Support | Child Benefit | Job Seeker Allowance | Pension | Child Or Working Tax Credit | Any other income | Adults | Childs 14-18 | Childs under 14 | Mortgage or Rent | Gas | Electricity | Water | Council Tax | Maintenance Or Child Care | Loans Or Credit Cards | Insurance | Rest All |
| 5000   | 100            | 25            | 20                   | 20      | 25                          | 25               | 2      | 1            | 2               | 600              | 50  | 50          | 50    | 25          | 25                        | 25                    | 25        | 50;50;25;20;15;20;25      |
| 4500   | 50             | 20            | 25                   | 25      | 20                          | 20               | 2      | 2            | 1               | 700              | 35  | 50          | 25    | 20          | 20                        | 25                    | 35        | 50;50;25;50;40;40;35      |
| 3500   | 20             | 50            | 15                   | 40      | 30                          | 20               | 2      | 1            | 1               | 800              | 100 | 40          | 20    | 45          | 50                        | 50                    | 35        | 25;40;30;20;15;35;20      |
| 2500   | 100            | 25            | 20                   | 20      | 25                          | 25               | 2      | 1            | 2               | 400              | 20  | 40          | 30    | 25          | 20                        | 20                    | 20        | 100;20;30;30;30;40;40      |
| 1500   | 200            | 50            | 50                   | 30      | 20                          | 40               | 1      | 1            | 1               | 700              | 20  | 25          | 25    | 20          | 20                        | 20                    | 15        | 25;30;50;25;30;45;40      |
| 3000   | 150            | 50            | 20                   | 25      | 15                          | 30               | 1      | 2            | 2               | 900              | 50  | 45          | 25    | 20          | 50                        | 20                    | 15        | 30;40;50;20;30;20;50      |
| 4000   | 50             | 250           | 25                   | 25      | 20                          | 15               | 2      | 1            | 1               | 800              | 100 | 50          | 50    | 20          | 20                        | 50                    | 40        | 50;20;20;20;30;40;50      |

Scenario Outline: Complete a Budget Calculator using multiple sets of data with Monthly Frequency
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login using automation19@test.com/Bolder@11
	And I complete a Budget Calculator using '<Salary>' '<Income Support>' '<Child Benefit>' '<Job Seeker Allowance>' '<Pension>' '<Child Or Working Tax Credit>' '<Any other income>' '<Adults>' '<Childs 14-18>' '<Childs under 14>' '<Mortgage or Rent>' '<Gas>' '<Electricity>' '<Water>' '<Council Tax>' '<Maintenance Or Child Care>' '<Loans Or Credit Cards>' '<Insurance>' '<Rest All>' using Monthly frequency
	Then Budget Planner in MyAccount screen should be updated
	And User is logged out and navigated to home page
Examples:
| Salary | Income Support | Child Benefit | Job Seeker Allowance | Pension | Child Or Working Tax Credit | Any other income | Adults | Childs 14-18 | Childs under 14 | Mortgage or Rent | Gas | Electricity | Water | Council Tax | Maintenance Or Child Care | Loans Or Credit Cards | Insurance | Rest All |
| 5000   | 100            | 25            | 20                   | 20      | 25                          | 25               | 2      | 1            | 2               | 600              | 50  | 50          | 50    | 25          | 25                        | 25                    | 25        | 50;50;25;20;15;20;25      |
| 4500   | 50             | 20            | 25                   | 25      | 20                          | 20               | 2      | 2            | 1               | 700              | 35  | 50          | 25    | 20          | 20                        | 25                    | 35        | 50;50;25;50;40;40;35      |
| 3500   | 20             | 50            | 15                   | 40      | 30                          | 20               | 2      | 1            | 1               | 800              | 100 | 40          | 20    | 45          | 50                        | 50                    | 35        | 25;40;30;20;15;35;20      |
| 2500   | 100            | 25            | 20                   | 20      | 25                          | 25               | 2      | 1            | 2               | 400              | 20  | 40          | 30    | 25          | 20                        | 20                    | 20        | 100;20;30;30;30;40;40      |
| 1500   | 200            | 50            | 50                   | 30      | 20                          | 40               | 1      | 1            | 1               | 700              | 20  | 25          | 25    | 20          | 20                        | 20                    | 15        | 25;30;50;25;30;45;40      |
| 3000   | 150            | 50            | 20                   | 25      | 15                          | 30               | 1      | 2            | 2               | 900              | 50  | 45          | 25    | 20          | 50                        | 20                    | 15        | 30;40;50;20;30;20;50      |
| 4000   | 50             | 250           | 25                   | 25      | 20                          | 15               | 2      | 1            | 1               | 800              | 100 | 50          | 50    | 20          | 20                        | 50                    | 40        | 50;20;20;20;30;40;50      |