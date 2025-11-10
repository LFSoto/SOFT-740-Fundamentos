using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using Proyecto_SwagLabs.Tests.Pages;
using Proyecto_SwagLabs.Tests.Utils;
using Reqnroll;

namespace Proyecto_SwagLabs.Tests.StepDefinitions.Purchase
{
    [Binding]
    public class PurchaseSteps
    {
        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenario;
        private readonly LoginPage _loginPage;
        private readonly ProductsPage _productsPage;
        private readonly PurchasePage _purchasePage;
        private JObject? _purchaseData;

        public PurchaseSteps(ScenarioContext scenarioContext)
        {
            _scenario = scenarioContext;
            _driver = _scenario.Get<IWebDriver>("WebDriver");
            _loginPage = new LoginPage(_driver);
            _productsPage = new ProductsPage(_driver);
            _purchasePage = new PurchasePage(_driver);
        }

        [Given(@"que inicio sesion con las credenciales validas del caso ""(.*)""")]
        public void GivenQueInicioSesionConLasCredencialesValidasDelCaso(string caseId)
        {
            _purchaseData ??= TestDataLoader.Load("purchase/purchase.json");
            var cases = (JArray)_purchaseData["Users"]!;
            var user = cases.OfType<JObject>().FirstOrDefault(c => (string)c["Id"]! == caseId)
                       ?? throw new InvalidOperationException($"No se encontró el usuario '{caseId}' en purchase.json");

            var username = (string)user["UserName"]!;
            var password = (string)user["Password"]!;

            _loginPage.Login(username, password);
        }

        [Given(@"que agrego los productos al carrito")]
        public void GivenQueAgregoLosProductosAlCarrito(Table table)
        {
            var productos = table.Rows.Select(r => r["Producto"]).ToArray();
            _productsPage.AddProductsToCartByName(productos);
        }

        [When(@"procedo al checkout y completo los datos del cliente")]
        public void WhenProcedoAlCheckoutYCompletoLosDatosDelCliente(Table table)
        {
            var fila = table.Rows.First();
            var nombre = fila["Nombre"];
            var apellido = fila["Apellido"];
            var codigoPostal = fila["CodigoPostal"];

            _productsPage.GoToCart();
            _purchasePage.CompleteCheckout(nombre, apellido, codigoPostal);
        }

        [Then(@"la compra debe completarse exitosamente")]
        public void ThenLaCompraDebeCompletarseExitosamente()
        {
            Assert.That(_purchasePage.IsOrderConfirmationVisible(),
                "No se mostró la confirmación de compra después del checkout.");
        }
    }
}
