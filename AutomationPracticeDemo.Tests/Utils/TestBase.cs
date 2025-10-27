using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationPracticeDemo.Tests.Utils
{
    public class TestBase
    {
        protected IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            //Si los dejo sin comentar se presenta un error, hay que revisarlo
            //options.AddArgument("-- disable-notifications");
            //options.AddArgument("-- disable-infobars");
            //options.AddArgument("-- headless=new");
            //options.AddArgument("-- window-size=1920,1080");
            Driver = new ChromeDriver(options);

            // Configurar tiempo de espera impl�cito de 10 segundos
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Driver.Navigate().GoToUrl("https://automationexercise.com/signup");
        }

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
