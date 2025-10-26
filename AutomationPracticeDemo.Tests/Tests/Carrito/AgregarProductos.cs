
using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Pages.AutomationExercisePage;
using AutomationPracticeDemo.Tests.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using System.IO;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;


namespace AutomationPracticeDemo.Tests.Tests.Carrito
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
            carritopage.verCarrito();
            


        }



        [Test]
        [TestCaseSource(typeof(dataSources), nameof(dataSources.TestCaseCart))]
        public void Montoproducto(string textoEsperadoUnitario, string textoEsperadoTotal, string identificadorTest)
        {
            var inicioPage = new InicioPage(Driver);
            inicioPage.carrito();
            var carritopage = new CarritoPage(Driver);
            carritopage.agregarcarrito();
            carritopage.agregarsegundocarrito();
            carritopage.verCarrito();

            var textoObtenidoUnitario = carritopage.Unitario();
            var textoObtenidoTotal = carritopage.precioTotal();

            Assert.Multiple(() =>
            {
                Assert.That(textoObtenidoUnitario, Is.EqualTo(textoEsperadoUnitario), $"Unitario mismatch for {identificadorTest}");
                Assert.That(textoObtenidoTotal, Is.EqualTo(textoEsperadoTotal), $"Total mismatch for {identificadorTest}");
            });
        }

        [Test]
        [TestCaseSource(typeof(dataSources), nameof(dataSources.TestCaseCart))]
        public void montoTotal(string textoEsperado2, string textoEsperadoTotal, string identificadorTest)
        {
            var inicioPage = new InicioPage(Driver);
            inicioPage.carrito();
            var carritopage = new CarritoPage(Driver);
            carritopage.agregarcarrito();
            carritopage.agregarsegundocarrito();
            carritopage.verCarrito();

            var textoObtenido2 = carritopage.precioTotal();
            Assert.That(textoObtenido2, Is.EqualTo(textoEsperadoTotal), $"Total mismatch for {identificadorTest}");
        }
    }
}