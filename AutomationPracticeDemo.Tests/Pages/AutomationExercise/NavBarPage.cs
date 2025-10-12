
using OpenQA.Selenium;

namespace AutomationPracticeDemo.Tests.Pages.AutomationExercise
{
    public class NavBarPage
    {
        private readonly IWebDriver driver;
        private IWebElement SgnupLoginLink => driver.FindElement(By.XPath("//a[@href='/login']"));
        public NavBarPage(IWebDriver driver)
        {
            this.driver = driver;
        }//ctor

        public void ClickSignupLogin()
        {
            SgnupLoginLink.Click();
        }//ClickSignupLogin
    }
}
