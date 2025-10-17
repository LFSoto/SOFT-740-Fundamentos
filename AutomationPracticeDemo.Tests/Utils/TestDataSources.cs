using AutomationPracticeDemo.Tests.Utils;

namespace AutomationPracticeDemo.Tests.Tests
{
    /// <summary>
    /// Proporciona fuentes de datos para los casos de prueba, 
    /// cargadas dinámicamente desde <c>TestData.json</c>.
    /// </summary>
    public static class TestDataSources
    {

        /// <summary>
        /// Casos para validar el inicio de sesión de usuarios existentes.
        /// </summary>
        public static IEnumerable<TestCaseData> ExistingUserLoginCases()
        {
            // Carga los datos desde el archivo TestData.json
            var data = TestDataLoader.LoadTestData();

            // Contador incremental que identifica el número de caso
            int index = 1;

            // Itera sobre cada conjunto de datos definido dentro de "ExistingUserLogin.Cases"
            foreach (var caseData in data.ExistingUserLogin.Cases)
            {
                // Crea un nuevo objeto TestCaseData con los parámetros necesarios para el test
                yield return new TestCaseData(
                    (string)caseData.Email,
                    (string)caseData.Password,
                    (string)caseData.Usuario
                ).SetName($"Existing_User_Login_TestCase_{index}"); // Define un nombre descriptivo único para cada test en el explorador
                index++;
            }
        }

        /// <summary>
        /// Casos para validar el envío del formulario de contacto.
        /// </summary>
        public static IEnumerable<TestCaseData> ContactFormCases()
        {
            // Carga los datos desde el archivo TestData.json
            var data = TestDataLoader.LoadTestData();
            int index = 1;

            // Recorre todos los casos definidos dentro de "ContactForm.Cases"
            foreach (var caseData in data.ContactForm.Cases)
            {
                // Crea un objeto TestCaseData con los valores necesarios para completar el formulario
                yield return new TestCaseData(
                    (string)caseData.Name,
                    (string)caseData.Email,
                    (string)caseData.Subject,
                    (string)caseData.Message,
                    (string)caseData.File
                ).SetName($"Fill_Out_The_Contact_Form_TestCase_{index}");
                index++;
            }
        }

        /// <summary>
        /// Casos para validar el flujo completo de compra.
        /// </summary>
        public static IEnumerable<TestCaseData> PurchaseOrderCases()
        {
            // Carga los datos desde el archivo TestData.json
            var data = TestDataLoader.LoadTestData();
            int index = 1;

            // Itera por cada conjunto de datos definido en "PurchaseOrder.Cases"
            foreach (var caseData in data.PurchaseOrder.Cases)
            {
                // Construye los parámetros requeridos por el flujo de compra
                yield return new TestCaseData(
                    (string)caseData.Email,
                    (string)caseData.Password,
                    (string)caseData.Products,
                    (string)caseData.Name,
                    (string)caseData.Card,
                    (string)caseData.Cvc,
                    (string)caseData.Date
                ).SetName($"Process_Purchase_Order_TestCase_{index}");
                index++;
            }
        }

        /// <summary>
        /// Casos para validar la suscripción al boletín.
        /// </summary>
        public static IEnumerable<TestCaseData> SubscriptionCases()
        {
            // Carga los datos desde el archivo TestData.json
            var data = TestDataLoader.LoadTestData();
            int index = 1;

            // Itera sobre todos los correos definidos en "Subscription.Cases"
            foreach (var caseData in data.Subscription.Cases)
            {
                // Construye los parámetros requeridos por el flujo de subcripción
                yield return new TestCaseData(
                    (string)caseData.Email
                ).SetName($"Subscription_Newsletter_TestCase_{index}");
                index++;
            }
        }

        /// <summary>
        /// Casos para validar la adición de productos al carrito.
        /// </summary>
        public static IEnumerable<TestCaseData> AddToCartCases()
        {
            // Carga los datos desde el archivo TestData.json
            var data = TestDataLoader.LoadTestData();
            int index = 1;

            // Recorre todos los casos definidos en "AddToCart.Cases"
            foreach (var caseData in data.AddToCart.Cases)
            {
                yield return new TestCaseData(
                    (string)caseData.Products
                ).SetName($"Add_Products_To_Cart_TestCase_{index}");
                index++;
            }
        }
    }
}

