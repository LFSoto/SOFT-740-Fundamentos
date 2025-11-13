Feature: Checkout
Scenario: Complete a checkout successfuly
	Given I logged in with valid credentials: "standard_user", "secret_sauce"
	And I'm on the Inventory Page: "/inventory"
	When I add two items in the postions one and two: "1,2"
	And I navigate to the Cart Page: "/cart"
	Then The items were added
	When I navigate to the Checkout step one page: "/checkout-step-one"
	And I enter my "first name", my "last name" and my "postal code"
	And I click the Continue button
	Then I'm on the Checkout step two page: "/checkout-step-two"
	When I validate the total price of the items
	And I click the Finish button
	Then I'm on the check out complete page: "/checkout-complete"
	And I see the Checkout complete text