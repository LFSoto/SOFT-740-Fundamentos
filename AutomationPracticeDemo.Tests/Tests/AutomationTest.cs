using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Utils;

namespace AutomationPracticeDemo.Tests.Tests
{
    [TestFixture]
    public class AutomationTest : TestBase
    {
        // Instancia compartida de la p�gina principal utilizada en todos los casos de prueba.
        private AutomationPage automationPage;

        /// <summary>
        /// M�todo de configuraci�n que se ejecuta antes de cada caso de prueba.
        /// Inicializa la instancia de AutomationPage con el WebDriver actual,
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            automationPage = new AutomationPage(Driver);
        }

        /// <summary>
        /// Caso de prueba que valida el registro exitoso de un nuevo usuario aleatorio - Ejercicio #1.
        /// </summary>
        [Test]
        public void Register_New_Random_User()
        {

            // Genera y registra un usuario con datos aleatorios
            automationPage.CreateRandomUser();

            // Obtiene el mensaje de �xito tras la creaci�n del usuario
            var message = automationPage.GetSuccessfulMessage();

            // Verifica que el mensaje mostrado coincida con el esperado
            Assert.That(message, Is.EqualTo("ACCOUNT CREATED!"));

            // Captura de pantalla para evidencia del resultado de la prueba
            ScreenshotHelper.TakeScreenshot(Driver, "Test_Register_New_User");

            // Contin�a al siguiente paso y cierra sesi�n
            automationPage.ClickContinueButton();
            automationPage.ClickLogoutLink();

            // Marca la prueba como exitosa
            Assert.Pass("Register New User - Test Success.");

        }

        /// <summary>
        /// Caso de prueba que valida el inicio de sesi�n exitoso de un usuario existente en la aplicaci�n - Ejercicio #2.
        /// </summary>
        /// <param name="email">Correo electr�nico del usuario registrado.</param>
        /// <param name="password">Contrase�a correspondiente al usuario.</param>
        /// <param name="usuario">Nombre del usuario que debe mostrarse al iniciar sesi�n.</param>
        [TestCase("jmata@testQA.com", "123456Aa", "Johan")]
        public void Existing_User_Login(string email, string password, string usuario)
        {
            // Ejecuta el flujo de inicio de sesi�n con las credenciales proporcionadas
            automationPage.LoginUser(email, password);

            // Obtiene el mensaje que muestra el nombre del usuario autenticado
            var message = automationPage.GetLoginUserNameMessage();

            // Valida que el mensaje coincida con el formato esperado
            Assert.That(message, Is.EqualTo("Logged in as " + usuario));

            // Captura de pantalla como evidencia del resultado de la prueba
            ScreenshotHelper.TakeScreenshot(Driver, "Test_Existing_User_Login");

            // Marca la prueba como exitosa
            Assert.Pass("Existing User Login - Test Success.");
        }

        /// <summary>
        /// Caso de prueba que valida que se a�ade los productos al carrito - Ejercicio #3
        /// Y verifica el c�lculo correcto de los totales en el carrito de compras,
        /// incluso cuando se agregan productos repetidos.
        /// </summary>
        /// <param name="products">Lista de IDs de productos separados por coma (por ejemplo, "1,2,3").</param>
        [TestCase("1,2,3,1,11")]
        public void Add_Products_To_Cart_Validate_Totals(string products)
        {
            // Convierte la cadena de productos en una lista de IDs (ejemplo: "1,2,3" -> ["1","2","3"])
            var productIds = products.Split(',').ToList();

            // Agrega los productos al carrito, incluyendo los repetidos
            automationPage.AddProductsToCart(productIds);

            // Obtiene los datos del carrito: precio, cantidad y total por producto
            var cartItems = automationPage.GetCartItems();

            // Agrupa y cuenta la cantidad de veces que se agreg� cada ID de producto
            var productCounts = products
                .GroupBy(x => x)
                .ToDictionary(g => g.Key, g => g.Count());

            // Valida que el total mostrado en la tabla coincida con (precio � cantidad)
            foreach (var item in cartItems)
            {
                decimal expectedTotal = item.Price * item.Quantity;
                Assert.That(item.Total, Is.EqualTo(expectedTotal),
                    $"Error en el c�lculo: Precio={item.Price}, Cantidad={item.Quantity}, Total={item.Total}, Esperado={expectedTotal}");
            }

            // Captura de pantalla como evidencia del resultado de la prueba
            ScreenshotHelper.TakeScreenshot(Driver, "Test_Add_Products__Validate_Totals");

            // Marca la prueba como exitosa
            Assert.Pass("Add Products To Cart Validate Totals - Test Success.");
        }

        /// <summary>
        /// Caso de prueba que valida el env�o exitoso del formulario de contacto - Ejercicio #4
        /// </summary>
        /// <param name="name">Nombre del usuario que completa el formulario.</param>
        /// <param name="email">Correo electr�nico de contacto.</param>
        /// <param name="subject">Asunto del mensaje enviado.</param>
        /// <param name="message">Cuerpo o contenido del mensaje.</param>
        /// <param name="file">Nombre del archivo (ubicado en la carpeta Resources) que se adjunta al formulario.</param>
        [TestCase("Johan", "jmata@testQA.com", "Subject Test", "Message Test", "Test_Image.jpg")]
        public void Fill_Out_The_Contact_Form(string name, string email, string subject, string message, string file)
        {
            // Completa todos los campos del formulario y adjunta el archivo indicado
            automationPage.FillOutTheContactForm(name, email, subject, message, file);

            // Obtiene el mensaje de confirmaci�n mostrado tras el env�o exitoso
            var messageText = automationPage.GetSuccessMessageContactForm();

            // Valida que el mensaje mostrado coincida con el esperado
            Assert.That(messageText, Is.EqualTo("Success! Your details have been submitted successfully."));

            // Captura de pantalla como evidencia del resultado de la prueba
            ScreenshotHelper.TakeScreenshot(Driver, "Test_The_Contact_Form");

            // Marca la prueba como exitosa
            Assert.Pass("Fill Out The Contact Form - Test Success.");
        }

        /// <summary>
        /// Caso de prueba que valida la suscripci�n exitosa al bolet�n mediante un correo electr�nico v�lido - Ejercicio #5.
        /// </summary>
        /// <param name="email">Direcci�n de correo electr�nico que ser� utilizada para la suscripci�n.</param>
        [TestCase("jmata@testQA.com")]
        public void Subscription_Newsletter(string email)
        {
            // Ingresa el correo y env�a la solicitud de suscripci�n
            automationPage.SubscriptionNewsletter(email);

            // Obtiene el mensaje de confirmaci�n mostrado tras la suscripci�n
            var message = automationPage.GetSuccessAlertMessage();

            // Valida que el mensaje coincida con el texto esperado
            Assert.That(message, Is.EqualTo("You have been successfully subscribed!"));

            // Captura de pantalla como evidencia de la ejecuci�n de la prueba
            ScreenshotHelper.TakeScreenshot(Driver, "Test_Subscription_Newsletter");

            // Marca la prueba como exitosa
            Assert.Pass("Subscription Newsletter - Test Success.");
        }

        /// <summary>
        /// Caso de prueba que valida el proceso completo de una orden de compra:
        /// inicio de sesi�n, selecci�n de productos, pago con tarjeta y confirmaci�n final.
        /// </summary>
        /// <param name="email">Correo electr�nico del usuario registrado.</param>
        /// <param name="password">Contrase�a del usuario.</param>
        /// <param name="products">Lista de identificadores de productos separados por coma.</param>
        /// <param name="name">Nombre impreso en la tarjeta.</param>
        /// <param name="card">N�mero de tarjeta de cr�dito o d�bito.</param>
        /// <param name="cvc">C�digo de seguridad de la tarjeta.</param>
        /// <param name="date">Fecha de expiraci�n de la tarjeta (formato MM/YYYY).</param>
        [TestCase("jmata@testQA.com", "123456Aa", "1,2,1", "Johan Test QA", "1234567890123456", "123", "12/2030")]
        public void Process_Purchase_Order(string email, string password, string products, 
            string name, string card, string cvc, string date)
        {
            // Convierte la cadena de productos a una lista (por ejemplo, "1,2,1" -> ["1", "2", "1"])
            var productIds = products.Split(',').ToList();

            // Ejecuta el flujo completo de la orden: login -> limpiar carrito -> agregar productos -> pagar
            automationPage.ProcessPurchaseOrder(email, password, productIds, name, card, cvc, date);

            // Obtiene el mensaje de �xito de la orden procesada correctamente
            var message = automationPage.GetMessageOrderConfirmed();

            // Valida que el mensaje coincida con el texto esperado
            Assert.That(message, Is.EqualTo("Congratulations! Your order has been confirmed!"));

            // Captura de pantalla como evidencia de la ejecuci�n de la prueba
            ScreenshotHelper.TakeScreenshot(Driver, "Test_Process_Purchase_Order");

            // Hace clic en el bot�n �Continue� para finalizar el flujo post-compra
            automationPage.ClickContinueEndOfOrderButton();

            // Marca la prueba como exitosa
            Assert.Pass("Process Purchase Order - Test Success.");
        }
    }
}
