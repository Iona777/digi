Feature: DigitalMyAccountTests
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario Outline: Test payment options available for an account with an active non-DD plan
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login to Digital using '<userName>' and '<password>' through data from feature file
	Then All the payment options should be available
	And I should see account details and Logout
Examples: 
| userName | password |
| automation21@test.com | Bolder@11 |
| automation22@test.com | Bolder@11 |
| automation27@test.com | Bolder@11 |
| automation31@test.com | Bolder@11 |
| automation32@test.com | Bolder@11 |
| automation34@test.com | Bolder@11 |

Scenario Outline: Test payment plan table and content below the table for an account with an account with accepted discount
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login to Digital using '<userName>' and '<password>' through data from feature file
	Then Discount details should be shown below the payment plan table
	And I should see account details and Logout
Examples: 
| userName | password |
| automation16@test.com | Bolder@11 |
| discCashInArrears1@test.com | Bolder@11 |
| newacc1@test.com | Bolder@11 |
| newacc2@test.com | Bolder@11 |
| sprint9C9@abc.com | Bolder@11 |

Scenario Outline: Test the status and payment options for an account with account status as "Closed"
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login to Digital using '<userName>' and '<password>' through data from feature file
	Then For an account with closed status payment options should not be shown
	And I should see account details and Logout
Examples: 
| userName | password |
| repcode2@test.com | Bolder@11 |
| exclude1@test.com | Bolder@11 |


Scenario Outline: Test the payment options for an account which accepted a discount and setup a plan
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login to Digital using '<userName>' and '<password>' through data from feature file
	Then If existing plan is DD then plan button should not be shown or else it should be shown
	And I should see account details and Logout
Examples: 
| userName            | password  |
| sprint9V@abc.com | Bolder@11 |
| Sprint9G@abc.com | Bolder@11 |
| test1@discounts.com | Bolder@11 |
| automation16@test.com | Bolder@11 |
| newacc1@test.com | Bolder@11 |
| newacc2@test.com | Bolder@11 |

Scenario Outline: Test navigation from MyAccount page to statement page
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login to Digital using '<userName>' and '<password>' through data from feature file
	And User navigates to statements page and searches for the payment
	Then User is logged out and navigated to home page
Examples:
| userName             | password  |
| automation4@test.com | Bolder@11 |
| automation5@test.com | Bolder@11 |
| automation6@test.com | Bolder@11 |
| automation7@test.com | Bolder@11 |
| automation8@test.com | Bolder@11 |
| automation9@test.com | Bolder@11 |

Scenario Outline: Test pdf download in statements page by clicking on pdf link
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login to Digital using '<userName>' and '<password>' through data from feature file
	And User navigates to statements page and searches for payments between dates '<fromDate>' to '<toDate>'
	And I download the pdf
	Then Pdf should be downloaded and closed
	And User is logged out and navigated to home page
Examples:
| userName             | password  | fromDate   | toDate     |
| automation4@test.com | Bolder@11 | 22/03/2016 | 22/03/2017 |
| automation5@test.com | Bolder@11 | 02/10/2014 | 14/03/2017 |
| automation6@test.com | Bolder@11 | 10/10/2015 | 22/02/2017 |
| automation7@test.com | Bolder@11 | 22/03/2015 | 22/03/2017 |
| automation8@test.com | Bolder@11 | 12/12/2015 | 22/03/2017 |
| automation9@test.com | Bolder@11 | 09/03/2014 | 22/03/2017 |