using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Pages.AutomationExercisePage;
using AutomationPracticeDemo.Tests.Tests.Login;
using AutomationPracticeDemo.Tests.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using System.IO;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;



namespace AutomationPracticeDemo.Tests.Tests.Tets
{
    [TestFixture]

    public class Suscripciónnewsletter : TestBase
    {
       

        [Test]
        public void subcripciónexistente()
        {
           
            var suscripciónnewsletter = new SuscripciónnewsletterPage(Driver);
            suscripciónnewsletter.subscribirEmail("SOFT-7401@cenfotec.com");
            suscripciónnewsletter.suscriBtn();

            //VALIDACION DE LOGIN
            var textoObtenido = suscripciónnewsletter.validasubscri();

            var textoEsperado = "You have been successfully subscribed!";
            Assert.That(textoObtenido, Is.EqualTo(textoEsperado));
            Assert.Pass("Subcripcion exitoso.");

        }
       



    }
}

