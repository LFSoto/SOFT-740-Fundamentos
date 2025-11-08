using AutomationPracticeDemo.Tests.Tests.Data;
using AutomationPracticeDemo.Tests.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutomationPracticeDemo.Tests.Tests.Data.GetUserData;

namespace AutomationPracticeDemo.Tests.Tests.ContactUs
{
    public class ContactUsTest : TestBase
    {

        [Test, TestCaseSource(typeof(GetUserData), nameof(UserLoginList))]
        public void contactUsFormTest(LoginData user)
        {
            var LoginPage = new Pages.LoginForm.LoginPage(Driver);
            LoginPage.LoginWithUserAccount(user.emailText, user.password);

            var ContactUsPage = new Pages.ContactUsForm.ContactUsPage(Driver);
            ContactUsPage.contactUsForm();
            string titulo = ContactUsPage.Get_titleContactUs();

            Assert.That(titulo, Is.EqualTo("CONTACT US"), "El título no coincide con el texto esperado.");

        }

        [Test, TestCaseSource(typeof(GetUserData), nameof(GetUserData.UserContactData))]
        public void fillOutFormContactUs_Test(string inputName, string inputEmail, string inputSubject, string inputMessage, string emailTest, string password)
        {
            var LoginPage = new Pages.LoginForm.LoginPage(Driver);
            LoginPage.LoginWithUserAccount(emailTest, password);

            var ContactUsPage = new Pages.ContactUsForm.ContactUsPage(Driver);
            ContactUsPage.contactUsForm();
            ContactUsPage.fillOutFormContactUs(inputName, inputEmail, inputSubject, inputMessage);

            ContactUsPage.submitButtonContactUs();
            string textoAlerta = ContactUsPage.Get_textAlert();
            Assert.That(textoAlerta, Is.EqualTo("Press OK to proceed!"), "El texto de la alerta no coincide con lo esperado.");
            ContactUsPage.AcceptAlert();

            var mensajeExito = ContactUsPage.validateSuccessMesaje();
            Assert.That(mensajeExito, Is.EqualTo("Success! Your details have been submitted successfully."), "El texto del mensaje de éxito no es correcto");

        }

    }
}
