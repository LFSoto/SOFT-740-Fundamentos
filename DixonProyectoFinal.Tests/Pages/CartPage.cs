using DixonProyectoFinal.Tests.Utils;
using OpenQA.Selenium;

namespace DixonProyectoFinal.Tests.Pages
{
    public class CartPage
    {
        private readonly IWebDriver _driver;

        public CartPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Elementos
        private IList<IWebElement> _itemList => _driver.FindElements(By.ClassName("cart_button"));
        private IWebElement _checkoutButton => _driver.FindElement(By.Id("checkout"));
        #endregion

        #region Métodos
        /// <summary>
        /// Valida exista al menos un item en el carrito
        /// </summary>
        /// <returns></returns>
        public bool ValidateItemsInTheCart()
        {
            if (_itemList.Count > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Elimina todos los items del carrito
        /// </summary>
        public void RemoveItemsFromTheCart()
        {
            foreach (var item in _itemList)
            {
                item.Click();
            }
        }

        public bool ValidateTheresItemsInTheCart()
        {
            if (_itemList.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Presiona el botón para ir al checkout
        /// </summary>
        public void GoToCheckOut()
        {
            _checkoutButton.Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants.Pages.TimeOut);
        }
        #endregion
    }
}
