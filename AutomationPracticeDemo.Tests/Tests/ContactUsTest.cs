using AutomationPracticeDemo.Tests.Pages.ContactUs;
using AutomationPracticeDemo.Tests.Pages.Home;
using AutomationPracticeDemo.Tests.Pages.Login;
using AutomationPracticeDemo.Tests.Pages.NavBar;
using AutomationPracticeDemo.Tests.Utils;

namespace AutomationPracticeDemo.Tests.Tests
{
    public class ContactUsTest : TestBase
    {
        [Test]
        [TestCaseSource(typeof(TestDataSources), nameof(TestDataSources.ContactUsDataCases))]
        public void ContactUsValidFormTest(string name, string email, string subject, string message, string fileName, string expectedMessage)
        {
            var navBarPage = new NavBarPage(Driver);
            //Hacer click en Contact Us
            navBarPage.ClickContactUs();
            var contactUsPage = new ContactUsPage(Driver);
            //Rellenar el formulario de Contact Us
            contactUsPage.FillContactForm(name, email, subject, message, fileName);
            //Se acepta el alert de file uploaded
            contactUsPage.AcceptAlert();
            //Se valida el alert de mensaje enviado correctamente
            Assert.That(expectedMessage, Is.EqualTo(contactUsPage.GetSuccessMessage()), "El mensaje actual:" + contactUsPage.GetSuccessMessage() + " no es el esperado: " + expectedMessage);
            //Tomar screenshot
            ScreenshotHelper.TakeScreenshot(Driver, "ContactUsValidFormTest.png");
        }//ContactUsValidFormTest
    }//class
}//namespace
