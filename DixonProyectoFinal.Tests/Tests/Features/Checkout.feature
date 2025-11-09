Feature: Checkout
Scenario: Complete a checkout successfuly
	Given I logged in
	And I'm on the "inventory page"
	When I add one item
	And I add another item
	And I click the shopping cart button
	Then I'm on the "cart page"
	When There´s two items in the cart
	And I click the Checkout button
	Then I'm on the "Checkout step one page"
	When I enter my "first name", my "last name" and my "postal code"
	And I click the Continue button
	Then I'm on the "Checkout step two page"
	When I validate the 'total price of the items'
	And I click the Finish button
	Then I'm on the "check out complete page"
	And I see the 'Checkout complete text'