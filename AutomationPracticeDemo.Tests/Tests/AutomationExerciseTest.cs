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
        [Test, Order(2)]
        public void Existing_User_Login()
        {
            // Carga los datos desde el archivo JSON usando el helper de configuración
            var data = TestDataLoader.LoadTestData();
            var login = data.ExistingUserLogin;

            // Ejecuta el flujo de inicio de sesión con las credenciales proporcionadas
            loginPage.LoginUser((string)login.Email, (string)login.Password);

            // Obtiene el mensaje que muestra el nombre del usuario autenticado
            var message = loginPage.GetLoginUserNameMessage();

            // Valida que el mensaje coincida con el formato esperado
            Assert.That(message, Is.EqualTo("Logged in as " + (string)login.Usuario));

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
        public void Add_Products_To_Cart_Validate_Totals()
        {
            // Carga el archivo JSON completo
            var data = TestDataLoader.LoadTestData();

            // Recorre todos los casos definidos en "AddToCart.Cases"
            foreach (var caseData in data.AddToCart.Cases)
            {
                // Obtiene la lista de productos del caso actual
                string products = (string)caseData.Products;

                // Convierte la cadena de productos en una lista y elimina espacios extra
                var productIds = products.Split(',').Select(p => p.Trim()).ToList();

                // Limpia el carrito antes de agregar nuevos productos
                productPage.DeleteCartItems();

                // Agrega productos al carrito
                productPage.AddProductsToCart(productIds);

                // Obtiene los productos agregados al carrito
                var cartItems = productPage.GetCartItems();

                // Valida que el total mostrado sea igual a (precio × cantidad)
                foreach (var item in cartItems)
                {
                    // Calcula el total esperado (precio × cantidad)
                    decimal expectedTotal = item.Price * item.Quantity;

                    // Compara el total esperado con el mostrado en la tabla
                    Assert.That(item.Total, Is.EqualTo(expectedTotal),
                        $"Error en cálculo: Precio={item.Price}, Cantidad={item.Quantity}, Total={item.Total}, Esperado={expectedTotal}");
                }

                // Guarda captura con nombre único según el caso
                ScreenshotHelper.TakeScreenshot(Driver, $"Test_Add_Products_Validate_Totals_{products.Replace(',', '_')}");

                // Muestra en consola el resultado del caso ejecutado
                Console.WriteLine($"Caso con productos [{products}] completado correctamente.");
            }

            // Marca el test completo como exitoso si todos los casos pasaron
            Assert.Pass("Todos los casos de Add Products To Cart se ejecutaron con éxito.");
        }


        /// <summary>
        /// Valida el envío exitoso del formulario de contacto — Ejercicio #4.
        /// </summary>
        /// <remarks>
        /// Carga los datos del formulario desde <c>TestData.json</c> (sección <c>ContactForm</c>),
        /// completa los campos, adjunta el archivo indicado y verifica el mensaje de éxito.
        /// </remarks>
        [Test, Order(4)]
        public void Fill_Out_The_Contact_Form()
        {
            // Carga todos los datos definidos en el archivo JSON
            var data = TestDataLoader.LoadTestData();

            // Obtiene la sección específica del formulario de contacto
            var contact = data.ContactForm;

            // Completa el formulario con los valores del JSON (nombre, correo, asunto, mensaje y archivo)
            contactPage.FillOutTheContactForm(
                (string)contact.Name,
                (string)contact.Email,
                (string)contact.Subject,
                (string)contact.Message,
                (string)contact.File
            );

            // Recupera el mensaje de confirmación mostrado tras enviar el formulario
            var messageText = contactPage.GetSuccessMessageContactForm();

            // Compara el mensaje mostrado con el texto esperado del archivo JSON
            Assert.That(messageText, Is.EqualTo((string)data.Messages.ContactFormSuccess));

            // Captura de pantalla como evidencia del resultado de la prueba
            ScreenshotHelper.TakeScreenshot(Driver, "Test_The_Contact_Form");

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
        [Test, Order(5)]
        public void Subscription_Newsletter()
        {
            // Carga los datos del archivo JSON
            var data = TestDataLoader.LoadTestData();

            // Itera sobre cada caso de suscripción definido en el JSON
            foreach (var caseData in data.Subscription.Cases)
            {
                // Limpia el campo del correo antes de ingresar un nuevo valor
                footerPage.CleanSusbscribeEmailInput();

                // Obtiene el correo electrónico actual del caso
                string email = (string)caseData.Email;

                // Ingresa el correo y envía la suscripción
                footerPage.SubscriptionNewsletter(email);

                // Obtiene el mensaje de confirmación mostrado tras la suscripción
                var message = footerPage.GetSuccessAlertMessage();

                // Valida que el mensaje coincida con el texto esperado del archivo JSON
                Assert.That(message, Is.EqualTo((string)data.Messages.SubscriptionSuccess));

                // Captura una evidencia visual con el correo en el nombre del archivo
                ScreenshotHelper.TakeScreenshot(Driver, $"Test_Subscription_Newsletter_{email}");
            }

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
        [Test, Order(6)]
        public void Process_Purchase_Order()
        {
            // Carga todos los datos de prueba desde el archivo JSON
            var data = TestDataLoader.LoadTestData();

            // Obtiene la sección específica con los datos de la orden de compra
            var order = data.PurchaseOrder;

            // Convierte la cadena de productos a una lista (por ejemplo, "1,2,1" -> ["1", "2", "1"])
            var productIds = ((string)order.Products).Split(',').Select(p => p.Trim()).ToList();

            // Ejecuta el flujo completo de la orden: login -> limpiar carrito -> agregar productos -> pagar
            purchasePage.ProcessPurchaseOrder(
                (string)order.Email,
                (string)order.Password,
                productIds,
                (string)order.Name,
                (string)order.Card,
                (string)order.Cvc,
                (string)order.Date
            );

            // Obtiene el mensaje de confirmación mostrado tras finalizar la compra
            var message = purchasePage.GetMessageOrderConfirmed();

            // Valida que el mensaje coincida con el esperado definido en el archivo JSON
            Assert.That(message, Is.EqualTo((string)data.Messages.OrderConfirmed));

            // Captura de pantalla como evidencia de la ejecución de la prueba
            ScreenshotHelper.TakeScreenshot(Driver, "Test_Process_Purchase_Order");

            // Finaliza el flujo haciendo clic en el botón “Continue”
            purchasePage.ClickContinueEndOfOrderButton();

            // Marca la prueba como exitosa
            Assert.Pass("Process Purchase Order - Test Success.");
        }
    }
}
