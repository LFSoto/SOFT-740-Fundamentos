Feature: New User Registration
  Scenario: Successful registration with valid details
	Given I am on the home page
	When I click the sign-up link
	Then I navigate to the New User Signup page
	When I enter valid registration "name" and "password"
	And I click the sign-up button
	Then I navigate to the registration page
	When I fill in the registration form with valid details
	And I click the create Account button
	Then I should see a confirmation message
	When I click the continue button
	Then I should be redirected to the home page