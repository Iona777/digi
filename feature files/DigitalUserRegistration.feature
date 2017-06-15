Feature: DigitalUserRegistration
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: Data driven test of registering new accounts
	Given I have opened Digital in Chrome 
	And I have clicked on Register button and navigated to the Register page
	When I enter '<Lowell reference number>' '<Date of birth>' '<PostCode>' '<Landline Telephone>' '<Mobile Telephone>' '<Email Address>' '<Password>' in relevant fields and register
	And I have Logged in to Umbraco using '<umbracoUserName>' '<umbracoPassword>' and activated the '<Email Address>' in Umbraco
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login to Digital using '<Email Address>' and '<Password>' through data from feature file
	Then I should see account details and Logout
Examples: 
| Lowell reference number | Date of birth | PostCode | Landline Telephone | Mobile Telephone | Email Address | Password | umbracoUserName | umbracoPassword | 
| 107903775	| 30/08/1974 | FS1 1FS | 0123777451 | 07774448541 | autorunexc1@test.com | Bolder@11 | sri | lowell |
| 113337208	| 09/02/1977 | FS1 1FS | 0123444521 | 07774448541 | autorunexc2@test.com | Bolder@11 | sri | lowell |
| 109959320	| 12/04/1975 | FS1 1FS | 0123956874 | 07774448541 | autorunexc3@test.com | Bolder@11 | sri | lowell |