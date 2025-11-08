Feature: Contact Us
  Scenario: Submit the contact us form with valid information
    Given I am on the start page
    And I open the "Contact Us" page
    When I enter a "Dixon", an "dixonc@test.com", a "subject test" and a "message test"
    And I attach a "capybara.png"
    And I click the Submit button
    And I confirm the alert message
    Then I should see a success message