using AutomationPracticeDemo.Tests.Pages.NavBar;
using AutomationPracticeDemo.Tests.Pages.Products;
using AutomationPracticeDemo.Tests.Pages.ShoppingCart;
using AutomationPracticeDemo.Tests.Utils;

namespace AutomationPracticeDemo.Tests.Tests
{
    public class CartTest : TestBase
    {
        [Test]
        public void AddProductsToCartTest()
        {
            var navBarPage = new NavBarPage(Driver);
            //Hacer click en Products
            navBarPage.ClickProducts();
            // Se navega a la página de productos
            var productsPage = new ProductsPage(Driver);
            // Agregar productos al carrito
            productsPage.AddProductsToCart();
            // Calcular el precio total de los productos agregados
            var totalPriceExpected = productsPage.CalculateTotalPrice();
            // Hacer click en el carrito
            navBarPage.ClickCart();
            // Calcular el precio total del carrito
            var ShoppingCartPage = new ShoppingCartPage(Driver);
            var totalPriceActual = ShoppingCartPage.CalculateTotalPriceInCart();
            // Validar que el precio total calculado sea igual al precio total del carrito
            Assert.That(totalPriceExpected, Is.EqualTo(totalPriceActual), "El precio total esperado: " + totalPriceExpected + " no es igual al precio total actual en el carrito: " + totalPriceActual);
            // Tomar captura de pantalla
            ScreenshotHelper.TakeScreenshot(Driver, "AddProductsToCartTest.png");
        }//AddProductsToCartTest
    }//class
}//namespace
