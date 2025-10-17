using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace AutomationPracticeDemo.Tests.Pages
{
    /// <summary>
    /// Clase principal de la p�gina AutomationPage, que encapsula las acciones y elementos
    /// </summary>
    public class FooterPage
    {
        // Instancia del controlador WebDriver utilizada para interactuar con el navegador
        private readonly IWebDriver _driver;

        public FooterPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region GUI Elements: https://automationexercise.com/
        // ==================================================================================================
        // Este bloque agrupa todos los elementos gr�ficos (GUI) utilizados en la p�gina bajo prueba.
        // Cada regi�n secundaria corresponde a una funcionalidad o formulario espec�fico.
        // Los elementos se localizan usando selectores Id, XPath o CSS, seg�n corresponda.
        // ==================================================================================================

        #region Subscription elements
        // ==================================================================================================
        // --- Elementos del bloque de suscripci�n al bolet�n ---
        // ==================================================================================================
        private IWebElement SusbscribeEmailInput => _driver.FindElement(By.Id("susbscribe_email"));
        private IWebElement SubscribeButton => _driver.FindElement(By.Id("subscribe"));
        private IWebElement SubscriptionSuccessAlertMessage => _driver.FindElement(By.CssSelector("#success-subscribe .alert-success"));
        #endregion

        #endregion

        /// <summary>
        /// Suscribe un usuario al bolet�n de suscripci�n ingresando su correo electr�nico en el campo correspondiente.
        /// </summary>
        /// <param name="email">Correo electr�nico del usuario que desea suscribirse.</param>
        public void SubscriptionNewsletter(string email)
        {
            // Ingresa el correo electr�nico en el campo de suscripci�n
            SusbscribeEmailInput.SendKeys(email);

            // Env�a el formulario de suscripci�n
            SubscribeButton.Submit();
        }

        /// <summary>
        /// Obtiene el texto del mensaje de �xito de la suscripci�n mostrado temporalmente en pantalla.
        /// </summary>
        /// <returns>
        /// Texto del mensaje de �xito si aparece a tiempo; de lo contrario, una cadena vac�a.
        /// </returns>
        public string GetSuccessAlertMessage()
        {
            // Espera expl�cita: da hasta 5 segundos para que el mensaje aparezca
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

            try
            {
                // Espera hasta que el mensaje sea visible en el DOM
                var messageElement = wait.Until(driver =>
                {
                    return SubscriptionSuccessAlertMessage.Displayed ? SubscriptionSuccessAlertMessage : null;
                });

                // Devuelve el texto limpio del mensaje
                return messageElement.Text.Trim();
            }
            catch
            {
                // Si el mensaje no aparece a tiempo, devuelve vac�o (sin lanzar excepci�n)
                return string.Empty;
            }
        }

        /// <summary>
        /// Limpia el campo de texto del correo en el formulario de suscripci�n.
        /// </summary>
        public void CleanSusbscribeEmailInput()
        {
            // Elimina cualquier texto existente antes de ingresar un nuevo correo
            SusbscribeEmailInput.Clear();
        }
    }
}

  