using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationPracticeDemo.Tests.StepDefinitions.Hooks
{
    [Binding]
    public sealed class WebDriverHooks
    {
        private readonly ScenarioContext _scenarioContext;

        public WebDriverHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--disable-infobars");
            //options.AddArgument("headless");

            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://automationexercise.com/");

            // Explicitly set as IWebDriver type to match retrieval in step definitions
            _scenarioContext.Set<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_scenarioContext.TryGetValue<IWebDriver>(out var driver))
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
//queremos llegar acá:
//.Feature (archivo texto plano de los test, incluye escenarios y pasos)
//.StepDefinitions (clases que implementan los pasos definidos en los archivos .feature) son una extensión de los test cases.
//Page Objects (definicion de los elementos web y acciones)

//Lo que tenemos
//Archivos test(clase que ejecuta acciones y valida comportamientos)
//Page Objects (definicion de los elementos web y acciones)