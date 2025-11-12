using DixonProyectoFinal.Tests.Pages;
using OpenQA.Selenium;
using Reqnroll;

namespace DixonProyectoFinal.Tests.StepDefinitions
{
    /// <summary>
    /// Esta clase contiene los pasos que serán utilizados por 2 o más features para evitar duplicar código
    /// </summary>
    [Binding]
    public class UniversalSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private LoginPage _loginPage;

        public UniversalSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
            _loginPage = new LoginPage(_driver);
        }

        [Given(@"I logged in with valid credentials: ""(.*)"", ""(.*)""")]
        public void LoginWithValidCredentials(string username, string password)
        {
            _loginPage.Login(username, password);
        }
        [Given(@"I'm on the Inventory Page: ""(.*)""")]
        [Then(@"I'm on the Inventory Page: ""(.*)""")]
        public void ValidateLogin(string url)
        {
            Assert.That(_driver.Url.Contains(url), "Not navigated to inventory page");
        }
    }
}
