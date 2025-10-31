Feature: Newsletter
  Scenario: Subscribe to the newsletter successfully
    Given I am on the start page
    And I scroll down to the bottom of the page
    When I enter an "email" in the subscription field
    And I click the subscribe button
    Then I should see a confirmation message that the subscription was successful