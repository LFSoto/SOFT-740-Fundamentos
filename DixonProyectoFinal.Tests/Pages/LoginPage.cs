using DixonProyectoFinal.Tests.Utils;
using OpenQA.Selenium;

namespace DixonProyectoFinal.Tests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Elementos
        private IWebElement _userNameTextBox => _driver.FindElement(By.Id("user-name"));
        private IWebElement _passwordTextBox => _driver.FindElement(By.Id("password"));
        private IWebElement _loginButton => _driver.FindElement(By.Id("login-button"));
        #endregion

        #region Métodos
        /// <summary>
        /// Llena el formulario con las credenciales recibidas
        /// </summary>
        public void FillForm(string userNameField, string passwordField)
        {
            _userNameTextBox.SendKeys(userNameField);
            _passwordTextBox.SendKeys(passwordField);
        }

        /// <summary>
        /// Presiona el botón de login
        /// </summary>
        public void SubmitForm()
        {
            _loginButton.Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants.Pages.TimeOut);
        }

        /// <summary>
        /// Realiza todo el proceso de login en un solo método
        /// </summary>
        public void Login(string userNameField, string passwordField)
        {
            FillForm(userNameField, passwordField);
            SubmitForm();
        }
        #endregion
    }
}
