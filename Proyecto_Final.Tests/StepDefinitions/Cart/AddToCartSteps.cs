using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using Proyecto_SwagLabs.Tests.Pages;
using Proyecto_SwagLabs.Tests.Utils;
using Reqnroll;

namespace Proyecto_SwagLabs.Tests.StepDefinitions.Cart
{
    /// <summary>
    /// Step definitions para los escenarios de añadir productos al carrito.
    /// </summary>
    [Binding]
    public class AddToCartSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly ProductsPage _productsPage;
        private readonly CartPage _cartPage;

        private JObject? _cartData;
        private JObject? _currentCase;

        public AddToCartSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>("WebDriver");

            _productsPage = new ProductsPage(_driver);
            _cartPage = new CartPage(_driver);
        }

        /// <summary>
        /// Carga los datos de productos del caso indicado desde addToCart.json.
        /// </summary>
        [Given(@"que tengo los datos de productos del caso ""(.*)""")]
        public void GivenQueTengoLosDatosDeProductosDelCaso(string caseId)
        {
            _cartData ??= TestDataLoader.Load("Cart/addToCart.json");

            var cases = (JArray)_cartData["Cases"]!;
            _currentCase = cases
                .OfType<JObject>()
                .FirstOrDefault(c => (string)c["Id"]! == caseId)
                ?? throw new InvalidOperationException(
                    $"No se encontró el caso '{caseId}' en addToCart.json");
        }

        /// <summary>
        /// Añade al carrito los productos definidos en el caso actual.
        /// </summary>
        [When(@"agrego esos productos al carrito")]
        public void WhenAgregoEsosProductosAlCarrito()
        {
            if (_currentCase is null)
                throw new InvalidOperationException("No se han cargado datos de caso para los productos.");

            var products = ((JArray)_currentCase["Products"]!)
                .Select(p => (string)p!)
                .ToArray();

            _productsPage.AddProductsToCartByName(products);
        }

        /// <summary>
        /// Verifica que todos los productos definidos en el caso actual estén presentes en el carrito.
        /// </summary>
        [Then(@"los productos deben estar en el carrito")]
        public void ThenLosProductosDebenEstarEnElCarrito()
        {
            if (_currentCase is null)
                throw new InvalidOperationException("No se han cargado datos de caso para los productos.");

            // Abrir carrito
            _productsPage.GoToCart();

            var expectedProducts = ((JArray)_currentCase["Products"]!)
                .Select(p => (string)p!)
                .ToList();

            var cartProductNames = _cartPage.GetProductNames();

            // Valida que todos los productos esperados estén en el carrito
            CollectionAssert.IsSubsetOf(
                expectedProducts,
                cartProductNames,
                "No todos los productos esperados se encontraron en el carrito."
            );
        }
    }
}
