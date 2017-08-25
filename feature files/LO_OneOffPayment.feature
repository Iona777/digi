Feature: LO_OneOffPayment
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: Logged Out One offPayment - Verify one-off payments accept penny amounts
	Given I have opened Digital in Chrome
	When I click on the Payment Options bubble icon
	And I select Payment Options radio button
	And I complete Anonymous Login using '<RefNo>', '<DOB>' and '<Postcode>' through data from feature file
	And I select Make a one off payment radio button and click on Continue
	And I complete the Logged Off One Off payment Step1 screen using '<PaymentAmount>' through data from feature file and click on Continue
	Then the Logged Off One Off payment Step2 -Review screen displays the payment amount '<PaymentAmount>'
	And I click on Continue and Complete the Verifone Payment page with valid data using '<CardNumber>' through data from feature file and click Continue
	And I click on the Finish button in the Logged out Payment confirmation page
	Then  PaymentOptionsPage1 screen is displayed
	And User is navigated to home page
Examples:
| RefNo		 | DOB		 | Postcode | PaymentAmount	|CardNumber      |
| 100020395	 |13/04/1954 | OX14 1QN | 1.21			|4012001038443335|

Scenario Outline: Logged Out One offPayment - Verify back button works in Review page
	Given I have opened Digital in Chrome
	When I click on the Payment Options bubble icon
	And I select Payment Options radio button
	And I complete Anonymous Login using '<RefNo>', '<DOB>' and '<Postcode>' through data from feature file
	And I select Make a one off payment radio button and click on Continue
	And I complete the Logged Off One Off payment Step1 screen using '<PaymentAmount>' through data from feature file and click on Continue
	Then the Logged Off One Off payment Step2 -Review screen displays the payment amount '<PaymentAmount>'
	And I click on the Back button in the the Logged Off One Off payment Step2 -Review screen
	Then the Logged Off One Off payment Step2 screen is displayed
	And User is navigated to home page
Examples:
| RefNo		 | DOB		 | Postcode | PaymentAmount	|CardNumber      |
| 100020395	 |13/04/1954 | OX14 1QN | 1.21			|4012001038443335|

Scenario Outline: Logged Out One offPayment - Verify user redirected to Terms and Conditons page
	Given I have opened Digital in Chrome
	When I click on the Payment Options bubble icon
	And I select Payment Options radio button
	And I complete Anonymous Login using '<RefNo>', '<DOB>' and '<Postcode>' through data from feature file
	And I select Make a one off payment radio button and click on Continue
	And I click on the Terms and Conditions link in the Logged Off One Off payment Step1 screen
	Then the user is redirected to the Terms and Conditions page
	And User is navigated to home page
Examples:
| RefNo		 | DOB		 | Postcode |
| 100020395	 |13/04/1954 | OX14 1QN |


Scenario Outline: Logged Out One offPayment - Verify discount amount
	Given I have opened Digital in Chrome
	When I click on the Payment Options bubble icon
	And I select Payment Options radio button
	And I complete Anonymous Login using '<RefNo>', '<DOB>' and '<Postcode>' through data from feature file
	And I note the value of the discount amount in green bar
	And I select Make a one off payment radio button and click on Continue
	And I complete the Logged Off One Off payment Step1 screen using '<PaymentAmount>' through data from feature file and click on Continue
	Then the Logged Off One Off payment Step2 -Review screen displays the payment amount '<PaymentAmount>'
	And I click on Continue and Complete the Verifone Payment page with valid data using '<CardNumber>' through data from feature file and click Continue
	And I click on the Finish button in the Logged out Payment confirmation page
	Then  PaymentOptionsPage1 screen is displayed
	And User is navigated to home page
	When I click on the Payment Options bubble icon
	And I select Payment Options radio button
	And I complete Anonymous Login using '<RefNo>', '<DOB>' and '<Postcode>' through data from feature file
	Then I verify that the discount amount in green bar has not changed
	And User is navigated to home page
Examples:
| RefNo     | DOB        | Postcode | PaymentAmount	| CardNumber       |
| 100038447 | 07/01/1944 | SP11 0LJ | 1				| 4012001038443335 |



Scenario Outline: Logged Out One offPayment - Navigate from DD page. Verify Balance not pre-populated
	Given I have opened Digital in Chrome
	When I click on the Payment Options bubble icon
	And I select Payment Options radio button
	And I complete Anonymous Login using '<RefNo>', '<DOB>' and '<Postcode>' through data from feature file
	And I select Setup a Direct Debit radio button and click on Continue
	And I complete the Logged Off Direct Debit Plan Step1 screen using '<DDAmount>',  '<Frequency>', '<AccountHolder>', '<AccountNo>', '<SortCode>' and '<EmailAddres>'  through data from feature file
	And I click on the Back button in the Direct Debit Plan Step1 screen
	And I select Make a one off payment radio button and click on Continue
	Then I verify that the Payment Amount field is NOT pre-populated
	And User is navigated to home page
Examples:
| RefNo     | DOB        | Postcode | DDAmount | Frequency | AccountHolder | AccountNo | SortCode | EmailAddress        |
| 100020395 | 13/04/1954 | OX14 1QN | 5.00     | Monthly   | A Test        | 14457846  | 308088   | autoTestLO@test.com |  