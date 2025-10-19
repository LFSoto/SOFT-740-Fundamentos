using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Pages.AddToCartForm
{
    public class AddToCartPage
    {
        private readonly IWebDriver _driver;
        public AddToCartPage(IWebDriver driver)
        {
            _driver = driver;
        }

        //Delete ProductsCart
        private IWebElement ViewcartBtn => _driver.FindElement(By.CssSelector("li a[href=\"/view_cart\"]"));
        private IReadOnlyCollection<IWebElement> cartRows => _driver.FindElements(By.CssSelector("#cart_info_table tbody tr"));
        private IReadOnlyCollection<IWebElement> botonesEliminar => _driver.FindElements(By.CssSelector("a.cart_quantity_delete"));
        private IWebElement logoutBtn => _driver.FindElement(By.CssSelector("li a[href=\"/logout\"]"));


        public void DeleteProductsCart()
        {
            ViewcartBtn.Click();
            //Ubicamos la tabla con los productos agregados al carrito.

            int cantidadFilasInicial = cartRows.Count;
            Console.WriteLine($"Cantidad de productos en el carrito antes de eliminarlas: {cantidadFilasInicial}");
            if (cantidadFilasInicial > 0)
            {
                // Elimina todos los productos del carrito haciendo clic en los botones de eliminar           
                foreach (var boton in botonesEliminar)
                {
                    //hacemos scroll si el botón está tapado por algún anuncio.
                    IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                    js.ExecuteScript("arguments[0].scrollIntoView(true);", boton);

                    boton.Click();

                }

            }
            //estas 3 lineas es para control y verificar que si se eliminaron los productos.
            var filasDespués = cartRows.Count;
            Console.WriteLine($"Cantidad de productos en el carrito despues de eliminarlas: {filasDespués}");

            logoutBtn.Click();
        }
        public void AddToCart()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            //Definimos estas variables para agregar solamente 2 productos al carrito.
            int productoId = 0; //Este id cambia por producto, tiene una secuencia en la página.
            int productoId_1 = 3;
            int productoId_2 = 6;
            int contador = 0;//Este campo cuenta las veces que se agrega un producto al carrito.

            productoId = productoId_1;
            while (contador < 2)
            {
                //UBICAMOS EL PRODUCTO POR SU ID:
                //Ubicamos los productos a comprar y nos posicionamos sobre él.
                wait.Until(driver => driver.FindElement(By.CssSelector($".single-products img[src='/get_product_picture/{productoId}']")).Displayed);
                var hoverElement = _driver.FindElement(By.CssSelector($".single-products img[src='/get_product_picture/{productoId}']"));
                // Crea una instancia de la clase Actions
                Actions actions = new Actions(_driver);
                // Mueve el ratón al elemento del menú principal
                actions.MoveToElement(hoverElement).Perform();


                //BUSCAMOS Y SELECCIONAMOS EL PRIMER PRODUCTO A AGREGAR AL CARRITO.
                //Ubicamos el botón dentro del overlay del producto a comprar.
                wait.Until(driver => driver.FindElement(By.CssSelector($".overlay-content a[data-product-id='{productoId}']")).Displayed);
                var button = _driver.FindElement(By.CssSelector($".overlay-content a[data-product-id='{productoId}']"));

                //Esperamos hasta que el botón sea clickeable
                wait.Until(driver => button.Displayed && button.Enabled);

                button.Click();

                //Esperamos a que se muestre el popup de la confirmación
                wait.Until(driver => driver.FindElement(By.Id("cartModal")).Displayed);
                var popupAdded = _driver.FindElement(By.Id("cartModal"));
                //Verificamos que el popup está visible.
                Assert.That(popupAdded.Displayed, Is.True, "El popup del carrito se mostró correctamente.");

                if (contador < 1)
                {
                    var ContinueShoppingBtn = _driver.FindElement(By.CssSelector(".modal-footer [class=\"btn btn-success close-modal btn-block\"]"));
                    ContinueShoppingBtn.Click();
                    Thread.Sleep(500);
                }
                if (contador == 1)
                {
                    //Ubicamos el botón "View Cart" dentro del popup porque ya agregamos el segundo producto.
                    var buttonViewCart = _driver.FindElement(By.CssSelector(".modal-body a[href='/view_cart']"));
                    buttonViewCart.Click();
                    var shoppingCartSection = _driver.FindElement(By.CssSelector(".breadcrumb li[class='active']"));
                    Assert.That(shoppingCartSection.Displayed, Is.True, "El elemento si existe y se ingresó a la sección de Shopping Cart");
                    //contamos la cantidad de productos en el carrito.
                    var infoTable = _driver.FindElements(By.CssSelector("#cart_info_table tbody tr"));
                    int cantidadFilas = infoTable.Count;
                    Console.WriteLine($"Cantidad de ítems en el carrito: {cantidadFilas}");
                }

                //Cambiamos el ID del producto para el siguiente ciclo
                productoId = productoId_2;
                contador++;
            }
        }

        public IList<IWebElement> ObtenerProductosDelCarrito()
        {
            return _driver.FindElements(By.CssSelector("#cart_info_table tbody tr"));
        }

    }
}

