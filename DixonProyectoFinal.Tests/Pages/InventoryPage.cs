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
        #endregion

        #region Métodos
        /// <summary>
        /// Agrega items al carrito según el parámetro recibido
        /// </summary>
        public void AddItemsToCart(string[] itemsPositions)
        {
            string addItemButtonXpath = string.Empty;

            foreach (var itemPosition in itemsPositions)
            {
                addItemButtonXpath = "//*[@class=\"inventory_list\"]/div[" + itemPosition + "]/div[2]/div[2]/button";
                _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(addItemButtonXpath))).Click();

                string buttonText = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(addItemButtonXpath))).Text;
                ValidateItemAdded(buttonText);
            }
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
        private void ValidateItemAdded(string buttonText)
        {
            if (buttonText.Equals("Remove"))
            {
                _itemsAdded++;
            }
        }
        #endregion
    }
}
