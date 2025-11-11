Feature: Add and remove product
  Scenario: Successful addition of products to cart
	Given I am on the products page
	When I Click Add Product
	Then The added product should be added to the cart icon
	When I click the cart button
	Then The added product should be there

	Scenario: Successful remove of products to cart
	Given I am on the products page
	When I click Add three products
	Then The added products should appear in the cart icon
	When I click the remove button
	Then The added products should appear updated in the cart icon