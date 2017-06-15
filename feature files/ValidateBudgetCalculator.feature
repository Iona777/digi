Feature: ValidateBudgetCalculator
	In order to test the validation of the budget calculator fields
	As a customer
	I want to the correct error messages displayed for invalid inputs

@mytag
	Scenario: Validate Budget Calculator Income fields using single row of data from file
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I read data from a file and Login using automation13@test.com/Bolder@11
	And I navigate to the Budget Calculator Page
	And  Populate the Budget Calculator Income Page with invalid alphabetic data using data from file 'Data\\BudgetCalc_InvalidInput1.xlsx'	                                                                                                  
	Then The error messages for invalid alphabetic data are displayed for each field
	And User is logged out and navigated to home page

	#This scenario takes multiple lines of invalid data 
	Scenario: Validate Budget Calculator Income fields using multiple rows of data from file
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I read data from a file and Login using automation13@test.com/Bolder@11
	And I navigate to the Budget Calculator Page
	Then Validate that error messages for invalid data are displayed for each field using data from file 'Data\\BudgetCalc_InvalidInput1.xlsx'
	And User is logged out and navigated to home page
	