using AutomationPracticeDemo.Tests.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Script;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using static NUnit.Framework.Constraints.Tolerance;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;

namespace AutomationPracticeDemo.Tests.Tests
{
    
    public class AutomationPractice:TestBase
    {
        static readonly int random = new Random().Next(1, 1000);
        static readonly string email = "SOFT-740" + random + "@cenfotec.com";
        static readonly string password = "SOFT-740";
        const string name = "SOFT-740";
        const string emailTest = "SOFT-740_SOFT@cenfotec.com";

        //1- Registro de usuario nuevo (. Click en Signup / Login. )
        [Test, Order(1)]
        public void SignupLoginTest()
        {

            var LoginButton = Driver.FindElement(By.CssSelector("li a[href=\"/login\"]"));
            string actualStyle = LoginButton.GetCssValue("color");
            LoginButton.Click();
            Assert.That(actualStyle, Is.EqualTo("rgba(105, 103, 99, 1)"));
        }


        //1- Registro de usuario nuevo (3. Completar nombre y correo.)
        [Test, Order(2)]
        public void NewUserTest()
        {
            var LoginButton = Driver.FindElement(By.CssSelector("li a[href=\"/login\"]"));
            LoginButton.Click();

            var nameInput = Driver.FindElement(By.CssSelector("input[data-qa='signup-name']"));
            var emailInput = Driver.FindElement(By.CssSelector("input[data-qa='signup-email']"));
            var submit = Driver.FindElement(By.CssSelector("button[data-qa='signup-button']"));

            //se ingresa el nombre
            nameInput.SendKeys(name);
            //se ingresa el correo
            emailInput.SendKeys(email);
            //se da click en el botón Signup
            submit.Click();
            //verificamos que haya ingresado al página de "enter account information"
            Thread.Sleep(1000); // Esperamos para que el DOM se actualice

            var titleEnterAccount = Driver.FindElement(By.CssSelector("#form > div > div > div > div.login-form > h2 > b"));
            Assert.That(titleEnterAccount.Text, Is.EqualTo("ENTER ACCOUNT INFORMATION"));
        }

        //1- Registro de usuario nuevo (cubre los puntos 4, 5, 6 ,7).
        [Test, Order(3)]
        public void EnterAccountInfoTest()
        {
            var LoginButton = Driver.FindElement(By.CssSelector("li a[href=\"/login\"]"));
            LoginButton.Click();

            var nameInput = Driver.FindElement(By.CssSelector("input[data-qa='signup-name']"));
            var emailInput = Driver.FindElement(By.CssSelector("input[data-qa='signup-email']"));
            var submit = Driver.FindElement(By.CssSelector("button[data-qa='signup-button']"));

            //se ingresa el nombre
            nameInput.SendKeys(name);
            //se ingresa el correo
            emailInput.SendKeys(email);
            //se da click en el botón Signup
            submit.Click();
            //Completamos los campos del formulario Name, Password, DateOfBirth.
            Thread.Sleep(1000); // Esperamos para que el DOM se actualice

            var titleRadButton = Driver.FindElement(By.Id("id_gender2"));
            var InputName = Driver.FindElement(By.CssSelector("input[data-qa=\"name\"]"));
            var InputPassword = Driver.FindElement(By.CssSelector("input[data-qa=\"password\"]"));
            var DropDownDay = Driver.FindElement(By.Id("password"));
            var DropDownMonth = Driver.FindElement(By.Id("months"));
            var DropDownYear = Driver.FindElement(By.Id("years"));

            //Completamos los campos del address information
            var inputFirstName = Driver.FindElement(By.Id("first_name"));
            var inputLastName = Driver.FindElement(By.Id("last_name"));
            var inputCompanyName = Driver.FindElement(By.Id("company"));
            var inputAddress1 = Driver.FindElement(By.Id("address1"));
            var inputAddress2 = Driver.FindElement(By.Id("address2"));
            var DropDownCountry = Driver.FindElement(By.Id("country"));
            var inputState = Driver.FindElement(By.Id("state"));
            var inputCity = Driver.FindElement(By.Id("city"));
            var inputZipCode = Driver.FindElement(By.Id("zipcode"));
            var inputMobileNumb = Driver.FindElement(By.Id("mobile_number"));

            //enviamos los campos del "ENTER ACCOUNT INFORMATION"
            titleRadButton.Click();
            InputPassword.SendKeys(password);
            DropDownDay.SendKeys("21");
            DropDownMonth.SendKeys("12");
            DropDownYear.SendKeys("1989");
            //enviamos los campos del "ADDRESS INFORMATION"
            inputFirstName.SendKeys("Angelica");
            inputLastName.SendKeys("Alvarez");
            inputCompanyName.SendKeys("Cenfotec");
            inputAddress1.SendKeys("Singapore");
            inputAddress2.SendKeys("Texas");
            DropDownCountry.SendKeys("Singapore");
            inputState.SendKeys("Texas");
            inputCity.SendKeys("Texas");
            inputZipCode.SendKeys("12764");
            inputMobileNumb.SendKeys("89789899");

            //Ubica el botón "Create Account" y se envía el formulario
            var submitCreateAccount = Driver.FindElement(By.CssSelector("button[data-qa='create-account']"));
            submitCreateAccount.Click();

            //Verificamos que la cuenta se haya creado de forma exitosa.
            var titleAccountCreate = Driver.FindElement(By.CssSelector("#form > div > div > div > h2"));
            var ContinueButton = Driver.FindElement(By.CssSelector("div a[data-qa='continue-button']"));
            Assert.That(titleAccountCreate.Text, Is.EqualTo("ACCOUNT CREATED!"));
            ContinueButton.Click();

            //Verificamos que el usuario ya se encuentra logueado.
            var userLoggued = Driver.FindElement(By.CssSelector("#header > div > div > div > div.col-sm-8 > div > ul > li:nth-child(10) > a > b"));
            Assert.That(userLoggued.Text, Is.EqualTo(name));
            //Cerramos sesión
            var userLogOut = Driver.FindElement(By.CssSelector("#header > div > div > div > div.col-sm-8 > div > ul > li:nth-child(4) > a"));
            userLogOut.Click();
        }

        //2 - Login con usuario existente:
        [Test, Order(4)]
        public void LoginWithUserAccount()
        {
            //Ingresamos al botón de Signup/Login
            var LoginButton = Driver.FindElement(By.CssSelector("li a[href=\"/login\"]"));
            string actualStyle = LoginButton.GetCssValue("color");
            LoginButton.Click();

            //declaramos las variables a utilizar.
            var emailInput = Driver.FindElement(By.CssSelector("input[data-qa='login-email']"));
            var PasswordInput = Driver.FindElement(By.CssSelector("input[data-qa='login-password']"));
            var submitLogin = Driver.FindElement(By.CssSelector("button[data-qa='login-button']"));

            //Ingresamos el email, password y click en "Login".
            emailInput.SendKeys(emailTest);
            PasswordInput.SendKeys(password);
            submitLogin.Click();

            //Verificamos que el usuario se haya logueado de forma exitosa.
            Thread.Sleep(1000); // Esperamos para que el DOM se actualice
            var userLoggued = Driver.FindElement(By.CssSelector("#header > div > div > div > div.col-sm-8 > div > ul > li:nth-child(10) > a > b"));
            Assert.That(userLoggued.Text, Is.EqualTo(name));
        }


        //TestOpcional:REVISAMOS LOS PRODUCTOS EN EL CARRITO Y LOS ELIMINAMOS SI HAY ALGUNO, ESTO PARA HACER UNA PRUEBA LIMPIA EN EL TEST DE AddToCart.
        [Test, Order(5)]
        public void DeleteProductsCart()
        {
            //Nos logueamos reutilizando el código del test LoginWithUserAccount.
            LoginWithUserAccount();

            var ViewcartBtn = Driver.FindElement(By.CssSelector("li a[href=\"/view_cart\"]"));
            ViewcartBtn.Click();

            //REVISAMOS LOS PRODUCTOS EN EL CARRITO Y LOS ELIMINAMOS SI HAY ALGUNO, ESTO PARA HACER UNA PRUEBA LIMPIA EN EL TEST DE AddToCart.

            //Ubicamos la tabla con los productos agregados al carrito.
            var filasInicial = Driver.FindElements(By.CssSelector("#cart_info_table tbody tr"));
            int cantidadFilasInicial = filasInicial.Count;
            Console.WriteLine($"Cantidad de productos en el carrito antes de eliminarlas: {cantidadFilasInicial}");
            if (cantidadFilasInicial > 0)
            {
                // Elimina todos los productos del carrito haciendo clic en los botones de eliminar
                var botonesEliminar = Driver.FindElements(By.CssSelector("a.cart_quantity_delete"));
                foreach (var boton in botonesEliminar)
                {
                    //hacemos scroll si el botón está tapado
                    IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                    js.ExecuteScript("arguments[0].scrollIntoView(true);", boton);

                    boton.Click();
                    Thread.Sleep(1000); // Esperamos para que el DOM se actualice
                }

            }
            //estas 3 lineas es para control y verificar que si se eliminaron los productos.
            var filasDespués = Driver.FindElements(By.CssSelector("#cart_info_table tbody tr"));
            int cantidadFilasDespues = filasDespués.Count;
            Console.WriteLine($"Cantidad de productos en el carrito despues de eliminarlas: {cantidadFilasDespues}");

            var logoutBtn = Driver.FindElement(By.CssSelector("li a[href=\"/logout\"]"));
            logoutBtn.Click();
        }


        //3 - Agregar productos al carrito y verificar total 
        [Test, Order(6)]
        public void AddToCart()
        {
            //Nos aseguramos de que el carrito esté vacío antes de comenzar el test.
            DeleteProductsCart();
            //Nos logueamos reutilizando el código del test LoginWithUserAccount.
            LoginWithUserAccount();

            //Definimos estas variables para agregar solamente 2 productos al carrito.
            int productoId = 0; //Este id cambia por producto, tiene una secuencia en la página.
            int productoId_1 = 3; 
            int productoId_2 = 6;
            int contador = 0;//Este campo cuenta las veces que se agrega un producto al carrito.


            //AGREGAMOS 2 PRODUCTOS AL CARRITO:
            productoId = productoId_1;
            while (contador < 2)
            {
                //UBICAMOS EL PRODUCTO POR SU ID:
                //Ubicamos los productos a comprar y nos posicionamos sobre él.
                wait.Until(driver => driver.FindElement(By.CssSelector($".single-products img[src='/get_product_picture/{productoId}']")).Displayed);
                var hoverElement = Driver.FindElement(By.CssSelector($".single-products img[src='/get_product_picture/{productoId}']"));
                // Crea una instancia de la clase Actions
                Actions actions = new Actions(Driver);
                // Mueve el ratón al elemento del menú principal
                actions.MoveToElement(hoverElement).Perform();
                // Espera un momento para que el overlay aparezca
                Thread.Sleep(1000);


                //BUSCAMOS Y SELECCIONAMOS EL PRIMER PRODUCTO A AGREGAR AL CARRITO.
                //Ubicamos el botón dentro del overlay del producto a comprar.
                wait.Until(driver => driver.FindElement(By.CssSelector($".overlay-content a[data-product-id='{productoId}']")).Displayed);
                var button = Driver.FindElement(By.CssSelector($".overlay-content a[data-product-id='{productoId}']"));

                //Esperamos hasta que el botón sea clickeable
                wait.Until(driver => button.Displayed && button.Enabled);
                Thread.Sleep(1000);

                button.Click();


                //Esperamos a que se muestre el popup de la confirmación
                wait.Until(driver => driver.FindElement(By.Id("cartModal")).Displayed);
                var popupAdded = Driver.FindElement(By.Id("cartModal"));
                //Verificamos que el popup está visible.
                Assert.That(popupAdded.Displayed, Is.True, "El popup del carrito se mostró correctamente.");

                if (contador < 1)
                {
                    var ContinueShoppingBtn = Driver.FindElement(By.CssSelector(".modal-footer [class=\"btn btn-success close-modal btn-block\"]"));
                    ContinueShoppingBtn.Click();
                    Thread.Sleep(500);
                }
                if (contador == 1)
                {
                    //Ubicamos el botón "View Cart" dentro del popup porque ya agregamos el segundo producto.
                    var buttonViewCart = Driver.FindElement(By.CssSelector(".modal-body a[href='/view_cart']"));
                    buttonViewCart.Click();
                    var shoppingCartSection = Driver.FindElement(By.CssSelector(".breadcrumb li[class='active']"));
                    Assert.That(shoppingCartSection.Displayed, Is.True, "El elemento si existe y se ingresó a la sección de Shopping Cart");
                    //contamos la cantidad de productos en el carrito.
                    var infoTable = Driver.FindElements(By.CssSelector("#cart_info_table tbody tr"));
                    int cantidadFilas = infoTable.Count;
                    Console.WriteLine($"Cantidad de ítems en el carrito: {cantidadFilas}");
                }

                //Cambiamos el ID del producto para el siguiente ciclo
                productoId = productoId_2;
                contador++;
            }

            //Verificamos que los productos del carrito sean los correctos.
            var producto1 = Driver.FindElements(By.CssSelector($"img[src='get_product_picture/{productoId_1}']"));
            var producto2 = Driver.FindElements(By.CssSelector($"img[src='get_product_picture/{productoId_2}']"));
            
            Assert.That(producto1.Count, Is.GreaterThan(0), "El elemento no existe en la página");
            Assert.That(producto2.Count, Is.GreaterThan(0), "El elemento no existe en la página");

            // Sumar los quantity de la tabla del carrito
            var botonesCantidad = Driver.FindElements(By.CssSelector("#cart_info_table td.cart_quantity button"));
            int sumaCantidad = 0;

            foreach (var boton in botonesCantidad)
            {
                int cantidad = int.Parse(boton.Text.Trim());
                sumaCantidad += cantidad;
            }

            Console.WriteLine($"Cantidad total en el carrito: {sumaCantidad}");
            Assert.That(sumaCantidad, Is.EqualTo(2), "La suma de cantidades no es la esperada");


        }

        //4 - Contact Us form:
        [Test, Order(7)]
        public void contactUsForm()
        {

            //Nos logueamos reutilizando el código del test LoginWithUserAccount.
            LoginWithUserAccount();


            //Ubicamos el botón "Contact Us" y damos click.

            var contactUsFormBtn = Driver.FindElement(By.CssSelector("li a[href=\"/contact_us\"]"));
            contactUsFormBtn.Click();


            // Validamos que el título "CONTACT US" está presente y visible en la página de contacto
            var tituloContactUs = Driver.FindElements(By.CssSelector("h2.title.text-center"));
            Assert.That(tituloContactUs.Count, Is.GreaterThan(0), "El título CONTACT US no está presente en la página");
            Assert.That(tituloContactUs[0].Text.Trim().ToUpper(), Is.EqualTo("CONTACT US"), "El texto del título no es correcto");


            //2. Completar nombre, email, asunto y mensaje. 

            var inputName = Driver.FindElement(By.CssSelector("input[data-qa='name']"));
            var inputEmail = Driver.FindElement(By.CssSelector("input[data-qa='email']"));
            var inputSubject = Driver.FindElement(By.CssSelector("input[data-qa='subject']"));
            var inputMessage = Driver.FindElement(By.CssSelector("textarea[data-qa='message']"));
            inputName.SendKeys("Angelica Alvarez");
            inputEmail.SendKeys("angelica@gmail.com");
            inputSubject.SendKeys("Consulta de productos");
            inputMessage.SendKeys("Hola, quisiera recibir más información sobre sus productos. Gracias.");
            //3.Adjuntar un archivo. 
            var uploadFileInput = Driver.FindElement(By.CssSelector("input[name='upload_file']"));
            string rutaArchivo = @"C:\Users\angea\source\repos\SOFT-740-Fundamentos\Practica3.pdf";


            uploadFileInput.SendKeys(rutaArchivo);
            //4.Click en Submit. 
            var submitButton = Driver.FindElement(By.CssSelector("input[data-qa='submit-button']"));
            submitButton.Click();

            Thread.Sleep(1000);
            //5.Validar el mensaje de éxito: Success! Your details have been submitted successfully.
            // Espera a que aparezca la alerta
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            // Cambiamos el foco a la alerta
            var alerta = Driver.SwitchTo().Alert();
            // Verificamos el texto de la alerta
            Assert.That(alerta.Text, Is.EqualTo("Press OK to proceed!"), "El texto de la alerta no es el esperado");
            // Aceptamos la alerta (da click en 'Aceptar')
            alerta.Accept();

            // Verificamos que se muestre el mensaje de éxito después de enviar el formulario
            wait.Until(driver => driver.FindElement(By.CssSelector("div.status.alert.alert-success")).Displayed);

            var mensajeExito = Driver.FindElement(By.CssSelector("div.status.alert.alert-success"));
            Assert.That(mensajeExito.Displayed, Is.True, "El mensaje de éxito no está visible");
            Assert.That(mensajeExito.Text.Trim(), Is.EqualTo("Success! Your details have been submitted successfully."), "El texto del mensaje de éxito no es correcto");
            
        }

        //5 - Suscripción al newsletter 
        [Test, Order(8)]
        public void newsLetterTest()
         {
             //Se definen los webElements
             var subscribeElementInput = Driver.FindElement(By.Id("susbscribe_email"));
             var subscribeButton = Driver.FindElement(By.Id("subscribe"));
             var subscribeMessage = Driver.FindElement(By.CssSelector("div[class=\"alert-success alert\"]"));

             //se escribe el correo
             subscribeElementInput.SendKeys(email);

             //se da click en el botón de suscribir
             subscribeButton.Click();

             //Se valida el mensaje de suscripción
             Assert.That(subscribeMessage.Text, Is.EqualTo("You have been successfully subscribed!"));

         }



    }
}
