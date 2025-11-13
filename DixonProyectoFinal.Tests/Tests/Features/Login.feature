Feature: Login

Scenario: Successful Login with valid credentials
	Given I am on the Login Page: "https://www.saucedemo.com/"
	When I enter valid credentials
	And I click the Login button
	Then I'm on the Inventory Page: "/inventory"

Scenario: Unsuccessful Login with invalid credentials
	Given I am on the Login Page: "https://www.saucedemo.com/"
	When I enter invalid credentials
	And I click the Login button
	Then It shows that the credentials are not valid