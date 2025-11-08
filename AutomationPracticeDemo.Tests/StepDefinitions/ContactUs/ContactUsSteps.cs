using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Pages.MainComponents;
using OpenQA.Selenium;
using Reqnroll;

namespace AutomationPracticeDemo.Tests.StepDefinitions.Products
{
    [Binding]
    public class ContactUsSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private HeaderNav _headerNav;
        private ContactUsPage _contactUsPage;

        public ContactUsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
            _headerNav = new HeaderNav(_driver);
            _contactUsPage = new ContactUsPage(_driver);
        }

        [Given(@"I am on the start page")]
        public void GivenIAmOnTheStartPage()
        {
            Assert.That(_driver.Url.Contains("https://automationexercise.com/"), "Not navigated to contact us page");
        }

        [Given(@"I open the ""(.*)"" page")]
        public void AndIOpenTheContactUsPage(string pageName)
        {
            _headerNav.NavigateToContactUsPage();
            if (pageName.Equals("Contact Us"))
            {
                Assert.That(_driver.Url.Contains("/contact_us"), "Not navigated to contact us page");
            }
        }

        //Para la práctica no se implementó la lectura de datos, para el proyecto si se implementará, por eso se les asignó valores por defecto a los parámetros
        [When(@"I enter a ""(.*)"", an ""(.*)"", a ""(.*)"" and a ""(.*)""")]
        public void WhenIEnterFillTheForm(string nameField, string emailField, string subjectField, string messageField)
        {
            _contactUsPage.FillForm(nameField, emailField, subjectField, messageField);
        }

        [When(@"I attach a ""(.*)""")]
        public void AndIAttachAFile(string fileName = "capybara.png")
        {
            _contactUsPage.AttachFile(fileName);
        }

        [When(@"I click the Submit button")]
        public void AndIClickTheSubmitButton()
        {
            _contactUsPage.SubmitForm();
        }

        [When(@"I confirm the alert message")]
        public void AndIConfirmTheAlertMessage()
        {
            _contactUsPage.ConfirmAlertMessage();
        }

        [Then(@"I should see a success message")]
        public void ThenIShouldSeeASuccessMessage()
        {
            Assert.That(_contactUsPage.GetAlertSuccessActualText, Is.EqualTo("Success! Your details have been submitted successfully."));
        }
    }
}
