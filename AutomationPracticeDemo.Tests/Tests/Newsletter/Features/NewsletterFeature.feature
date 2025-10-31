Feature: Subscribe to the newsletter
 
  Scenario: Successful newsletter subscription
    Given The user is on the home page
    When The user enter the email address in the subscription field
    And The user clicks the subscribe button
    Then A message "You have been successfully subscribed!" is displayed