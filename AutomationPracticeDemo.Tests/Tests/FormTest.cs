using NUnit.Framework;
using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Utils;

namespace AutomationPracticeDemo.Tests.Tests
{
    public class FormTests : TestBase
    {
        [Test]
        public void Should_FillAndSubmitFormTest()
        {
            var formPage = new FormPage(Driver);
            formPage.FillForm("Juan Perez", "juan@test.com", "88888888", "Costa Rica");
            formPage.Submit();

            ScreenshotHelper.TakeScreenshot(Driver, "form_test.png");
            Assert.Pass("Formulario llenado y enviado.");
        }//Should_FillAndSubmitForm

        [Test]
        public void FillAndSubmitFormClientTest()
        {
            var formPage = new FormPage(Driver);
            formPage.FillForm2("Melvin Marin", "mmarin@test.com", "88888888", "Shibuya, Tokyo", 
                "male", "TUESDAY", "Japan", "BLUE", "dog", "1/10/2025");
            formPage.Submit();

            ScreenshotHelper.TakeScreenshot(Driver, "form_test.png");
            var expectedTitle = "Automation Testing Practice";
            // Se valida el título de la página
            Assert.That(expectedTitle, Is.EqualTo(formPage.GetLabelTitle()), "El titulo actual: " + formPage.GetLabelTitle()+" no es el esperado: "+ expectedTitle);
            // Se valida el input Name
            var expectedName = "Melvin Marin";
            Assert.That(expectedName, Is.EqualTo(formPage.GetName()), "El Name actual: " + formPage.GetName() + " no es el esperado: " + expectedName);
            // Se valida el input Phone
            var expectedPhone = "88888888";
            Assert.That(expectedPhone, Is.EqualTo(formPage.GetPhone()), "El input Phone actual: "+ formPage.GetPhone() + " no es el esperado: "+ expectedPhone);
            // se valida el input Address
            var expectedAddress = "Shibuya, Tokyo";
            Assert.That(expectedAddress, Is.EqualTo(formPage.GetAddress()), "El input Address actual:"+ formPage.GetAddress() + " no es el esperado: "+ expectedAddress);
            // se valida el input Email
            var expectedEmail = "mmarin@test.com";
            Assert.That(expectedEmail, Is.EqualTo(formPage.GetEmail()), "El input Email actual: "+formPage.GetEmail()+ " no es el esperado: "+expectedEmail);
            // Se valida el radio button Gender
            var expectedGender = "male";
            Assert.That(expectedGender, Is.EqualTo(formPage.GetGender()), "El GenderId actual: "+ formPage.GetGender() + " no es el esperado: "+ expectedGender);
            // Se valida el checkbox Day
            var expectedDay = "tuesday";
            Assert.That(expectedDay, Is.EqualTo(formPage.GetDay()), "El Day actual: "+ formPage.GetDay() + " no es el esperado: "+ expectedDay);
            // Se valida el select Country
            var expectedCountry = "japan";
            Assert.That(expectedCountry, Is.EqualTo(formPage.GetCountry()), "El CountryId actual: "+ formPage.GetCountry() + " no es el esperado: "+ expectedCountry);
            // Se agrega un assert para validar que el formulario se envió correctamente
            Assert.Pass("Formulario llenado y enviado.");
        }//FillAndSubmitFormClientTest
    }//class
}//namespace
