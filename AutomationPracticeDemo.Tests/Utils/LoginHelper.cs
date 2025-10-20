using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Pages.MainComponents;
using OpenQA.Selenium;

namespace AutomationPracticeDemo.Tests.Utils
{
    //TODO agregar datadriven
    public class LoginHelper
    {
        private readonly IWebDriver _driver;

        public LoginHelper(IWebDriver driver)
        {
            _driver = driver;
        }

        //Credenciales de usuario de prueba: 
        private const string _emailLogin = "dchavarriaca@ucenfotec.ac.cr";
        private const string _password = "123456Aa";
        public void Login(string email = _emailLogin, string password = _password)
        {
            HeaderNav headerNav = new HeaderNav(_driver);
            LoginPage loginPage = new LoginPage(_driver);

            //Se presiona el botón Signup / Login y se espera a que carguen los elementos de la pantalla login
            headerNav.LoginLink.Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Se llenan los campos email address y password, se presiona el botón Login y se espera a que carguen los elementos de la pantalla de inicio
            loginPage.LoginEmailTextbox.SendKeys(email);
            loginPage.LoginPasswordTextbox.SendKeys(password);
            loginPage.LoginButton.Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
    }
}
