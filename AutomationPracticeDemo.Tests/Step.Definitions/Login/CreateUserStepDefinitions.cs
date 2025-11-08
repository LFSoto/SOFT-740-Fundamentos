using AutomationPracticeDemo.Tests.Pages.LoginForm;
using AutomationPracticeDemo.Tests.Tests.Data;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using Reqnroll;
using System;

namespace AutomationPracticeDemo.Tests.Step.Definitions.Login
{
    [Binding]
    public class CreateUserStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private LoginPage _loginPage;

        static readonly int random = new Random().Next(1, 1000);
        static readonly string email = "SOFT-740" + random + "@cenfotec.com";
        const string name = "SOFT-740";

        public CreateUserStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
            _loginPage = new LoginPage(_driver);
        }

        [Given("I click on the SignupLogin button")]
        public void GivenIClickOnTheSignupLoginButton()
        {
            _loginPage.SignupLogin();
        }

        [When("I enter the email and password")]
        public void WhenIEnterTheInformation()
        {
            _loginPage.NewUser(name, email);
        }

        [Then("I should see the title ENTER ACCOUNT INFORMATION")]
        public void ThenIShouldSeeTheTitleENTERACCOUNTINFORMATION()
        {
            Assert.That(_loginPage.GetTexttitleEnterAccount, Is.EqualTo("ENTER ACCOUNT INFORMATION"));
        }

        [When("I enter the account information")]
        public void EnterInformationAccount()
        {
            foreach (var user in GetUserData.NewUserLoginList)//obtener los datos de NewUserLoginList
            {
                _loginPage.EnterAccountInfo(user.password, user.dropDownDay, user.dropDownMonth, user.dropDownYear, user.inputFirstName, user.inputLastName, user.inputCompanyName, user.inputAddress1, user.inputAddress2, user.dropDownCountry, user.inputState, user.inputCity, user.inputZipCode, user.inputMobileNumb);
            }
        }
        //And I click on the Create Account button
        [When("I click on the Create Account button")]
        public void WhenIClickOnTheCreateAccountButton()
        {
            _loginPage._submitCreateAccount();
        }


        [Then("I should see the message ACCOUNT CREATED!")]
        public void ThenIShouldSeeTheMessage()
        {
            var message = _loginPage.GetCreateAccountMessage();
            Assert.That(message, Is.EqualTo("ACCOUNT CREATED!"));
        }

        [When("I click on the Continue button")]
        public void WhenIClickOnTheContinueButton()
        {
            _loginPage.ContinueAfterCreateAccount();
        }

        [Then("The user name is displayed on the Logged in as button")]
        public void ThenTheUserNameIsDisplayed()
        {
            var textUserLogged = _loginPage.GetUserLoggued();
            Assert.That(textUserLogged, Is.EqualTo(name));
        }
    }
}
