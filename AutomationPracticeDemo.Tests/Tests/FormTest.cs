using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

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

            ScreenshotHelper.TakeScreenshot(Driver, "form_test.png");
            Assert.Pass("Formulario llenado y enviado.");

        }
        [Test]
        public void Should_fillRadioButtonsGender()
        {
            var formPage = new FormPage(Driver);
            formPage.Gender( "male");
            formPage.Submit1();

            ScreenshotHelper.TakeScreenshot(Driver, "form_test.png");
            Assert.Pass("Gender seleccionado correctamente.");

        }
        [Test]
        public void Should_uploadimage()
        {
            var formPage = new FormPage(Driver);
            formPage.Selectfile("C:\\Users\\Kenneth\\OneDrive\\Imágenes\\Selenium_Logo.png");
            formPage.Submit2();

            ScreenshotHelper.TakeScreenshot(Driver, "Selenium_Logo.png");
            Assert.Pass("Imagen cargada.");

        }
        [Test]
        public void Should_fillfieldclearfill()
        {
            var formPage = new FormPage(Driver);
            IJavaScriptExecutor? js = Driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0, 500);");
            Thread.Sleep(1000);
            formPage.field2Input("Valor Inicial","Nuevo Valor");
            formPage.Submit3();
            ScreenshotHelper.TakeScreenshot(Driver, "Selenium_Logo.png");
            Assert.Pass("Se ingresa primer valor, se limpia limpia campo y se ingresa segundo valor.");

        }
        [Test]
        public void Should_selectcolor()
       {
            var formPage = new FormPage(Driver);
            System.Threading.Thread.Sleep(500);
            formPage.Colorsselect("white");
            formPage.Submit();

            ScreenshotHelper.TakeScreenshot(Driver, "form_test.png");
            Assert.Pass("Color seleccionado correctamente.");

        }
    }
}
