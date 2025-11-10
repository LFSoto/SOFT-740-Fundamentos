using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Proyecto_SwagLabs.Tests.Pages
{
    /// <summary>
    /// Page Object para el flujo de compra (cart + checkout) en Swag Labs.
    /// </summary>
    public class PurchasePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public PurchasePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        #region Selectores

        private IWebElement CartIcon =>
            _driver.FindElement(By.CssSelector("a.shopping_cart_link"));

        private IWebElement CheckoutButton =>
            _driver.FindElement(By.CssSelector("button[data-test='checkout']"));

        private IWebElement FirstNameInput =>
            _driver.FindElement(By.CssSelector("input[data-test='firstName']"));

        private IWebElement LastNameInput =>
            _driver.FindElement(By.CssSelector("input[data-test='lastName']"));

        private IWebElement PostalCodeInput =>
            _driver.FindElement(By.CssSelector("input[data-test='postalCode']"));

        private IWebElement ContinueButton =>
            _driver.FindElement(By.CssSelector("input[data-test='continue']"));

        private IWebElement FinishButton =>
            _driver.FindElement(By.CssSelector("button[data-test='finish']"));

        // Header de confirmación: "Thank you for your order!"
        private By OrderCompleteHeaderLocator =>
            By.CssSelector("h2.complete-header, h2[data-test='complete-header']");

        // Texto descriptivo de confirmación
        private By OrderCompleteTextLocator =>
            By.CssSelector("div.complete-text, div[data-test='complete-text']");

        #endregion

        /// <summary>
        /// Abre el carrito desde el icono del header.
        /// </summary>
        public void GoToCart()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(CartIcon)).Click();
            _wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.cart_list")));
        }

        /// <summary>
        /// Inicia el flujo de checkout desde la página del carrito.
        /// </summary>
        public void ClickCheckout()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(CheckoutButton)).Click();
            _wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.checkout_info")));
        }

        /// <summary>
        /// Completa el formulario de checkout (datos del cliente).
        /// </summary>
        public void FillCheckoutForm(string firstName, string lastName, string postalCode)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input[data-test='firstName']")));

            FirstNameInput.Clear();
            FirstNameInput.SendKeys(firstName);

            LastNameInput.Clear();
            LastNameInput.SendKeys(lastName);

            PostalCodeInput.Clear();
            PostalCodeInput.SendKeys(postalCode);
        }

        /// <summary>
        /// Avanza de la pantalla de datos del cliente al resumen de compra.
        /// </summary>
        public void ClickContinue()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(ContinueButton)).Click();
            _wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.summary_info")));
        }

        /// <summary>
        /// Finaliza el checkout haciendo clic en el botón Finish.
        /// </summary>
        public void ClickFinish()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(FinishButton)).Click();
            // Aquí todavía no asumimos que ya se ve el mensaje; lo valida IsOrderConfirmationVisible
        }

        /// <summary>
        /// Ejecuta el flujo completo: ir al carrito, checkout, llenar datos y finalizar.
        /// </summary>
        public void CompleteCheckout(string firstName, string lastName, string postalCode)
        {
            GoToCart();
            ClickCheckout();
            FillCheckoutForm(firstName, lastName, postalCode);
            ClickContinue();
            ClickFinish();
        }

        /// <summary>
        /// Verifica si se muestra la confirmación de compra ("Thank you for your order!").
        /// Usa un wait corto y devuelve true/false sin lanzar excepción.
        /// </summary>
        public bool IsOrderConfirmationVisible()
        {
            try
            {
                // Espera hasta 5s a que aparezca el header de confirmación
                var waitShort = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

                return waitShort.Until(d =>
                {
                    var headers = d.FindElements(OrderCompleteHeaderLocator);
                    if (headers.Any(h => h.Displayed))
                        return true;

                    var texts = d.FindElements(OrderCompleteTextLocator);
                    return texts.Any(t => t.Displayed);
                });
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}

