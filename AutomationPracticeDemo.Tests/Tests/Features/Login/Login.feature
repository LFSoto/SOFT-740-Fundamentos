Feature: Login Functionality
  Scenario: Successful login with valid credentials
	Given I am on the Login page
	When I enter valid Username and Password
	And I click the login button
	Then I should be redirected to the home page

Scenario: Unsuccessful login with invalid credentials
	Given I am on the Login page
	When I enter invalid Username and Password
	And I click the login button
	Then I should see an error message indicating invalid credentials