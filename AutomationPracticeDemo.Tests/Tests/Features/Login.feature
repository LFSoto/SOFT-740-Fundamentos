Feature: Login Functionality
  Scenario: Successful login with valid credentials
	Given I am on the home page
	When I click the login link
	Then I navigate to login page
	When I enter valid credentials
	And I click the login button
	Then I should be redirected to the home page