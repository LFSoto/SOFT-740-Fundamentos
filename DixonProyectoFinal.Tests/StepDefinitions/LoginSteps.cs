using DixonProyectoFinal.Tests.Pages;
using OpenQA.Selenium;
using Reqnroll;

namespace DixonProyectoFinal.Tests.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private LoginPage _loginPage;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
            _loginPage = new LoginPage(_driver);
        }

        #region Métodos en común
        [Given(@"I am on the Login Page: ""(.*)""")]
        public void GivenIAmOnTheLoginPage(string url)
        {
            Assert.That(_driver.Url.Contains(url), "Not navigated to login page");
        }

        [When(@"I click the Login button")]
        public void SubmitForm()
        {
            _loginPage.SubmitForm();
        }
        #endregion

        #region Scenario: Successful Login with valid credentials
        [When(@"I enter a valid username: ""(.*)"" and a valid ""(.*)""")]
        public void FillLoginFormWithValidCredentials(string username, string password)
        {
            _loginPage.FillForm(username, password);
        }
        #endregion

        #region Scenario: Unsuccessful Login with invalid credentials
        [When(@"I enter an invalid ""(.*)"" and a invalid ""(.*)""")]
        public void FillLoginFormWithInvalidCredentials(string username, string password)
        {
            _loginPage.FillForm(username, password);
        }

        [Then(@"It shows that the credentials are not valid")]
        public void ValidateInvalidUser()
        {
            Assert.That(_loginPage.ReturnInvalidUserText, Does.Contain("Username and password do not match any user in this service"));
        }
        #endregion
    }
}
