Feature: Products
  Scenario: Add multiple items to the cart and verify the total cost
    Given I am on the start page
    And I open the "Products" page
    When I click the Add to cart button on the first product
    And I click the Continue Shopping button
    And I click the Add to cart button on the second product
    And I click the View Cart link
    And the page redirects to the View Cart page
    And I click the Proceed To Checkout button
    And the page redirects to the Checkout page
    Then the total amount displayed should be equal to the sum of each product price