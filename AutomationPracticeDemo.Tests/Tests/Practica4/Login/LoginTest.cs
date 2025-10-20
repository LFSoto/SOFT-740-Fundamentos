using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Pages.MainComponents;
using AutomationPracticeDemo.Tests.Tests.Practica4.Login.Data;
using AutomationPracticeDemo.Tests.Utils;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Network;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Tests.Practica4.Login
{
    //agregar datadriven
    [TestFixture]
    public class LoginTest : TestBase
    {
        private static List<User> usersDataList = LoginData.UserTestData();
        private static List<SignUp> sigUpDataList = LoginData.SignUpTestData();

        [TestCaseSource(nameof(sigUpDataList))]
        public void Should_RegisterNewUser(SignUp sigUpData)
        {
            //Se instancian las clases necesarias para ejecutar el test
            HeaderNav headerNav = new HeaderNav(Driver);
            LoginPage loginPage = new LoginPage(Driver);
            SignUpPage signUpPage = new SignUpPage(Driver);
            GetPathHelper getPathHelper = new GetPathHelper();

            //Se presiona el botón Signup / Login y se espera a que carguen los elementos de la pantalla login
            headerNav.LoginLink.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Se crea el correo que se va a utilizar para evitar que ya exista un usuario con el mismo correo
            string formattedDateTime = DateTime.Now.ToString("ddMMyyyyHHmmssfff");//Se obtiene la fecha y hora actual y se formatea para que no tenga espacios ni caracteres que no sean numeros
            string email = "dchavarria" + formattedDateTime + "@test.com";

            //Se llenan los campos nombre y correo, se presiona el botón Signup y se espera a que carguen los elementos de la pantalla signup
            loginPage.SignUpNameTextbox.SendKeys(sigUpData.Name);
            loginPage.SignUpEmailTextbox.SendKeys(email);
            loginPage.SignupButton.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Se desplaza hasta el final de la página para que desaparezcan los banners ya que dan problemas en algunas ejecuciones
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

            //Se completa el formulario
            signUpPage.MrRadioButton.Click();
            signUpPage.PasswordTextbox.SendKeys(sigUpData.Password);
            signUpPage.DaySelect.SendKeys(sigUpData.Day);
            signUpPage.MonthSelect.SendKeys(sigUpData.Month);
            signUpPage.YearSelect.SendKeys(sigUpData.Year);
            //Se agregó esta línea ya que en una de las pruebas un anuncio cargó un iframe (que no volvió a aparecer) que no permitia interactuar con ciertos elementos y arrojaba un error
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", signUpPage.NewsLetterCheckBox);
            signUpPage.NewsLetterCheckBox.Click();
            signUpPage.SpecialOffersCheckBox.Click();
            signUpPage.FirstNameTextbox.SendKeys(sigUpData.FirstName);
            signUpPage.LastNameTextbox.SendKeys(sigUpData.LastName);
            signUpPage.CompanyTextbox.SendKeys(sigUpData.Company);
            signUpPage.Adress1Textbox.SendKeys(sigUpData.Address1);
            signUpPage.Adress2Textbox.SendKeys(sigUpData.Address2);
            signUpPage.CountrySelect.SendKeys(sigUpData.Country);
            signUpPage.StateTextBox.SendKeys(sigUpData.State);
            signUpPage.CityTextBox.SendKeys(sigUpData.City);
            signUpPage.ZipCodeTextBox.SendKeys(sigUpData.ZipCode);
            signUpPage.MobileNumberTextBox.SendKeys(sigUpData.MobileNumber);

            //Se hace click en el botón Create Account
            signUpPage.CreateAccountButton.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Se captura la evidencia del resultado
            ScreenshotHelper.TakeScreenshot(Driver, getPathHelper.GetFilePathScreenShots() + "Should_RegisterNewUser_" + sigUpData.TestCaseNumber +  "-1.png");

            //Se crea la validación del mensaje al crear la cuenta
            Assert.That(signUpPage.AccountCreatedText, Is.EqualTo("ACCOUNT CREATED!"));

            //Se hace clic en el botón Continue y se crea la validación de si se inició sesión con éxito
            signUpPage.ContinueButton.Click();

            //Se captura la evidencia del resultado
            ScreenshotHelper.TakeScreenshot(Driver, getPathHelper.GetFilePathScreenShots() + "Should_RegisterNewUser_" + sigUpData.TestCaseNumber + "-2.png");

            Assert.That(headerNav.LogoutLink.Displayed);
        }

        [TestCaseSource(nameof(usersDataList))]
        public void Should_Login(User user)
        {
            //Se instancian las clases necesarias para ejecutar el test
            LoginHelper loginHelper = new LoginHelper(Driver);
            LoginPage loginPage = new LoginPage(Driver);
            GetPathHelper getPathHelper = new GetPathHelper();

            //Se llama al método que realiza el inicio de sesión
            loginHelper.Login(user.Email, user.Password);

            //Se valida si la data que se utiliza es de un usuario valido o no
            if (user.IsValid)
            {
                //Se captura la evidencia del resultado
                ScreenshotHelper.TakeScreenshot(Driver, getPathHelper.GetFilePathScreenShots() + "Should_Login_1.png");

                //Se valida que se haya iniciado sesión
                Assert.That(loginPage.LoggedInTextActualResult, Is.EqualTo("Logged in as DixonC"));
            }
            else
            {
                //Se captura la evidencia del resultado
                ScreenshotHelper.TakeScreenshot(Driver, getPathHelper.GetFilePathScreenShots() + "Should_Login_2.png");

                //Se valida que se haya iniciado sesión
                Assert.That(loginPage.LogInFailedActualResult, Is.EqualTo("Your email or password is incorrect!"));
            }
        }
    }
}
