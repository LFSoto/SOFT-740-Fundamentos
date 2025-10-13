using OpenQA.Selenium;

namespace AutomationPracticeDemo.Tests.Pages.AutomationExercise
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        private IWebElement ImageAutomationExcercis => driver.FindElement(By.XPath("//img[@src='/static/images/home/logo.png']"));
        public HomePage(IWebDriver driver) {
            this.driver = driver;
        }//ctor

        public bool IsHomePageDisplayed()
        {
            return ImageAutomationExcercis.Displayed;
        }//IsHomePageDisplayed
    }//class
}//namespace
