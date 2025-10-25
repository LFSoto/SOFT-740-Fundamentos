using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using AutomationPracticeDemo.Tests.Tests.Data.LoginUsuarioExistente;

namespace AutomationPracticeDemo.Tests.Utils
{
    public class TestBasePractica3
    {
        protected IWebDriver Driver;
        private object[] dataLogin;


        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--disable-infobars");
            //options.AddArgument("--headless=new");
            Driver = new ChromeDriver(options);
            Driver.Navigate().GoToUrl("https://automationexercise.com/");
        }

        public void ReloadData()
        {
            dataLogin = new LoginData().getLoginData;
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
