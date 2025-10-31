Feature: SignUp/Login
  Scenario: Successful Sign up for a new user
    Given I am on the start page
    And I open the "Sign Up / Login" page
    When I enter an "email" and a "name" in the Sign Up form
    And I click the SignUp button
    And the page redirects to Register Form
    When I fill the form with valid data
    And I click the Create Account button
    Then I should see a confirmation message saying ACCOUNT CREATED!
    When I continue to the site
    Then I should be logged in successfully

  Scenario: Succesful Login with valid credentials
    Given I am on the start page
    And I navigate to the "Sign Up / Login" page
    When I enter a valid email address and a valid password in the login form
    And I click the Login button
    Then I should be logged in successfully

  Scenario: Fail Login with invalid email or password
    Given I am on the start page
    And I navigate to the "Sign Up / Login" page
    When I enter an invalid email address or an incorrect password
    And I click the Login button
    Then I should see an error message indicating that the email or password is incorrect