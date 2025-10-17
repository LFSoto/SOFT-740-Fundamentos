using OpenQA.Selenium;
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
        private IWebElement LoginEmail => _driver.FindElement(By.CssSelector("input[data-qa='login-email']"));
        private IWebElement LoginPassword => _driver.FindElement(By.CssSelector("input[data-qa='login-password']"));
        private IWebElement LoginButton => _driver.FindElement(By.CssSelector("button[data-qa='login-button']"));
        private IWebElement LoggedInMsg => _driver.FindElement(By.XPath("//a[i[@class='fa fa-user']]"));

        public void Login(string email, string password)
        {
            LoginEmail.SendKeys(email);
            LoginPassword.SendKeys(password);
            LoginButton.Click();
        }

        public string GetLoggedInUser()
        {
            return LoggedInMsg.Text;
        }
    }
}
