using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationPracticeDemo.Tests.Pages.Products
{
    public class ProductsPage
    {
        private readonly IWebDriver driver;
        private IWebElement AddProduct1Link => driver.FindElement(By.XPath("//div[@class='productinfo text-center']//a[@data-product-id='1']"));
        private IWebElement Product1Price => driver.FindElement(By.XPath("//div[@class='productinfo text-center'][contains(., 'Blue Top')]//h2"));
        private IWebElement AddProduct2Link => driver.FindElement(By.XPath("//div[@class='productinfo text-center']//a[@data-product-id='2']"));
        private IWebElement Product2Price => driver.FindElement(By.XPath("//div[@class='productinfo text-center'][contains(., 'Men Tshirt')]//h2"));
        private IWebElement AddProduct3Link => driver.FindElement(By.XPath("//div[@class='productinfo text-center']//a[@data-product-id='3']"));
        private IWebElement Product3Price => driver.FindElement(By.XPath("//div[@class='productinfo text-center'][contains(., 'Sleeveless Dress')]//h2"));
        private IWebElement ButtonContinueShopping => driver.FindElement(By.XPath("//button[@class='btn btn-success close-modal btn-block']"));
        private IWebElement ButtonProceedToCheckout => driver.FindElement(By.XPath("//a[@class='btn btn-default check_out']"));

        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
        }//ctor

        public void AddProductsToCart()
        {
            AddProduct1Link.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(drv => ButtonContinueShopping.Displayed);
            ButtonContinueShopping.Click();
            AddProduct2Link.Click();
            wait.Until(drv => ButtonContinueShopping.Displayed);
            ButtonContinueShopping.Click();
            AddProduct3Link.Click();
            wait.Until(drv => ButtonContinueShopping.Displayed);
            ButtonContinueShopping.Click();
        }//AddProduct1ToCart

        public string CalculateTotalPrice()
        {
          string totalPrice = (int.Parse(Product1Price.Text.Replace("Rs.", "")) +
                  int.Parse(Product2Price.Text.Replace("Rs.", "")) +
                  int.Parse(Product3Price.Text.Replace("Rs.", ""))).ToString();
         string totalPriceFormatted = "Rs." + totalPrice;
            Console.WriteLine("Total price calculated: " + totalPriceFormatted);
          return totalPriceFormatted;
        }//CalculateTotalPrice
        public void ClickProceedToCheckout()
        {
            ButtonProceedToCheckout.Click();
        }//ClickProceedToCheckout
    }//class
}//namespace
