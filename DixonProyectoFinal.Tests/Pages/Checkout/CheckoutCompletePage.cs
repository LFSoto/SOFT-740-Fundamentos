using OpenQA.Selenium;

namespace DixonProyectoFinal.Tests.Pages.Checkout
{
    public class CheckoutCompletePage
    {
        private readonly IWebDriver _driver;

        public CheckoutCompletePage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Elementos
        private string _checkOutCómpleteText => _driver.FindElement(By.CssSelector("span[data-test=\"title\"]")).Text;
        #endregion

        #region Métodos
        /// <summary>
        /// Valida que se muestre el texto que indica que el checkout ha sido completado
        /// </summary>
        /// <returns></returns>
        public bool ValidateCheckOutComplete()
        {
            if (_checkOutCómpleteText.Equals("Checkout: Complete!"))
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}
