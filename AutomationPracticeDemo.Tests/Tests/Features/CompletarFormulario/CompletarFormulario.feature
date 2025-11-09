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