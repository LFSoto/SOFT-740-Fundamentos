using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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
            options.AddArgument("--disable-notifications");
            options.AddArgument("--disable-infobars");
            options.AddArgument("--headless=new");
            Driver = new ChromeDriver(options);
            Driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
        }

        [TearDown]
        public void TearDown()
        {
            if (Driver != null)
            {
                System.Threading.Thread.Sleep(2000);
                Driver.Quit();
                Driver.Dispose();
            }
        }
    }
}
