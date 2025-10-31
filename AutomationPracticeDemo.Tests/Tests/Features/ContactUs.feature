Feature: Contact Us Functionality
  Scenario: Successful submission of contact us form with valid details
	Given I am on the home page
	When I click the Contact Us link
	Then I navigate to the Contact Us page
	When I fill in the contact form with "name", "email", "subject", "message" and "fileName"
	And I click the submit button
	Then I should see a confirmation alert message indicating successful submission
	When I click the Acept button on the alert
	Then I should be redirected to the home page