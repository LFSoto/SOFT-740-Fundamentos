Feature: Add products to cart
 
  Scenario: Add products successfully using test data from JSON
    Given The user is on the home page
    When The user logins with credentials from test data
    Then The user is logged in and the home page is displayed with a message "Logged in as [username]"
    Then The user empties the cart if there are any items
    When The user navigates to product page
    Then The user adds products from test data
    When The user clicks on the cart link
    Then The cart should display correct product information from test data