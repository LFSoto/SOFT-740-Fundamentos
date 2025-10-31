Feature: Contact Us
  Scenario: Submit the contact us form with valid information
    Given I am on the start page
    And I open the "Contact Us" page
    When I enter a "name", an "email", a "subject" and a "message"
    And I attach a "file"
    And I click the Submit button
    And I confirm the alert message
    Then I should see a success message