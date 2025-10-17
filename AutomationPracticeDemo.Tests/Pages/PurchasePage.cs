using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace AutomationPracticeDemo.Tests.Pages
{
    /// <summary>
    /// Clase principal de la página AutomationPage, que encapsula las acciones y elementos
    /// </summary>
    public class PurchasePage
    {
        // Instancia del controlador WebDriver utilizada para interactuar con el navegador
        private readonly IWebDriver _driver;

        private readonly LoginPage loginPage;

        private readonly ProductPage productPage;

        public PurchasePage(IWebDriver driver)
        {
            _driver = driver;
            loginPage = new LoginPage(driver);
            productPage = new ProductPage(driver);
        }

        #region GUI Elements: https://automationexercise.com/
        // ==================================================================================================
        // Este bloque agrupa todos los elementos gráficos (GUI) utilizados en la página bajo prueba.
        // Cada región secundaria corresponde a una funcionalidad o formulario específico.
        // Los elementos se localizan usando selectores Id, XPath o CSS, según corresponda.
        // ==================================================================================================

        #region Process Purchase Order
        // ==================================================================================================
        // --- Elementos de la orden de pedido ---
        // ==================================================================================================
        private IWebElement ProceedCheckoutButton => _driver.FindElement(By.CssSelector(".btn.btn-default.check_out"));
        private IWebElement PlaceOrderButton => _driver.FindElement(By.CssSelector(".btn.btn-default.check_out"));
        private IWebElement NameOnCardInput => _driver.FindElement(By.CssSelector("input[name='name_on_card']"));
        private IWebElement CardNumberInput => _driver.FindElement(By.CssSelector("input[name='card_number']"));
        private IWebElement CVCInput => _driver.FindElement(By.CssSelector("input[data-qa='cvc']"));
        private IWebElement MonthExpirationInput => _driver.FindElement(By.CssSelector("input[placeholder='MM']"));
        private IWebElement YearExpirationInput => _driver.FindElement(By.CssSelector("input[data-qa='expiry-year']"));
        private IWebElement PayConfirmOrderButton => _driver.FindElement(By.CssSelector("button[data-qa='pay-button']"));
        private IWebElement MessageOrderConfirmed => _driver.FindElement(By.XPath("//p[contains(text(), 'Congratulations')]"));
        private IWebElement ContinueEndOfOrderButton => _driver.FindElement(By.CssSelector(".btn.btn-primary"));
        #endregion

        #endregion

        /// <summary>
        /// Ejecuta el flujo completo de compra: inicia sesión, limpia el carrito, 
        /// agrega productos, avanza al checkout y completa el pago.
        /// </summary>
        public void ProcessPurchaseOrder(string email, string password, List<string> productIds, string name,
            string cardNumber, string cvcCode, string date)
        {
            // Inicia sesión en la cuenta del usuario
            loginPage.LoginUser(email, password);

            // Elimina los productos existentes del carrito (si hay)
            productPage.DeleteCartItems();

            // Agrega nuevos productos al carrito según los IDs especificados
            productPage.AddProductsToCart(productIds);

            // Avanza al proceso de pago (checkout)
            ProceedCheckoutButton.Click();

            // Confirma la orden antes de ingresar los datos de pago
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(25));
            IWebElement ContinueShoppingButton = wait.Until(
            SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(PlaceOrderButton));

            PlaceOrderButton.Click();

            // Completa el formulario de pago con la información de la tarjeta
            CardPaymentInformation(name, cardNumber, cvcCode, date);

        }

        /// <summary>
        /// Completa el formulario de pago con la información del usuario 
        /// y confirma la orden mediante un clic seguro en el botón de pago.
        /// </summary>
        public void CardPaymentInformation(string name, string card, string cvc, string date)
        {
            // Completa los campos del formulario de pago
            NameOnCardInput.SendKeys(name);
            CardNumberInput.SendKeys(card);
            CVCInput.SendKeys(cvc);

            // Divide la cadena de fecha (formato: MM/YY)
            var dateParts = date.Split('/');

            // Extrae los valores de mes y año de expiración
            string month = dateParts[0];
            string year = dateParts[1];

            //Selecciona la fecha de expiración en la pantalla
            MonthExpirationInput.SendKeys(month);
            YearExpirationInput.SendKeys(year);

            // Espera explícita: espera hasta que el botón de pago sea clickeable (máximo 10 segundos)
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(PayConfirmOrderButton));

            // Asegura que el botón esté visible en pantalla antes de hacer clic
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", PayConfirmOrderButton);

            // Intenta el clic normal, y si falla por bloqueo visual, usa clic JS
            try
            {
                // Intenta hacer clic de forma normal en el botón
                PayConfirmOrderButton.Click();
            }
            catch (ElementClickInterceptedException)
            {
                // Si otro elemento bloquea el clic, se realiza un clic mediante JavaScript
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", PayConfirmOrderButton);
            }
        }

        /// <summary>
        /// Obtiene el texto del mensaje de confirmación de pedido
        /// mostrado tras completar exitosamente una orden.
        /// </summary>
        public string GetMessageOrderConfirmed()
        {
            // Espera explícita: espera hasta que el botón de pago sea clickeable (máximo 10 segundos)
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            var messageElement = wait.Until(driver =>
            {
                return MessageOrderConfirmed.Displayed ? MessageOrderConfirmed : null;
            });

            // Recupera el texto del elemento que muestra el mensaje de éxito del pedido de la orden
            var message = MessageOrderConfirmed.Text.Trim();

            // Devuelve el texto del mensaj
            return message;
        }

        /// <summary>
        /// Realiza clic en el botón "Continue" que aparece al finalizar el proceso de compra,
        /// completando así el flujo de la orden.
        /// </summary>
        public void ClickContinueEndOfOrderButton()
        {
            // Ejecuta el clic sobre el botón de continuación al final del pedido
            ContinueEndOfOrderButton.Click();
        }

    }
}

  