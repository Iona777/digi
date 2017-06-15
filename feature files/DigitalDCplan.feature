Feature: DigitalDCplan
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Setup a Discounted Debit Card plan on an account using a new card
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login using automation7@test.com/Bolder@11
	And I setup a Discounted Debit Card plan using a new card
	Then MyAccount page should show plan details
	And User is logged out and navigated to home page

Scenario: Setup a Discounted Debit Card plan on an account using a saved card
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login using automation8@test.com/Bolder@11
	And I setup a Discounted Debit Card plan using a saved card
	Then MyAccount page should show plan details
	And User is logged out and navigated to home page

Scenario: Setup a Full Debit Card plan on an account using a new card
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login using automation9@test.com/Bolder@11
	And I setup a Full Debit Card plan using a new card
	Then MyAccount page should show plan details
	And User is logged out and navigated to home page

Scenario: Setup a Full Debit Card plan on an account using a saved card
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login using automation10@test.com/Bolder@11
	And I setup a Full Debit Card plan using a saved card
	Then MyAccount page should show plan details
	And User is logged out and navigated to home page