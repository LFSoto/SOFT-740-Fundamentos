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
            var url = "https://testautomationpractice.blogspot.com/";
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            Driver = new ChromeDriver(options);
            Driver.Navigate().GoToUrl(url);
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
