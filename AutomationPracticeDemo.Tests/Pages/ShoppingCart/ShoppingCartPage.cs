using System;
using OpenQA.Selenium;
using AutomationPracticeDemo.Tests.Utils;

namespace AutomationPracticeDemo.Tests.Pages.ShoppingCart
{
    public class ShoppingCartPage
    {
        private readonly IWebDriver driver;
        private readonly WaitHelper wait;
        private readonly By Product1TotalPrice = By.XPath("//tr[@id='product-1']//td[@class='cart_total']//p");
        private readonly By Product2TotalPrice = By.XPath("//tr[@id='product-2']//td[@class='cart_total']//p");
        private readonly By Product3TotalPrice = By.XPath("//tr[@id='product-3']//td[@class='cart_total']//p");

        public ShoppingCartPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WaitHelper(driver);
        }//ctor

        public string CalculateTotalPriceInCart()
        {
            string totalPrice = (int.Parse(wait.WaitForElementVisible(Product1TotalPrice).Text.Replace("Rs.", "")) +
                    int.Parse(wait.WaitForElementVisible(Product2TotalPrice).Text.Replace("Rs.", "")) +
                    int.Parse(wait.WaitForElementVisible(Product3TotalPrice).Text.Replace("Rs.", ""))).ToString();
            string totalPriceFormatted = "Rs." + totalPrice;
            Console.WriteLine("Total price in cart calculated: " + totalPriceFormatted);
            return totalPriceFormatted;
        }//CalculateTotalPriceInCart
    }//class
}//namespace
