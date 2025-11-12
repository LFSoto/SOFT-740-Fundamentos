Feature: Cart Page
Scenario: Remove all items from the cart
	Given I logged in with valid credentials: "standard_user", "secret_sauce"
	And I validate that there's at least one item in the cart
	When I navigate to the Cart Page: "/cart"
	And I remove all the items from the cart
	Then There's no items in the cart