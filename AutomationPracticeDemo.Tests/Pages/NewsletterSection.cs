using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Pages
{
    public class NewsletterSection
    {
        private readonly IWebDriver _driver;
        public NewsletterSection(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement EmailInput => _driver.FindElement(By.Id("susbscribe_email"));
        private IWebElement SubscribeButton => _driver.FindElement(By.Id("subscribe"));
        private IWebElement SubscribeMessage => _driver.FindElement(By.CssSelector("div.alert-success.alert"));
        
        //Llenar suscripción
        public void Subscribe(string email)
        {
            EmailInput.SendKeys(email);
            SubscribeButton.Click();
        }

        public string GetSubscribeMessage()
        {
            return SubscribeMessage.Text;
        }


    }
}
