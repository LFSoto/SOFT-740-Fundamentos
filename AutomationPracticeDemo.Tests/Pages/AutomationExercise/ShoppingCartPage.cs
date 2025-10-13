using OpenQA.Selenium;

namespace AutomationPracticeDemo.Tests.Pages.AutomationExercise
{
    public class ShoppingCartPage
    {
        private readonly IWebDriver driver;
        private IWebElement Product1TotalPrice => driver.FindElement(By.XPath("//tr[@id='product-1']//td[@class='cart_total']//p"));
        private IWebElement Product2TotalPrice => driver.FindElement(By.XPath("//tr[@id='product-2']//td[@class='cart_total']//p"));
        private IWebElement Product3TotalPrice => driver.FindElement(By.XPath("//tr[@id='product-3']//td[@class='cart_total']//p"));

        public ShoppingCartPage(IWebDriver driver)
        {
            this.driver = driver;
        }//ctor

        public string CalculateTotalPriceInCart()
        {
            string totalPrice = (int.Parse(Product1TotalPrice.Text.Replace("Rs.", "")) +
                    int.Parse(Product2TotalPrice.Text.Replace("Rs.", "")) +
                    int.Parse(Product3TotalPrice.Text.Replace("Rs.", ""))).ToString();
            string totalPriceFormatted = "Rs." + totalPrice;
            Console.WriteLine("Total price in cart calculated: " + totalPriceFormatted);
            return totalPriceFormatted;
        }//CalculateTotalPriceInCart
    }//class
}//namespace
