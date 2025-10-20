using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Pages.AutomationExercisePage;
using AutomationPracticeDemo.Tests.Tests.Login.Data;
using AutomationPracticeDemo.Tests.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using System.IO;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;



namespace AutomationPracticeDemo.Tests.Tests.Login.Tets
{
    [TestFixture]

    public class LoginTest : TestBase
    {
        /* [Test, TestCaseSource(typeof(TestData), nameof(TestData.LoginUsers))]
         public void TestLoginexitoso(dynamic user)

         {
             var home = new  InicioPage(Driver);
             home.signuplogin();

             var loginPage = new LoginPage(Driver);

             loginPage.Login((string)user.email, (string)user.password);


             Assert.Multiple(() =>
             {
                 Assert.That(new InicioPage(Driver).IsLoggedInAs((string)user.displayName), Is.True,
                             "No se mostró 'Logged in as [usuario]'.");
             });
        */

        [Test]
        public void loginexistente()
        {
            var inicioPage = new InicioPage(Driver);
            inicioPage.signuplogin();
            //INGRESO DE CREDENCIALES
            var loginPage = new LoginPage(Driver);
            loginPage.Login("SOFT-7401@cenfotec.com", "SOFT-7400");


            //VALIDACION DE LOGIN
            var textoObtenido = loginPage.getTexto();

            var textoEsperado = "Logged in as tamara";
            Assert.That(textoObtenido, Is.EqualTo(textoEsperado));
            Assert.Pass("Login exitoso.");

        }
        [Test]
        public void loginFallido()
        {
            var inicioPage = new InicioPage(Driver);
            inicioPage.signuplogin();
            //INGRESO DE CREDENCIALES
            var loginPage = new LoginPage(Driver);
            loginPage.Login("SOFT-7401@cenfotec.com", "SOFT-7401");


            //VALIDACION DE LOGIN
            var textoObtenido = loginPage.getTextoFallido();

            var textoEsperado = "Your email or password is incorrect!";
            Assert.That(textoObtenido, Is.EqualTo(textoEsperado));
            Assert.Pass("Usuario no existe.");

        }



    }
}

