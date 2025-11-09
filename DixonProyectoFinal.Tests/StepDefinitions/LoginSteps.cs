using DixonProyectoFinal.Tests.Pages;
using OpenQA.Selenium;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #region Scenario: Successful Login with valid credentials
        [Given(@"I am on the Login Page: ""(.*)""")]
        public void GivenIAmOnTheLoginPage(string url)
        {
            Assert.That(_driver.Url.Contains(url), "Not navigated to login page");
        }

        [When(@"I enter a valid username: ""(.*)"" and a valid ""(.*)""")]
        public void FillLoginForm(string username, string password)
        {
            _loginPage.FillForm(username, password);
        }

        [When(@"I click the Login button")]
        public void SubmitForm()
        {
            _loginPage.SubmitForm();
        }

        [Then(@"I'm on the Inventory Page: ""(.*)""")]
        public void ValidateLogin(string url)
        {
            Assert.That(_driver.Url.Contains(url), "Not navigated to inventory page");
        }
        #endregion

        #region Scenario: Unsuccessful Login with invalid credentials
        #endregion
    }
}
