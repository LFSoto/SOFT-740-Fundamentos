using NUnit.Framework;
using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Utils;

namespace AutomationPracticeDemo.Tests.Tests
{
    public class FormTests : TestBase
    {
        [Test]
        public void Should_FillForm()
        {
            var formPage = new FormPage(Driver);
            formPage.FillForm("Juan Perez", "juan@test.com", "88888888", "Costa Rica");
         
            ScreenshotHelper.TakeScreenshot(Driver, "form_test.png");
            Assert.Pass("Formulario llenado.");

            //las imagenes se almacenan en: AutomationPracticeDemo.Tests\bin\Debug\net9.0
        }
        [Test]
        public void Should_SelectGender()
        {
            var formPage = new FormPage(Driver); 
            formPage.RadButtom();

            ScreenshotHelper.TakeScreenshot(Driver, "gender_test.png");
            Assert.Pass("Género seleccionado.");

        }
        [Test]
        public void Should_AddressInput()
        {
            var formPage = new FormPage(Driver);

            formPage._AddressInput();

            ScreenshotHelper.TakeScreenshot(Driver, "addressInput_test.png");
            Assert.Pass("Se ha ingresado el texto en el input.");

        }
        [Test]
        public void Should_SelectDatetimePicker1()
        {
            var formPage = new FormPage(Driver);

            formPage.DateTimePicker1();
            ScreenshotHelper.TakeScreenshot(Driver, "selectDateTP1_test.png");
            Assert.Pass("Se ha seleccionado una fecha.");

        }
        [Test]
        public void Should_SelectSortedList()
        {
            var formPage = new FormPage(Driver);

            formPage.SelectSortedList();
            ScreenshotHelper.TakeScreenshot(Driver, "selectSortedList_test.png");
            Assert.Pass("Se ha seleccionado el valor Dog de la lista.");

        }
        [Test]
        public void Should_SubmitForm()
        {
            var formPage = new FormPage(Driver);
            formPage.Submit();

            ScreenshotHelper.TakeScreenshot(Driver, "Submitform_test.png");
            Assert.Pass("Formulario enviado.");

        }
    }
}
