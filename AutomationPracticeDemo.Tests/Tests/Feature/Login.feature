Feature: Login

  Scenario: Successful login with valid credentials
        Given I am on the start page
        And I navigate to the "Login" page
        Then I should see the title "Login to your account"
        When I fill the login form with email "<email>" and password "<password>"
        And I click the login button
        Then I should see the "Logout" button

  Scenario: Failed login with invalid credentials
        Given I am on the start page
        And I navigate to the "Login" page
        Then I should see the title "Login to your account"
        When I fill the login form with email "<email>" and password "<password>"
        And I click the login button
        Then I should see the error message "Your email or password is incorrect!"