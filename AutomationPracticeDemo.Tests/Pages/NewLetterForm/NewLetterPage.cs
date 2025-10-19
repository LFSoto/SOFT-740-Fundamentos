using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Pages.NewLetterForm
{
    public class NewLetterPage
    {
        private readonly IWebDriver _driver;
        public NewLetterPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement subscribeElementInput => _driver.FindElement(By.Id("susbscribe_email"));
        private IWebElement subscribeButton => _driver.FindElement(By.Id("subscribe"));
        private IWebElement subscribeMessage => _driver.FindElement(By.CssSelector("div[class=\"alert-success alert\"]"));

        public void newLetter(string email) 
        {
            subscribeElementInput.SendKeys(email);
            subscribeButton.Click();
        }
        public string ObtenerMensajeSuscripcion()
        {
            return subscribeMessage.Text;
        }
    }
}
