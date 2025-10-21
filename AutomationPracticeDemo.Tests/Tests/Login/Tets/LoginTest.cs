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
     

        [Test]
        [TestCaseSource(typeof(dataSources), nameof(dataSources.TestCaseLogin))]
        public void loginExitoso(string email, string password, string textoEsperado)
        {
            var inicioPage = new InicioPage(Driver);
            inicioPage.signuplogin();

            var loginPage = new LoginPage(Driver);
            loginPage.Login(email, password);

            // Intentamos primero obtener el texto de éxito. Si no existe, capturamos la excepción
            // y validamos el mensaje de error.
            try
            {
                var textoObtenido = loginPage.getTexto();
                Assert.That(textoObtenido, Is.EqualTo(textoEsperado), "Se esperaba texto de login exitoso pero no coincide.");
            }
            catch (NoSuchElementException)
            {
                var textoObtenido2 = loginPage.getTextoFallido();
                Assert.That(textoObtenido2, Is.EqualTo(textoEsperado), "Se esperaba texto de error de login pero no coincide.");
            }

        /*[Test]
        
        [TestCaseSource(typeof(dataSources), nameof(dataSources.TestCaseLogin))]
        public void loginFallido(string email, string password, string textoEsperado)
        {
            var inicioPage = new InicioPage(Driver);
            inicioPage.signuplogin();
            //INGRESO DE CREDENCIALES
            var loginPage = new LoginPage(Driver);
            loginPage.Login(email, password);


            //VALIDACION DE LOGIN
            var textoObtenido = loginPage.getTextoFallido();

            var TextoEsperado = textoEsperado;
            Assert.That(textoObtenido, Is.EqualTo(TextoEsperado));
            Assert.Pass("Usuario no existe.");

       }

         */

    }
}
}

