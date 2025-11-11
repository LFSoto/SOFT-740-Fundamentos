Feature: Checkout Your Information
Scenario: Steps to complete purchase with valid data
	Given Complete the product page
	And Complete the cart page
	And I am on the Checkout: Your Information page
	When I enter valid First Name, Last Name, and Postal Code
	And I click Continue button
	Then I should be redirected to the Checkout: Overview page

Scenario: Valid information (cancel button)
	Given Complete the product page
	And Complete the cart page
	And I am on the Checkout: Your Information page
	When I enter valid First Name, Last Name, and Postal Code
	And I click Cancel button
	Then I should be redirected to Your Cart page

Scenario: Steps to complete purchase with invalid data
	Given Complete the product page
	And Complete the cart page
	And I am on the Checkout: Your Information page
	When I click Continue button
	Then An error message should be displayed on the screen