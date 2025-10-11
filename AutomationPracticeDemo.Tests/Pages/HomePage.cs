using OpenQA.Selenium;

namespace AutomationPracticeDemo.Tests.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }
        // Declaración de los elementos de la página

        //Elementos del menu
        private IWebElement signupLoginOption => _driver.FindElement(By.CssSelector("li a[href=\"/login\"]"));
        private IWebElement productOption => _driver.FindElement(By.CssSelector("li a[href=\"/products\"]"));
        private IWebElement logoutOption => _driver.FindElement(By.CssSelector("li a[href=\"/logout\"]"));
        private IWebElement contactUsOption => _driver.FindElement(By.CssSelector("li a[href=\"/contact_us\"]"));

        // Elementos del newsletter subscription
        private IWebElement subscribreElementInput => _driver.FindElement(By.Id("susbscribe_email"));
        private IWebElement suscribeButton => _driver.FindElement(By.Id("subscribe"));
        private IWebElement susbscribreMessage => _driver.FindElement(By.CssSelector("div[class=\"alert-success alert\"]"));


        // Declaración de metodos para interactuar con los elementos del menu de navegación
        public void ClickSignUpLogin()
        {
            signupLoginOption.Click();
        }
        public void ClickProductOption()
        {
            productOption.Click();
        }
        public void ClickContactUsOption()
        {
            contactUsOption.Click();
        }   
        public string validatedUserLogout()
        {
            if (logoutOption.Displayed == false)
            {
                throw new NoSuchElementException("El elemento Logout no está visible en la página.");
            }
            return logoutOption.Text;
        }

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
