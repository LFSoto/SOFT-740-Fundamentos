Feature: Add products to cart and verify the total purchase amount

  Scenario: Successful purchase with products added to the cart
    Given I am on the homepage
    When I navigate to the "login" page
    And I enter a valid "email" and "password"
    And I click on the "SignUp" button to access the homepage
    And I navigate to the products section
    And I view the list of available products
    And I select the first product and click the button to "add" it to the cart
    And I return to the products section
    And I select the second product and click the button to "add" it to the cart
    And I open the shopping cart to review the selected products
    And I confirm that both products are listed with their correct descriptions and prices
    And I proceed to the checkout section
    And I enter the "cardholder name", "card number", "CVC", "month", and "year" to complete the payment
    Then the system displays the homepage
    And the connected user's name is shown
    And the products form title is displayed
    And it is confirmed that the products were added correctly
    And the description of the "first" product is shown
    And the description of the "second" product is shown
    And the total displayed by the system matches the calculated "total"
    And a message appears confirming that the order was successfully completed