Feature: AddToCart
Scenario: Add products to cart
	Given I click on the Signup/login button
	When I navigate to the Signup/login page
	And I enter my login credentials "emailTest" "passwordTest"
	Then I should be logged in successfully
	When I navigate to the Products page
	And I clik on viewCart button
	And The products are removed from the list
	Then The cart is empty
	When The cart is empty
	And I click on the Signup/login button
	And I enter my login credentials "emailTest" "passwordTest"
	And I should be logged in successfully
	Then I navigate to the Products page
	When I select a product from the list
	And I click on Add to cart button
	And The confirmation alert is displayed
	Then The product was added successfully
	When The products were added to the cart
	And The number of items in the cart is counted
	And The number of items is as expected
	Then The cart shows the correct number of items
