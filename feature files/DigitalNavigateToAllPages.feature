Feature: DigitalNavigateToAllPages
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Navigate to All Pages
	Given I have opened Digital in Chrome
	And I am on Home
	When I navigate between all the pages
	Then There should be no errors thrown
