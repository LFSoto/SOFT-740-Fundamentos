Feature: Login
  Scenario: Login with existing user
	Given I click on the Signup/login button
	When I navigate to the Signup/login page
	And I enter my login credentials "emailTest" "passwordTest"
	Then I should be logged in successfully