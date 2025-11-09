Feature: Subscribe to the newsletter

  Scenario: Successful newsletter subscription
    Given I am on the website's homepage
    When I enter "email" address in the subscription field
    And I click the button to "subscribe" to the newsletter
    Then a message appears confirming that the subscription was successful