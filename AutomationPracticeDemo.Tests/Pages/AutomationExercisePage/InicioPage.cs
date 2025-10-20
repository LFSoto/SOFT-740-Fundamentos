using AutomationPracticeDemo.Tests.Utils;
using OpenQA.Selenium;

namespace AutomationPracticeDemo.Tests.Pages.AutomationExercisePage
{
    public class InicioPage 
    {
        private readonly IWebDriver _driver;


        // Constructor público para permitir la instanciación desde otras clases
        public InicioPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement SignupLogin => _driver.FindElement(By.CssSelector("a[href='/login']"));
        private IWebElement contactUs => _driver.FindElement(By.CssSelector("a[href='/contact_us']"));
        private IWebElement productos => _driver.FindElement(By.CssSelector("a[href='/products']"));
       
        private readonly By loggedInText = By.XPath("//a[contains(.,'Logged in as')]");

        public void signuplogin()
        {
            SignupLogin.Click();

        }
        public void ContactUs()
        {
            contactUs.Click();

        }
        public void carrito()
        {
            productos.Click();

        }


        public bool IsLoggedInAs(string name) => _driver.FindElement(loggedInText).Text.Contains(name, StringComparison.OrdinalIgnoreCase);

    }
}
