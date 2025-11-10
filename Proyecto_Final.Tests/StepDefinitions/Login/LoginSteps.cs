using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using Proyecto_SwagLabs.Tests.Pages;
using Proyecto_SwagLabs.Tests.Utils;
using Reqnroll;

namespace Proyecto_SwagLabs.Tests.StepDefinitions.Login
{
    /// <summary>
    /// Step definitions para los escenarios de login en SwagLabs.
    /// </summary>
    /// <remarks>
    /// Los datos de prueba se obtienen del archivo <c>Tests/TestData/Login/loginUser.json</c>
    /// mediante <see cref="TestDataLoader"/>, y las acciones sobre la UI se delegan a
    /// <see cref="LoginPage"/>.
    /// </remarks>
    [Binding]
    public class LoginSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;

        // JSON completo de loginUser.json
        private JObject? _loginData;

        // Caso actual (nodo "Cases[i]") correspondiente al Id indicado en el escenario
        private JObject? _currentCase;

        /// <summary>
        /// Inicializa los steps de login utilizando el <see cref="ScenarioContext"/> actual.
        /// </summary>
        /// <param name="scenarioContext">
        /// Contexto del escenario BDD, desde el cual se recupera la instancia de <see cref="IWebDriver"/>.
        /// </param>
        /// <remarks>
        /// Se asume que el WebDriver ha sido creado y almacenado previamente en el contexto
        /// bajo la clave <c>"WebDriver"</c> por los hooks de inicialización.
        /// </remarks>
        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>("WebDriver");
            _loginPage = new LoginPage(_driver);
        }

        /// <summary>
        /// Carga en memoria los datos del caso de login indicado por su identificador.
        /// </summary>
        /// <param name="caseId">
        /// Identificador del caso definido en <c>loginUser.json</c> (propiedad <c>Id</c> dentro de cada objeto de <c>Cases</c>).
        /// </param>
        /// <remarks>
        /// Este paso lee el archivo <c>Login/loginUser.json</c> sólo una vez por escenario y
        /// selecciona el caso correspondiente, dejándolo disponible en <see cref="_currentCase"/>.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Se lanza si no existe ningún caso en el JSON cuyo <c>Id</c> coincida con <paramref name="caseId"/>.
        /// </exception>
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
        /// <remarks>
        /// Actualmente no realiza ninguna acción, ya que la navegación inicial se hace en los hooks
        /// de WebDriver. Puede utilizarse para validar la URL o elementos característicos de la página.
        /// </remarks>
        [Given(@"estoy en la pagina de login")]
        public void GivenEstoyEnLaPaginaDeLogin()
        {
            // Aquí podrías validar que la URL o el título corresponden a la página de login.
            // Por ejemplo:
            // Assert.That(_driver.Url, Does.Contain("saucedemo.com"));
        }

        /// <summary>
        /// Ejecuta el inicio de sesión usando las credenciales cargadas para el caso actual.
        /// </summary>
        /// <remarks>
        /// Usa los campos <c>UserName</c> y <c>Password</c> del objeto <see cref="_currentCase"/>
        /// y delega la acción a <see cref="LoginPage.Login(string,string)"/>.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Se lanza si no se ha cargado previamente un caso de login mediante
        /// <see cref="GivenQueTengoLosDatosDeLoginDelCaso(string)"/>.
        /// </exception>
        [When(@"inicio sesion con esas credenciales")]
        public void WhenInicioSesionConEsasCredenciales()
        {
            if (_currentCase is null)
                throw new InvalidOperationException(
                    "No hay caso de login cargado. Asegúrate de ejecutar primero el step 'Given que tengo los datos de login del caso \"X\"'.");

            var username = (string)_currentCase["UserName"]!;
            var password = (string)_currentCase["Password"]!;

            _loginPage.Login(username, password);
        }

        /// <summary>
        /// Verifica que el login haya sido exitoso mostrando la página de productos.
        /// </summary>
        /// <remarks>
        /// La validación se realiza mediante <see cref="LoginPage.IsProductsPageVisible"/>,
        /// que comprueba la presencia de elementos característicos de la página posterior al login.
        /// </remarks>
        /// <exception cref="AssertionException">
        /// Se lanza si la página de productos no es visible después del intento de login.
        /// </exception>
        [Then(@"el login debe ser exitoso")]
        public void ThenElLoginDebeSerExitoso()
        {
            Assert.That(_loginPage.IsProductsPageVisible(),
                "Se esperaba que la página de productos estuviera visible después de un login exitoso.");
        }

        /// <summary>
        /// Verifica que el intento de login falle y se muestre un mensaje de error.
        /// </summary>
        /// <remarks>
        /// Este paso se utiliza en escenarios negativos de autenticación
        /// (por ejemplo, usuario bloqueado o credenciales incorrectas).
        /// La validación se realiza revisando el texto devuelto por <see cref="LoginPage.GetErrorMessage"/>.
        /// </remarks>
        /// <exception cref="AssertionException">
        /// Se lanza si no se encuentra un mensaje de error o si el texto está vacío.
        /// </exception>
        [Then(@"el login debe fallar mostrando un mensaje de error")]
        public void ThenElLoginDebeFallarMostrandoUnMensajeDeError()
        {
            var error = _loginPage.GetErrorMessage();

            Assert.That(error, Is.Not.Null.And.Not.Empty,
                "Se esperaba un mensaje de error para un login no válido.");
        }
    }
}



