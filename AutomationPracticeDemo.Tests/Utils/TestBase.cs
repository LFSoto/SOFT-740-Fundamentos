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
            options.AddArgument("--headless=new");
            Driver = new ChromeDriver(options);
            //Driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
            Driver.Navigate().GoToUrl("https://automationexercise.com/");

            // Configure a global timeout for waits used across pages (seconds)
            WaitHelper.GlobalDefaultTimeoutSeconds = 15; // <-- change this value to adjust global timeout
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
