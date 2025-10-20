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

    public class SignuploginTest : TestBase
    {


        [Test]
        public void SignuploginTestexitosa()
        {
            var inicioPage = new InicioPage(Driver);
            inicioPage.signuplogin();
            //INGRESO DE CREDENCIALES
            var signupPage = new signupPage(Driver);
             int random = new Random().Next(1, 1000);
            signupPage.Signup("Tamara", "SOFT-7" + random + "@cenfotec.com");

            //iNSERCCION DE DATOS EN EL FORMULARIO DE REGISTRO
            var datosformulario = new signupPage(Driver);
            signupPage.Datosformulario("Ms", "Tamara Salazar", "SOFT-7401", "Newsletter", "Special Offers",
            "Calle 123", "San Jose", "Cali|fornia", "United States", "12345", "1234567890");


            //VALIDACION DE Signuplogin
            var textoObtenido = signupPage.getTexto();
            var textoEsperado = "ACCOUNT CREATED!";
            Assert.That(textoObtenido, Is.EqualTo(textoEsperado));
            Assert.Pass("Creacion de cuenta exitoso.");

            var Continuar = new signupPage(Driver);
            signupPage.continuar();
        }


        [Test]
        public void SignuploginTestFallido()
        {
            var inicioPage = new InicioPage(Driver);
            inicioPage.signuplogin();
            //INGRESO DE CREDENCIALES
            var signupPage = new signupPage(Driver);
            signupPage.Signup("Tamara", "SOFT-7401@cenfotec.com");


            //VALIDACION DE Signuplogin
            var textoObtenido = signupPage.getTextoFallido();
            var textoEsperado = "Email Address already exist!";
            Assert.That(textoObtenido, Is.EqualTo(textoEsperado));
            Assert.Pass("NO fué posible crear cuenta");

            
        }






    }
}

