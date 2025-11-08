using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Pages.AutomationExercisePage;
using AutomationPracticeDemo.Tests.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Reqnroll;


namespace AutomationPracticeDemo.Tests.Steps
{
    public class NewsletterSteps : TestBase
    {
        private SuscripciónnewsletterPage _newsletterPage;

        [Given(@"El usuario navega a la página principal de Automation Practice")]
        public void GivenElUsuarioNavegaALaPaginaPrincipal()
        {
            var baseUrl = TestContext.Parameters.Get("baseUrl", "https://automationexercise.com");
            Driver.Navigate().GoToUrl(baseUrl);
            _newsletterPage = new SuscripciónnewsletterPage(Driver);
        }

        [When(@"El usuario se dirige a la sección de suscripción al boletín")]
        public void WhenElUsuarioSeDirigeALaSeccionDeSuscripcion()
        {
            // Si la sección está en la home y es visible no hace falta más; si requiere scroll:
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }

        [When(@"El usuario ingresa un correo electrónico ""(.*)""")]
        public void WhenElUsuarioIngresaUnCorreoElectronico(string existingEmail)
        {
            _newsletterPage.subscribirEmail(existingEmail);
        }

        [When(@"El usuario da click en el botón de suscribirse")]
        public void WhenElUsuarioDaClickEnElBotonDeSuscribirse()
        {
            _newsletterPage.suscriBtn();
        }

        [Then(@"El usuario visualiza el mensaje de confirmación de suscripción exitosa ""(.*)""")]
        public void ThenElUsuarioVisualizaElMensajeDeConfirmacion(string expectedMessage)
        {
            // Espera explícita mínima por si tarda en aparecer
            Wait.Until(d => {
                try { return !string.IsNullOrEmpty(_newsletterPage.validasubscri()); }
                catch { return false; }
            });

            var actual = _newsletterPage.validasubscri();
            Assert.That(actual, Is.EqualTo(expectedMessage));
        }
    }
}