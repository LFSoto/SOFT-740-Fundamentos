Feature: Inventory Page
Scenario: Add two items
	Given I logged in
	And I'm on the "inventory page"
	When I add an "item"
	And I add another "item"
	Then The Remove button shows on those items