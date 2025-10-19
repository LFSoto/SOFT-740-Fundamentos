using AutomationPracticeDemo.Tests.Tests.Data;
using AutomationPracticeDemo.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Tests.Cart
{
    public class CartTest : TestBase
    {

        [Test, TestCaseSource(typeof(GetUserData), nameof(GetUserData.UserLogin))]
        public void AddToCartTest(string emailTest, string password)
        {
            var LoginPage = new Pages.LoginForm.LoginPage(Driver);
            LoginPage.LoginWithUserAccount(emailTest, password);


            var AddToCartPage = new Pages.AddToCartForm.AddToCartPage(Driver);
            AddToCartPage.DeleteProductsCart();

            //Ingresamos nuevamente el usuario y contraseña después de eliminar los productos del carrito.
            LoginPage.LoginWithUserAccount(emailTest, password);
            AddToCartPage.AddToCart();

            var productos = AddToCartPage.ObtenerProductosDelCarrito();
            Assert.That(productos.Count, Is.EqualTo(2), "El carrito no contiene exactamente 2 productos.");
        }

    }
}
