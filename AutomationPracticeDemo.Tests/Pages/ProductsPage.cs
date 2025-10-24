using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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

        public IWebElement AddToCart1Button => _driver.FindElement(By.CssSelector(".productinfo a[data-product-id=\"1\"]"));
        public IWebElement ContinueShoppingButton => _driver.FindElement(By.ClassName("btn-success"));
        public IWebElement AddToCart2Button => _driver.FindElement(By.CssSelector(".productinfo a[data-product-id=\"2\"]"));
        public IWebElement ViewCartButton => _driver.FindElement(By.CssSelector("p a[href=\"/view_cart\"]"));
        public IWebElement CheckoutButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".check_out")));
        public int Price1Value => Convert.ToInt32(_driver.FindElement(By.CssSelector("#product-1 .cart_total_price")).Text.Remove(0, 4));
        public int Price2Value => Convert.ToInt32(_driver.FindElement(By.CssSelector("#product-2 .cart_total_price")).Text.Remove(0, 4));
    }
}
