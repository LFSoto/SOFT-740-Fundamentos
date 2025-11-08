Feature: Contact Us register
 
  Scenario:Successful submission of contact us form with valid info
	Given The user is on the home page
	When The user clicks on Contact Us buttom
	Then The contact form is displayed

	When The user fills in the contact form from testdata
	And The user clicks the submit button
	Then An alert is displayed for confirmation

	When The user accepts the alert
	Then A success message "Success! Your details have been submitted successfully." is displayed
