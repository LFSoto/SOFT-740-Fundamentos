using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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

        private IWebElement _contactUsLink => _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[href=\"/contact_us\"]")));

        public void NavigateToContactUsPage()
        {
            _contactUsLink.Click();
        }
    }
}
