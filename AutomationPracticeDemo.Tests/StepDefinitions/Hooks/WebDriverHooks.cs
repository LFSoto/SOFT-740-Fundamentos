using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Reqnroll;

namespace Proyecto_SwagLabs.Tests.StepDefinitions.Hooks
{
    /// <summary>
    /// Hooks de Reqnroll para inicializar y finalizar el WebDriver
    /// antes y después de cada escenario. Usa Firefox.
    /// </summary>
    [Binding]
    public class WebDriverHooks
    {
        private readonly ScenarioContext _scenarioContext;

        public WebDriverHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            // ==============================
            // CONFIGURACIÓN FIREFOX
            // ==============================
            var options = new FirefoxOptions();

            // Tamaño de ventana / maximizado
            options.AddArgument("--width=1920");
            options.AddArgument("--height=1080");

            // Si quieres modo privado en cada ejecución:
            // options.AddArgument("-private");

            // ==============================
            // INICIALIZAR DRIVER
            // ==============================
            var driver = new FirefoxDriver(options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://automationexercise.com/");

            // Guardamos el driver en el contexto del escenario
            _scenarioContext["WebDriver"] = driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_scenarioContext.TryGetValue("WebDriver", out IWebDriver? driver) && driver != null)
            {
                try
                {
                    // Pequeña pausa opcional para ver el resultado
                    // Thread.Sleep(2000);
                    driver.Quit();
                }
                finally
                {
                    driver.Dispose();
                }
            }
        }
    }
}
