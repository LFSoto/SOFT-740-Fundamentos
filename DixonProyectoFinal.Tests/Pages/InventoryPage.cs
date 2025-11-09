using DixonProyectoFinal.Tests.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DixonProyectoFinal.Tests.Pages
{
    public class InventoryPage
    {
        private readonly IWebDriver _driver;
        private WebDriverWait _wait;
        private int _itemsAdded;

        public InventoryPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _itemsAdded = 0;
        }

        #region Elementos
        private IWebElement _shoppingCartButton => _driver.FindElement(By.ClassName("shopping_cart_link"));
        private IWebElement? _addItemButton;
        #endregion

        #region Métodos
        /// <summary>
        /// Agrega items al carrito según el parámetro recibido
        /// </summary>
        public void AddItemToCart(int productPosition)
        {
            _addItemButton = _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@class=\"inventory_list\"]/div[" + productPosition + "]/div[2]/div[2]/button")));
            _addItemButton.Click();
            ValidateItemAdded();
        }

        /// <summary>
        /// Valida que se hayan agregado todos los items de la lista de productos
        /// </summary>
        public bool ValidatedItemsAdded(int itemsLength)
        {
            if (_itemsAdded == itemsLength)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Presiona el botón para ir al carrito de compras
        /// </summary>
        public void GoToShoppingCart()
        {
            _shoppingCartButton.Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants.Pages.TimeOut);
        }

        /// <summary>
        /// Valida si el item fue agregado al carrito
        /// </summary>
        private void ValidateItemAdded()
        {
            if (_addItemButton is not null)
            {
                if (_addItemButton.Text.Equals("Removed"))
                {
                    _itemsAdded++;
                }
            }
        }
        #endregion
    }
}
