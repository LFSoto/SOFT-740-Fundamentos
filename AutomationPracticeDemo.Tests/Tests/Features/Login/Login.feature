Feature: User login with valid credentials

  Scenario: Successful login with valid credentials
    Given I am on the homepage
    When I navigate to the "login" page
    And I enter a valid "email" and "password"
    And I click the "SignUp" button to access the "homepage"
    Then the user should see their username displayed
    And a welcome message should appear on the screen


Feature: User login with invalid credentials

  Scenario: Failed login with incorrect credentials
    Given I am on the homepage
    When I navigate to the login page
    And I enter an invalid email and password
    And I click on the SignUp button
    Then the system should not allow access to the homepage
    And a message should appear indicating that the credentials are incorrect


Feature: Registration of a new user

  Scenario: Successful registration of a new user
    Given I am on the homepage
    When I navigate to the registration form
    And I enter a "name" and a valid "email" to start the registration
    And I fill in the form with a "password", "year of birth", and "country"
    And I complete the personal information with "full name", "last name", and "company"
    And I provide the address details including "primary address", "secondary address", "state", "city", and "postal code"
    And I enter the "phone number" to finish the registration form
    And I click the button to create the account
    Then the system displays the homepage
    And the registered username is shown
    And the form title is displayed correctly
    And a message appears confirming the successful registration
    And the user accesses the system with the newly created account
    And a welcome message appears with the user's name



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




Feature: Complete the contact us form

  Scenario: Successful submission of the contact form
    Given I am on the homepage
    When I navigate to the contact section
    And I enter "name", "email", "subject", and "message"
    And I attach an image in the form
    And I click the button to "send" the message
    Then an alert appears indicating that I must confirm the action
    And I confirm the alert by pressing the "OK" button
    And a message appears confirming that the details were submitted successfully


Feature: Subscribe to the newsletter

  Scenario: Successful newsletter subscription
    Given I am on the website's homepage
    When I enter "email" address in the subscription field
    And I click the button to "subscribe" to the newsletter
    Then a message appears confirming that the subscription was successful