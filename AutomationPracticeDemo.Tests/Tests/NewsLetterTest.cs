using AutomationPracticeDemo.Tests.Pages.Footer;
using AutomationPracticeDemo.Tests.Utils;

namespace AutomationPracticeDemo.Tests.Tests
{
    public class NewsLetterTest : TestBase
    {
        [Test]
        [TestCaseSource(typeof(TestDataSources), nameof(TestDataSources.NewsLetterDataCases))]
        public void NewsLetterSubscribedTest(string email, string expectedMessage)
        {
            var footerPage = new FooterPage(Driver);
            //Suscribirse al newsletter
            footerPage.SubscribeNewsletter(email);
            //Se valida el mensaje de confirmación
            Assert.That(expectedMessage, Is.EqualTo(footerPage.GetConfirmationMessage()), "El mensaje actual:" + footerPage.GetConfirmationMessage() + " no es el esperado: " + expectedMessage);
            //Tomar screenshot
            ScreenshotHelper.TakeScreenshot(Driver, "NewsLetterSubscribedTest.png");
        }//NewsLetterTest
    }//class
}//namespace
