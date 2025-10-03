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
            formPage.FillForm("Juan Perez", "juan@test.com", "88888888", "Costa Rica");
            formPage.Submit();

            ScreenshotHelper.TakeScreenshot(Driver, "Form_test.png");
            Assert.Pass("Formulario llenado y enviado.");
        }

        [Test]
        public void Should_SelectGenderAndSubmit()
        {
            var formPage = new FormPage(Driver);
            formPage.SelectGender("Female");
            formPage.Submit();
            ScreenshotHelper.TakeScreenshot(Driver, "imagenes/Gender_test.png");
            Assert.Pass("Género seleccionado y formulario enviado.");
        }

        [Test]  
        public void Should_validateAlert()
        {
            var formPage = new FormPage(Driver);
            ScreenshotHelper.TakeScreenshot(Driver, "imagenes/Alert_test.png");
            var textAlert = formPage.TriggerAlert();
            Assert.That(textAlert.Equals("I am an alert box!"));
            Assert.Pass("Comprobación de texto de la alerta exitoso");
         
            formPage.AcceptAlert();
            Assert.Pass("Alerta aceptada y cerrada correctamente.");
        }   

        [Test]
        public void Should_ValidateDatePicker()
        {
            var formPage = new FormPage(Driver);
            formPage.AddDate("10/02/2025");
            ScreenshotHelper.TakeScreenshot(Driver, "imagenes/DatePiker_test.png");
            formPage.ClearDate();

            formPage.SelectTodayDate();
            ScreenshotHelper.TakeScreenshot(Driver, "imagenes/TodayDate_test.png");
            Assert.Pass("Selector de fecha validado correctamente.");
        }

        [Test]
        public void Should_CompletedSection1AndSubmit()
        {
            var formPage = new FormPage(Driver);
            formPage.FillSection1("Automatización de pruebas con Selenium");
            formPage.Submit();
            Assert.That(formPage.GetSection1Text().Equals("Automatización de pruebas con Selenium"));
            ScreenshotHelper.TakeScreenshot(Driver, "imagenes/Section1Completed_test.png");
            Assert.Pass("Sección 1 llenada y enviada correctamente.");
        }
    }
}
