using OpenQA.Selenium;
using AutomationPracticeDemo.Tests.Utils;

namespace AutomationPracticeDemo.Tests.Pages.Footer
{
    public class FooterPage
    {
        private readonly IWebDriver driver;
        private readonly WaitHelper wait;
        private readonly By NewsletterInput = By.Id("susbscribe_email");
        private readonly By SubscribeButton = By.Id("subscribe");
        private readonly By SubscriptionConfirmationMessage = By.Id("success-subscribe"); //You have been successfully subscribed!
        public FooterPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WaitHelper(driver);
        }//ctor
       
        public void SubscribeNewsletter(string email)
        {
            wait.WaitForElementVisible(NewsletterInput).SendKeys(email);
            wait.WaitForElementClickable(SubscribeButton).Click();
        }//SubscribeNewsletter

        public string GetConfirmationMessage()
        {
            var el = wait.WaitForElementVisible(SubscriptionConfirmationMessage);
            return el?.Text ?? string.Empty;
        }//GetConfirmationMessage

    }//class
}//namespace
