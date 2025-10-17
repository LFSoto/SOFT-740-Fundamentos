using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutomationPracticeDemo.Tests.Utils
{
    public class TestBase
    {
        protected IWebDriver Driver;
        protected WebDriverWait? Wait;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            Driver = new ChromeDriver(options);
            Driver.Navigate().GoToUrl("https://automationexercise.com/");
        }

        [TearDown]
        public void TearDown()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
            }
        }
        //protected void EmptyCart()
        //{
        //    try
        //    {
        //        // Ir al carrito
        //        var cartButton = Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("a[href='/view_cart']")));
        //        cartButton.Click();

        //        // Si hay productos, eliminarlos todos
        //        var deleteButtons = Driver.FindElements(By.CssSelector("a.cart_quantity_delete"));
        //        foreach (var deleteButton in deleteButtons)
        //        {
        //            deleteButton.Click();
        //            // pequeña espera entre clics
        //            System.Threading.Thread.Sleep(500);
        //        }

        //        // Confirmar que el carrito esté vacío
        //        var emptyMessage = Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
        //            By.CssSelector("#empty_cart > p")));
        //        Assert.That(emptyMessage.Text.Contains("Cart is empty"), "El carrito no se vació correctamente");
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        // Si no hay productos o botón de carrito, simplemente continuar
        //    }
        //}
    }
}
