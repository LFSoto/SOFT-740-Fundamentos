Feature: Add products to cart
 
  Scenario: Add products successfully
  Given The user is on the home page
	When The user logins with valid credentials "email" and "password"
	 And The user clicks the "Login" button
    Then The user is logged in and the home page is displayed with a message "Logged in as [username]"

	When The user is on the main page after logging in 
	And The user empties the cart if there are any items
	And The user clicks on a product link
	Then The product details page is displayed

	When The user add the first product
	And The user clicks on the Continue Shopping buttom
	Then The product details page is displayed

	When The user add the second product
	And The user clicks on the Continue Shopping buttom
	Then The product details page is displayed

	When The user add the same second product
	And The user clicks on the Continue Shopping buttom
	Then The product details page is displayed

	When The user clicks on the cart link
	Then The shopping cart page is displayed with the added items, their quantity, and their respective price