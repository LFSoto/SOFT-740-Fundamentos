using OpenQA.Selenium;
using AutomationPracticeDemo.Tests.Utils;

namespace AutomationPracticeDemo.Tests.Pages.Login
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        private readonly WaitHelper wait;
        // New User Signup!
        private readonly By nameNewUser = By.XPath("//input[@data-qa='signup-name']");
        private readonly By emailNewUser = By.XPath("//input[@data-qa='signup-email']");
        private readonly By signupButton = By.XPath("//button[@data-qa='signup-button']");
        private string userGenerated = "";
        private string emailGenerated = "";

        // Login to your account
        private readonly By InputEmailLogin = By.XPath("//input[@data-qa='login-email']");
        private readonly By InputPasswordLogin = By.XPath("//input[@data-qa='login-password']");
        private readonly By ButtonLogin = By.XPath("//button[@data-qa='login-button']");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WaitHelper(driver);
        }//ctor

        public void NewUserSignup(string user)
        {
            GenerateRandomData(user);
            wait.WaitForElementVisible(nameNewUser).SendKeys(userGenerated);
            wait.WaitForElementVisible(emailNewUser).SendKeys(emailGenerated);
            wait.WaitForElementClickable(signupButton).Click();
        }//NewUserSignup

        public void LoginExistingUser(string email, string password)
        {
            wait.WaitForElementVisible(InputEmailLogin).SendKeys(email);
            wait.WaitForElementVisible(InputPasswordLogin).SendKeys(password);
            wait.WaitForElementClickable(ButtonLogin).Click();
        }//LoginExistingUser

        public void GenerateRandomData(string user)
        {
            var random = new Random();
            int randomNumber = random.Next(1, 9999);
            userGenerated = user + randomNumber;
            emailGenerated = userGenerated + "@test.com";
        }//GenerateRandomName

        public string GetGeneratedEmail()
        {
            return emailGenerated;
        }//GetGeneratedEmail

        public string GetGeneratedUser()
        {
            return userGenerated;
        }//GetGeneratedUser
    }//class
}//namespace
