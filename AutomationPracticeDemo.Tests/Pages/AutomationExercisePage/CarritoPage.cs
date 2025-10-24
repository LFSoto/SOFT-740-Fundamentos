using AutomationPracticeDemo.Tests.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Xml.Linq;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationPracticeDemo.Tests.Pages
{

    public class CarritoPage
    {
        private readonly IWebDriver _driver;
        private readonly TimeSpan _defaultTimeout = TimeSpan.FromSeconds(10);
        public CarritoPage(IWebDriver driver)
        {
            _driver = driver;
        }



        
        private IWebElement addtocart1 => _driver.FindElement(By.CssSelector("a[data-product-id='13']"));
        // var addtocart2 = Driver.FindElement(By.CssSelector("a[data-product-id='13']"));
        private IWebElement viewcartbutton => _driver.FindElement(By.XPath("//u[contains(text(), 'View Cart')]"));
        private IWebElement continuebutton => _driver.FindElement(By.CssSelector("button[class='btn btn-success close-modal btn-block']"));
        private IWebElement cartbutton => _driver.FindElement(By.CssSelector("a[href='/view_cart']"));

        private readonly By _precioUnitarioRelative = By.XPath("//a[@data-product-id='13']/following::p[contains(normalize-space(.), 'Rs.')][1]");
        private readonly By _precioUnitarioGeneric = By.XPath("//p[contains(normalize-space(.), 'Rs.')]");
        private readonly By _precioTotalBy = By.ClassName("cart_total_price");

        // Helper: espera explícita para elemento visible y habilitado
        private IWebElement FindVisible(By by, TimeSpan? timeout = null)
        {
            var wait = new WebDriverWait(_driver, timeout ?? _defaultTimeout);
            return wait.Until(d =>
            {
                try
                {
                    var el = d.FindElement(by);
                    return (el != null && el.Displayed && el.Enabled) ? el : null;
                }
                catch (NoSuchElementException) { return null; }
                catch (StaleElementReferenceException) { return null; }
            });
        }



        public void agregarcarrito()
        {
            //se agrega primer articulo al carrito
            addtocart1.Click();
            Thread.Sleep(2000);

        }
        public void agregarsegundocarrito()
        {
            //se da click en continue shopping  
            continuebutton.Click();
            //se agrega segundo articulo al carrito
            addtocart1.Click();
            Thread.Sleep(2000);
         }
        public void vercarrito()
        {
            //se da click en view cart
            viewcartbutton.Click();

        }

        public string Unitario()
        {
            // Intento localizador relativo al producto, si falla uso genérico
            try
            {
                var el = FindVisible(_precioUnitarioRelative, TimeSpan.FromSeconds(5));
                return el.Text?.Trim() ?? string.Empty;
            }
            catch (WebDriverTimeoutException)
            {
                try
                {
                    var el2 = FindVisible(_precioUnitarioGeneric, TimeSpan.FromSeconds(5));
                    return el2.Text?.Trim() ?? string.Empty;
                }
                catch (WebDriverTimeoutException)
                {
                    return string.Empty;
                }
            }
        }
        public string precioTotal()
        {
            try
            {
                var el = FindVisible(_precioTotalBy, TimeSpan.FromSeconds(5));
                return el.Text?.Trim() ?? string.Empty;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty;
            }



        }
}
}