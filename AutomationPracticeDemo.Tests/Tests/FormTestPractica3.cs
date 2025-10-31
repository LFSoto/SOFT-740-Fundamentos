using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationPracticeDemo.Tests.Utils;
using AutomationPracticeDemo.Tests.Pages;
using OpenQA.Selenium;
using SeleniumExtras;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutomationPracticeDemo.Tests.Tests
{
    public class FormTestPractica3 : TestBasePractica3
    {

        [TestCase("Yei", "123", "1991","Canada","Yeison", "Rojas Sancho", "CENFOTEC", "Toronto", "Phillips", "Toronto", "JST West","234554-09","8888888")]
        [Ignore("Este test está deshabilitado temporalmente")]
        public void a_RegistroUsuarioNuevo(string nombre, string pass, string AnnoNacimiento, string pais, string nombrecompleto, string apellidos, string compania, string dprincipal, string dsecundaria, string estado, string ciudad, string postal, string telefono)
        {
            var frompage = new FromPagePractica3(Driver);
            
            string correo = frompage.GenerarCorreoAleatorio();
            frompage.ValidarCargaHome();
            frompage.SuscripcionUsuarioNuevo(nombre,correo);
            frompage.CompletarFormularioUsuarioNuevo(pass, AnnoNacimiento, pais, nombrecompleto, apellidos, compania, dprincipal, dsecundaria, estado, ciudad, postal, telefono);
            ScreenshotHelper.TakeScreenshot(Driver, "test_RegistroUsuarioNuevo.png");

            Assert.That(frompage.Valorhome, Is.EqualTo("Home"));
            Assert.That(frompage.ValorUserSingup, Is.EqualTo("New User Signup!"));
            Assert.That(frompage.ValorTitleForm, Is.EqualTo("ENTER ACCOUNT INFORMATION"));
            Assert.That(frompage.ValorValidarMensajeConfirmar,Is.EqualTo("ACCOUNT CREATED!"));
            Assert.That(frompage.ValorLoggin,Is.EqualTo("Logged in as "+nombre));
        }

        [TestCase("yeisonrojass@hotmail.com","123")]
        [Ignore("Este test está deshabilitado temporalmente")]
        public void b_LoginUsuarioExistente(string correo, string contrasena) 
        {
            var formpage = new FromPagePractica3(Driver);

            formpage.ValidarCargaHome();
            formpage.IngresarPlataforma(correo,contrasena);
            ScreenshotHelper.TakeScreenshot(Driver, "test_LoginUsuarioExistente.png");

            Assert.That(formpage.Valorhome, Is.EqualTo("Home"));
            Assert.That(formpage.ValorUserLogin,Is.EqualTo("Login to your account"));
            Assert.That(formpage.ValorLoggin, Is.EqualTo("Logged in as " + formpage.ValorNombreLogin));
        }

        [TestCase("yeisonrojass@hotmail.com", "123",2,14,"Yeison Rojas S","23445576785890","345","05","2027")]
        [Ignore("Este test está deshabilitado temporalmente")]
        public void c_AgregarProductosCarritoyVerificarTotal(string correo, string contrasenna, int Idproducto1, int Idproducto2,string nombre, string numTarjeta, string cvc, string mes, string anno) 
        {
            var formpage = new FromPagePractica3(Driver);

            formpage.ValidarCargaHome();
            formpage.LlenarCarritoyTotales(correo,contrasenna,Idproducto1,Idproducto2,nombre,numTarjeta,cvc,mes,anno);
            ScreenshotHelper.TakeScreenshot(Driver, "test_AgregarProductosCarritoyVerificarTotal.png");

            Assert.That(formpage.Valorhome, Is.EqualTo("Home"));
            Assert.That(formpage.ValorLoggin, Is.EqualTo("Logged in as " + formpage.ValorNombreLogin));
            Assert.That(formpage.ValorTituloFormularioProductos, Is.EqualTo("ALL PRODUCTS"));
            Assert.That(formpage.ValorTitleProductoAgregado,Is.EqualTo("Your product has been added to cart."));
            Assert.That(formpage.ValorDescripcionproducto1, Is.EqualTo("Men Tshirt"));
            Assert.That(formpage.ValorDescripcionproducto2, Is.EqualTo("Full Sleeves Top Cherry - Pink"));
            Assert.That(formpage.ValorTotalDesdeElSistema, Is.EqualTo(formpage.ValorTotalEsperadoXFormula));
            Assert.That(formpage.ValorConfirmarOrdenFinalizada, Is.EqualTo("Congratulations! Your order has been confirmed!"));
        }

        [TestCase("yeisonrojass@hotmail.com","Yeison Rojas S","Recibir Información","Aquí paso a saludar")]
        [Ignore("Este test está deshabilitado temporalmente")]
        public void d_ContactUsForm(string correo, string nombre, string subject, string mensaje)
        {
            var formpage = new FromPagePractica3(Driver);
       
            formpage.LlenarFormularioContactar(correo, nombre, subject, mensaje);
            ScreenshotHelper.TakeScreenshot(Driver, "test_ContactUsForm.png");

            Assert.That(formpage.ValorTextUrl, Does.Contain("Foto.jpg"));
            Assert.That(formpage.ValorTextoAlerta, Is.EqualTo("Press OK to proceed!"));
            Assert.That(formpage.ValorMensajeExitoCorreo, Is.EqualTo("Success! Your details have been submitted successfully."));
        }

        [TestCase("yeisonrojass@hotmail.com")]
        [Ignore("Este test está deshabilitado temporalmente")]
        public void e_SuscripcionNewsLetter(string correo)
        {
            var formpage = new FromPagePractica3(Driver);

            formpage.EnviarSuscripcion(correo);
            ScreenshotHelper.TakeScreenshot(Driver, "test_SuscripcionNewsLetter.png");

            Assert.That(formpage.ValorMensajeExitoSuscripcion, Is.EqualTo("You have been successfully subscribed!"));
        }



    }
}
