
using AutomationPracticeDemo.Tests.Utils;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using AutomationPracticeDemo.Tests.Pages;
using Reqnroll;

namespace Proyecto_SwagLabs.Tests.StepDefinitions.Login
{
    /// <summary>
    /// Step definitions para los escenarios de login en AutomationExercise.
    /// Usa datos desde Tests/TestData/login/login.json y valida el flujo completo.
    /// </summary>
    [Binding]
    public class LoginSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;

        private JObject? _loginData;
        private JObject? _currentCase;

        /// <summary>
        /// Inicializa los steps de login obteniendo el WebDriver desde el contexto.
        /// </summary>
        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>("WebDriver");
            _loginPage = new LoginPage(_driver);
        }

        /// <summary>
        /// Carga en memoria los datos del caso indicado por su ID (ejemplo: TC01, TC02).
        /// </summary>
        /// <param name="caseId">Identificador del caso en login.json.</param>
        [Given(@"que tengo los datos de login del caso ""(.*)""")]
        public void GivenQueTengoLosDatosDeLoginDelCaso(string caseId)
        {
            // Carga perezosa del JSON de login
            _loginData ??= TestDataLoader.Load("Login/loginUser.json");

            var cases = (JArray)_loginData["Cases"]!;
            _currentCase = cases
                .OfType<JObject>()
                .FirstOrDefault(c => (string)c["Id"]! == caseId)
                ?? throw new InvalidOperationException(
                    $"No se encontró el caso '{caseId}' en loginUser.json");
        }

        /// <summary>
        /// Garantiza que el usuario se encuentra en la página de login.
        /// </summary>
        [Given(@"que estoy en la pagina de login")]
        public void GivenEstoyEnLaPaginaDeLogin()
        {
            // Navegación a la página de login si fuera necesario.
            // Ejemplo:
            // _driver.Navigate().GoToUrl("https://automationexercise.com/login");
        }

        /// <summary>
        /// Ejecuta el inicio de sesión usando las credenciales cargadas.
        /// </summary>
        [When(@"inicio sesion con esas credenciales")]
        public void WhenInicioSesionConEsasCredenciales()
        {
            if (_currentCase is null)
                throw new InvalidOperationException(
                    "No hay caso cargado. Asegúrate de ejecutar primero el Given con el CaseId.");

            var email = (string)_currentCase["Email"]!;
            var password = (string)_currentCase["Password"]!;
            _loginPage.LoginUser(email, password);
        }

        /// <summary>
        /// Valida que, tras el login, se muestre el texto "Logged in as {Usuario}".
        /// </summary>
        [Then(@"el sistema debe mostrar el nombre del usuario autenticado")]
        public void ThenElSistemaDebeMostrarElNombreDelUsuarioAutenticado()
        {
            if (_currentCase is null)
                throw new InvalidOperationException("No hay datos de usuario cargados.");

            var expectedName = (string)_currentCase["Usuario"]!;
            var message = _loginPage.GetLoginUserNameMessage();

            Assert.That(message, Is.EqualTo("Logged in as " + expectedName),
                $"Se esperaba 'Logged in as {expectedName}' pero se obtuvo '{message}'.");
        }

        /// <summary>
        /// Verifica que el login falle mostrando el mensaje de error de AutomationExercise.
        /// </summary>
        [Then(@"el login debe fallar mostrando un mensaje de error")]
        public void ThenElLoginDebeFallarMostrandoUnMensajeDeError()
        {
            var error = _loginPage.GetErrorMessage();

            Assert.That(error, Is.Not.Null.And.Not.Empty,
                "Se esperaba un mensaje de error para un login no válido.");
        }
    }
}


