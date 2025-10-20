using OpenQA.Selenium;

namespace AutomationPracticeDemo.Tests.Pages.MainComponents
{
    public class Footer
    {
        private readonly IWebDriver _driver;

        public Footer(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement subscribeEmailTextbox => _driver.FindElement(By.Id("susbscribe_email"));
        public IWebElement subscribeButton => _driver.FindElement(By.Id("subscribe"));
        public string SuccessMessage => _driver.FindElement(By.ClassName("alert-success")).Text;
    }
}
