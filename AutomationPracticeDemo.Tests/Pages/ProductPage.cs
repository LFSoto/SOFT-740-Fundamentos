using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Globalization;
using System.Text.RegularExpressions;


namespace AutomationPracticeDemo.Tests.Pages
{
    /// <summary>
    /// Clase principal de la página AutomationPage, que encapsula las acciones y elementos
    /// </summary>
    public class ProductPage
    {
        // Instancia del controlador WebDriver utilizada para interactuar con el navegador
        private readonly IWebDriver _driver;

        public ProductPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region GUI Elements: https://automationexercise.com/
        // ==================================================================================================
        // Este bloque agrupa todos los elementos gráficos (GUI) utilizados en la página bajo prueba.
        // Cada región secundaria corresponde a una funcionalidad o formulario específico.
        // Los elementos se localizan usando selectores Id, XPath o CSS, según corresponda.
        // ==================================================================================================

        #region Add Product
        // ==================================================================================================
        // --- Elementos relacionados con la gestión de productos ---
        // ==================================================================================================
        private IWebElement ProductLink => _driver.FindElement(By.CssSelector("a[href='/products']"));
        private IWebElement CartLink => _driver.FindElement(By.CssSelector("a[href='/view_cart']"));
        #endregion

        #endregion

        /// <summary>
        /// Agrega al carrito una lista de productos identificados por su data-product-id.
        /// </summary>
        /// <param name="productIds">Lista de identificadores únicos (data-product-id) de los productos a agregar.</param>
        public void AddProductsToCart(List<string> productIds)
        {
            // Abre la sección de productos
            ProductLink.Click();

            // Espera explícita utilizada para asegurar que los elementos estén disponibles antes de interactuar (timeout: 5 segundos)
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            // Recorre cada identificador de producto y lo agrega al carrito
            foreach (var productId in productIds)
            {
                // Espera hasta que el botón "Add to Cart" esté clickeable para el producto actual
                var addProductButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    By.CssSelector($"a[data-product-id='{productId}']")));

                // Desplaza la vista para asegurar que el botón esté visible en pantalla
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", addProductButton);

                try
                {
                    //Clic en el botón de añadir producto
                    addProductButton.Click();
                }
                catch (ElementClickInterceptedException)
                {
                    // Si otro elemento bloquea el clic, usa JavaScript como alternativa
                    ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", addProductButton);
                }

                // Espera que aparezca el botón "Continue Shopping" en el modal y lo presiona
                IWebElement ContinueShoppingButton = wait.Until(
                    SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                        By.CssSelector("button.btn.btn-success.close-modal.btn-block")));

                //Clic en el botón de "Continue Shopping"
                ContinueShoppingButton.Click();

                // Espera hasta que el modal con clase "modal-content" desaparezca del DOM.
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(
                By.CssSelector("div.modal-content")));

            }
            // Abre la vista del carrito una vez agregados todos los productos
            CartLink.Click();
        }

        /// <summary>
        /// Obtiene los productos del carrito de compras y sus valores de precio, cantidad y total.
        /// </summary>
        /// <returns>Lista de objetos <see cref="CartItem"/> con la información de cada producto en el carrito.</returns>
        internal List<CartItem> GetCartItems()
        {
            // Espera explícita: garantiza que la tabla del carrito esté visible antes de interactuar (timeout: 5 segundos)
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

            // Localiza la tabla principal del carrito cuando esté visible
            IWebElement cartTable = wait.Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("cart_info_table"))
            );

            // Obtiene todas las filas (<tr>) del cuerpo de la tabla (<tbody>)
            var rows = cartTable.FindElements(By.CssSelector("tbody tr"));
            var items = new List<CartItem>();

            // Recorre cada fila de la tabla para extraer la información de cada producto
            foreach (var row in rows)
            {
                // Obtiene el texto del precio individual del producto (columna Price)
                string priceText = row.FindElement(By.CssSelector(".cart_price p")).Text.Trim();

                // Obtiene el texto que indica la cantidad de unidades (columna Quantity)
                string quantityText = row.FindElement(By.CssSelector(".cart_quantity button")).Text.Trim();

                // Obtiene el texto del precio total para ese producto (columna Total)
                string totalText = row.FindElement(By.CssSelector(".cart_total p")).Text.Trim();

                // Crea un objeto CartItem con los valores numéricos procesados
                items.Add(new CartItem
                {
                    Price = ParseCurrency(priceText),
                    Quantity = int.Parse(quantityText),
                    Total = ParseCurrency(totalText)
                });
            }

            // Devuelve la lista con los datos de todos los productos del carrito
            return items;
        }

        /// <summary>
        /// Elimina todos los productos actualmente visibles en el carrito de compras.
        /// Recorre cada fila de la tabla, obtiene el ID del producto y hace clic en su botón de eliminación.
        /// </summary>
        /// <summary>
        /// Elimina todos los productos del carrito si existen.
        /// Si la tabla no se encuentra visible (carrito vacío), no realiza ninguna acción.
        /// </summary>
        public void DeleteCartItems()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

            // 1. Ir al carrito de forma segura, con protección de stale.
            //    Reintenta hasta que logre hacer clic en el link "/view_cart".
            wait.Until(driver =>
            {
                try
                {
                    By cartLinkLocator = By.CssSelector("a[href='/view_cart']");
                    var cartLinkEl = driver.FindElement(cartLinkLocator);

                    // Si el DOM cambió entre FindElement y Displayed, esto lanzaría StaleElementReferenceException,
                    // que capturamos abajo en catch y retornamos false para reintentar.
                    if (cartLinkEl.Displayed && cartLinkEl.Enabled)
                    {
                        cartLinkEl.Click();
                        return true; // success -> se sale del Until
                    }

                    return false; // aún no clickable
                }
                catch (NoSuchElementException)
                {
                    return false; // todavía no apareció el link
                }
                catch (StaleElementReferenceException)
                {
                    return false; // el link se volvió stale, reintentar
                }
            });

            // 2. Ahora ya hicimos click en "Cart". Esperamos que aparezca (o no) la tabla.
            //    Si no aparece la tabla, asumimos carrito vacío y salimos sin fallar.
            By cartTableLocator = By.Id("cart_info_table");

            bool tablePresent = false;
            IWebElement cartTable = null;

            try
            {
                cartTable = wait.Until(driver =>
                {
                    try
                    {
                        var table = driver.FindElement(cartTableLocator);
                        if (table.Displayed)
                        {
                            return table;
                        }
                        return null;
                    }
                    catch (NoSuchElementException)
                    {
                        return null;
                    }
                    catch (StaleElementReferenceException)
                    {
                        return null;
                    }
                });

                tablePresent = cartTable != null;
            }
            catch (WebDriverTimeoutException)
            {
                tablePresent = false;
            }

            if (!tablePresent)
            {
                Console.WriteLine("No hay productos en el carrito. Ninguna acción requerida.");
                return;
            }

            // 3. Loop hasta que el carrito quede vacío.
            while (true)
            {
                IReadOnlyCollection<IWebElement> rows;

                // Siempre relocalizamos tabla y filas en cada iteración
                try
                {
                    cartTable = _driver.FindElement(cartTableLocator);
                    rows = cartTable.FindElements(By.CssSelector("tbody tr"));
                }
                catch (NoSuchElementException)
                {
                    // tabla ya no está -> carrito vacío
                    Console.WriteLine("Carrito vacío (tabla ya no está presente).");
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    // DOM cambió justo ahora -> volver a intentar el while desde arriba
                    continue;
                }

                // ¿Quedan filas en el carrito?
                if (rows.Count == 0)
                {
                    Console.WriteLine("Todos los productos han sido eliminados del carrito.");
                    break;
                }

                // Tomamos la PRIMERA fila disponible en este momento
                IWebElement row;
                try
                {
                    row = rows.First();
                }
                catch (InvalidOperationException)
                {
                    // rows estaba vacío al final, carrera rara pero válida
                    Console.WriteLine("Carrito ya quedó vacío (sin filas).");
                    break;
                }

                try
                {
                    // Ej: <tr id="product-3">
                    string productIdAttr = row.GetAttribute("id") ?? string.Empty;
                    string productId = productIdAttr.Replace("product-", "").Trim();

                    // Buscar el botón de delete dentro de ESTA fila
                    var deleteButton = row.FindElement(
                        By.CssSelector($"a.cart_quantity_delete[data-product-id='{productId}']"));

                    // Intentar click normal primero
                    try
                    {
                        deleteButton.Click();
                    }
                    catch (ElementClickInterceptedException)
                    {
                        // Si algo tapa el botón, forzamos con JS
                        ((IJavaScriptExecutor)_driver)
                            .ExecuteScript("arguments[0].click();", deleteButton);
                    }

                    // Esperar a que esa fila específica ya no exista en el DOM
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(row));
                }
                catch (StaleElementReferenceException)
                {
                    // La fila cambió entre leerla y borrarla -> reintentar loop
                    continue;
                }
                catch (NoSuchElementException)
                {
                    // Algo cambió y ya no hay botón/row -> reintentar
                    continue;
                }
            }

            Console.WriteLine("DeleteCartItems() terminó.");
        }


        /// <summary>
        /// Convierte una cadena que representa una cantidad monetaria en un valor decimal normalizado.
        /// </summary>
        /// <param name="text">Texto que contiene el valor numérico, por ejemplo: "Rs. 1,000.50" o "€1.000,50".</param>
        /// <returns>Valor numérico decimal del texto procesado.</returns>
        private decimal ParseCurrency(string text)
        {
            // Usa una expresión regular para localizar el primer número dentro del texto,
            // incluyendo posibles separadores de miles ('.' o ',') y parte decimal.
            // Ejemplo: "Rs. 1,200.50" -> captura "1,200.50"
            var m = Regex.Match(text, @"([0-9]+(?:[.,][0-9]{3})*(?:[.,][0-9]+)?)");


            // Si la expresión regular no encuentra ningún número válido en el texto, devuelve 0 como valor por defecto
            if (!m.Success) return 0m;

            // Extrae la subcadena numérica capturada por el primer grupo de la RegEx
            var num = m.Groups[1].Value;

            // Determina cuál es el separador decimal (punto o coma)
            char decimalSep;
            if (num.Contains('.') && num.Contains(','))
            {
                // Si contiene ambos, el último encontrado se considera el separador decimal
                decimalSep = (num.LastIndexOf('.') > num.LastIndexOf(',')) ? '.' : ',';
            }
            else
            {
                // Si contiene solo uno, se asume como separador decimal
                decimalSep = num.Contains(',') ? ',' : '.';
            }

            // Quita el separador de miles (opuesto al separador decimal)
            char thousandSep = (decimalSep == '.') ? ',' : '.';
            num = num.Replace(thousandSep.ToString(), "");

            // Normaliza el formato: reemplaza ',' por '.' si es necesario
            if (decimalSep == ',')
                num = num.Replace(',', '.');

            // Convierte el texto resultante en decimal usando formato invariante
            return decimal.Parse(num, CultureInfo.InvariantCulture);
        }
    }

    /// <summary>
    /// Representa un producto dentro del carrito de compras,
    /// con sus valores de precio unitario, cantidad y total calculado.
    /// </summary>
    class CartItem
    {
        // Precio unitario del producto (ej. 500.00)
        public decimal Price { get; set; }

        // Cantidad de unidades del producto en el carrito (ej. 2)
        public int Quantity { get; set; }

        // Total del producto (Price * Quantity)
        public decimal Total { get; set; }
    }
}


  