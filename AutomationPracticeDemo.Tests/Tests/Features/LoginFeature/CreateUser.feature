Feature: CreateUser
Scenario: Create new user account
	Given I click on the Signup/login button
	When I navigate to the Signup/login page
	And I enter my login credentials "emailTest" "passwordTest"
	Then I should be logged in successfully
	When I enter the "email" and "password"
	And I click on the Signup button
	Then The title is displayed "ENTER ACCOUNT INFORMATION"
	When I entre the account information
	And I click on the Create Account button
	Then I should see the message "ACCOUNT CREATED!"
	When I click on the Continue button
	Then The user's name is displayed on the “Logged in as” button.