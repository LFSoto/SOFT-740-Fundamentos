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
            formPage.FillForm("Juan Perez", "juan@test.com", "88888888","Costa Rica");
            formPage.Submit();

            ScreenshotHelper.TakeScreenshot(Driver, "form_test.png");
            Assert.Pass("Formulario llenado y enviado.");
        }

        [Test]
        public void Should_FillAndSubmitForm2()
        {
            var formPage = new FormPage(Driver);
            formPage.FillForm2("Ale Fonseca", "afonseca1506@test.com", "87888888", "Heredia", "Brazil");
            formPage.Submit();

            ScreenshotHelper.TakeScreenshot(Driver, "form_test2.png");
            //var namecompare = "Ale Fonseca";
            //Assert.That(namecompare, Is.EqualTo(formPage.GetName()), "El Nombre actual: " + formPage.GetName() + " no es el valor que se espera: " + namecompare);
            var emailcompare = "afonseca1506@test.com";
            Assert.That(emailcompare, Is.EqualTo(formPage.GetEmail()), "El Email actual: " + formPage.GetEmail() + " no es el valor que se espera: " + emailcompare);
            var phonecompare = "87888888";
            Assert.That(phonecompare, Is.EqualTo(formPage.GetPhone()), "El Teléfono actual: " + formPage.GetPhone() + " no es el valor que se espera: " + phonecompare);
            var addresscompare = "Heredia";
            Assert.That(addresscompare, Is.EqualTo(formPage.GetAddress()), "La Dirección actual: " + formPage.GetAddress() + " no es el valor que se espera: " + addresscompare);
            var gendercompare = "female";
            Assert.That(gendercompare, Is.EqualTo(formPage.GetGender()), "El Género actual: " + formPage.GetGender() + " no es el valor que se espera: " + gendercompare);
            var dayscompare = "tuesday";
            Assert.That(dayscompare, Is.EqualTo(formPage.GetDays()), "El Día actual: " + formPage.GetDays() + " no es el valor que se espera: " + dayscompare);
            var countrycompare = "brazil";
            Assert.That(countrycompare, Is.EqualTo(formPage.GetCountry()), "El País actual: " + formPage.GetCountry() + " no es el valor que se espera: " + countrycompare);
            var colorscompare = "Blue";
            Assert.That(colorscompare, Is.EqualTo(formPage.GetColors()), "El Color actual: " + formPage.GetColors() + " no es el valor que se espera: " + colorscompare);
            Assert.Pass("Formulario llenado y enviado.");
        }

        [Test]
        public void Upload()
        {
            var formPage = new FormPage(Driver);
            formPage.UploadSingleFile("C:\\Users\\LENOVO\\OneDrive\\Escritorio\\QA.jpeg");
            formPage.Submit2();

            ScreenshotHelper.TakeScreenshot(Driver, "form_test3.png");
            var uploadcompare = "Single file selected: QA.jpeg, Size: 8337 bytes, Type: image/jpeg";
            Assert.That(uploadcompare, Is.EqualTo(formPage.GetSuccessUploadMessage()), "El Mensaje actual: " + formPage.GetSuccessUploadMessage() + " no es el valor que se espera: " + uploadcompare);
            Assert.Pass("Imagen cargada y enviada.");
        }

    }
}
