using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement WaitAndFindElement(By by, int timeoutSeconds = 10)
        {
            if (timeoutSeconds <= 0)
                return _driver.FindElement(by);

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        private IWebElement LoginEmail => WaitAndFindElement(By.CssSelector("input[data-qa='login-email']"));
        private IWebElement LoginPassword => WaitAndFindElement(By.CssSelector("input[data-qa='login-password']"));
        private IWebElement LoginButton => WaitAndFindElement(By.CssSelector("button[data-qa='login-button']"));
        private IWebElement LoggedInMsg => WaitAndFindElement(By.XPath("//a[i[@class='fa fa-user']]"));
        private IWebElement LoginError => WaitAndFindElement(By.XPath("//p[contains(text(),'Your email or password is incorrect!')]"), 5);

        public void Open()
        {
            _driver.Navigate().GoToUrl("https://automationexercise.com/login");
        }
        public void Login(string email, string password)
        {
            Open();
            LoginEmail.SendKeys(email);
            LoginPassword.SendKeys(password);
            LoginButton.Click();
        }

        public string GetLoggedInUser()
        {
            return LoggedInMsg.Text;
        }

        public string GetLoginErrorMessage()
        {
            try
            {
                return LoginError.Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty;
            }
            catch (NoSuchElementException)
            {
                return string.Empty;
         
            }
        }
    }
}
