using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Pages.MainComponents;
using AutomationPracticeDemo.Tests.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Tests.Practica4
{
    //TODO agregar datadriven
    public class ProductsTest:TestBase
    {
        [Test]
        public void Should_AddItemsToCartAndVerifyTotal()
        {
            //Se instancian las clases necesarias para ejecutar el test
            LoginHelper loginHelper = new LoginHelper(Driver);
            HeaderNav headerNav = new HeaderNav(Driver);
            ProductsPage productsPage = new ProductsPage(Driver);
            GetPathHelper getPathHelper = new GetPathHelper();

            //Se llama al método que realiza el inicio de sesión
            loginHelper.Login();

            //Se presiona el botón Products y se espera a que carguen los elementos de la pantalla
            headerNav.ProductsLink.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Se agregan los productos al carrito
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", productsPage.AddToCart1Button);
            productsPage.AddToCart1Button.Click();
            productsPage.ContinueShoppingButton.Click();//Se cierra el pop up de Added

            productsPage.AddToCart2Button.Click();
            productsPage.ViewCartButton.Click(); //Se hace click en el enlace View cart del pop up de Added

            //Se presiona el botón checkout
            productsPage.CheckoutButton.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Se llaman las variables que contienen los precios de los productos y se se suma el valor de cada uno para validar el total
            string totalPriceActualResult = (productsPage.Price1Value + productsPage.Price2Value).ToString();
            string totalPriceExpectedResult = Driver.FindElement(By.XPath("//td[4]/p")).Text.Remove(0, 4);

            //Se captura la evidencia del resultado
            ScreenshotHelper.TakeScreenshot(Driver, getPathHelper.GetFilePathScreenShots() + "Should_AddItemsToCartAndVerifyTotal.png");

            Assert.That(totalPriceActualResult, Is.EqualTo(totalPriceExpectedResult));
        }
    }
}
