Feature: Register new user
 
  Scenario: Successful registration of a new user
    Given The user is on the home page

    When The user clicks on the "SignUp/Login" button
    Then The basic data form is displayed

    When The user fills name and email in the registration form with valid data
    and The user submits the registration form
    Then The account information details form is displayed

    When The user fills all required fields in the account information form with valid data
    and  The user clicks on the "Create Account" button
    Then The account return as a success message "ACCOUNT CREATED!"

    When The user clicks on the "Continue" button
    Then The user is logged in and the home page is displayed with a message "Logged in as [username]"
    
 