Feature: DigitalLoginAndLogout
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Login and Logout of Digital
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login using dcplantest@dcplantest.com/Bolder11
	Then I should see account details and Logout

Scenario Outline: Login and Logout of Digital multiple times
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login to Digital using '<userName>' and '<password>' through data from feature file
	Then I should see account details and Logout
Examples: 
| userName | password |
| automation1@test.com | Bolder@11 |
| automation2@test.com | Bolder@11 |
| automation3@test.com | Bolder@11 |
| automation4@test.com | Bolder@11 |
| automation5@test.com | Bolder@11 |
| automation6@test.com | Bolder@11 |
| automation7@test.com | Bolder@11 |
| automation8@test.com | Bolder@11 |
| automation9@test.com | Bolder@11 |
| automation10@test.com | Bolder@11 |
| automation11@test.com | Bolder@11 |
| automation12@test.com | Bolder@11 |
| automation13@test.com | Bolder@11 |

Scenario Outline: Test Error Messages for excluded accounts
	Given I have opened Digital in Chrome
	And I have navigated to Login page
	When I Login to Digital using '<userName>' and '<password>' through data from feature file
	Then I should see this error message '<error message>' in place of payment options
	And I should see account details and Logout
Examples: 
| userName                    | password  | error message                                                                                                                                                                                                                                                                                                                                                                       |
| autorun2@test.com           | Bolder@11 | We’re sorry you’re unable to pay this account online at the moment. Please contact us at support@lowellgroup.co.uk or phone us on 0333 556 5551 where we will be happy to help.                                                                                                                                                                                                     |
| autorun8@test.com           | Bolder@11 | We’re sorry you’re unable to pay this account online at the moment. Please contact us at support@lowellgroup.co.uk or phone us on 0333 556 5551 where we will be happy to help.                                                                                                                                                                                                     |
| uattest5@test.com           | Bolder@11 | We’re sorry you’re unable to pay this account online at the moment. Please contact us at support@lowellgroup.co.uk or phone us on 0333 556 5551 where we will be happy to help.                                                                                                                                                                                                     |
| autorunexc1@test.com        | Bolder@11 | We’re sorry you’re unable to pay this account online. Please contact Insolvency team. Our opening times are Mon – Fri opening times 9am – 5pm. Direct Telephone Number : 0333 556 5990 or Email : insolvencyteam@lowellgroup.co.uk                                                                                                                                                  |
| autorunexc2@test.com        | Bolder@11 | We’re sorry you’re unable to pay this account online. Please contact Insolvency team. Our opening times are Mon – Fri opening times 9am – 5pm. Direct Telephone Number : 0333 556 5990 or Email : insolvencyteam@lowellgroup.co.uk                                                                                                                                                  |
| autorunexc3@test.com        | Bolder@11 | We’re sorry you’re unable to pay this account online. Please contact Insolvency team. Our opening times are Mon – Fri opening times 9am – 5pm. Direct Telephone Number : 0333 556 5990 or Email : insolvencyteam@lowellgroup.co.uk                                                                                                                                                  |
| excluded2@test.com          | Bolder@11 | Your account has been forwarded to a debt collection agency and therefore you cannot make payment or set up plans on line. You can view account details if you are logged in. If you have any queries, please contact us at support@lowellgroup.co.uk or phone us on 0333 556 5551 where we will be happy to help. Our opening times are Mon – Fri 8.00am -8.00pm and Sat 8am – 2pm |
| outsourced1@outsourced1.com | Bolder@11 | Your account has been forwarded to a debt collection agency : BPO Collections, telephone number 0123456780 and therefore you cannot make payment or set up plans on line. You can view account details if you are logged in. If you have any queries, please contact your agency.                                                                                                   |
| tester1@statii.com          | Bolder@11 | We’re aware there is a query with this account and will contact you when we have a resolution. If you have any questions please contact us. Our opening times are Mon – Fri 8am – 8pm and Sat 8am-2pm. Email us at support@lowellgroup.co.uk or telephone us on 0333 556 5551                                                                                                       |
| tester2@statii.com          | Bolder@11 | We’re aware there is a query with this account and will contact you when we have a resolution. If you have any questions please contact us. Our opening times are Mon – Fri 8am – 8pm and Sat 8am-2pm. Email us at support@lowellgroup.co.uk or telephone us on 0333 556 5551                                                                                                       |
| tester3@statii.com          | Bolder@11 | Your account has been forwarded to a debt collection agency and therefore you cannot make payment or set up plans on line. You can view account details if you are logged in. If you have any queries, please contact us at support@lowellgroup.co.uk or phone us on 0333 556 5551 where we will be happy to help. Our opening times are Mon – Fri 8.00am -8.00pm and Sat 8am – 2pm |
| repcode2@test.com           | Bolder@11 | We’re sorry you’re unable to pay this account online at the moment. Please contact us at support@lowellgroup.co.uk or phone us on 0333 556 5551 where we will be happy to help. Our opening times are Mon - Fri 8am - 8pm and Sat 8am - 2pm                                                                                                                                         |
| exclude1@test.com           | Bolder@11 | We’re sorry you’re unable to pay this account online at the moment. Please contact us at support@lowellgroup.co.uk or phone us on 0333 556 5551 where we will be happy to help. Our opening times are Mon - Fri 8am - 8pm and Sat 8am - 2pm                                                                                                                                         |
| tokentest4@test.com         | Bolder@11 | We’re sorry you’re unable to pay this account online at the moment. Please contact us at support@lowellgroup.co.uk or phone us on 0333 556 5551 where we will be happy to help. Our opening times are Mon - Fri 8am - 8pm and Sat 8am - 2pm                                                                                                                                         |