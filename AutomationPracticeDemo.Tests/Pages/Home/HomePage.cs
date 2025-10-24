using OpenQA.Selenium;
using AutomationPracticeDemo.Tests.Utils;

namespace AutomationPracticeDemo.Tests.Pages.Home
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        private readonly WaitHelper wait;
        private readonly By ImageAutomationExcercis = By.XPath("//img[@src='/static/images/home/logo.png']");

        public HomePage(IWebDriver driver) {
            this.driver = driver;
            this.wait = new WaitHelper(driver);
        }//ctor

        public bool IsHomePageDisplayed()
        {
            var el = wait.WaitForElementVisible(ImageAutomationExcercis);
            return el != null && el.Displayed;
        }//IsHomePageDisplayed
    }//class
}//namespace
