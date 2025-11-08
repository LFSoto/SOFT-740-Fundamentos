using System;
using System.IO;
using AutomationPracticeDemo.Tests.Constants;
using AutomationPracticeDemo.Tests.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using System.Text.Json;

namespace AutomationPracticeDemo.Tests.StepDefinitions.Hooks;
[Binding]
public sealed class WebDriverHooks
{
    private readonly ScenarioContext _scenarioContext;

    public WebDriverHooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }//ctor

    [BeforeScenario]
    public void BeforeScenario()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        options.AddArgument("--disable-notifications");
        options.AddArgument("--disable-infobars");
        // Para ejecutar pruebas en segundo plano, descomenta la siguiente línea
        //options.AddArgument("--headless=new");
        // Disable Chrome password manager and save-password prompts
        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);
        options.AddUserProfilePreference("password_manager_enabled", false);
        options.AddUserProfilePreference("password_manager_leak_detection_enabled", false);
        options.AddUserProfilePreference("autofill.password_enabled", false);
        options.AddArgument("--disable-extensions");
        options.AddArgument("--no-first-run");
        options.AddArgument("--no-default-browser-check");
        options.AddArgument("--disable-save-password-bubble");
        options.AddArgument("--disable-sync");
        options.AddArgument("--disable-features=PasswordLeakDetection,PasswordManagerForAutofill,PasswordManagerUI,AutofillServerCommunication,PasswordManagerAutoSignIn");
        options.AddUserProfilePreference("password_manager_leak_detection_enabled", false);
        options.AddUserProfilePreference("password_manager_enabled", false);
        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);
        options.AddUserProfilePreference("password_manager_saved_passwords", false);
        options.AddUserProfilePreference("sync_disabled", true);

        // Use a temporary clean user profile to avoid Google-synced prompts
        var tempProfile = Path.Combine(Path.GetTempPath(), "chrometemp_" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(tempProfile);
        var prefs = new {
          profile = new {
            password_manager_enabled = false,
            default_content_setting_values = new { notifications = 2 }
          },
          credentials_enable_service = false,
          password_manager_leak_detection_enabled = false,
          sync_disabled = true
        };
        File.WriteAllText(Path.Combine(tempProfile, "Preferences"), JsonSerializer.Serialize(prefs));
        options.AddArgument($"--user-data-dir={tempProfile}");

        IWebDriver driver = new ChromeDriver(options);
        driver.Navigate().GoToUrl(ProjectConstants.BASE_URL);
        _scenarioContext.Set(driver);
        // store temp profile path to clean up later
        _scenarioContext.Set(tempProfile);
        // Configure a global timeout for waits used across pages (seconds)
        WaitHelper.GlobalDefaultTimeoutSeconds = 15; // <-- change this value to adjust global timeout
    }//BeforeScenario

    [AfterScenario]
    public void AfterScenario()
    {
        if (_scenarioContext.TryGetValue<IWebDriver>(out var driver))
        {
            try
            {
                //Comentar para que el navegador no se cierre al finalizar la prueba
                //driver.Quit();
                //driver.Dispose();
            }
            catch { }
        }//if

        if (_scenarioContext.TryGetValue<string>(out var tempProfile))
        {
            try
            {
                // small delay to ensure Chrome has released files
                System.Threading.Thread.Sleep(500);
                if (Directory.Exists(tempProfile))
                    Directory.Delete(tempProfile, true);
            }
            catch { }
        }
    }//AfterScenario
}//class
