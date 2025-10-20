using AutomationPracticeDemo.Tests.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Xml.Linq;

namespace AutomationPracticeDemo.Tests.Pages
{

    public class CarritoPage
    {
        private readonly IWebDriver _driver;
        public CarritoPage(IWebDriver driver)
        {
            _driver = driver;
        }



        
        private IWebElement addtocart1 => _driver.FindElement(By.CssSelector("a[data-product-id='13']"));
        // var addtocart2 = Driver.FindElement(By.CssSelector("a[data-product-id='13']"));
        private IWebElement viewcartbutton => _driver.FindElement(By.XPath("//u[contains(text(), 'View Cart')]"));
        private IWebElement continuebutton => _driver.FindElement(By.CssSelector("button[class='btn btn-success close-modal btn-block']"));
        private IWebElement cartbutton => _driver.FindElement(By.CssSelector("a[href='/view_cart']"));

        private IWebElement precioProductounitario => _driver.FindElement(By.XPath("//p[contains(text(), 'Rs. 278')]"));
        private IWebElement precioProductototal => _driver.FindElement(By.ClassName("cart_total_price"));



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

            string texto = precioProductounitario.Text;
            return texto;

        }
        public string precioTotal()
        {

            string texto = precioProductototal.Text;
            return texto;

        }



    }
}