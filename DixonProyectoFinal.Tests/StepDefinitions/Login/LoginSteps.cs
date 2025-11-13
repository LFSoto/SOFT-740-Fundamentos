using DixonProyectoFinal.Tests.Pages;
using DixonProyectoFinal.Tests.Utils;
using OpenQA.Selenium;
using Reqnroll;

namespace DixonProyectoFinal.Tests.StepDefinitions.Login
{
    [Binding]
    public class LoginSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private LoginPage _loginPage;
        private LoginDataResult _loginDataResult;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
            _loginPage = new LoginPage(_driver);
            _loginDataResult = JsonLoaderDataHelper.LoadLoginData();
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
        [When(@"I enter valid credentials")]
        public void FillLoginFormWithValidCredentials()
        {
            if (_loginDataResult.LoginData.ElementAt(0) is not null)
            {
                LoginData loginData = _loginDataResult.LoginData.ElementAt(0);
                _loginPage.FillForm(loginData.UserName, loginData.Password);
            }
            else
            {
                Assert.Throws<ArgumentException>(() => throw new ArgumentException());
            }
        }
        #endregion

        #region Scenario: Unsuccessful Login with invalid credentials
        [When(@"I enter invalid credentials")]
        public void FillLoginFormWithInvalidCredentials()
        {
            if (_loginDataResult.LoginData.ElementAt(1) is not null)
            {
                LoginData loginData = _loginDataResult.LoginData.ElementAt(1);
                _loginPage.FillForm(loginData.UserName, loginData.Password);
            }
            else
            {
                Assert.Throws<ArgumentException>(() => throw new ArgumentException());
            }
        }

        [Then(@"It shows that the credentials are not valid")]
        public void ValidateInvalidUser()
        {
            Assert.That(_loginPage.ReturnInvalidUserText, Does.Contain("Username and password do not match any user in this service"));
        }
        #endregion
    }
}
