using Bogus;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace AutomationPracticeDemo.Tests.Pages
{
    /// <summary>
    /// Clase principal de la p�gina AutomationPage, que encapsula las acciones y elementos
    /// </summary>
    public class LoginPage
    {
        // Instancia del controlador WebDriver utilizada para interactuar con el navegador
        private readonly IWebDriver _driver;

        // Instancia de la librer�a Bogus.Faker para generar datos aleatorios (en idioma espa�ol)
        private readonly Faker faker = new Faker("es");

        public LoginPage(IWebDriver driver)
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
        private IWebElement EmailAddressLoginInput => _driver.FindElement(By.XPath("//input[@data-qa='login-email']"));
        private IWebElement PasswordLoginInput => _driver.FindElement(By.XPath("//input[@data-qa='login-password']"));
        private IWebElement LoginButton => _driver.FindElement(By.XPath("//button[@data-qa='login-button']"));
        private IWebElement LoggedUserName => _driver.FindElement(By.XPath("//a[contains(., 'Logged in as')]"));
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

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            var messageElement = wait.Until(driver =>
            {
                return PasswordInpunt.Displayed ? PasswordInpunt : null;
            });
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
            IWebElement ContinueShoppingButton = wait.Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(CreateAccountButton));

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
        /// Obtiene el texto del mensaje que muestra el nombre del usuario actualmente autenticado.
        /// </summary>
        /// <returns>Nombre del usuario que ha iniciado sesi�n.</returns>
        public string GetLoginUserNameMessage()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            // Recupera el texto del elemento que contiene el nombre del usuario logueado
            // Espera expl�cita: espera hasta que el bot�n de pago sea clickeable (m�ximo 10 segundos)
            var messageElement = wait.Until(driver =>
            {
                return LoggedUserName.Displayed ? LoggedUserName : null;
            });

            var message = LoggedUserName.Text;
            return message;
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
    }
}

  