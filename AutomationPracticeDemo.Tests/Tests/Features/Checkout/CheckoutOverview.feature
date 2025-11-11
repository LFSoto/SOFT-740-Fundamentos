Feature: Checkout: Overview
Scenario: Complete the checkout summary
	Given Complete product page
	And Complete cart page
	And I am on the Checkout:Your Information page
	When I enter valid First Name, Last Name and Postal Code
	And Click Continue button
	And Click Finish button
	Then I should be redirected to the Checkout: Complete

Scenario: Cancel the checkout summary
	Given Complete product page
	And Complete cart page
	And I am on the Checkout:Your Information page
	When I enter valid First Name, Last Name and Postal Code
	And Click Cancel button
	Then I should be redirected to product screen