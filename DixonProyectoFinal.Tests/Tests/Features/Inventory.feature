Feature: Inventory Page
Scenario: Add two items
	Given I logged in with valid credentials: "standard_user", "secret_sauce"
	And I'm on the Inventory Page: "/inventory"
	When I add two items in the postions one and two: "1,2"
	Then The items were added