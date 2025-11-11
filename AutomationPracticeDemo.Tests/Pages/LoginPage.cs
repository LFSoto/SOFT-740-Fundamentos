using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace AutomationPracticeDemo.Tests.Pages
{
    /// <summary>
    /// Page Object para la funcionalidad de Login en https://automationexercise.com/
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

        #region Elementos de la página

        /// <summary>
        /// Link "Signup / Login" del menú superior.
        /// </summary>
        private IWebElement SignupLoginLink =>
            _driver.FindElement(By.CssSelector("a[href='/login']"));

        /// <summary>
        /// Campo de email del formulario de Login (Login to your account).
        /// </summary>
        private IWebElement EmailAddressLoginInput =>
            _driver.FindElement(By.CssSelector("input[data-qa='login-email']"));

        /// <summary>
        /// Campo de password del formulario de Login.
        /// </summary>
        private IWebElement PasswordLoginInput =>
            _driver.FindElement(By.CssSelector("input[data-qa='login-password']"));

        /// <summary>
        /// Botón "Login" del formulario de Login.
        /// </summary>
        private IWebElement LoginButton =>
            _driver.FindElement(By.CssSelector("button[data-qa='login-button']"));

        /// <summary>
        /// Texto "Logged in as {Usuario}" que aparece en el navbar cuando el login es exitoso.
        /// Ejemplo: "Logged in as Johan".
        /// </summary>
        private IWebElement LoggedInAsLabel =>
            _driver.FindElement(By.CssSelector("li a:contains('Logged in as')")); // si no funciona, ajusta el selector

        /// <summary>
        /// Contenedor del mensaje de error de login (ej: "Your email or password is incorrect!").
        /// </summary>
        private IWebElement LoginErrorMessage =>
            _driver.FindElement(By.CssSelector("p[style='color: red;']"));

        #endregion

        #region Acciones públicas

        /// <summary>
        /// Navega a la página de Login haciendo clic en el link "Signup / Login"
        /// y espera a que el formulario esté visible.
        /// </summary>
        public void NavigateToLoginPage()
        {
            // Si ya estamos en /login, no es necesario volver a hacer clic.
            if (!_driver.Url.Contains("/login", StringComparison.OrdinalIgnoreCase))
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(SignupLoginLink)).Click();
            }

            // Espera a que el campo de email del login esté visible.
            _wait.Until(ExpectedConditions.ElementIsVisible(
                By.CssSelector("input[data-qa='login-email']")));
        }

        /// <summary>
        /// Realiza el login con las credenciales proporcionadas.
        /// Si aún no estamos en la página de login, navega primero a ella.
        /// </summary>
        /// <param name="email">Correo electrónico del usuario.</param>
        /// <param name="password">Contraseña del usuario.</param>
        public void LoginUser(string email, string password)
        {
            // Asegura que estamos en la página de login y que el formulario está cargado.
            NavigateToLoginPage();

            // Espera explícitamente a que los campos estén visibles antes de escribir.
            var emailInput = _wait.Until(ExpectedConditions.ElementIsVisible(
                By.CssSelector("input[data-qa='login-email']")));
            var passwordInput = _wait.Until(ExpectedConditions.ElementIsVisible(
                By.CssSelector("input[data-qa='login-password']")));
            var loginButton = _wait.Until(ExpectedConditions.ElementToBeClickable(
                By.CssSelector("button[data-qa='login-button']")));

            emailInput.Clear();
            emailInput.SendKeys(email);

            passwordInput.Clear();
            passwordInput.SendKeys(password);

            loginButton.Click();
        }

        /// <summary>
        /// Obtiene el texto completo del mensaje "Logged in as {Usuario}" después de un login exitoso.
        /// </summary>
        public string GetLoginUserNameMessage()
        {
            // Aquí conviene usar un wait por si la navegación tarda un poco
            var label = _wait.Until(driver =>
            {
                try
                {
                    // Ajusta el selector si es necesario según el HTML real:
                    // normalmente es algo como:  //*[contains(text(),'Logged in as')]
                    var element = driver.FindElement(By.XPath("//*[contains(text(),'Logged in as')]"));
                    return element.Displayed ? element : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });

            return label.Text.Trim();
        }

        /// <summary>
        /// Devuelve el mensaje de error mostrado en el login cuando las credenciales son inválidas.
        /// </summary>
        /// <returns>
        /// Texto del mensaje de error, o cadena vacía si no se encuentra el elemento.
        /// </returns>
        public string GetErrorMessage()
        {
            try
            {
                // Esperamos un poco a que aparezca el mensaje (si es que se muestra).
                var errorElement = _wait.Until(driver =>
                {
                    try
                    {
                        var el = driver.FindElement(By.CssSelector("p[style='color: red;']"));
                        return el.Displayed ? el : null;
                    }
                    catch (NoSuchElementException)
                    {
                        return null;
                    }
                });

                return errorElement?.Text.Trim() ?? string.Empty;
            }
            catch (WebDriverTimeoutException)
            {
                // No apareció mensaje de error dentro del tiempo de espera.
                return string.Empty;
            }
        }

        #endregion
    }
}

