﻿Feature: Newsletter Subscription

  Scenario: Successful subscription to the newsletter
        Given I am on the start page
        When I enter "email" in the newsletter subscription field
        And I click the "Subscribe" button
        Then I should see the message "You have been successfully subscribed!"

