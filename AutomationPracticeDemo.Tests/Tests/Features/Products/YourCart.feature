Feature: Remove product Your Cart
Scenario: Products removed from cart successfully
	Given I am on the product page
	And I am on the Your Cart page
	When I click the Remove button
	Then The product should be removed from the cart

Scenario: Functionality: Continue shopping button
	Given I am on the product page
	And I am on the Your Cart page
	When I click the continue shopping button
	Then You should see the products page

Scenario: Functionality: Checkout button
	Given I am on the product page
	And I am on the Your Cart page
	When I click the Checkout button
	Then You should see the Checkout: Your Information page