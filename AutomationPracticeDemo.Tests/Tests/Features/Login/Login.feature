Feature: User login with valid credentials

  Scenario: Successful login with valid credentials
    Given I am on the home page
    Then I should see the text Home
    When I click the Signup button
    Then I should see the text Login to your account
    When I enter the system with valid credentials
    Then I should see the text Logged in as username













