using OpenQA.Selenium;

namespace AutomationPracticeDemo.Tests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement SignUpNameTextbox => _driver.FindElement(By.Name("name"));
        public IWebElement SignUpEmailTextbox => _driver.FindElement(By.CssSelector("form[action=\"/signup\"] input[name=\"email\"]"));
        public IWebElement SignupButton => _driver.FindElement(By.CssSelector("form[action=\"/signup\"] button"));
        public IWebElement LoginEmailTextbox => _driver.FindElement(By.CssSelector("form[action=\"/login\"] input[name=\"email\"]"));
        public IWebElement LoginPasswordTextbox => _driver.FindElement(By.Name("password"));
        public IWebElement LoginButton => _driver.FindElement(By.CssSelector("form[action=\"/login\"] button"));
        public string LoggedInTextActualResult => _driver.FindElement(By.XPath("//li[10]/a")).Text;
        public string LogInFailedActualResult => _driver.FindElement(By.CssSelector("form[action='/login'] p")).Text;
    }
}
