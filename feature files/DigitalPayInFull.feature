Feature: DigitalPayInFull
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Complete a discounted pay in full using a new card
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login using automation1@test.com/Bolder@11
	And Complete a discounted pay in full using a new card
	Then Balance should be zero
	And User is logged out and navigated to home page

Scenario: Complete a discounted pay in full using a saved card
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login using automation2@test.com/Bolder@11
	And Complete a discounted pay in full using a saved card
	Then Balance should be zero
	And User is logged out and navigated to home page

Scenario: Complete a full pay in full using a new card
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login using automation3@test.com/Bolder@11
	And Complete a full pay in full using a new card
	Then Balance should be zero
	And User is logged out and navigated to home page

Scenario: Complete a full pay in full using a saved card
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login using automation4@test.com/Bolder@11
	And Complete a full pay in full using a new card
	Then Balance should be zero
	And User is logged out and navigated to home page

Scenario Outline: Data driven test of completing a discounted pay in full
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login to Digital using '<userName>' and '<password>' through data from feature file
	And Complete a discounted pay in full using a new card
	Then Balance should be zero
	And User is logged out and navigated to home page
Examples: 
| userName | password |
| automation11@test.com | Bolder@11 |
| automation12@test.com | Bolder@11 |
| automation13@test.com | Bolder@11 |
| automation14@test.com | Bolder@11 |
| automation15@test.com | Bolder@11 |

Scenario Outline: Data driven test of completing a pay in full
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login to Digital using '<userName>' and '<password>' through data from feature file
	And Complete a discounted pay in full using a new card
	Then Balance should be zero
	And User is logged out and navigated to home page
Examples: 
| userName | password |
| automation16@test.com | Bolder@11 |
| automation17@test.com | Bolder@11 |
| automation18@test.com | Bolder@11 |
| automation19@test.com | Bolder@11 |
| automation20@test.com | Bolder@11 |

Scenario Outline: Data driven test to verify that when an account with a payment plan is paid off in full, then the payment plan is closed and balance is shown as 0
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login to Digital using '<userName>' and '<password>' through data from feature file
	And Complete a full pay in full using a new card
	Then Balance should be zero
	And Acconunt status should not be '<PlanInPlace>'	
	And User is logged out and navigated to home page
Examples: 
| userName              | password  | PlanInPlace   |
| automation16@test.com | Bolder@11 | Plan In Place |
| automation17@test.com | Bolder@11 | Plan In Place |
| automation18@test.com | Bolder@11 | Plan In Place |

Scenario Outline: Data driven test to verify the content warning Credit Cards are not accepted in pay in full journey
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login to Digital using '<userName>' and '<password>' through data from feature file
	And I navigate to pay in full first page
	Then Content '<ContentForCreditCard>' warning Credit Cards are not accepted should be shown
	And User is logged out and navigated to home page
Examples: 
| userName              | password  | ContentForCreditCard   |
| automation16@test.com | Bolder@11 | Please note, unfortunately we are unable to accept payment by credit card.  |
| automation17@test.com | Bolder@11 | Please note, unfortunately we are unable to accept payment by credit card.  |
| automation18@test.com | Bolder@11 | Please note, unfortunately we are unable to accept payment by credit card.  |

Scenario Outline: Data driven test to verify if pay in full transactions are shown in RecentTransactions and Statements page
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login to Digital using '<userName>' and '<password>' through data from feature file
	And Complete a full pay in full using a new card
	Then Balance should be zero
	When User navigates to statements page and searches for the full payment
	Then Full payment should be shown in statements page
	And User is logged out and navigated to home page
Examples: 
| userName | password |
| automation31@test.com | Bolder@11 |
| automation32@test.com | Bolder@11 |
| automation33@test.com | Bolder@11 |


Scenario Outline: Test back button in pay in full 1st and 2nd pages
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login to Digital using '<userName>' and '<password>' through data from feature file
	And I navigate to pay in full first page
	And Click on Back button in first page
	And I navigate to pay in full second page and back to MyAccount	
	Then User is logged out and navigated to home page
Examples:
| userName              | password  |
| automation34@test.com | Bolder@11 |
| automation35@test.com | Bolder@11 |
| automation36@test.com | Bolder@11 |

Scenario Outline: Test terms and conditions link in pay in full
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login to Digital using '<userName>' and '<password>' through data from feature file
	And I navigate to pay in full first page
	And I click on terms and conditions link in pay in full journey 
	Then User should be shown terms and conditions page
	And User is logged out and navigated to home page
Examples:
| userName              | password  |
| automation34@test.com | Bolder@11 |
| automation35@test.com | Bolder@11 |
| automation36@test.com | Bolder@11 |

Scenario Outline: Create a payment error by entering invalid data in Verifone and make sure that payment is not posted to Digital
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login to Digital using '<userName>' and '<password>' through data from feature file
	And I create payment errors in Verifone till the payment is failed
	Then Balance should not be zero	
	When User navigates to statements page and searches for the full payment
	Then Full payment should not be shown in statements page
	And User is logged out and navigated to home page
Examples: 
| userName              | password  |
| automation34@test.com | Bolder@11 |
| automation35@test.com | Bolder@11 |
| automation36@test.com | Bolder@11 |