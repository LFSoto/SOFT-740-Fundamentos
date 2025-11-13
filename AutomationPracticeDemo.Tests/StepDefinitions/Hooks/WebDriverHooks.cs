using Reqnroll;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AutomationPracticeDemo.Tests.Constants;

namespace AutomationPracticeDemo.Tests.StepDefinitions.Hooks;
[Binding]
public sealed class WebDriverHooks
{
    private readonly ScenarioContext scenarioContext;
    public WebDriverHooks(ScenarioContext scenarioContext)
    {
        this.scenarioContext = scenarioContext;
    }//WebDriverHooks

    [BeforeScenario]
    public void BeforeScenario()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        options.AddArgument("--disable-notifications");
        options.AddArgument("--disable-infobars");
        options.AddArgument("--disable-extensions");
        // Coment the next line to see the browser during test execution 
        options.AddArgument("headless");
        // Disable Chrome password manager and save-password prompts
        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);
        options.AddUserProfilePreference("profile.password_manager_leak_detection", false);

        IWebDriver driver = new ChromeDriver(options);
        driver.Navigate().GoToUrl(ProjectConstants.BASE_URL);
        scenarioContext.Set(driver);
    }//BeforeScenario

    [AfterScenario]
    public void AfterScenario()
    {
        if (scenarioContext.TryGetValue<IWebDriver>(out var driver))
        {
           driver.Quit();
           driver.Dispose();
        }//if
    }//AfterScenario
}//WebDriverHooks