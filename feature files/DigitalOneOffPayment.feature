Feature: DigitalOneOffPayment
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Making a OneOff Payment on Digital saving the card details
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login using automation5@test.com/Bolder@11
	And I Complete a OneOff payment by saving card details
	Then balance should be reduced
	And User is logged out and navigated to home page

Scenario: Making a OneOff Payment on Digital without saving the card details
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login using automation17@test.com/Bolder@11
	And I Complete a OneOff payment without saving card details
	Then balance should be reduced
	And User is logged out and navigated to home page

Scenario: Making a OneOff Payment on Digital using a saved card
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login using automation6@test.com/Bolder@11
	And I Complete a OneOff payment using a saved card
	Then balance should be reduced
	And User is logged out and navigated to home page

Scenario Outline: Data driven test of making a OneOff Payment on Digital
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login to Digital using '<userName>' and '<password>' through data from feature file
	And I Complete a OneOff payment by saving card details
	Then balance should be reduced
	And Account status should not be changed
	When User navigates to statements page and searches for the payment
	Then payment should be shown in statements page
	And User is logged out and navigated to home page
Examples:
|userName|password| 
| automation4@test.com | Bolder@11 |
| automation5@test.com | Bolder@11 |
| automation6@test.com | Bolder@11 |
| automation7@test.com | Bolder@11 |
| automation8@test.com | Bolder@11 |
| automation9@test.com | Bolder@11 |
| automation10@test.com | Bolder@11 |
| automation31@test.com | Bolder@11 |
| automation32@test.com | Bolder@11 |
| automation34@test.com | Bolder@11 |


Scenario Outline: Data driven test for making a payment of more than the outstanding balance on Digital
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login to Digital using '<userName>' and '<password>' through data from feature file
	And I try to do a OneOff payment for more than the outstanding balance
	Then This '<error message>' error message should be shown
	And User is logged out and navigated to home page

Examples:
| userName             | password  | error message                                                                               |
| automation4@test.com | Bolder@11 | You have entered a value greater than allowed. Please enter an amount less than or equal to |
| automation5@test.com | Bolder@11 | You have entered a value greater than allowed. Please enter an amount less than or equal to |
| automation6@test.com | Bolder@11 | You have entered a value greater than allowed. Please enter an amount less than or equal to |

Scenario Outline: Data driven test for paying invalid payment amounts
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login to Digital using '<userName>' and '<password>' through data from feature file
	And I try to do a OneOff payment using an invalid payment amount of '<paymentAmount>'
	Then This '<error message>' error message should be shown
	And User is logged out and navigated to home page

Examples:
| userName             | password  | paymentAmount | error message                                      |
| automation4@test.com | Bolder@11 | "-45.58"      | Please enter a payment amount in pounds and pence. |
| automation5@test.com | Bolder@11 | "5.55648"     | Please enter a payment amount in pounds and pence. |
| automation6@test.com | Bolder@11 | "0.00"        | Please enter a payment amount in pounds and pence. |


Scenario Outline: Test terms and conditions link in one off payment
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login to Digital using '<userName>' and '<password>' through data from feature file
	And I click on terms and conditions link in one off payment 
	Then User should be shown terms and conditions page
	And User is logged out and navigated to home page
Examples:
| userName             | password  |
| automation4@test.com | Bolder@11 |
| automation5@test.com | Bolder@11 |
| automation6@test.com | Bolder@11 |

Scenario Outline: Test back button in one off payment 1st and 2nd pages
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login to Digital using '<userName>' and '<password>' through data from feature file
	And I navigate to One Off payment first page and back to Myaccount
	And I navigate to One off payment second page and back to MyAccount
	Then I should see account details and Logout

Examples:
| userName             | password  |
| automation4@test.com | Bolder@11 |
| automation5@test.com | Bolder@11 |
| automation6@test.com | Bolder@11 |

Scenario Outline: Data driven test to check that the values of the fields in first and second pages of one off payment match
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login to Digital using '<userName>' and '<password>' through data from feature file
	And I navigate to One Off payment and check if values selected in first and second pages of the journey match	
	Then I should see account details and Logout

Examples:
| userName             | password  |
| automation4@test.com | Bolder@11 |
| automation5@test.com | Bolder@11 |
| automation6@test.com | Bolder@11 |