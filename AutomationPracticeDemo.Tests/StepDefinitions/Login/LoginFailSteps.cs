using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Tests.Data.LoginUsuarioFail;
using AutomationPracticeDemo.Tests.StepDefinitions.Login;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using System.Diagnostics.Metrics;

namespace AutomationPracticeDemo.Tests.StepDefinitions.Login
{
    [Binding]
    public class LoginFailSteps
    {
        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private FromPagePractica3 _formPage;
        private readonly LoginDataFail _loginDataFail = new();
        private int _indiceActual = 0;

        public LoginFailSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
            _formPage = new FromPagePractica3(_driver);
        }

        private void CargarDatosLoginFail()
        {
            var dataLoginFail = _loginDataFail.getLoginDataLogin;

            // Si ya llegamos al final, NO explota → vuelve al inicio (opcional)
            if (_indiceActual >= dataLoginFail.Length)
                _indiceActual = 0;

            var datos = dataLoginFail[_indiceActual] as object[];

            _scenarioContext["usuario"] = datos[0].ToString();
            _scenarioContext["contrasena"] = datos[1].ToString();
            _scenarioContext["valorHome"] = datos[2].ToString();
            _scenarioContext["valorUserLogin"] = datos[3].ToString();
            _scenarioContext["valorLogin"] = datos[4].ToString();

            _indiceActual++; // Avanza para la próxima vez que lo llames
        }

        [Given(@"I am on the home pageF")]
        public void IAmOnTheHomePage() {
            CargarDatosLoginFail();
            _formPage.ValidarCargaHome();
        }

        [Then(@"I should see the text HomeF")]
        public void IShouldSeeTheTextHome() {
            Assert.That(_formPage.Valorhome, Is.EqualTo(_scenarioContext["valorHome"].ToString()));
        }

        [When(@"I click the Signup buttonF")]
        public void IClickTheSignupButton() {
            _formPage.DarClicSingUP();
        }

        [Then(@"I should see the text Login to your accountF")]
        public void IShouldTextLoginToYourAccount() {
            Assert.That(_formPage.ValorUserLogin, Is.EqualTo(_scenarioContext["valorUserLogin"].ToString()));
        }

        [When(@"I enter the system with invalid credentialsF")]
        public void IEnterInvalidCredentials() {
            _formPage.IngresarPlataformaFail(_scenarioContext["usuario"].ToString(), _scenarioContext["contrasena"].ToString());
        }

        [Then(@"I should see the message indicating to the user Your email or password is incorrect!F")]
        public void IShouldSeeMessagePasswordIncorrect() {
            Assert.That(_formPage.ValorLoggin, Is.EqualTo(_scenarioContext["valorLogin"].ToString()));
        }

    }
}
