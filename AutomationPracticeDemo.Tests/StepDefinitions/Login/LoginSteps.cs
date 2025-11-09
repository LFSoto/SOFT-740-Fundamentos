using AutomationPracticeDemo.Tests.Pages;
using OpenQA.Selenium;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationPracticeDemo.Tests.StepDefinitions.Login;
using AutomationPracticeDemo.Tests.Tests.Data.LoginUsuarioExistente;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;

namespace AutomationPracticeDemo.Tests.StepDefinitions.Login
{
    [Binding]
    public class LoginSteps
    {
        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private FromPagePractica3 _formPage;
        private readonly LoginData _loginData = new();
        private int _indiceActual = 0;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
            _formPage = new FromPagePractica3(_driver);
        }

        private void CargarDatosLogin()
        {
            var dataLogin = _loginData.getLoginData;

            // Si ya llegamos al final, NO explota → vuelve al inicio (opcional)
            if (_indiceActual >= dataLogin.Length)
                _indiceActual = 0;

            var datos = dataLogin[_indiceActual] as object[];

            _scenarioContext["usuario"] = datos[0].ToString();
            _scenarioContext["contrasena"] = datos[1].ToString();
            _scenarioContext["valorHome"] = datos[2].ToString();
            _scenarioContext["valorUserLogin"] = datos[3].ToString();
            _scenarioContext["valorLogin"] = datos[4].ToString();

            _indiceActual++; // Avanza para la próxima vez que lo llames
        }


        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            CargarDatosLogin(); 
            _formPage.ValidarCargaHome();
        }

        [Then(@"I should see the text Home")]
        public void IShouldSeeTheTextHome()
        {
            Assert.That(_formPage.Valorhome, Is.EqualTo(_scenarioContext["valorHome"].ToString()));
        }

        [When(@"I click the Signup button")]
        public void IClickTheSignupButton()
        {
            _formPage.DarClicSingUP();
        }

        [Then(@"I should see the text Login to your account")]
        public void IShouldSeeTheTextLoginToYourAccount()
        {
            Assert.That(_formPage.ValorUserLogin, Is.EqualTo(_scenarioContext["valorUserLogin"].ToString()));
        }

        [When(@"I enter the system with valid credentials")]
        public void IEnterTheSystemWithValidCredentials()
        {
            _formPage.IngresarPlataforma(_scenarioContext["usuario"].ToString(),_scenarioContext["contrasena"].ToString());
        }

        [Then(@"I should see the text Logged in as username")]
        public void IShouldSeeTheTextLoggedInAsUsername()
        {
            Assert.That(_formPage.ValorLoggin,Is.EqualTo(_scenarioContext["valorLogin"].ToString()+_formPage.ValorNombreLogin));
        }
    }
}

