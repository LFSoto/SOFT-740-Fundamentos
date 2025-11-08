Feature: News Letter Subscription
  Scenario: Successful subscription to the newsletter
	Given I am on the home page
	When I enter a valid "SOFT-740@cenfotec.com" address in the newsletter subscription field
	And I click the subscribe button
	Then I should see a subscription confirmation message "You have been successfully subscribed!"