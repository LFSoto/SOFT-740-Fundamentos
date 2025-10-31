Feature: NewLetter
Scenario: Enter email to subscribe to newsletter
	Given I enter the "https://automationexercise.com" page
	When I navigate to the automation exercise home page
	And I added the email
	And I click on the "Subscribe" button
	Then The message “You have been successfully subscribed!” is displayed