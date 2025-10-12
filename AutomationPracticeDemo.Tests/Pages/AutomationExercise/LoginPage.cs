
using OpenQA.Selenium;

namespace AutomationPracticeDemo.Tests.Pages.AutomationExercise
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        private IWebElement nameNewUser => driver.FindElement(By.XPath("//input[@data-qa='signup-name']"));
        private IWebElement emailNewUser => driver.FindElement(By.XPath("//input[@data-qa='signup-email']"));
        private IWebElement signupButton => driver.FindElement(By.XPath("//button[@data-qa='signup-button']"));
        private string userGenerated = "";
        private string emailGenerated = "";

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }//ctor

        public void NewUserSignup(string user)
        {
            GenerateRandomData(user);
            nameNewUser.SendKeys(userGenerated);
            emailNewUser.SendKeys(emailGenerated);
            signupButton.Click();
        }//NewUserSignup

        public void GenerateRandomData(string user)
        {
            var random = new Random();
            int randomNumber = random.Next(1, 9999);
            userGenerated = user + randomNumber;
            emailGenerated = userGenerated + "@test.com";
        }//GenerateRandomName
    }//class
}//namespace
