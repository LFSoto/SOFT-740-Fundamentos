Feature: User login
 
  Scenario: Successful login with valid credentials "quemado"
    Given The user is on the home page
    When The user go to the "login" page
    And The user enter a valid "SOFT-740@cenfotec.com" and "SOFT-740"
    And The user clicks the "Login" button
    Then The user is logged in and the home page is displayed with a message "Logged in as [username]"

  Scenario: Unsuccessful login with invalid credentials from test data
    Given The user is on the home page
    When The user go to the "login" page
    And The user enter an invalid "email" or "password"
    And The user clicks the "Login" button
    Then An error message "Your email or password is incorrect!" is displayed