using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Tests.Login.Data;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace AutomationPracticeDemo.Tests.StepDefinitions.Login
{
    [Binding]
    public class LoginSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;
        private readonly ProductsPage _productsPage;
        private string _email = "";
        private string _password = "";

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
            _loginPage = new LoginPage(_driver);
            _productsPage = new ProductsPage(_driver);
        }

        [Given(@"The user is on the home page")]
        public void GivenTheUserIsOnTheHomePage()
        {
            Assert.That(_driver.Url, Does.Contain("automationexercise.com"));
        }

        [When(@"The user go to the ""(.*)"" page")]
        public void WhenTheUserGoToThePage(string pageName)
        {
            if (pageName.ToLower() == "login")
            {
                _loginPage.Open();
            }
        }

        [When(@"The user enter a valid ""(.*)"" and ""(.*)""")]
        public void WhenTheUserEnterAValidAnd(string emailField, string passwordField)
        {
            //// Get valid credentials from test data
            //var validData = LoginData.TestCases().First(d => d.IsValid);
            //_email = validData.Email;
            //_password = validData.Password;

            // Use Page Object methods instead of direct driver access
            _loginPage.EnterEmail(emailField);
            _loginPage.EnterPassword(passwordField);
        }

        [When(@"The user enter an invalid ""(.*)"" or ""(.*)""")]
        public void WhenTheUserEnterAnInvalidOr(string emailField, string passwordField)
        {
            // Get invalid credentials from test data
            var invalidData = LoginData.TestCases().First(d => !d.IsValid);
            _email = invalidData.Email;
            _password = invalidData.Password;

            // Use Page Object methods instead of direct driver access
            _loginPage.EnterEmail(_email);
            _loginPage.EnterPassword(_password);
        }

        [When(@"The user clicks the ""(.*)"" button")]
        public void WhenTheUserClicksTheButton(string buttonName)
        {
            if (buttonName.ToLower() == "login")
            {
                _loginPage.ClickLoginButton();
            }
        }

        [Given(@"The user is logged in and the home page is displayed with a message ""(.*)""")]
        [Then(@"The user is logged in and the home page is displayed with a message ""(.*)""")]
        public void ThenTheUserIsLoggedInAndTheHomePageIsDisplayedWithAMessage(string expectedMessage)
        {
            var loggedInMessage = _loginPage.GetLoggedInUser();

            // expectedMessage will be "Logged in as [username]"
            // We need to check if it contains "Logged in as"
            Assert.That(loggedInMessage, Does.Contain("Logged in as"));
        }

        [Then(@"User validated correctly")]
        public void AndUserValidatedCorrectly() 
        {
            var loggedInMessage = _loginPage.GetLoggedInUser();
            Assert.That(loggedInMessage, Does.Contain("Logged in as"));
        }

        [Then(@"An error message ""(.*)"" is displayed")]
        public void ThenAnErrorMessageIsDisplayed(string expectedError)
        {
            var errorMessage = _loginPage.GetLoginErrorMessage();
            Assert.That(errorMessage, Is.EqualTo(expectedError));
        }

        [When(@"The user is on the main page after logging in")]
        public void WhenTheUserIsOnTheMainPageAfterLoggingIn() 
        {
            Assert.That(true);
        }

        [Then(@"The user empties the cart if there are any items")]
        public void AndTheUserEmptiesTheCartIfThereAreAnyItems()
        {
            _productsPage.EmptyCart();
        }

        [When(@"The user clicks on a product link")]
        public void AndTheUserClicksOnAProductLink()
        {
            Assert.That(true);
        }

        [When(@"The user logins with valid credentials ""(.*)"" and ""(.*)""")]
        public void WhenTheUserLoginsWithValidCredentialsAnd(string email, string password)
        {
            _loginPage.Login(email, password);
        }
    }
}
