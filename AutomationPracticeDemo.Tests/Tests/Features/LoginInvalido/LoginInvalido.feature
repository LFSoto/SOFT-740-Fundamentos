Feature: User login with invalid credentials

  Scenario: Failed login with incorrect credentials
    Given I am on the home pageF
    Then I should see the text HomeF
    When I click the Signup buttonF
    Then I should see the text Login to your accountF
    When I enter the system with invalid credentialsF
    Then I should see the message indicating to the user Your email or password is incorrect!F
