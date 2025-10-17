using AutomationPracticeDemo.Tests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationPracticeDemo.Tests.Utils
{
    /// <summary>
    /// Clase base para todas las pruebas automatizadas.
    /// Contiene la configuración y finalización del WebDriver,
    /// así como la inicialización de las páginas del proyecto.
    /// </summary>
    public class TestBase
    {
        protected IWebDriver Driver;

        // Instancias compartidas de las diferentes páginas del sitio.
        protected ContactUsPage contactPage;
        protected FooterPage footerPage;
        protected ProductPage productPage;
        protected LoginPage loginPage;
        protected PurchasePage purchasePage;


        /// <summary>
        /// Método que se ejecuta antes de cada prueba.
        /// Inicializa el navegador, abre la URL base e instancia las páginas requeridas.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // URL base de la aplicación bajo prueba
            var url = "https://automationexercise.com/";

            // Configura el navegador (modo maximizado)
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            // Inicia el navegador con las opciones configuradas
            Driver = new ChromeDriver(options);

            // Navega hacia la URL del entorno de pruebas
            Driver.Navigate().GoToUrl(url);

            // Inicializa las páginas con el mismo controlador WebDriver
            contactPage = new ContactUsPage(Driver);
            footerPage = new FooterPage(Driver);
            productPage = new ProductPage(Driver);
            loginPage = new LoginPage(Driver);
            purchasePage = new PurchasePage(Driver);
        }

        /// <summary>
        /// Método que se ejecuta después de cada prueba.
        /// Cierra y libera los recursos del navegador.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
            }
        }
    }
}
