using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Tests.SignUp.Data;
using AutomationPracticeDemo.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Tests.SignUp.Test
{
    public class SignUpTest:TestBase
    {
        [Test, TestCaseSource(typeof(SignUpData), nameof(SignUpData.TestCases))]
        public void SignUpTests(SignUpData data)
        {
           //definición de los web elements (migrado a SignUpPage usando POM)
            var page = new SignUpPage(Driver);

            //abrir la página de sign up / login
            page.SignupOpen();

            //datos de sign up inicial
            page.FillBasicData(data.Name, data.email);

            //clic en el botón de Submit Sign Up
            page.SubmitSignup();

            //llenado del formulario de Account Information y Address Information
            page.FillAccountDetails(data.Password, data.Day, data.Month, data.Year);

            //llenado de la información de dirección
            page.FillAddressInfo(data.FirstName, data.LastName, data.Company, data.Address1, data.Country, data.State, data.City, data.ZipCode, data.MobileNumber);
            //clic en el botón de Create Account
            page.CreateAccount();

            ScreenshotHelper.TakeScreenshot(Driver, "SignUpTest_test.png");

            //validar el mensaje de cuenta creada
            var accountCreatedMessage = page.GetSuccessMessage();
            Assert.That(accountCreatedMessage, Is.EqualTo("ACCOUNT CREATED!"));

            //clic en el botón de continuar
            page.Continue();

            //validar que el usuario esté logueado
            var confirmationLogin = page.GetConfirmationLogin();
            Assert.That(confirmationLogin, Does.Contain("Logged in as"));
        }


    }
}
