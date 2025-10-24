using AutomationPracticeDemo.Tests.Utils;
using AutomationPracticeDemo.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationPracticeDemo.Tests.Tests.Data.LoginUsuarioExistente;
using AutomationPracticeDemo.Tests.Tests.Data.SuscripcionNewsLetter;
using AutomationPracticeDemo.Tests.Tests.Data.CompletarFormularioContactar;
using AutomationPracticeDemo.Tests.Tests.Data.CompraLinea;
using AutomationPracticeDemo.Tests.Tests.Data.RegistrarUsuario;
using AutomationPracticeDemo.Tests.Tests.Data.LoginUsuarioFail;

namespace AutomationPracticeDemo.Tests.Tests
{
    public class FromTestPractica4 : TestBasePractica3
    {
        private static object[] dataLogin = new LoginData().getLoginData;
        private static object[] dataLoginFail = new LoginDataFail().getLoginDataLogin;
        private static object[] dataSuscripcionNewLetter = new SuscripcionNewsLetterData().getSuscripcionNewsLetterData;
        private static object[] dataCompletarFormularioContactar = new FormularioContactarData().getCompletarFormularioContactarData;
        private static object[] dataCompraLinea = new ComprarLineaData().getCompraLineaData;
        private static object[] dataRegistrarUsuario = new RegistrarUsuarioData().getRegistrarUsuarioData;

        /// <summary>
        /// Caso de prueba que valida el flujo de registro de un nuevo usuario.
        /// Se genera un correo aleatorio, se completan todos los campos requeridos
        /// y se verifica que el sistema muestre los mensajes correctos de confirmación.
        /// </summary>
        /// <param name="nombre">Nombre del usuario a registrar.</param>
        /// <param name="pass">Contraseña de la cuenta nueva.</param>
        /// <param name="AnnoNacimiento">Año de nacimiento del usuario.</param>
        /// <param name="pais">País seleccionado en el formulario.</param>
        /// <param name="nombrecompleto">Nombre completo del usuario.</param>
        /// <param name="apellidos">Apellidos del usuario.</param>
        /// <param name="compania">Nombre de la compañía.</param>
        /// <param name="dprincipal">Dirección principal del usuario.</param>
        /// <param name="dsecundaria">Dirección secundaria (opcional).</param>
        /// <param name="estado">Estado o provincia.</param>
        /// <param name="ciudad">Ciudad del usuario.</param>
        /// <param name="postal">Código postal.</param>
        /// <param name="telefono">Número de teléfono.</param>
        /// <param name="home">Texto esperado en la página principal.</param>
        /// <param name="usuario">Nombre esperado del usuario registrado.</param>
        /// <param name="tituloformulario">Título del formulario de registro.</param>
        /// <param name="mensajeConfirmar">Mensaje de confirmación esperado al registrar.</param>
        /// <param name="login">Texto de bienvenida esperado después del registro.</param>
        [TestCaseSource(nameof(dataRegistrarUsuario))]
        public void a_RegistroUsuarioNuevo(string nombre, string pass, string AnnoNacimiento, string pais, string nombrecompleto, string apellidos, string compania, string dprincipal, string dsecundaria, string estado, string ciudad, string postal, string telefono, string home, string usuario,string tituloformulario, string mensajeConfirmar, string login)
        {
            var frompage = new FromPagePractica3(Driver);

            string correo = frompage.GenerarCorreoAleatorio();
            frompage.ValidarCargaHome();
            frompage.SuscripcionUsuarioNuevo(nombre, correo);
            frompage.CompletarFormularioUsuarioNuevo(pass, AnnoNacimiento, pais, nombrecompleto, apellidos, compania, dprincipal, dsecundaria, estado, ciudad, postal, telefono);
            ScreenshotHelper.TakeScreenshot(Driver, "test_RegistroUsuarioNuevo.png");

            Assert.That(frompage.Valorhome, Is.EqualTo(home));
            Assert.That(frompage.ValorUserSingup, Is.EqualTo(usuario));
            Assert.That(frompage.ValorTitleForm, Is.EqualTo(tituloformulario));
            Assert.That(frompage.ValorValidarMensajeConfirmar, Is.EqualTo(mensajeConfirmar));
            Assert.That(frompage.ValorLoggin, Is.EqualTo(login + nombre));
        }

        /// <summary>
        /// Caso de prueba que valida el inicio de sesión con un usuario existente.
        /// Se cubren escenarios con credenciales correctas e incorrectas, obtenidas desde el archivo JSON.
        /// </summary>
        /// <param name="correo">Correo del usuario registrado.</param>
        /// <param name="contrasena">Contraseña asociada al usuario.</param>
        /// <param name="home">Texto esperado en la página principal tras el login.</param>
        /// <param name="userLogin">Mensaje de usuario logueado esperado.</param>
        /// <param name="Login">Texto base del mensaje de bienvenida.</param>
        [TestCaseSource(nameof(dataLogin))]
        public void b_LoginUsuarioExistente(string correo, string contrasena, string home, string userLogin, string Login)
        {
            var formpage = new FromPagePractica3(Driver);

            formpage.ValidarCargaHome();
            formpage.IngresarPlataforma(correo, contrasena);
            ScreenshotHelper.TakeScreenshot(Driver, "test_LoginUsuarioExistente.png");

            Assert.That(formpage.Valorhome, Is.EqualTo(home));
            Assert.That(formpage.ValorUserLogin, Is.EqualTo(userLogin));
            Assert.That(formpage.ValorLoggin, Is.EqualTo(Login + formpage.ValorNombreLogin));
        }

        /// <summary>
        /// Verifica que el sistema muestre el mensaje de error correcto cuando 
        /// un usuario intenta iniciar sesión con credenciales inválidas.
        /// </summary>
        /// <param name="correo">Correo electrónico ingresado (usuario inexistente o incorrecto).</param>
        /// <param name="contrasena">Contraseña ingresada (incorrecta).</param>
        /// <param name="home">Texto esperado de la página principal.</param>
        /// <param name="userLogin">(No aplica en este caso).</param>
        /// <param name="Login">Mensaje de error esperado al fallar el inicio de sesión.</param>
        [TestCaseSource(nameof(dataLoginFail))]
        public void c_LoginUsuarioNoExistente(string correo, string contrasena, string home, string userLogin, string Login)
        {
            var formpage = new FromPagePractica3(Driver);

            formpage.ValidarCargaHome();
            formpage.IngresarPlataformaFail(correo, contrasena);
            ScreenshotHelper.TakeScreenshot(Driver, "test_LoginUsuarioExistente.png");

            Assert.That(formpage.Valorhome, Is.EqualTo(home));
            Assert.That(formpage.ValorLoggin, Is.EqualTo(Login));
        }

        /// <summary>
        /// Caso de prueba que verifica el proceso de compra en línea,
        /// agregando productos al carrito, realizando el pago y validando los totales finales.
        /// </summary>
        /// <param name="correo">Correo del usuario que realiza la compra.</param>
        /// <param name="contrasenna">Contraseña del usuario comprador.</param>
        /// <param name="Idproducto1">ID del primer producto a agregar.</param>
        /// <param name="Idproducto2">ID del segundo producto a agregar.</param>
        /// <param name="nombre">Nombre del titular de la tarjeta.</param>
        /// <param name="numTarjeta">Número de la tarjeta de crédito.</param>
        /// <param name="cvc">Código CVC de la tarjeta.</param>
        /// <param name="mes">Mes de vencimiento de la tarjeta.</param>
        /// <param name="anno">Año de vencimiento de la tarjeta.</param>
        /// <param name="home">Texto esperado al volver al home.</param>
        /// <param name="login">Mensaje esperado con el nombre del usuario logueado.</param>
        /// <param name="formularioProductos">Título del formulario de compra.</param>
        /// <param name="productoAgregado">Mensaje de confirmación de producto agregado.</param>
        /// <param name="producto1">Descripción del primer producto.</param>
        /// <param name="producto2">Descripción del segundo producto.</param>
        /// <param name="ordenFinalizada">Mensaje esperado al finalizar la orden.</param>
        [TestCaseSource(nameof(dataCompraLinea))]
        public void d_AgregarProductosCarritoyVerificarTotal(string correo, string contrasenna, int Idproducto1, int Idproducto2, string nombre, string numTarjeta, string cvc, string mes, string anno, string home, string login, string formularioProductos, string productoAgregado, string producto1, string producto2, string ordenFinalizada)
        {
            var formpage = new FromPagePractica3(Driver);

            formpage.ValidarCargaHome();
            formpage.LlenarCarritoyTotales(correo, contrasenna, Idproducto1, Idproducto2, nombre, numTarjeta, cvc, mes, anno);
            ScreenshotHelper.TakeScreenshot(Driver, "test_AgregarProductosCarritoyVerificarTotal.png");

            Assert.That(formpage.Valorhome, Is.EqualTo(home));
            Assert.That(formpage.ValorLoggin, Is.EqualTo(login + formpage.ValorNombreLogin));
            Assert.That(formpage.ValorTituloFormularioProductos, Is.EqualTo(formularioProductos));
            Assert.That(formpage.ValorTitleProductoAgregado, Is.EqualTo(productoAgregado));
            Assert.That(formpage.ValorDescripcionproducto1, Is.EqualTo(producto1));
            Assert.That(formpage.ValorDescripcionproducto2, Is.EqualTo(producto2));
            Assert.That(formpage.ValorTotalDesdeElSistema, Is.EqualTo(formpage.ValorTotalEsperadoXFormula));
            Assert.That(formpage.ValorConfirmarOrdenFinalizada, Is.EqualTo(ordenFinalizada));
        }

        /// <summary>
        /// Caso de prueba que valida el formulario "Contact Us",
        /// verificando que se pueda enviar un mensaje con archivo adjunto
        /// y que se muestren los mensajes de alerta y éxito correspondientes.
        /// </summary>
        /// <param name="correo">Correo del remitente.</param>
        /// <param name="nombre">Nombre del remitente.</param>
        /// <param name="subject">Asunto del mensaje.</param>
        /// <param name="mensaje">Contenido del mensaje a enviar.</param>
        /// <param name="textoUrl">Texto de la URL que contiene el nombre del archivo cargado.</param>
        /// <param name="textoAlerta">Texto esperado en la alerta del navegador.</param>
        /// <param name="mensajeExito">Mensaje de éxito esperado tras el envío.</param>
        [TestCaseSource(nameof(dataCompletarFormularioContactar))]
        public void e_ContactUsForm(string correo, string nombre, string subject, string mensaje, string textoUrl, string textoAlerta, string mensajeExito)
        {
            var formpage = new FromPagePractica3(Driver);

            formpage.LlenarFormularioContactar(correo, nombre, subject, mensaje);
            ScreenshotHelper.TakeScreenshot(Driver, "test_ContactUsForm.png");

            Assert.That(formpage.ValorTextUrl, Does.Contain("Foto.jpg"));
            Assert.That(formpage.ValorTextoAlerta, Is.EqualTo("Press OK to proceed!"));
            Assert.That(formpage.ValorMensajeExitoCorreo, Is.EqualTo("Success! Your details have been submitted successfully."));
        }

        /// <summary>
        /// Caso de prueba que valida el flujo de suscripción al boletín informativo (newsletter),
        /// comprobando que el sistema muestre el mensaje de confirmación correspondiente.
        /// </summary>
        /// <param name="correo">Correo utilizado para suscribirse al newsletter.</param>
        /// <param name="valorSuscripcionNewsLetter">Mensaje de confirmación esperado tras la suscripción.</param>
        [TestCaseSource(nameof(dataSuscripcionNewLetter))]
        public void f_SuscripcionNewsLetter(string correo, string valorSuscripcionNewsLetter)
        {
            var formpage = new FromPagePractica3(Driver);

            formpage.EnviarSuscripcion(correo);
            ScreenshotHelper.TakeScreenshot(Driver, "test_SuscripcionNewsLetter.png");
            
            Assert.That(formpage.ValorMensajeExitoSuscripcion, Is.EqualTo(valorSuscripcionNewsLetter));
        }

    }
}
