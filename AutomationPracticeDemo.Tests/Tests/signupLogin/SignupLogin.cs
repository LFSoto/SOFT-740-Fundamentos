using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Pages.AutomationExercisePage;
using AutomationPracticeDemo.Tests.Tests.signupPage;
using AutomationPracticeDemo.Tests.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using System.IO;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;



namespace AutomationPracticeDemo.Tests.Tests.signupPage
{
    [TestFixture]

    public class SignuploginTest : TestBase
    {


        [Test]
        [TestCaseSource(typeof(dataSources), nameof(dataSources.TestCaseSignup))]
        public void SignuploginTestexitosa( string password, string textoEsperado,string firstName, string lastName, string company,
        string address1, string adress2, string country, string state, string city, string zipcode, string mobileNumber, string day, string month, string year, string name)
      
        {

            var inicioPage = new InicioPage(Driver);
            inicioPage.signuplogin();
            //INGRESO DE CREDENCIALES
            var signupPage = new SignupPage(Driver);
             int random = new Random().Next(1, 1000);
            signupPage.Signup(name, "SOFT-7" + random + "@cenfotec.com");

            //iNSERCCION DE DATOS EN EL FORMULARIO DE REGISTRO
            signupPage.Datosformulario(password, firstName, lastName, company,
         address1,  adress2,  country,  state,  city,  zipcode,  mobileNumber, day,  month,  year);

            //VALIDACION DE Signuplogin
            try
            {
                var textoObtenido = signupPage.getTexto();
                Assert.That(textoObtenido, Is.EqualTo(textoEsperado), "Se esperaba texto de login exitoso pero no coincide.");
            }
            catch (NoSuchElementException)
            {
                var textoObtenido2 = signupPage.getTextoFallido();
                Assert.That(textoObtenido2, Is.EqualTo(textoEsperado), "Se esperaba texto de error de login pero no coincide.");
            }
          
        }


       /* [Test]
        public void SignuploginTestFallido()
        {
            var inicioPage = new InicioPage(Driver);
            inicioPage.signuplogin();
            //INGRESO DE CREDENCIALES
            var signupPage = new SignupPage(Driver);
            signupPage.Signup("Tamara", "SOFT-7401@cenfotec.com");


          

            
        }
       */




    }
}

