using Bogus;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Globalization;
using System.Text.RegularExpressions;


namespace AutomationPracticeDemo.Tests.Pages
{
    /// <summary>
    /// Clase principal de la p�gina AutomationPage, que encapsula las acciones y elementos
    /// </summary>
    public class AutomationPage
    {
        // Instancia del controlador WebDriver utilizada para interactuar con el navegador
        private readonly IWebDriver _driver;

        // Instancia de la librer�a Bogus.Faker para generar datos aleatorios (en idioma espa�ol)
        private readonly Faker faker = new Faker("es");

        /// <summary>
        /// Constructor de la clase que inicializa el WebDriver.
        /// </summary>
        /// <param name="driver">Instancia activa del navegador controlado por Selenium WebDriver.</param>
        public AutomationPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region GUI Elements: https://automationexercise.com/
        // ==================================================================================================
        // Este bloque agrupa todos los elementos gr�ficos (GUI) utilizados en la p�gina bajo prueba.
        // Cada regi�n secundaria corresponde a una funcionalidad o formulario espec�fico.
        // Los elementos se localizan usando selectores Id, XPath o CSS, seg�n corresponda.
        // ==================================================================================================

        #region Register_New_User
        // ==================================================================================================
        // --- Elementos del flujo de registro de un nuevo usuario ---
        // ==================================================================================================
        private IWebElement SignupLoginLink => _driver.FindElement(By.XPath("//a[@href='/login']"));
        private IWebElement NameUserSignupInput => _driver.FindElement(By.XPath("//input[@data-qa ='signup-name']"));
        private IWebElement EmailAddressSignupInput => _driver.FindElement(By.XPath("//input[@data-qa ='signup-email']"));
        private IWebElement SignupButton => _driver.FindElement(By.XPath("//button[@data-qa ='signup-button']"));
        private IWebElement PasswordInpunt => _driver.FindElement(By.Id("password"));
        private IWebElement DaySelect => _driver.FindElement(By.Id("days"));
        private IWebElement MonthSelect => _driver.FindElement(By.Id("months"));
        private IWebElement YearSelect => _driver.FindElement(By.Id("years"));
        private IWebElement FirstNameInput => _driver.FindElement(By.Id("first_name"));
        private IWebElement LastNameInput => _driver.FindElement(By.Id("last_name"));
        private IWebElement AddressInput => _driver.FindElement(By.Id("address1"));
        private IWebElement CountrySelect => _driver.FindElement(By.Id("country"));
        private IWebElement StateInpunt => _driver.FindElement(By.Id("state"));
        private IWebElement CityInpunt => _driver.FindElement(By.Id("city"));
        private IWebElement ZipCodeInpunt => _driver.FindElement(By.Id("zipcode"));
        private IWebElement MobileNumberInpunt => _driver.FindElement(By.Id("mobile_number"));
        private IWebElement CreateAccountButton => _driver.FindElement(By.XPath("//button[@data-qa='create-account']"));
        private IWebElement SuccessfulMessage => _driver.FindElement(By.XPath("//b[normalize-space()='Account Created!']"));
        private IWebElement ContinueButton => _driver.FindElement(By.XPath("//a[@data-qa='continue-button']"));
        private IWebElement LogoutLink => _driver.FindElement(By.XPath("//a[@href='/logout']"));
        #endregion

        #region Add Product
        // ==================================================================================================
        // --- Elementos relacionados con la gesti�n de productos ---
        // ==================================================================================================
        private IWebElement EmailAddressLoginInput => _driver.FindElement(By.XPath("//input[@data-qa='login-email']"));
        private IWebElement PasswordLoginInput => _driver.FindElement(By.XPath("//input[@data-qa='login-password']"));
        private IWebElement LoginButton => _driver.FindElement(By.XPath("//button[@data-qa='login-button']"));
        private IWebElement LoggedUserName => _driver.FindElement(By.XPath("//a[contains(., 'Logged in as')]"));
        private IWebElement ProductLink => _driver.FindElement(By.CssSelector("a[href='/products']"));
        private IWebElement CartLink => _driver.FindElement(By.CssSelector("a[href='/view_cart']"));
        #endregion

        #region Subscription elements
        // ==================================================================================================
        // --- Elementos del bloque de suscripci�n al bolet�n ---
        // ==================================================================================================
        private IWebElement SusbscribeEmailInput => _driver.FindElement(By.Id("susbscribe_email"));
        private IWebElement SubscribeButton => _driver.FindElement(By.Id("subscribe"));
        private IWebElement SubscriptionSuccessAlertMessage => _driver.FindElement(By.CssSelector("#success-subscribe .alert-success"));
        #endregion

        #region Contacts us elements
        // ==================================================================================================
        // --- Elementos del formulario de contacto ---
        // ==================================================================================================
        private IWebElement ContactUsLink => _driver.FindElement(By.CssSelector("a[href='/contact_us']"));
        private IWebElement NameInput => _driver.FindElement(By.CssSelector("input[data-qa='name']"));
        private IWebElement EmailInput => _driver.FindElement(By.CssSelector("input[data-qa='email']"));
        private IWebElement SubjectInput => _driver.FindElement(By.CssSelector("input[data-qa='subject']"));
        private IWebElement MessageInput => _driver.FindElement(By.Id("message"));
        private IWebElement UploadFileInput => _driver.FindElement(By.CssSelector("input[name='upload_file']"));
        private IWebElement SubnitButton => _driver.FindElement(By.CssSelector("input[data-qa='submit-button']"));
        private IWebElement SuccessMessageContactForm => _driver.FindElement(By.CssSelector(".status.alert.alert-success"));
        #endregion

        #region Process Purchase Order
        // ==================================================================================================
        // --- Elementos de la orden de pedido ---
        // ==================================================================================================
        private IWebElement ProceedCheckoutButton=> _driver.FindElement(By.CssSelector(".btn.btn-default.check_out"));
        private IWebElement PlaceOrderButton => _driver.FindElement(By.CssSelector(".btn.btn-default.check_out"));
        private IWebElement NameOnCardInput => _driver.FindElement(By.CssSelector("input[name='name_on_card']"));
        private IWebElement CardNumberInput => _driver.FindElement(By.CssSelector("input[name='card_number']"));
        private IWebElement CVCInput => _driver.FindElement(By.CssSelector("input[data-qa='cvc']"));
        private IWebElement MonthExpirationInput => _driver.FindElement(By.CssSelector("input[placeholder='MM']"));
        private IWebElement YearExpirationInput => _driver.FindElement(By.CssSelector("input[data-qa='expiry-year']"));
        private IWebElement PayConfirmOrderButton => _driver.FindElement(By.CssSelector("button[data-qa='pay-button']"));
        private IWebElement MessageOrderConfirmed => _driver.FindElement(By.XPath("//p[contains(text(), 'Congratulations')]"));
        private IWebElement ContinueEndOfOrderButton => _driver.FindElement(By.CssSelector(".btn.btn-primary"));
        #endregion

        #endregion

        /// <summary>
        /// Crea un nuevo usuario de manera aleatoria utilizando datos generados por la librer�a Bogus.Faker.
        /// </summary>
        /// <remarks>
        /// Genera todos los datos necesarios din�micamente y selecciona los valores aleatorios v�lidos para cada campo.
        /// </remarks>
        public void CreateRandomUser()
        {
            // Realiza un clic en el link de Signup/Login del m�nu superior
            ClickSignupLoginLink();

            //Genera e ingresa un UserName aleatorio
            string userName = faker.Internet.UserName();
            NameUserSignupInput.SendKeys(userName);

            //Genera e ingresa un Email aleatorio
            string email = faker.Internet.ExampleEmail();
            EmailAddressSignupInput.SendKeys(email);

            //Realiza un clic en el bot�n Signup
            SignupButton.Click();

            //Genera e ingresa un Password aleatorio
            string password = faker.Internet.Password();
            PasswordInpunt.SendKeys(password);

            // Genera e ingresa una fecha aleatoria entre 18 y 48 a�os atr�s (30 a�os antes de la base de -18) en formato DD/MM/YYYY
            string birthDate = faker.Date.Past(30, DateTime.Today.AddYears(-18)).ToString("dd/MM/yyyy");
            SelectDate(birthDate);

            //Genera e ingresa un nombre aleatorio
            string firstName = faker.Name.FirstName();
            FirstNameInput.SendKeys(firstName);

            //Genera e ingresa un apellido aleatorio
            string lastName = faker.Name.LastName();
            LastNameInput.SendKeys(lastName);

            //Genera e ingresa una direci�n aleatorio
            string address = faker.Address.StreetAddress();
            AddressInput.SendKeys(address);

            //Genera e ingresa un pa�s aleatorio seg�n la lista disponible
            string country = GenerateRandomCountry();
            SelectElement selectCountry = new(CountrySelect);
            selectCountry.SelectByValue(country);

            //Genera e ingresa un estado aleatorio
            string state = faker.Address.State();
            StateInpunt.SendKeys(state);

            //Genera e ingresa una ciudad aleatorio
            string city = faker.Address.City();
            CityInpunt.SendKeys(city);

            //Genera e ingresa un c�digo postal aleatorio
            string zipCode = faker.Address.ZipCode();
            ZipCodeInpunt.SendKeys(zipCode);

            //Genera e ingresa un n�mero celular aleatorio
            string phone = faker.Phone.PhoneNumber("####-####");
            MobileNumberInpunt.SendKeys(phone);

            // Realiza un clic en el bot�n de "Create Account" del formulario
            CreateAccountButton.Submit();
        }

        /// <summary>
        /// Inicia sesi�n en la aplicaci�n utilizando las credenciales proporcionadas.
        /// </summary>
        /// <param name="email">Correo electr�nico del usuario.</param>
        /// <param name="password">Contrase�a del usuario.</param>
        public void LoginUser(string email, string password)
        {
            // Realiza un clic en el link de Signup/Login del m�nu superior
            ClickSignupLoginLink();

            // Ingresa las credenciales del usuario
            EmailAddressLoginInput.SendKeys(email);
            PasswordLoginInput.SendKeys(password);

            // Realiza un clic en el bot�n "Login" 
            LoginButton.Submit();
        }

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
        /// Completa y env�a el formulario de contacto.
        /// </summary>
        /// <param name="name">Nombre del remitente.</param>
        /// <param name="email">Correo electr�nico del remitente.</param>
        /// <param name="subject">Asunto del mensaje.</param>
        /// <param name="message">Contenido del mensaje.</param>
        /// <param name="file">Nombre del archivo a subir desde la carpeta Resources.</param>
        public void FillOutTheContactForm(string name, string email, string subject, string message, string file)
        {
            // Abre el formulario de contacto
            ContactUsLink.Click();

            // Completa los campos de texto del formulario
            NameInput.SendKeys(name);
            EmailInput.SendKeys(email);
            SubjectInput.SendKeys(subject);
            MessageInput.SendKeys(message);

            // Obtiene la ruta del archivo desde la carpeta Resources y lo adjunta
            var filePath = GetProjectFilePath(file);
            UploadFileInput.SendKeys(filePath);

            // Env�a el formulario y acepta la alerta de confirmaci�n
            SubnitButton.Submit();
            _driver.SwitchTo().Alert().Accept();
        }

        /// <summary>
        /// Suscribe un usuario al bolet�n de suscripci�n ingresando su correo electr�nico en el campo correspondiente.
        /// </summary>
        /// <param name="email">Correo electr�nico del usuario que desea suscribirse.</param>
        public void SubscriptionNewsletter(string email)
        {
            // Ingresa el correo electr�nico en el campo de suscripci�n
            SusbscribeEmailInput.SendKeys(email);

            // Env�a el formulario de suscripci�n
            SubscribeButton.Submit();
        }

        /// <summary>
        /// Ejecuta el flujo completo de compra: inicia sesi�n, limpia el carrito, 
        /// agrega productos, avanza al checkout y completa el pago.
        /// </summary>
        public void ProcessPurchaseOrder(string email, string password, List<string> productIds, string name,
            string cardNumber, string cvcCode, string date)
        {
            // Inicia sesi�n en la cuenta del usuario
            LoginUser(email, password);

            // Elimina los productos existentes del carrito (si hay)
            DeleteCartItems();

            // Agrega nuevos productos al carrito seg�n los IDs especificados
            AddProductsToCart(productIds);

            // Avanza al proceso de pago (checkout)
            ProceedCheckoutButton.Click();

            // Confirma la orden antes de ingresar los datos de pago
            PlaceOrderButton.Click();

            // Completa el formulario de pago con la informaci�n de la tarjeta
            CardPaymentInformation(name, cardNumber, cvcCode, date);

        }

        /// <summary>
        /// Completa el formulario de pago con la informaci�n del usuario 
        /// y confirma la orden mediante un clic seguro en el bot�n de pago.
        /// </summary>
        public void CardPaymentInformation(string name, string card, string cvc, string date)
        {
            // Completa los campos del formulario de pago
            NameOnCardInput.SendKeys(name);
            CardNumberInput.SendKeys(card);
            CVCInput.SendKeys(cvc);

            // Divide la cadena de fecha (formato: MM/YY)
            var dateParts = date.Split('/');

            // Extrae los valores de mes y a�o de expiraci�n
            string month = dateParts[0];
            string year = dateParts[1];

            //Selecciona la fecha de expiraci�n en la pantalla
            MonthExpirationInput.SendKeys(month);
            YearExpirationInput.SendKeys(year);

            // Espera expl�cita: espera hasta que el bot�n de pago sea clickeable (m�ximo 10 segundos)
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(PayConfirmOrderButton));

            // Asegura que el bot�n est� visible en pantalla antes de hacer clic
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", PayConfirmOrderButton);

            // Intenta el clic normal, y si falla por bloqueo visual, usa clic JS
            try
            {
                // Intenta hacer clic de forma normal en el bot�n
                PayConfirmOrderButton.Click();
            }
            catch (ElementClickInterceptedException)
            {
                // Si otro elemento bloquea el clic, se realiza un clic mediante JavaScript
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", PayConfirmOrderButton);
            }
        }

        /// <summary>
        /// Obtiene el texto del mensaje exitoso mostrado tras registrar un nuevo usuario.
        /// </summary>
        /// <returns>Texto del mensaje de �xito.</returns>
        public string GetSuccessfulMessage()
        {
            // Recupera el texto del elemento que muestra el mensaje de �xito
            var message = SuccessfulMessage.Text;
            return message;
        }

        /// <summary>
        /// Obtiene el texto del mensaje de �xito de la suscripci�n mostrado temporalmente en pantalla.
        /// </summary>
        /// <returns>
        /// Texto del mensaje de �xito si aparece a tiempo; de lo contrario, una cadena vac�a.
        /// </returns>
        public string GetSuccessAlertMessage()
        {
            // Espera expl�cita: da hasta 5 segundos para que el mensaje aparezca
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

            try
            {
                // Espera hasta que el mensaje sea visible en el DOM
                var messageElement = wait.Until(driver =>
                {
                    return SubscriptionSuccessAlertMessage.Displayed ? SubscriptionSuccessAlertMessage : null;
                });

                // Devuelve el texto limpio del mensaje
                return messageElement.Text.Trim();
            }
            catch
            {
                // Si el mensaje no aparece a tiempo, devuelve vac�o (sin lanzar excepci�n)
                return string.Empty;
            }
        }

        /// <summary>
        /// Obtiene la ruta completa de un archivo ubicado en la carpeta "Resources" del proyecto.
        /// </summary>
        /// <param name="fileName">Nombre del archivo dentro de la carpeta Resources.</param>
        /// <returns>Ruta absoluta del archivo dentro del proyecto.</returns>
        public string GetProjectFilePath(string fileName)
        {
            // Obtiene la ruta base del proyecto (subiendo desde /bin)
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = Path.GetFullPath(Path.Combine(basePath, @"..\..\.."));

            // Asume autom�ticamente que los archivos est�n en la carpeta "Resources"
            string resourcesPath = Path.Combine(projectRoot, "Resources");

            // Devuelve la ruta completa del archivo
            return Path.Combine(resourcesPath, fileName);
        }

        /// <summary>
        /// Obtiene el texto del mensaje que muestra el nombre del usuario actualmente autenticado.
        /// </summary>
        /// <returns>Nombre del usuario que ha iniciado sesi�n.</returns>
        public string GetLoginUserNameMessage()
        {
            // Recupera el texto del elemento que contiene el nombre del usuario logueado
            var message = LoggedUserName.Text;
            return message;
        }

        /// <summary>
        /// Obtiene el texto del mensaje exitoso mostrado tras enviar el formulario de contacto.
        /// </summary>
        /// <returns>Texto del mensaje de �xito del formulario de contacto.</returns>
        public string GetSuccessMessageContactForm()
        {
            // Recupera el texto del elemento que contiene el mensaje de �xito
            var message = SuccessMessageContactForm.Text;
            return message;
        }

        /// <summary>
        /// Obtiene el texto del mensaje de confirmaci�n de pedido
        /// mostrado tras completar exitosamente una orden.
        /// </summary>
        public string GetMessageOrderConfirmed()
        {
            // Recupera el texto del elemento que muestra el mensaje de �xito del pedido de la orden
            var message = MessageOrderConfirmed.Text.Trim();

            // Devuelve el texto del mensaj
            return message;
        }

        /// <summary>
        /// Realiza clic en el enlace de registro o inicio de sesi�n para abrir el formulario correspondiente.
        /// </summary>
        public void ClickSignupLoginLink()
        {
            // Clic en el enlace "Signup / Login" del men� superior
            SignupLoginLink.Click();
        }

        /// <summary>
        /// Realiza clic en el bot�n "Continue" para avanzar en el flujo de registrar nuevo usuario.
        /// </summary>
        public void ClickContinueButton()
        {
            // Clic en el bot�n "Continue" del formulario
            ContinueButton.Click();
        }

        /// <summary>
        /// Realiza clic en el enlace de cierre de sesi�n asegurando primero que el elemento est� visible y habilitado.
        /// </summary>
        public void ClickLogoutLink()
        {
            // Espera expl�cita: espera hasta que el enlace de logout est� visible y habilitado (m�x. 5 segundos)
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(_ => LogoutLink.Displayed && LogoutLink.Enabled);

            // Clic en el enlace "Logout" para cerrar sesi�n
            LogoutLink.Click();
        }

        /// <summary>
        /// Realiza clic en el bot�n "Continue" que aparece al finalizar el proceso de compra,
        /// completando as� el flujo de la orden.
        /// </summary>
        public void ClickContinueEndOfOrderButton()
        {
            // Ejecuta el clic sobre el bot�n de continuaci�n al final del pedido
            ContinueEndOfOrderButton.Click();
        }

        /// <summary>
        /// Devuelve aleatoriamente un pa�s de una lista predefinida.
        /// </summary>
        /// <returns>Nombre del pa�s seleccionado al azar.</returns>
        public string GenerateRandomCountry()
        {
            // Lista de pa�ses posibles para generar datos de prueba (Disponibles en el ComboBox)
            var countries = new string[] { "India", "United States", "Canada", "Australia", "Israel", "New Zealand", "Singapore" };

            // Selecciona un �ndice aleatorio dentro del rango de la lista
            var rnd = new Random();
            int index = rnd.Next(countries.Length);

            // Devuelve el pa�s correspondiente al �ndice generado
            return countries[index];
        }

        /// <summary>
        /// Selecciona una fecha en los men�s desplegables del formulario a partir de una cadena en formato DD/MM/YYYY.
        /// </summary>
        /// <param name="date">Fecha en formato DD/MM/YYYY.</param>
        public void SelectDate(string date)
        {
            // Divide la cadena de fecha en partes separadas usando "/" como delimitador.
            var dateParts = date.Split('/');

            //Extrae los segmentos de la fecha y realiza una conversi�n para eliminar posibles 0 a la izquierda
            string day = int.Parse(dateParts[0]).ToString();
            string month = int.Parse(dateParts[1]).ToString();
            string year = dateParts[2];

            // Selecciona el d�a
            SelectElement selectDay = new(DaySelect);
            selectDay.SelectByValue(day);

            // Selecciona el mes
            SelectElement selectMonth = new(MonthSelect);
            selectMonth.SelectByValue(month);

            // Selecciona el a�o
            SelectElement selectYear = new(YearSelect);
            selectYear.SelectByValue(year);
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
            // Realiza clic en el link "Cart" del carrito de compras
            CartLink.Click();

            // Espera expl�cita: espera hasta 5 segundos a que la tabla del carrito sea visible
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
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
