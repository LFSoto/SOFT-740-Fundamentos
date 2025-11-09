Feature: Cart Page
Scenario: Remove all items from the cart
	Given I logged in
	And I'm on the "cart page"
	And I validate that there's at least one item in the cart
	When I remove all the items from the cart
	Then There's no items in the cart