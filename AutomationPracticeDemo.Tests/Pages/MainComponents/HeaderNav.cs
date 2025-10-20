using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationPracticeDemo.Tests.Pages.MainComponents
{
    public class HeaderNav
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public HeaderNav(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement LoginLink => _driver.FindElement(By.CssSelector("li a[href=\"/login\"]"));
        public IWebElement LogoutLink => _wait.Until(d => d.FindElement(By.CssSelector("a[href=\"/logout\"]")));
        public IWebElement ProductsLink => _driver.FindElement(By.CssSelector("a[href=\"/products\"]"));
        public IWebElement ContactUsLink => _driver.FindElement(By.CssSelector("a[href=\"/contact_us\"]"));
    }
}
