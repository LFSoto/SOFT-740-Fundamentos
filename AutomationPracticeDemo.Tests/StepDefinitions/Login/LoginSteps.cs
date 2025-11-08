using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Pages.AutomationExercisePage;
using OpenQA.Selenium;
using Reqnroll;


namespace AutomationPracticeDemo.Tests.StepDefinitions.Login
{
    [Binding]
    public class LoginSteps 
    {
        private InicioPage _inicioPage;
        private LoginPage _loginPage;
        private string _email = string.Empty;
        private string _password = string.Empty;
        private IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
            _loginPage = new LoginPage(_driver);
            _inicioPage = new InicioPage(_driver);
        }

        [Given(@"El usuario realiza una solicitud de inicio de sesion")]
        public void GivenElUsuarioNavegaALaPaginaPrincipal()
        {
            _driver.Navigate().GoToUrl("https://automationexercise.com/");
        }

        [When(@"El Usuario da click en registro de sesion")]
        public void WhenElUsuarioDaClickEnRegistroInicioDeSesion()
        {
            _inicioPage.signuplogin();
        }

        [Then(@"El usuario visualiza la pagina de inicio de sesion")]
        public void ThenElUsuarioIngresa()
        {
           var mensajeEsperado= "Login to your account";
            Assert.That(mensajeEsperado,Is.EqualTo(_loginPage.getSignuploginTexto()));
        }

        [When(@"El usuario digita el correo electronico ""(.*)"" y contrasena ""(.*)""")]
        public void WhenElUsuarioDigitaElCorreoElectronicoyContraseña(string email, string password)
        {
            _loginPage.Login(email, password);
        }

        [When(@"El usuario da click en el boton de iniciar sesion")]
        public void WhenElUsuarioDaClickEnElBotonDeIniciarSesion()
        {
            _loginPage.clickSignup();
        }

        [Then(@"El usuario visualiza su cuenta con el nombre ""(.*)""")]
        public void ThenElUsuarioVisualizaSuCuentaOMensaje(string expected)
        {
            var mensajeEsperado = "Logged in as SOFT-740";
            Assert.That(mensajeEsperado, Is.EqualTo(_loginPage.getTexto()));
        }
    }
}