using AutomationPracticeDemo.Tests.Tests.CartProducts.Data;
using AutomationPracticeDemo.Tests.Tests.SignUp.Data;
using AutomationPracticeDemo.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Tests.CartProducts.Test
{
    public class CartProductsTest:TestBase
    {
        [Test, TestCaseSource(typeof(CartProductsData), nameof(CartProductsData.TestCases))]
        public void CartProductsTests(CartProductsData data)
        {
            var page = new Pages.ProductsPage(Driver);
            var page2 = new Pages.LoginPage(Driver);
            page2.Login(data.Email, data.Password);
            page.EmptyCart();
            page.GoToProducts();
            page.AddProduct(data.IdProduct1);
            page.ContinueShopping();
            page.AddProduct(data.IdProduct2);
            page.ContinueShopping();
            page.AddProduct(data.IdProduct2);
            page.ContinueShopping();
            page.GoToCart();
            ScreenshotHelper.TakeScreenshot(Driver, "Cart.png");
            Assert.Multiple(() =>
            {
                Assert.That(page.GetPriceProduct1(), Is.EqualTo(data.Price1), "Price of product 1 is incorrect");
                Assert.That(page.GetPriceProduct2(), Is.EqualTo(data.Price2), "Price of product 2 is incorrect");
                Assert.That(page.GetQuantityProduct1, Is.EqualTo(data.Cant1), "Quantity of product 1 is incorrect");
                Assert.That(page.GetQuantityProduct2, Is.EqualTo(data.Cant2), "Quantity of product 2 is incorrect");
                Assert.That(page.GetTotalProduct1, Is.EqualTo(data.TotalProd1), "Total of product 1 is incorrect");
                Assert.That(page.GetTotalProduct2, Is.EqualTo(data.TotalProd2), "Total of product 2 is incorrect");
            });

        }


        }

    
}
