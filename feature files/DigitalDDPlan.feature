Feature: DigitalDDPlan
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Setup a Discounted Direct Debit plan on an account
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login using automation11@test.com/Bolder@11
	And I setup a Discounted Direct Debit plan on an account
	Then MyAccount page should show plan details
	And User is logged out and navigated to home page

Scenario: Setup a Full Direct Debit plan on an account
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login using automation12@test.com/Bolder@11
	And I setup a Full Direct Debit plan on an account
	Then MyAccount page should show plan details
	And User is logged out and navigated to home page

Scenario Outline: Data Driven test to setup a Discounted Direct Debit plan on an account
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login to Digital using '<userName>' and '<password>' through data from feature file
	And I setup a '<Discounted>' Direct Debit plan using '<PlanFrequency>' '<BankAccount HolderName>' '<Bank AccountNumber>' and '<SortCode>'on an account
	Then MyAccount page should show plan details
	And User is logged out and navigated to home page
Examples: 
| userName             | password  | PlanFrequency | BankAccount HolderName | Bank AccountNumber | SortCode | Discounted |
| automation1@test.com | Bolder@11 | FortNightly   | automation            | 24060240           | '542122'   | Discounted |
| automation2@test.com | Bolder@11 | FourWeekly    | automation            | 10433055           | '202015'   | Discounted |
| automation3@test.com | Bolder@11 | Monthly       | automation            | 49362580           | '090133'   | Discounted |
| automation4@test.com | Bolder@11 | Weekly        | automation            | 93014649           | '203089'   | Discounted |
| automation5@test.com | Bolder@11 | Monthly       | automation            | 85337361           | '090127'   | Discounted |

Scenario Outline: Data Driven test to setup a Full Direct Debit plan on an account
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login to Digital using '<userName>' and '<password>' through data from feature file
	And I setup a '<Full>' Direct Debit plan using '<PlanFrequency>' '<BankAccount HolderName>' '<Bank AccountNumber>' and '<SortCode>'on an account
	Then MyAccount page should show plan details
	And User is logged out and navigated to home page
Examples: 
| userName             | password  | PlanFrequency | BankAccount HolderName | Bank AccountNumber | SortCode | Full |
| automation6@test.com | Bolder@11 | FortNightly   | automation            | 51214068           | '771217'   | Full |
| automation7@test.com | Bolder@11 | FourWeekly    | automation            | 66131936           | '515010'   | Full |
| automation8@test.com | Bolder@11 | Monthly       | automation            | 40970344           | '207655'   | Full |
| automation9@test.com | Bolder@11 | Weekly        | automation            | 30049899           | '070246'  | Full |
| automation10@test.com | Bolder@11 | Monthly       | automation            | 61411442           | '608009'   | Full |