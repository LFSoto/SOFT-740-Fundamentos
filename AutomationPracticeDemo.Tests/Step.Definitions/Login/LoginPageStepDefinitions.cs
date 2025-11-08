using AutomationPracticeDemo.Tests.Pages.LoginForm;
using OpenQA.Selenium;
using Reqnroll;
using System;

namespace AutomationPracticeDemo.Tests
{
    [Binding]
    public class LoginPageStepDefinitions
    {

        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private LoginPage _loginPage;

        public LoginPageStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
            _loginPage = new LoginPage(_driver);
        }

        [Given("I click on the Signup\\/login button")]
        public void GivenIClickOnTheSignupLoginButton()
        {
            _loginPage.SignupLogin();
        }

        [When("I navigate to the Signup\\/login page")]
        public void WhenINavigateToTheSignupLoginPage()
        {
            Assert.That(_driver.Url, Is.EqualTo("https://automationexercise.com/login"));
        }


        [Then("the button changes color")]
        public void ThenTheButtonChangesColor()
        {
            Assert.That(_loginPage.LoginButtonColor, Is.EqualTo("rgba(255, 165, 0, 1)"));
        }
    }
}
