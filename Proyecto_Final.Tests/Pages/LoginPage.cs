using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Proyecto_SwagLabs.Tests.Pages
{
    /// <summary>
    /// Page Object de la pantalla de inventario de Swag Labs.
    /// </summary>
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement UserNameInput => _driver.FindElement(By.Id("user-name"));
        private IWebElement PasswordInput => _driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => _driver.FindElement(By.Id("login-button"));
        private IWebElement ErrorMessage => _driver.FindElement(By.CssSelector("[data-test='error']"));
        private IWebElement ProductsTitle => _driver.FindElement(By.CssSelector(".title"));

        /// <summary>
        /// Realiza el login con las credenciales indicadas.
        /// </summary>
        public void Login(string username, string password)
        {
            UserNameInput.Clear();
            UserNameInput.SendKeys(username);

            PasswordInput.Clear();
            PasswordInput.SendKeys(password);

            LoginButton.Click();
        }

        /// <summary>
        /// Indica si la página de productos está visible (login exitoso).
        /// </summary>
        public bool IsProductsPageVisible()
        {
            try
            {
                _wait.Until(d => ProductsTitle.Displayed);
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        /// <summary>
        /// Devuelve el mensaje de error de login, si existe; en caso contrario, null.
        /// </summary>
        public string? GetErrorMessage()
        {
            try
            {
                _wait.Until(d => ErrorMessage.Displayed);
                return ErrorMessage.Text.Trim();
            }
            catch (NoSuchElementException)
            {
                return null;
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }
    }
}


