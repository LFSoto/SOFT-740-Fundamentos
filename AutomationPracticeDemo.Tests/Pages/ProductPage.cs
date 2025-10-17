using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Globalization;
using System.Text.RegularExpressions;


namespace AutomationPracticeDemo.Tests.Pages
{
    /// <summary>
    /// Clase principal de la p�gina AutomationPage, que encapsula las acciones y elementos
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
        // Este bloque agrupa todos los elementos gr�ficos (GUI) utilizados en la p�gina bajo prueba.
        // Cada regi�n secundaria corresponde a una funcionalidad o formulario espec�fico.
        // Los elementos se localizan usando selectores Id, XPath o CSS, seg�n corresponda.
        // ==================================================================================================

        #region Add Product
        // ==================================================================================================
        // --- Elementos relacionados con la gesti�n de productos ---
        // ==================================================================================================
        private IWebElement ProductLink => _driver.FindElement(By.CssSelector("a[href='/products']"));
        private IWebElement CartLink => _driver.FindElement(By.CssSelector("a[href='/view_cart']"));
        #endregion

        #endregion

        /// <summary>
        /// Agrega al carrito una lista de productos identificados por su data-product-id.
        /// </summary>
        /// <param name="productIds">Lista de identificadores �nicos (data-product-id) de los productos a agregar.</param>
        public void AddProductsToCart(List<string> productIds)
        {
            // Abre la secci�n de productos
            ProductLink.Click();

            // Espera expl�cita utilizada para asegurar que los elementos est�n disponibles antes de interactuar (timeout: 5 segundos)
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            // Recorre cada identificador de producto y lo agrega al carrito
            foreach (var productId in productIds)
            {
                // Espera hasta que el bot�n "Add to Cart" est� clickeable para el producto actual
                var addProductButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    By.CssSelector($"a[data-product-id='{productId}']")));

                // Desplaza la vista para asegurar que el bot�n est� visible en pantalla
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", addProductButton);

                try
                {
                    //Clic en el bot�n de a�adir producto
                    addProductButton.Click();
                }
                catch (ElementClickInterceptedException)
                {
                    // Si otro elemento bloquea el clic, usa JavaScript como alternativa
                    ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", addProductButton);
                }

                // Espera que aparezca el bot�n "Continue Shopping" en el modal y lo presiona
                IWebElement ContinueShoppingButton = wait.Until(
                    SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                        By.CssSelector("button.btn.btn-success.close-modal.btn-block")));

                //Clic en el bot�n de "Continue Shopping"
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
        /// <returns>Lista de objetos <see cref="CartItem"/> con la informaci�n de cada producto en el carrito.</returns>
        internal List<CartItem> GetCartItems()
        {
            // Espera expl�cita: garantiza que la tabla del carrito est� visible antes de interactuar (timeout: 5 segundos)
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

            // Localiza la tabla principal del carrito cuando est� visible
            IWebElement cartTable = wait.Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("cart_info_table"))
            );

            // Obtiene todas las filas (<tr>) del cuerpo de la tabla (<tbody>)
            var rows = cartTable.FindElements(By.CssSelector("tbody tr"));
            var items = new List<CartItem>();

            // Recorre cada fila de la tabla para extraer la informaci�n de cada producto
            foreach (var row in rows)
            {
                // Obtiene el texto del precio individual del producto (columna Price)
                string priceText = row.FindElement(By.CssSelector(".cart_price p")).Text.Trim();

                // Obtiene el texto que indica la cantidad de unidades (columna Quantity)
                string quantityText = row.FindElement(By.CssSelector(".cart_quantity button")).Text.Trim();

                // Obtiene el texto del precio total para ese producto (columna Total)
                string totalText = row.FindElement(By.CssSelector(".cart_total p")).Text.Trim();

                // Crea un objeto CartItem con los valores num�ricos procesados
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
        /// Recorre cada fila de la tabla, obtiene el ID del producto y hace clic en su bot�n de eliminaci�n.
        /// </summary>
        /// <summary>
        /// Elimina todos los productos del carrito si existen.
        /// Si la tabla no se encuentra visible (carrito vac�o), no realiza ninguna acci�n.
        /// </summary>
        public void DeleteCartItems()
        {
            // Espera expl�cita: espera hasta que el bot�n de pago sea clickeable (m�ximo 10 segundos)
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(40));

            IWebElement ContinueShoppingButton = wait.Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(CartLink));

            // Realiza clic en el link "Cart" del carrito de compras
            CartLink.Click();

            // Espera expl�cita: espera hasta 5 segundos a que la tabla del carrito sea visible
            var wait1 = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IReadOnlyCollection<IWebElement> rows = [];

            try
            {
                // Espera hasta que la tabla sea visible (si existe)
                IWebElement cartTable = wait.Until(
                    SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("cart_info_table"))
                );

                // Obtiene las filas de la tabla (tbody > tr)
                rows = cartTable.FindElements(By.CssSelector("tbody tr"));
            }
            catch (WebDriverTimeoutException)
            {
                // Si no se encuentra la tabla, significa que el carrito est� vac�o
                Console.WriteLine("No hay productos en el carrito. Ninguna acci�n requerida.");
                return; // Sale del m�todo
            }

            // Si existen filas, recorre cada producto y lo elimina
            foreach (var row in rows)
            {
                // Obtiene el ID del producto desde el atributo "id" del <tr> 
                string productIdAttr = row.GetAttribute("id") ?? string.Empty;

                // Extrae solo el n�mero del ID (remueve el prefijo "product-")
                string productId = productIdAttr.Replace("product-", "").Trim();

                // Localiza el bot�n de eliminaci�n del producto seg�n su ID
                var deleteButton = row.FindElement(By.CssSelector($"a.cart_quantity_delete[data-product-id='{productId}']"));

                // Hace clic en el bot�n de eliminar
                deleteButton.Click();

                // Espera a que la fila desaparezca del DOM
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(row));
            }
        }

        /// <summary>
        /// Convierte una cadena que representa una cantidad monetaria en un valor decimal normalizado.
        /// </summary>
        /// <param name="text">Texto que contiene el valor num�rico, por ejemplo: "Rs. 1,000.50" o "�1.000,50".</param>
        /// <returns>Valor num�rico decimal del texto procesado.</returns>
        private decimal ParseCurrency(string text)
        {
            // Usa una expresi�n regular para localizar el primer n�mero dentro del texto,
            // incluyendo posibles separadores de miles ('.' o ',') y parte decimal.
            // Ejemplo: "Rs. 1,200.50" -> captura "1,200.50"
            var m = Regex.Match(text, @"([0-9]+(?:[.,][0-9]{3})*(?:[.,][0-9]+)?)");


            // Si la expresi�n regular no encuentra ning�n n�mero v�lido en el texto, devuelve 0 como valor por defecto
            if (!m.Success) return 0m;

            // Extrae la subcadena num�rica capturada por el primer grupo de la RegEx
            var num = m.Groups[1].Value;

            // Determina cu�l es el separador decimal (punto o coma)
            char decimalSep;
            if (num.Contains('.') && num.Contains(','))
            {
                // Si contiene ambos, el �ltimo encontrado se considera el separador decimal
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


  