using AutomationPracticeDemo.Tests.Pages.Footer;
using AutomationPracticeDemo.Tests.Utils;
using OpenQA.Selenium;
using Reqnroll;

namespace AutomationPracticeDemo.Tests.StepDefinitions.NewsLetterSteps
{
    [Binding]
    public class NewsLetterSteps
    {
        private readonly ScenarioContext scenarioContext;
        private IWebDriver driver;
        private FooterPage footerPage;
        public NewsLetterSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            this.driver = scenarioContext.Get<IWebDriver>();
            this.footerPage = new FooterPage(driver);
        }
        [Given(@"I am on the home page")]
        public void GivenTheUserIsOnTheHomepage()
        {   
            driver.Navigate().GoToUrl("https://automationexercise.com/");
        }
            [When(@"I enter a valid ""(.*)"" address in the newsletter subscription field")]
        public void WhenTheUserSubscribesToTheNewsletterWithEmail(string email)
        {
            footerPage.SubscribeNewsletter(email);
        }
        [When(@"I click the subscribe button")]
        public void WhenIClickTheSubscribeButton()
        {
            footerPage.ClickSubscribeButton();
        }
        [Then(@"I should see a subscription confirmation message ""(.*)""")]
        public void ThenTheConfirmationMessageShouldBe(string expectedMessage)
        {
            var actualMessage = footerPage.GetConfirmationMessage();
            Assert.That(expectedMessage, Is.EqualTo(actualMessage), "El mensaje actual:" + actualMessage + " no es el esperado: " + expectedMessage);
            ScreenshotHelper.TakeScreenshot(driver, "NewsLetterSubscribedTest.png");
        }
    }//class
}//namespace
