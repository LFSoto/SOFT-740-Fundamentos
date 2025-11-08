using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.Attributes;
using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Pages.AutomationExercisePage;

namespace AutomationPracticeDemo.Tests.StepDefinitions.Login
{
    [Binding]
    public class LoginSteps
    {
        private readonly InicioPage _inicioPage;
        private readonly LoginPage _loginPage;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;
        private string _email = string.Empty;
        private string _password = string.Empty;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            try
            {
                _driver = _scenarioContext.Get<IWebDriver>();
            }
            catch (System.Collections.Generic.KeyNotFoundException ex)
            {
                throw new InvalidOperationException("IWebDriver no está registrado en ScenarioContext. Añade un Hook [BeforeScenario] que cree y registre el driver.", ex);
            }

            _loginPage = new LoginPage(_driver);
            _inicioPage = new InicioPage(_driver);
        }

        [Given(@"El usuario realiza una solicitud de inicio de sesión")]
        public void GivenElUsuarioRealizaUnaSolicitudDeInicioDeSesion()
        {
            _driver.Navigate().GoToUrl("https://automationexercise.com/");
        }

        [When(@"El usuario da click en registro/inicio de sesión")]
        public void WhenElUsuarioDaClickEnRegistroInicioDeSesion()
        {
            _inicioPage.signuplogin();
        }

        [Then(@"El usuario visualiza la página de inicio de sesión")]
        public void ThenElUsuarioVisualizaLaPaginaDeInicioDeSesion()
        {
            var mensajeEsperado = "Login to your account";
            Assert.That(_loginPage.getSignuploginTexto(), Is.EqualTo(mensajeEsperado));
        }

        [When(@"El usuario digita\s+el correo electrónico\s+""(.*)""")]
        public void WhenElUsuarioDigitaElCorreoElectronico(string email)
        {
            _email = email;
        }

        [When(@"El usuario digita\s+la contraseña\s+""(.*)""")]
        public void WhenElUsuarioDigitaLaContrasena(string password)
        {
            _password = password;
        }

        // Variante: correo y contraseña en una sola línea (si tu Feature la usa)
        [When(@"El usuario digita\s+el correo electrónico\s+""(.*)""\s+y\s+la contraseña\s+""(.*)""")]
        public void WhenElUsuarioDigitaCorreoYContrasena(string email, string password)
        {
            _email = email;
            _password = password;
        }

        [When(@"El usuario da click en el botón de iniciar sesión")]
        public void WhenElUsuarioDaClickEnElBotonDeIniciarSesion()
        {
            _loginPage.Login(_email, _password);
        }

        [Then(@"El usuario visualiza su cuenta con el nombre\s+""(.*)""")]
        public void ThenElUsuarioVisualizaSuCuentaOMensaje(string expected)
        {
            // comprobación flexible: que el texto mostrado contiene el nombre esperado
            var actual = _loginPage.getTexto();
            Assert.That(actual, Does.Contain(expected), $"Texto mostrado: '{actual}' no contiene '{expected}'");
        }
    }
}