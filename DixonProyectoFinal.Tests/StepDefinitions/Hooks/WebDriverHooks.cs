using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;

namespace DixonProyectoFinal.Tests.StepDefinitions.Hooks
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
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--disable-infobars");
            options.AddArgument("--guest");

            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            _scenarioContext.Set(driver);
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
