Feature: CreateUser
Scenario: Create new user account
	Given I click on the SignupLogin button
	When I enter the email and password
	Then I should see the title ENTER ACCOUNT INFORMATION
	When I enter the account information
	And I click on the Create Account button
	Then I should see the message ACCOUNT CREATED!
	When I click on the Continue button
	Then The user name is displayed on the Logged in as button