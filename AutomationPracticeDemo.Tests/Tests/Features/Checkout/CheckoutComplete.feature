Feature: Checkout: Complete
Scenario: Purchase complete
	Given Fill Product page
	And Fill Cart page
	And I am on the Checkout Your Information page
	When I enter valid First Name,Last Name and Postal Code
	And Click continue button
	And Click finish button
	Then You should see a thank you message for your purchase

Scenario: Redirect to homepage
	Given Fill Product page
	And Fill Cart page
	And I am on the Checkout Your Information page
	When I enter valid First Name,Last Name and Postal Code
	And Click continue button
	And Click finish button
	And Click Homepage button
	Then You should be redirected to the homepage
