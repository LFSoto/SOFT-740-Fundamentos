Feature: Shopping cart Functionality
  Scenario: Successful addition of a product to the cart
	Given I am on the home page
	When I navigate to the Products page
	Then I should see a list of products displayed
	When I hover over the first product and click the "Add to cart" button
	Then I should see a confirmation modal indicating the product was added to the cart
	When I click the "Continue Shopping" button on the confirmation modal
	Then I should be redirected back to the Products page
	When I click the Cart button in the navigation bar
	Then I should see the cart page with the added product listed and total price displayed