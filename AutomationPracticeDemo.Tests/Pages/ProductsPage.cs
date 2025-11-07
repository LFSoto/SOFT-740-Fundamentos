using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
            try
            {
                // Workaround para anuncios
                // Find the product button
                var addButton = _wait.Until(ExpectedConditions.ElementExists(By.CssSelector($"a[data-product-id='{productId}']")));
                
                // Scroll the element into view
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", addButton);
                
                // Wait a bit for any overlays to disappear
                Thread.Sleep(500);
                
                try
                {
                    // Try normal click first
                    _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector($"a[data-product-id='{productId}']"))).Click();
                }
                catch (ElementClickInterceptedException)
                {
                    // If intercepted by ad or modal, use JavaScript click
                    ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", addButton);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add product {productId}: {ex.Message}", ex);
            }
        }

        public void ContinueShopping()
        {
            ContinueShoppingButton.Click();

            // Esperar a que el modal desaparezca
            _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".modal-content")));
        }
        

        public string GetPriceProduct1()
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[@id='product-1']//td[@class='cart_price']/p"))).Text;
        }

        public string GetPriceProduct2()
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[@id='product-2']//td[@class='cart_price']/p"))).Text;
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
            return _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[@id='product-1']//td[@class='cart_total']/p"))).Text;
        }
        
        public string GetTotalProduct2()
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[@id='product-2']//td[@class='cart_total']/p"))).Text;
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
                while (deleteButtons.Count > 0)
                {
                    deleteButtons[0].Click();
                    // Wait for the element to be removed from DOM
                    _wait.Until(ExpectedConditions.StalenessOf(deleteButtons[0]));
                    // Refresh the list
                    deleteButtons = _driver.FindElements(By.CssSelector("a.cart_quantity_delete"));
                }
            }
            catch (NoSuchElementException)
            {
                // If no products or cart button, simply continue
            }
            catch (WebDriverTimeoutException)
            {
                // Cart might already be empty
            }
        }
    }
}
