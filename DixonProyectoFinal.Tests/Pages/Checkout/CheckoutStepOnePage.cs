using DixonProyectoFinal.Tests.Utils;
using OpenQA.Selenium;

namespace DixonProyectoFinal.Tests.Pages.Checkout
{
    public class CheckoutStepOnePage
    {
        private readonly IWebDriver _driver;

        public CheckoutStepOnePage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Elementos
        private IWebElement _firstNameTextBox => _driver.FindElement(By.Id("first-name"));
        private IWebElement _LastNameTextBox => _driver.FindElement(By.Id("last-name"));
        private IWebElement _postalCodeTextBox => _driver.FindElement(By.Id("postal-code"));
        private IWebElement _continueButton => _driver.FindElement(By.Id("continue"));
        #endregion

        #region Métodos
        /// <summary>
        /// Llena el formulario de checkout
        /// </summary>
        public void FillForm(string firstName, string lastName, string postalCode)
        {
            _firstNameTextBox.SendKeys(firstName);
            _LastNameTextBox.SendKeys(lastName);
            _postalCodeTextBox.SendKeys(postalCode);
        }

        /// <summary>
        /// Presiona el botón Continue
        /// </summary>
        public void SubmitForm()
        {
            _continueButton.Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants.Pages.TimeOut);
        }
        #endregion
    }
}
