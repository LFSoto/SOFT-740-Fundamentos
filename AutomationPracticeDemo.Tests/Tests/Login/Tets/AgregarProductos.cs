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

    public class agregarProductos : TestBase
    {


        [Test]
        public void productoscarritoexitosa()
        {
            //Click en productos
            var inicioPage = new InicioPage(Driver);
            inicioPage.carrito();
            //AGREGAR PRODUCTOS AL CARRITO
            var carritopage = new CarritoPage(Driver);
            carritopage.agregarcarrito();
            carritopage.agregarsegundocarrito();
            carritopage.vercarrito();
            


        }
        [Test]
        public void Montoproducto()
        {
            //Click en productos
            var inicioPage = new InicioPage(Driver);
            inicioPage.carrito();
            //AGREGAR PRODUCTOS AL CARRITO
            var carritopage = new CarritoPage(Driver);
            carritopage.agregarcarrito();
            carritopage.agregarsegundocarrito();
            carritopage.vercarrito();
            //VALIDACION DE LOGIN

            var textoObtenido = carritopage.Unitario();
            var textoEsperado = "Rs. 278";
            Assert.That(textoObtenido, Is.EqualTo(textoEsperado));
            Assert.Pass("Total unitario correcta");

            


        }
        [Test]
        public void montoTotal()
        {
            //Click en productos
            var inicioPage = new InicioPage(Driver);
            inicioPage.carrito();
            //AGREGAR PRODUCTOS AL CARRITO
            var carritopage = new CarritoPage(Driver);
            carritopage.agregarcarrito();
            carritopage.agregarsegundocarrito();
            carritopage.vercarrito();
            //VALIDACION DE LOGIN

     

            var textoObtenido2 = carritopage.precioTotal();
            var textoEsperado2 = "Rs. 556";
            Assert.That(textoObtenido2, Is.EqualTo(textoEsperado2));
            Assert.Pass("Monto total correcta");


        }


    }
}

