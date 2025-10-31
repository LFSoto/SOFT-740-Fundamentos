Feature: ContactUs
Scenario: Add products to cart
Given I click on the Signup/login button
	When I navigate to the Signup/login page
	And I enter my login credentials "emailTest" "passwordTest"
	Then I should be logged in successfully
	When I click on the "Contact us" button
	And The title “CONTACT US” is displayed
	Then I navigate to the Contact Us page
	When I navigate to the Contact Us page
	And I add the "name", "email", "address", "subject", "message" and upload a file
	And I click on the "Submit" button
	And I see the alert message "Press OK to proceed!"
	Then I should see a success message "Success! Your details have been submitted successfully."