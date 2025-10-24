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
        private IWebElement ContinueShoppingButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button.btn.btn-success.close-modal.btn-block")));
        private IWebElement PriceProd1 => _driver.FindElement(By.XPath("//td[@class='cart_price']/p[contains(text(),'Rs. 500')]"));
        private IWebElement PriceProd2 => _driver.FindElement(By.XPath("//td[@class='cart_price']/p[contains(text(),'Rs. 400')]"));
        private IWebElement CantProd1 => _driver.FindElement(By.CssSelector("#product-1 > td.cart_quantity > button"));
        private IWebElement CantProd2 => _driver.FindElement(By.CssSelector("#product-2 > td.cart_quantity > button"));
        private IWebElement TotalProd1 => _driver.FindElement(By.XPath("//td[@class='cart_total']/p[contains(text(),'Rs. 500')]"));
        private IWebElement TotalProd2 => _driver.FindElement(By.XPath("//td[@class='cart_total']/p[contains(text(),'Rs. 800')]"));
        
        

        // Ir a página de productos
        public void GoToProducts()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(ProductsButtom)).Click();
        }

        public void GoToCart()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(CartButton)).Click();
        }

        public void AddProduct(int productId)
        {
            var addButton = By.CssSelector($"a[data-product-id='{productId}']");
            _wait.Until(ExpectedConditions.ElementToBeClickable(addButton)).Click();
        }

        public void ContinueShopping()
        {
            ContinueShoppingButton.Click();

            // Esperar a que el modal desaparezca
            _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cartModal")));
        }
        

        public string GetPriceProduct1()
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[@class='cart_price']/p[contains(text(),'Rs. 500')]"))).Text;
        }

        public string GetPriceProduct2()
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[@class='cart_price']/p[contains(text(),'Rs. 400')]"))).Text;
        }

        public string GetQuantityProduct1()
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#product-1 > td.cart_quantity > button"))).Text;
        }
        public string GetQuantityProduct2()
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#product-2 > td.cart_quantity > button"))).Text;
        } 

        public string GetTotalProduct1()
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[@class='cart_total']/p[contains(text(),'Rs. 500')]"))).Text;
        }
        public string GetTotalProduct2()
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[@class='cart_total']/p[contains(text(),'Rs. 800')]"))).Text;
        }
        
     
        public void EmptyCart()
        {
            try
            {
                // Ir al carrito
                var cartButton = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("a[href='/view_cart']")));
                cartButton.Click();

                // Si hay productos, eliminarlos todos
                var deleteButtons = _driver.FindElements(By.CssSelector("a.cart_quantity_delete"));
                foreach (var deleteButton in deleteButtons)
                {
                    deleteButton.Click();
                    // pequeña espera entre clics
                    _wait.Until(ExpectedConditions.StalenessOf(deleteButton));
                    //System.Threading.Thread.Sleep(500);
                }

                // Confirmar que el carrito esté vacío
                var emptyMessage = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                    By.CssSelector("#empty_cart > p")));
                Assert.That(emptyMessage.Text.Contains("Cart is empty"), "El carrito no se vació correctamente");
            }
            catch (NoSuchElementException)
            {
                // Si no hay productos o botón de carrito, simplemente continuar
            }
        }

    }
}
