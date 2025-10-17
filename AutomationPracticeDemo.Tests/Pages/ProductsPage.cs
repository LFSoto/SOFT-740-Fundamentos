using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Pages
{
    public class ProductsPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public ProductsPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }
       
        private IWebElement ProductsButtom => _driver.FindElement(By.CssSelector("a[href='/products']"));
        private IWebElement CartButton => _driver.FindElement(By.CssSelector("a[href='/view_cart']"));
        private IWebElement ContinueShoppingButton => _driver.FindElement(By.CssSelector("button.btn.btn-success.close-modal.btn-block"));



        // Ir a página de productos
        public void GoToProducts()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(ProductsButtom)).Click();
        }

        public void GoToCart()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(CartButton)).Click();
        }

        public void AddProduct(string productId)
        {
            var addButton = By.CssSelector($"a[data-product-id='{productId}']");
            _wait.Until(ExpectedConditions.ElementToBeClickable(addButton)).Click();

            // Clic en “Continue Shopping”
            _wait.Until(ExpectedConditions.ElementIsVisible((By)ContinueShoppingButton)).Click();
        }

    }
}
