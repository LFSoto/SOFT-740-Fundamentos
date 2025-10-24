using System;
using OpenQA.Selenium;
using AutomationPracticeDemo.Tests.Utils;

namespace AutomationPracticeDemo.Tests.Pages.Products
{
    public class ProductsPage
    {
        private readonly IWebDriver driver;
        private readonly WaitHelper wait;
        private readonly By AddProduct1Link = By.XPath("//div[@class='productinfo text-center']//a[@data-product-id='1']");
        private readonly By Product1Price = By.XPath("//div[@class='productinfo text-center'][contains(., 'Blue Top')]//h2");
        private readonly By AddProduct2Link = By.XPath("//div[@class='productinfo text-center']//a[@data-product-id='2']");
        private readonly By Product2Price = By.XPath("//div[@class='productinfo text-center'][contains(., 'Men Tshirt')]//h2");
        private readonly By AddProduct3Link = By.XPath("//div[@class='productinfo text-center']//a[@data-product-id='3']");
        private readonly By Product3Price = By.XPath("//div[@class='productinfo text-center'][contains(., 'Sleeveless Dress')]//h2");
        private readonly By ButtonContinueShopping = By.XPath("//button[@class='btn btn-success close-modal btn-block']");
        private readonly By ButtonProceedToCheckout = By.XPath("//a[@class='btn btn-default check_out']");

        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WaitHelper(driver);
        }//ctor

        public void AddProductsToCart()
        {
            wait.WaitForElementClickable(AddProduct1Link).Click();
            wait.WaitForElementVisible(ButtonContinueShopping);
            wait.WaitForElementClickable(ButtonContinueShopping).Click();
            wait.WaitForElementClickable(AddProduct2Link).Click();
            wait.WaitForElementVisible(ButtonContinueShopping);
            wait.WaitForElementClickable(ButtonContinueShopping).Click();
            wait.WaitForElementClickable(AddProduct3Link).Click();
            wait.WaitForElementVisible(ButtonContinueShopping);
            wait.WaitForElementClickable(ButtonContinueShopping).Click();
        }//AddProduct1ToCart

        public string CalculateTotalPrice()
        {
          string totalPrice = (int.Parse(wait.WaitForElementVisible(Product1Price).Text.Replace("Rs.", "")) +
                  int.Parse(wait.WaitForElementVisible(Product2Price).Text.Replace("Rs.", "")) +
                  int.Parse(wait.WaitForElementVisible(Product3Price).Text.Replace("Rs.", ""))).ToString();
         string totalPriceFormatted = "Rs." + totalPrice;
            Console.WriteLine("Total price calculated: " + totalPriceFormatted);
          return totalPriceFormatted;
        }//CalculateTotalPrice
        public void ClickProceedToCheckout()
        {
            wait.WaitForElementClickable(ButtonProceedToCheckout).Click();
        }//ClickProceedToCheckout
    }//class
}//namespace
