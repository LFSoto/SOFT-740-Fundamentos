Feature: News Letter Subscription
  Scenario: Successful subscription to the newsletter
	Given I am on the home page
	When I enter a valid email address in the newsletter subscription field
	And I click the subscribe button
	Then I should see a subscription confirmation message