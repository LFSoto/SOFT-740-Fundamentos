using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Proyecto_SwagLabs.Tests.Pages
{
    /// <summary>
    /// Página del carrito de compras de SwagLabs.
    /// Permite consultar los productos actualmente en el carrito.
    /// </summary>
    public class CartPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public CartPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Elementos que representan cada producto en el carrito.
        /// </summary>
        private IReadOnlyCollection<IWebElement> CartItems =>
            _driver.FindElements(By.CssSelector("div.cart_item"));

        /// <summary>
        /// Obtiene la lista de nombres de productos actualmente visibles en el carrito.
        /// </summary>
        public IList<string> GetProductNames()
        {
            _wait.Until(_ => CartItems.Any());

            return CartItems
                .Select(item => item.FindElement(By.CssSelector("div.inventory_item_name")).Text.Trim())
                .ToList();
        }
    }
}
