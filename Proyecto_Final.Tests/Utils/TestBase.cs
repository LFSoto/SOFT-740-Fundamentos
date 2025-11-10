using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using Proyecto_SwagLabs.Tests.Pages;

namespace Proyecto_SwagLabs.Tests.Utils
{
    /// <summary>
    /// Clase base para todas las pruebas automatizadas.
    /// Configura y cierra el WebDriver (Firefox en este caso).
    /// Incluye medidas para evitar pop-ups de seguridad o contraseñas guardadas.
    /// </summary>
    public class TestBase
    {
        protected IWebDriver Driver;
        protected LoginPage LoginPage;

        [SetUp]
        public void Setup()
        {
            const string url = "https://www.saucedemo.com/";

            // ================================================
            // CONFIGURACIÓN DE FIREFOX
            // ================================================
            var firefoxOptions = new FirefoxOptions();

            // Ejecutar en modo normal (puedes usar --headless si deseas)
            firefoxOptions.AddArgument("--width=1920");
            firefoxOptions.AddArgument("--height=1080");

            // Crear un perfil limpio solo para las pruebas
            var profile = new FirefoxProfile();

            // Desactivar almacenamiento de contraseñas
            profile.SetPreference("signon.rememberSignons", false);
            profile.SetPreference("signon.autofillForms", false);
            profile.SetPreference("signon.storeWhenAutocompleteOff", false);

            // Desactivar advertencias o ventanas de password manager
            profile.SetPreference("extensions.formautofill.creditCards.enabled", false);
            profile.SetPreference("extensions.formautofill.addresses.enabled", false);
            profile.SetPreference("extensions.formautofill.heuristics.enabled", false);
            profile.SetPreference("security.insecure_field_warning.contextual.enabled", false);

            // Bloquear notificaciones o popups de sitios
            profile.SetPreference("dom.webnotifications.enabled", false);
            profile.SetPreference("dom.push.enabled", false);

            firefoxOptions.Profile = profile;

            // ================================================
            // INICIALIZAR DRIVER
            // ================================================
            Driver = new FirefoxDriver(firefoxOptions);
            Driver.Manage().Window.Maximize();

            // Navegar a la URL de pruebas
            Driver.Navigate().GoToUrl(url);

            // Enviar tecla ESC como medida de seguridad para cerrar overlays
            try
            {
                new Actions(Driver)
                    .SendKeys(Keys.Escape)
                    .Perform();
            }
            catch (WebDriverException)
            {
                // No crítico si falla
            }

            // Inicializar las PageObjects
            LoginPage = new LoginPage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            if (Driver == null) return;

            try
            {
                Driver.Quit();
            }
            finally
            {
                Driver.Dispose();
            }
        }
    }
}
