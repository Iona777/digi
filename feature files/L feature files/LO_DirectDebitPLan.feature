Feature: LO_DirectDebitPayment
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: Logged Out DDPlan - Set up DD plan with various frequencies
	Given I have opened Digital in Chrome
	When I click on the Payment Options bubble icon
	And I select Payment Options radio button
	And I complete Anonymous Login using '<RefNo>', '<DOB>' and '<Postcode>' through data from feature file
	And I select Setup a Direct Debit radio button and click on Continue
	And I complete the Logged Off Direct Debit Plan Step1 screen using '<PaymentAmount>',  '<Frequency>', '<AccountHolder>', '<AccountNo>', '<SortCode>' and '<EmailAddres>'  through data from feature file
	And I note the value of the Start Date and click on Continue
	Then the Logged Off Direct Debit Plan Step2 -Review screen displays the values entered '<RefNo>', '<PaymentAmount>', '<Frequency>','<AcccountHolder>','<AccountNo>', '<SortCode>', '<EmailAddress>'  
	And the Logged Off Direct Debit Plan Step2 -Review screen displays the other values entered: Start Date, Repayment Method
	And I click on the Continue button in the Logged Off Direct Debit Plan Step2 -Review screen
	Then the Logged Off Direct Debit Plan Confirmation screen displays the values entered '<RefNo>', '<PaymentAmount>', '<Frequency>','<AccountNo>', '<SortCode>'  
	And the Logged Off Direct Debit Plan Confirmation screen displays the other values entered: Start Date, Repayment Method, Account Holder and Email Address 
	And User is navigated to home page
Examples:
| Frequency		| RefNo     | DOB        | Postcode | PaymentAmount |AccountHolder	| AccountNo | SortCode | EmailAddres         |
|   Weekly		| 100022771 | 20/01/1986 | SW8 1EP	| 1.00          | A Test		| 14457846  | 308088   | autoTestLO@test.com |
|   Monthly		| 100023068 | 13/02/1989 | G1 1QD	| 2.00          | A Test        | 14457846  | 308088   | autoTestLO@test.com |
|   Fortnightly	| 100023837 | 03/06/1968 | HU1 3RT	| 3.00          | A Test        | 14457846  | 308088   | autoTestLO@test.com |
|   Four Weekly	| 100024363 | 09/02/1969 | B36 0UB	| 4.00			| A Test		| 14457846	| 308088   | autoTestLO@test.com |


Scenario Outline: Logged Out DDPlan - Validate Bank Account for non-existent account number
	Given I have opened Digital in Chrome
	When I click on the Payment Options bubble icon
	And I select Payment Options radio button
	And I complete Anonymous Login using '<RefNo>', '<DOB>' and '<Postcode>' through data from feature file
	And I select Setup a Direct Debit radio button and click on Continue
	And I complete the Logged Off Direct Debit Plan Step1 screen using '<PaymentAmount>',  '<Frequency>', '<AccountHolder>', '<NonExistentAccountNo>', '<SortCode>' and '<EmailAddres>'  through data from feature file
	And I click on the Continue button in the Logged Off Direct Debit Plan Step1 screen
	Then the non-existent account number error message:  '<NonExistentAccountNumberErrorMessage>' is displayed in the Logged Off Direct Debit Plan Step1 screen
	And User is navigated to home page
Examples:
| Frequency | RefNo     | DOB        | Postcode | PaymentAmount | AccountHolder | NonExistentAccountNo | SortCode | EmailAddres         | NonExistentAccountNumberErrorMessage																|
| Weekly    | 100025949 | 13/01/1981 | B60 2BT  | 1.00          | A Test        | 00000000             | 308088   | autoTestLO@test.com | Please enter a valid account number – if you believe this is valid then contact us so we can help.|

Scenario Outline: Logged Out DDPlan - Validate Bank Account for Modulus check
	Given I have opened Digital in Chrome
	When I click on the Payment Options bubble icon
	And I select Payment Options radio button
	And I complete Anonymous Login using '<RefNo>', '<DOB>' and '<Postcode>' through data from feature file
	And I select Setup a Direct Debit radio button and click on Continue
	And I complete the Logged Off Direct Debit Plan Step1 screen using '<PaymentAmount>',  '<Frequency>', '<AccountHolder>', '<ModulusAccountNo>', '<ModulusSortCode>' and '<EmailAddres>'  through data from feature file
	And I click on the Continue button in the Logged Off Direct Debit Plan Step1 screen
	Then the modulus error message:  '<ModulusErrorMessage>' is displayed in the Logged Off Direct Debit Plan Step1 screen
	And User is navigated to home page
Examples:
| Frequency | RefNo     | DOB        | Postcode | PaymentAmount | AccountHolder | ModulusAccountNo	| ModulusSortCode	| EmailAddres				| ModulusErrorMessage																											|
| Weekly    | 100025949 | 13/01/1981 | B60 2BT  | 1.00          | A Test        |    12563958		| 201188 			| autoTestLO@test.com		| Please check your bank account and sort code are correct - if you believe they are correct then contact us so we can help.	|

Scenario Outline: Logged Out DDPlan - Validate Bank Account for invalid sort code 
	Given I have opened Digital in Chrome
	When I click on the Payment Options bubble icon
	And I select Payment Options radio button
	And I complete Anonymous Login using '<RefNo>', '<DOB>' and '<Postcode>' through data from feature file
	And I select Setup a Direct Debit radio button and click on Continue
	And I complete the Logged Off Direct Debit Plan Step1 screen using '<PaymentAmount>',  '<Frequency>', '<AccountHolder>', '<AccountNo>', '<InvalidSortCode>' and '<EmailAddres>'  through data from feature file
	And I click on the Continue button in the Logged Off Direct Debit Plan Step1 screen
	Then the sort code error message:  '<SortCodeErrorMessage>' is displayed in the Logged Off Direct Debit Plan Step1 screen
	And User is navigated to home page
Examples:
|  Reason				| Frequency | RefNo		| DOB			| Postcode | PaymentAmount | AccountHolder | AccountNo		| InvalidSortCode	| EmailAddres			| SortCodeErrorMessage				|
| SortCodeTooShort		| Weekly    | 100025949 | 13/01/1981	| B60 2BT  | 1.00          | A Test        |    12563958	| 12345				| autoTestLO@test.com	| Please enter a valid sort code	|
| SortCodeText			| Weekly    | 100025949 | 13/01/1981	| B60 2BT  | 1.00          | A Test        |    12563958	| 123a45			| autoTestLO@test.com	| Please enter a valid sort code	|
| SortCodeSpecialChar	| Weekly    | 100025949 | 13/01/1981	| B60 2BT  | 1.00          | A Test        |    12563958	| 123?45			| autoTestLO@test.com	| Please enter a valid sort code	|

Scenario Outline: Logged Out DDPlan - Validate Bank Account for invalid account number 
	Given I have opened Digital in Chrome
	When I click on the Payment Options bubble icon
	And I select Payment Options radio button
	And I complete Anonymous Login using '<RefNo>', '<DOB>' and '<Postcode>' through data from feature file
	And I select Setup a Direct Debit radio button and click on Continue
	And I complete the Logged Off Direct Debit Plan Step1 screen using '<PaymentAmount>',  '<Frequency>', '<AccountHolder>', '<InvalidAccountNo>', '<SortCode>' and '<EmailAddres>'  through data from feature file
	And I click on the Continue button in the Logged Off Direct Debit Plan Step1 screen
	Then the account number error message:  '<AccountNumberErrorMessage>' is displayed in the Logged Off Direct Debit Plan Step1 screen
	And User is navigated to home page
Examples:
|  Reason					| Frequency | RefNo		| DOB			| Postcode | PaymentAmount | AccountHolder | InvalidAccountNo	|SortCode	| EmailAddres			| AccountNumberErrorMessage																												|
| AccountNumberTooShort		| Weekly    | 100025949 | 13/01/1981	| B60 2BT  | 1.00          | A Test        |    1234567			| 308088	| autoTestLO@test.com	| Please enter a valid account number. If your account number has fewer than 8 digits please add zeroes in front of the account number	|
| AccountNumberText			| Weekly    | 100025949 | 13/01/1981	| B60 2BT  | 1.00          | A Test        |    1234567A		| 308088	| autoTestLO@test.com	| The field AccountNumber must be a number.																								|
| AccountNumberSpecialChar	| Weekly    | 100025949 | 13/01/1981	| B60 2BT  | 1.00          | A Test        |    1234567?		| 308088	| autoTestLO@test.com	| The field AccountNumber must be a number.																								|


Scenario Outline: Logged Out DDPlan - Logged out users cannot set up discounted DD
	Given I have opened Digital in Chrome
	When I click on the Payment Options bubble icon
	And I select Payment Options radio button
	And I complete Anonymous Login using '<RefNo>', '<DOB>' and '<Postcode>' through data from feature file
	And I select Setup a Direct Debit radio button and click on Continue
	Then the Discounted DD Amount buttons are NOT displayed
Examples:
| AccountType | RefNo		| DOB			| Postcode |
| Single      |100022185	| 01/07/1967	| NE34 8HX |
| Linked      |100053107	| 04/04/1957	| SP11 0LJ |

Scenario Outline: Logged Out DDPlan - Verify back button works in Review page
	Given I have opened Digital in Chrome
	When I click on the Payment Options bubble icon
	And I select Payment Options radio button
	And I complete Anonymous Login using '<RefNo>', '<DOB>' and '<Postcode>' through data from feature file
	And I select Setup a Direct Debit radio button and click on Continue
	And I complete the Logged Off Direct Debit Plan Step1 screen using '<PaymentAmount>',  '<Frequency>', '<AccountHolder>', '<AccountNo>', '<SortCode>' and '<EmailAddres>'  through data from feature file
	And I note the value of the Start Date and click on Continue
	Then the Logged Off Direct Debit Plan Step2 -Review screen displays the values entered '<RefNo>', '<PaymentAmount>', '<Frequency>','<AcccountHolder>','<AccountNo>', '<SortCode>', '<EmailAddress>'  
	And I click on the Back button in the the Direct Debit Plan Step2 -Review screen
	Then the Logged Off Direct Debit Plan Step1 screen is displayed
	And User is navigated to home page
Examples:
| Frequency | RefNo     | DOB        | Postcode | PaymentAmount | AccountHolder | AccountNo		| SortCode	| EmailAddres			|
| Weekly    | 100025949 | 13/01/1981 | B60 2BT  | 1.00          | A Test        |    14457846	| 308088 	| autoTestLO@test.com	|


Scenario Outline: Logged Out DDPlan - Check DD Guarantee and Terms and Conditons links work
	Given I have opened Digital in Chrome
	When I click on the Payment Options bubble icon
	And I select Payment Options radio button
	And I complete Anonymous Login using '<RefNo>', '<DOB>' and '<Postcode>' through data from feature file
	And I select Setup a Direct Debit radio button and click on Continue
	And I click on the DD Guarantee link in the logged Off Direct Debit Plan Step1 screen
	Then the DD Guarantee PDF is displayed
	And I click on the Terms and Conditions link in the logged Off Direct Debit Plan Step1 screen
	Then the user is redirected to the Terms and Conditions page
	And User is navigated to home page
Examples:
| RefNo     | DOB        | Postcode | 
| 100025949 | 13/01/1981 | B60 2BT  | 

Scenario Outline: Logged Out DDPlan - Navigate from One off page. Verify Amount not pre-populated
	Given I have opened Digital in Chrome
	When I click on the Payment Options bubble icon
	And I select Payment Options radio button
	And I complete Anonymous Login using '<RefNo>', '<DOB>' and '<Postcode>' through data from feature file
	And I select Make a one off payment radio button and click on Continue
	And I complete the Logged Off One Off payment Step1 screen using '<PaymentAmount>' through data from feature file
	And I click on the Back button in the Logged Off One Off payment Step1 screen
	And I select Setup a Direct Debit radio button and click on Continue
	Then I verify that the Repayment Amount field is NOT pre-populated
	And User is navigated to home page
	Examples:
| RefNo     | DOB        | Postcode | PaymentAmount	| 
| 100020395 | 13/04/1954 | OX14 1QN | 1				| 

Scenario Outline: Logged Out DDPlan - Navigate from Pay in Full page. Verify Amount not pre-populated
	Given I have opened Digital in Chrome
	When I click on the Payment Options bubble icon
	And I select Payment Options radio button
	And I complete Anonymous Login using '<RefNo>', '<DOB>' and '<Postcode>' through data from feature file
	And I select Pay in Full radio button and click on Continue
	Then the Logged off Pay in Full Page1 screen is displayed
	And I click on the Back button in the Logged off Pay in Full Page1 screen
	And I select Setup a Direct Debit radio button again and click on Continue
	Then I verify that the Repayment Amount field is NOT pre-populated
	And User is navigated to home page
Examples:
| RefNo     | DOB        | Postcode | 
| 100020395 | 13/04/1954 | OX14 1QN | 