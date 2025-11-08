using AutomationPracticeDemo.Tests.Pages.LoginForm;
using AutomationPracticeDemo.Tests.Tests.Data;
using OpenQA.Selenium;
using Reqnroll;
using System;
using System.Xml.Linq;

namespace AutomationPracticeDemo.Tests.Step.Definitions.Login
{
    [Binding]
    public class LoginStepDefinitions
    {

        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private LoginPage _loginPage;

        static readonly int random = new Random().Next(1, 1000);
        static readonly string email = "SOFT-740" + random + "@cenfotec.com";

        const string name = "SOFT-740";

        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
            _loginPage = new LoginPage(_driver);
        }

        [When("I enter my login credentials email and password")]
        public void WhenIEnterMyLoginCredentials()
        {
            foreach (var user in GetUserData.UserLoginList) //Accedemos a public static List<LoginData> UserLoginList de la clase GetUserData.
            {
                _loginPage.LoginWithUserAccount(user.emailText, user.password);
                //ingresamos los datos desde el archivo json utilizando el objeto user de la clase GetUserData.
            }
        }

        [Then("I should be logged in successfully")]
        public void ThenIShouldBeLoggedInSuccessfully()
        {
            var textUserLogged = _loginPage.GetUserLoggued();
            Assert.That(textUserLogged, Is.EqualTo(name));
        }
    }
}
