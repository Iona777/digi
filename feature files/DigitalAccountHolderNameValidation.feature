Feature: DigitalAccountHolderNameValidation
	In order to check the validation of the Bank Account Holder's Name field
	As a customer
	I want the appropriate error message to be displayed if I enter an incorrect value

@mytag
Scenario: Account Holder Name field blank
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I read data from a file and Login using automation13@test.com/Bolder@11
	And  I navigate to the Direct Debit page
	And  I submit the page while leaving the Bank Account Holder Name field blank
	Then the 'Please enter the account holders name' message should be displayed on the screen
	And User is logged out and navigated to home page

	Scenario: Account Holder Name field contains invalid characters
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I read data from a file and Login using automation13@test.com/Bolder@11
	And  I navigate to the Direct Debit page
	Then Validate the Account Holder Name field using data read from the file 'Data\\AccountHolderName_Input1.xlsx'
	And User is logged out and navigated to home page
	
	