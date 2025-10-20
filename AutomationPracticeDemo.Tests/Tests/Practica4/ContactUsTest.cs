using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Pages.MainComponents;
using AutomationPracticeDemo.Tests.Utils;
using OpenQA.Selenium;

namespace AutomationPracticeDemo.Tests.Tests.Practica4
{
    //TODO agregar datadriven
    public class ContactUsTest:TestBase
    {
        [Test]
        public void Should_SendContactForm()
        {
            //Se instancian las clases necesarias para ejecutar el test
            HeaderNav headerNav = new HeaderNav(Driver);
            ContactUsPage contactUsPage = new ContactUsPage(Driver);
            GetPathHelper getPathHelper = new GetPathHelper();

            //Se presiona el botón Contact us y se espera a que carguen los elementos de la pantalla
            headerNav.ContactUsLink.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Se interactua con los elementos de la pantalla contact us
            contactUsPage.NameTextbox.SendKeys("Dixon C");
            contactUsPage.EmailTextbox.SendKeys("dixon@test.com");
            contactUsPage.SubjectTextbox.SendKeys("Subject Test Text");
            contactUsPage.MessageTextbox.SendKeys("Message Test Text");
            contactUsPage.UploadFileInput.SendKeys(getPathHelper.GetFilePathUpload());
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", contactUsPage.SubmitButton);
            contactUsPage.SubmitButton.Click();

            //Se le a aceptar a la alerta
            Driver.SwitchTo().Alert().Accept();

            //Se captura la evidencia del resultado
            ScreenshotHelper.TakeScreenshot(Driver, getPathHelper.GetFilePathScreenShots() + "Should_SendContactForm.png");

            //Se valida el mensaje de éxito
            Assert.That(contactUsPage.AlertSuccessActualText, Is.EqualTo("Success! Your details have been submitted successfully."));
        }
    }
}
