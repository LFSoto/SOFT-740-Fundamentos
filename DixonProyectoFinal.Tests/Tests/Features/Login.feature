Feature: Login

Scenario: Successful Login with valid credentials
	Given I am on the Login Page: "https://www.saucedemo.com/"
	When I enter a valid username: "standard_user" and a valid "secret_sauce"
	And I click the Login button
	Then I'm on the Inventory Page: "/inventory"

Scenario: Unsuccessful Login with invalid credentials
	Given I am on the Login Page: "https://www.saucedemo.com/"
	When I enter an invalid "username" and a invalid "password"
	And I click the Login button
	Then It shows that the credentials are not valid