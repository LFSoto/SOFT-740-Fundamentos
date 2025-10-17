using AutomationPracticeDemo.Tests.Utils;

namespace AutomationPracticeDemo.Tests.Tests
{
    [TestFixture]
    public class AutomationExerciseTest : TestBase
    {
        /// <summary>
        /// Caso de prueba que valida el registro exitoso de un nuevo usuario aleatorio - Ejercicio #1.
        /// </summary>
        [Test, Order(1)]
        public void Register_New_Random_User()
        {
            // Carga los datos del archivo JSON
            var data = TestDataLoader.LoadTestData();

            // Genera y registra un usuario con datos aleatorios
            loginPage.CreateRandomUser();

            // Obtiene el mensaje de éxito tras la creación del usuario
            var message = loginPage.GetSuccessfulMessage();

            // Compara el mensaje mostrado con el texto esperado del archivo JSON
            Assert.That(message, Is.EqualTo((string)data.Messages.AccountCreated));

            // Captura de pantalla para evidencia del resultado de la prueba
            ScreenshotHelper.TakeScreenshot(Driver, "Test_Register_New_User");

            // Continúa al siguiente paso y cierra sesión
            loginPage.ClickContinueButton();
            loginPage.ClickLogoutLink();

            // Marca la prueba como exitosa
            Assert.Pass("Register New User - Test Success.");

        }

        /// <summary>
        /// Valida el inicio de sesión exitoso de un usuario existente usando datos del archivo JSON - Ejercicio #2.
        /// </summary>
        /// <remarks>
        /// Carga las credenciales desde <c>TestData.json</c>, ejecuta el flujo de login 
        /// y verifica que el nombre mostrado coincida con el esperado.
        /// </remarks>
        [TestCaseSource(typeof(TestDataSources), nameof(TestDataSources.ExistingUserLoginCases))]
        [Order(2)]
        public void Existing_User_Login(string email, string password, string usuario)
        {
            // Inicia sesión con las credenciales del caso actual
            loginPage.LoginUser(email, password);

            // Obtiene el mensaje que muestra el nombre del usuario autenticado
            var message = loginPage.GetLoginUserNameMessage();

            // Valida que el mensaje coincida con el formato esperado
            Assert.That(message, Is.EqualTo("Logged in as " + usuario));

            // Captura de pantalla como evidencia del resultado de la prueba
            ScreenshotHelper.TakeScreenshot(Driver, "Test_Existing_User_Login");

            // Marca la prueba como exitosa
            Assert.Pass("Existing User Login - Test Success.");
        }

        /// <summary>
        /// Valida que los productos se agreguen correctamente al carrito y 
        /// que el total mostrado sea igual a (precio × cantidad) — Ejercicio #3.
        /// </summary>
        /// <remarks>
        /// Lee los casos desde <c>TestData.json</c> (sección <c>AddToCart.Cases</c>),
        /// limpia el carrito antes de cada iteración y verifica los cálculos de totales,
        /// incluso cuando hay productos repetidos.
        /// </remarks>
        [Test, Order(3)]
        [TestCaseSource(typeof(TestDataSources), nameof(TestDataSources.AddToCartCases))]
        public void Add_Products_To_Cart(string products)
        {
            // Convierte la lista de productos del JSON en una lista de IDs
            var productIds = products.Split(',').Select(p => p.Trim()).ToList();

            // Limpia el carrito y agrega los productos definidos en el caso
            productPage.DeleteCartItems();
            productPage.AddProductsToCart(productIds);

            // Obtiene los elementos del carrito para validación
            var cartItems = productPage.GetCartItems();

            // Valida el cálculo total de cada producto
            foreach (var item in cartItems)
            {
                decimal expectedTotal = item.Price * item.Quantity;
                Assert.That(item.Total, Is.EqualTo(expectedTotal),
                    $"Error en cálculo: Precio={item.Price}, Cantidad={item.Quantity}, Total={item.Total}, Esperado={expectedTotal}");
            }

            // Captura de pantalla como evidencia del resultado de la prueba
            ScreenshotHelper.TakeScreenshot(Driver, $"Test_AddToCart_{products.Replace(',', '_')}");

            // Marca la prueba como exitosa
            Assert.Pass("Add Products To Cart - Test Success.");
        }


        /// <summary>
        /// Valida el envío exitoso del formulario de contacto — Ejercicio #4.
        /// </summary>
        /// <remarks>
        /// Carga los datos del formulario desde <c>TestData.json</c> (sección <c>ContactForm</c>),
        /// completa los campos, adjunta el archivo indicado y verifica el mensaje de éxito.
        /// </remarks>
        [TestCaseSource(typeof(TestDataSources), nameof(TestDataSources.ContactFormCases))]
        [Order(4)]
        public void Fill_Out_The_Contact_Form(string name, string email, string subject, string message, string file)
        {
            // Completa el formulario con los datos del caso actual
            contactPage.FillOutTheContactForm(name, email, subject, message, file);

            // Obtiene el mensaje de confirmación mostrado tras el envío
            var messageText = contactPage.GetSuccessMessageContactForm();
            var data = TestDataLoader.LoadTestData();

            // Valida que el mensaje coincida con el esperado del archivo JSON
            Assert.That(messageText, Is.EqualTo((string)data.Messages.ContactFormSuccess));

            // Captura de pantalla como evidencia del resultado de la prueba
            ScreenshotHelper.TakeScreenshot(Driver, $"Test_Contact_Form_{email}");

            // Marca la prueba como exitosa
            Assert.Pass("Fill Out The Contact Form - Test Success.");
        }

        /// <summary>
        /// Valida la suscripción exitosa al boletín mediante diferentes correos válidos — Ejercicio #5.
        /// </summary>
        /// <remarks>
        /// Carga los casos desde <c>TestData.json</c> (sección <c>Subscription.Cases</c>),
        /// limpia el campo de entrada antes de cada envío y verifica el mensaje de éxito mostrado.
        /// </remarks>
        [Order(5)]
        [TestCaseSource(typeof(TestDataSources), nameof(TestDataSources.SubscriptionCases))]
        public void Subscription_Newsletter(string email)
        {
            // Limpia el campo del correo antes de ingresar un nuevo valor
            footerPage.CleanSusbscribeEmailInput();

            // Ingresa el correo y envía la suscripción
            footerPage.SubscriptionNewsletter(email);

            // Obtiene el mensaje de confirmación mostrado tras la suscripción
            var message = footerPage.GetSuccessAlertMessage();

            // Carga el texto esperado desde el archivo JSON
            var data = TestDataLoader.LoadTestData();

            // Valida que el mensaje coincida con el esperado del archivo JSON
            Assert.That(message, Is.EqualTo((string)data.Messages.SubscriptionSuccess));

            // Captura una evidencia visual con el correo en el nombre del archivo
            ScreenshotHelper.TakeScreenshot(Driver, $"Test_Subscription_Newsletter_{email}");

            // Marca la prueba como exitosa
            Assert.Pass("Subscription Newsletter - Test Success.");
        }

        /// <summary>
        /// Valida el proceso completo de una orden de compra — Ejercicio #6.
        /// </summary>
        /// <remarks>
        /// Carga los datos desde <c>TestData.json</c> (sección <c>PurchaseOrder</c>),
        /// inicia sesión con un usuario válido, limpia el carrito, agrega productos,
        /// realiza el pago con tarjeta y verifica el mensaje de confirmación final.
        /// </remarks>
        [Order(6)]
        [TestCaseSource(typeof(TestDataSources), nameof(TestDataSources.PurchaseOrderCases))]
        public void Process_Purchase_Order(string email, string password, string products, string name, string card, string cvc, string date)
        {
            // Convierte la cadena de productos a una lista
            var productIds = products.Split(',').Select(p => p.Trim()).ToList();

            // Ejecuta el flujo completo de la orden: login -> limpiar carrito -> agregar productos -> pagar
            purchasePage.ProcessPurchaseOrder(email, password, productIds, name, card, cvc, date);

            // Obtiene el mensaje de confirmación mostrado tras finalizar la compra
            var data = TestDataLoader.LoadTestData();
            var message = purchasePage.GetMessageOrderConfirmed();

            // Valida que el mensaje coincida con el esperado definido en el archivo JSON
            Assert.That(message, Is.EqualTo((string)data.Messages.OrderConfirmed));

            // Captura de pantalla como evidencia de la ejecución de la prueba
            ScreenshotHelper.TakeScreenshot(Driver, $"Test_Process_Purchase_Order_{email}");

            // Finaliza el flujo haciendo clic en el botón “Continue”
            purchasePage.ClickContinueEndOfOrderButton();

            // Marca la prueba como exitosa
            Assert.Pass("Process Purchase Order - Test Success.");
        }
    }
}
