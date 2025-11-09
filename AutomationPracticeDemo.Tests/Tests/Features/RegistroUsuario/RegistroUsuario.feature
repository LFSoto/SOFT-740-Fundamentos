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