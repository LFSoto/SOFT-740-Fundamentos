using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DixonProyectoFinal.Tests.Utils
{
    /// <summary>
    /// Contiene los métodos que serán utilizados en las pruebas web del proyecto
    /// </summary>
    public class TestBase
    {
        protected IWebDriver Driver;

        /// <summary>
        /// Inicializa el driver de chrome con las opciones necesarias para realizar las pruebas
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized");
            //chromeOptions.AddArgument("--headless=new");

            Driver = new ChromeDriver(chromeOptions);
            Driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        /// <summary>
        /// Cierra driver y elimina su instancia de la memoria
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
