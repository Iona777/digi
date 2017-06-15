Feature: POCRegister
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Register an account read from file
	#I will refer to new Digial when I need to replace existing page object creation 
	#with new page object creation
	Given I have opened new Digital in Chrome 
	And I have navigated to the Register page
	When I enter registration details from the 'C:\\Selenium\\Test files\\Registration_Input1.xlsx' file
	

