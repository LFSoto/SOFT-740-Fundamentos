using NUnit.Framework;
using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Utils;

namespace AutomationPracticeDemo.Tests.Tests
{
    public class FormTests : TestBase
    {
        [Test]
        public void Should_FillAndSubmitForm()
        {
            var formPage = new FormPage(Driver);
            formPage.FillForm("Juan Perez", "juan@test.com", "88888888", "Costa Rica", "male");
            formPage.Submit();

            ScreenshotHelper.TakeScreenshot(Driver, "form_test.png");
            Assert.Pass("Formulario llenado y enviado.");

        }
        [Test]
        public void Should_FillAndSubmitForm2()
        {
            var formPage = new FormPage(Driver);
            formPage.Selectfile("C:\\Users\\Kenneth\\OneDrive\\Imágenes\\Selenium_Logo.png");
            formPage.Submit2();

            ScreenshotHelper.TakeScreenshot(Driver, "Selenium_Logo.png");
            Assert.Pass("Imagen cargada.");

        }
    }
}
