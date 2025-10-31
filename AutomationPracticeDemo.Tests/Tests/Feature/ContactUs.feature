Feature: Contact Us Form Submission

  Scenario: Successful submission of Contact Us
        Given I am on the start page
        When I navigate to the "Contact Us" page
        Then I should see the title "CONTACT US"

        When I fill the contact form with:Name,Email,Subject,Message 
        And I upload the file "Paisaje.jpg"
        And I click on the button to submit the contact form
        Then I should see an alert with message "Press OK to proceed!"

        When I click accept button the alert
        Then I should see the success message "Success! Your details have been submitted successfully."
