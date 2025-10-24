using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Pages.MainComponents
{
    public class footerPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public footerPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        // Elementos del newsletter subscription
        //Implementación de espera explícita para asegurar que los elementos estén presentes antes de interactuar con ellos
        private IWebElement subscribreElementInput => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("susbscribe_email")));
        private IWebElement suscribeButton => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("subscribe")));
        private IWebElement susbscribreMessage => _driver.FindElement(By.CssSelector("div[class=\"alert-success alert\"]"));

        // Métodos para la suscripción al newsletter
        public void FillSuscribeInput(string email)
        {
            subscribreElementInput.SendKeys(email);
        }
        public string GetSuscribeMessage()
        {
            return susbscribreMessage.Text;
        }
        public void SumitSuscibeButton()
        {
            suscribeButton.Click();
        }
    }
}
