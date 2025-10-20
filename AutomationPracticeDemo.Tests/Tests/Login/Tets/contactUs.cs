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

    public class contactUs : TestBase
    {


        [Test]
        public void contactUsTestexitosa()
        {
            var inicioPage = new InicioPage(Driver);
            inicioPage.ContactUs();
            //INGRESO DE CREDENCIALES
            var contactUsPage = new contactUsPage(Driver);
           
            //iNSERCCION DE DATOS EN EL FORMULARIO DE REGISTRO
            var datosformulario = new contactUsPage(Driver);
            datosformulario.contactUs("Tamara Salazar", "tsalazar@gmail.com", "validar el envío correcto del formulario de contacto.", "Este es un mensaje de prueba para validar el envío correcto del formulario de contacto.", "SOFT-740-Fundamentos\\AutomationPracticeDemo.Tests\\Selenium_Logo.png");
            
            //Alerta
            Driver.SwitchTo().Alert().Accept();
            //validación
            var textoObtenido = contactUsPage.getTexto();
            var textoEsperado = "Success! Your details have been submitted successfully.";
            Assert.That(textoObtenido, Is.EqualTo(textoEsperado));
            Assert.Pass("Datos enviadoS correctamente.");
     
        }
    }
}
