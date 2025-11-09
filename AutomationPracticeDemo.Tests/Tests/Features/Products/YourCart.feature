Feature: Remove product Your Cart
  Scenario: Products removed from cart successfully
	Given I am on the product page
	And I am on the Your Cart page
	When I click the Remove button
	Then The product should be removed from the cart