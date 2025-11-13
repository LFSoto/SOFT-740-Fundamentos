using DixonProyectoFinal.Tests.Utils;
using OpenQA.Selenium;

namespace DixonProyectoFinal.Tests.Pages.Checkout
{
    public class CheckoutStepTwoPage
    {
        private readonly IWebDriver _driver;

        public CheckoutStepTwoPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Elementos
        private IList<IWebElement> _itemsList => _driver.FindElements(By.ClassName("inventory_item_price"));
        private double _itemsTotalPrice => Convert.ToDouble(_driver.FindElement(By.ClassName("summary_subtotal_label")).Text.Remove(0,13));
        private IWebElement _finishButton => _driver.FindElement(By.CssSelector("button[data-test=\"finish\"]"));
        #endregion

        #region Métodos
        /// <summary>
        /// Valida que la sumatoria de los precios de los productos sea correcta
        /// </summary>
        public bool ValidateItemsTotalPrice()
        {
            double itemsTotalPrice = 0.00;
            foreach (var item in _itemsList)
            {
                itemsTotalPrice += Convert.ToDouble(item.Text.Remove(0,1));
            }

            if (_itemsTotalPrice == itemsTotalPrice)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Presina el botón Finish
        /// </summary>
        public void FinishCheckOut()
        {
            _finishButton.Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants.Pages.TimeOut);
        }
        #endregion
    }
}
