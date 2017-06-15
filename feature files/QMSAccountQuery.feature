Feature: QMSAccountQuery

Scenario: QMSAccountQuery Login/Logout
	Given I am on "http://539494-teapo04/uat/QMSAccountQuery.html#/Login/"
	When I login
	Then the "http://539494-teapo04/uat/QMSAccountQuery.html#/Account/" page is displayed
	When I logout
	Then the "http://539494-teapo04/uat/QMSAccountQuery.html#/Login/" page is displayed
