using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace AutomationPracticeDemo.Tests.Pages
{
    /// <summary>
    /// Clase principal de la página AutomationPage, que encapsula las acciones y elementos
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
        // Este bloque agrupa todos los elementos gráficos (GUI) utilizados en la página bajo prueba.
        // Cada región secundaria corresponde a una funcionalidad o formulario específico.
        // Los elementos se localizan usando selectores Id, XPath o CSS, según corresponda.
        // ==================================================================================================

        #region Subscription elements
        // ==================================================================================================
        // --- Elementos del bloque de suscripción al boletín ---
        // ==================================================================================================
        private IWebElement SusbscribeEmailInput => _driver.FindElement(By.Id("susbscribe_email"));
        private IWebElement SubscribeButton => _driver.FindElement(By.Id("subscribe"));
        private IWebElement SubscriptionSuccessAlertMessage => _driver.FindElement(By.CssSelector("#success-subscribe .alert-success"));
        #endregion

        #endregion

        /// <summary>
        /// Suscribe un usuario al boletín de suscripción ingresando su correo electrónico en el campo correspondiente.
        /// </summary>
        /// <param name="email">Correo electrónico del usuario que desea suscribirse.</param>
        public void SubscriptionNewsletter(string email)
        {
            // Ingresa el correo electrónico en el campo de suscripción
            SusbscribeEmailInput.SendKeys(email);

            // Envía el formulario de suscripción
            SubscribeButton.Submit();
        }

        /// <summary>
        /// Obtiene el texto del mensaje de éxito de la suscripción mostrado temporalmente en pantalla.
        /// </summary>
        /// <returns>
        /// Texto del mensaje de éxito si aparece a tiempo; de lo contrario, una cadena vacía.
        /// </returns>
        public string GetSuccessAlertMessage()
        {
            // Espera explícita: da hasta 5 segundos para que el mensaje aparezca
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
                // Si el mensaje no aparece a tiempo, devuelve vacío (sin lanzar excepción)
                return string.Empty;
            }
        }

        /// <summary>
        /// Limpia el campo de texto del correo en el formulario de suscripción.
        /// </summary>
        public void CleanSusbscribeEmailInput()
        {
            // Elimina cualquier texto existente antes de ingresar un nuevo correo
            SusbscribeEmailInput.Clear();
        }
    }
}

  