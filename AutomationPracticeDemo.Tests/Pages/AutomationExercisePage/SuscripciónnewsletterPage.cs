using AutomationPracticeDemo.Tests.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Xml.Linq;

namespace AutomationPracticeDemo.Tests.Pages
{

    public class SuscripciónnewsletterPage
    {
        private readonly IWebDriver _driver;
        public SuscripciónnewsletterPage(IWebDriver driver)
        {
            _driver = driver;
        }



        private IWebElement signupemailinput => _driver.FindElement(By.CssSelector("input[data-qa='signup-email']"));
        private IWebElement subscribenElementInput => _driver.FindElement(By.Id("susbscribe_email"));
        private IWebElement suscribeButton => _driver.FindElement(By.Id("susbscribe_email"));
        private IWebElement suscribeMessage => _driver.FindElement(By.CssSelector("div[class=\"alert-success alert\"] "));
        private IWebElement suscribtn => _driver.FindElement(By.Id("subscribe"));
        //Se escribe el correo

        public void subscribirEmail(string email)
       {

            subscribenElementInput.SendKeys(email);
            
        }
        public void suscriBtn()
        {

            
            suscribtn.Click();
        }
        public string validasubscri()
        {
            string texto = suscribeMessage.Text;
            return texto;
        }

    }
}
