using OpenQA.Selenium;

namespace AutomationPracticeDemo.Tests.Pages.AutomationExercise
{
    public class FooterPage
    {
        private readonly IWebDriver driver;
        private IWebElement NewsletterInput => driver.FindElement(By.Id("susbscribe_email"));
        private IWebElement SubscribeButton => driver.FindElement(By.Id("subscribe"));
        private IWebElement SubscriptionConfirmationMessage => driver.FindElement(By.Id("success-subscribe")); //You have been successfully subscribed!
        public FooterPage(IWebDriver driver)
        {
            this.driver = driver;
        }//ctor
       
        public void SubscribeNewsletter(string email)
        {
            NewsletterInput.SendKeys(email);
            SubscribeButton.Click();
        }//SubscribeNewsletter

        public string GetConfirmationMessage()
        {
            return SubscriptionConfirmationMessage.Text;
        }//GetConfirmationMessage

    }//class
}//namespace
