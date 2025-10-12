using AutomationPracticeDemo.Tests.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationPracticeDemo.Tests.Tests
{
    public class AutomationExercise : TestBase
    {
        //Credenciales de usuario de prueba: 
        private const string _emailLogin = "dchavarriaca@ucenfotec.ac.cr";
        private const string _password = "123456Aa";

        #region Test Cases
        [Test]
        public void Should_RegisterNewUser()
        {
            //Se definen los elementos de la pantalla principal
            IWebElement signUpLink = Driver.FindElement(By.CssSelector("li a[href=\"/login\"]"));
            //Se presiona el botón Signup / Login y se espera a que carguen los elementos de la pantalla login
            signUpLink.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Se definen los elementos de la pantalla de login
            IWebElement signUpNameTextbox = Driver.FindElement(By.Name("name"));
            IWebElement signUpEmailTextbox = Driver.FindElement(By.CssSelector("form[action=\"/signup\"] input[name=\"email\"]"));
            IWebElement signupButton = Driver.FindElement(By.CssSelector("form[action=\"/signup\"] button"));

            //Se crea el correo que se va a utilizar para evitar que ya exista un usuario con el mismo correo
            string formattedDateTime = DateTime.Now.ToString("ddMMyyyyHHmmssfff");//Se obtiene la fecha y hora actual y se formatea para que no tenga espacios ni caracteres que no sean numeros
            string email = "dchavarria" + formattedDateTime + "@test.com";

            //Se llenan los campos nombre y correo, se presiona el botón Signup y se espera a que carguen los elementos de la pantalla signup
            signUpNameTextbox.SendKeys("DixonC");
            signUpEmailTextbox.SendKeys(email);
            signupButton.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Se desplaza hasta el final de la página para que desaparezcan los banners ya que dan problemas en algunas ejecuciones
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

            //Se definen los elementos de la pantalla de signup
            IWebElement mrRadioButton = Driver.FindElement(By.Id("id_gender1"));
            IWebElement passwordTextbox = Driver.FindElement(By.Id("password"));
            IWebElement daySelect = Driver.FindElement(By.Id("days"));
            IWebElement monthSelect = Driver.FindElement(By.Id("months"));
            IWebElement yearSelect = Driver.FindElement(By.Id("years"));
            IWebElement newsLetterCheckBox = Driver.FindElement(By.Id("newsletter"));
            IWebElement specialOffersCheckBox = Driver.FindElement(By.Id("optin"));
            IWebElement firstNameTextbox = Driver.FindElement(By.Id("first_name"));
            IWebElement lastNameTextbox = Driver.FindElement(By.Id("last_name"));
            IWebElement companyTextbox = Driver.FindElement(By.Id("company"));
            IWebElement adress1Textbox = Driver.FindElement(By.Id("address1"));
            IWebElement adress2Textbox = Driver.FindElement(By.Id("address2"));
            IWebElement countrySelect = Driver.FindElement(By.Id("country"));
            IWebElement stateTextBox = Driver.FindElement(By.Id("state"));
            IWebElement cityTextBox = Driver.FindElement(By.Id("city"));
            IWebElement zipCodeTextBox = Driver.FindElement(By.Id("zipcode"));
            IWebElement mobileNumberTextBox = Driver.FindElement(By.Id("mobile_number"));
            IWebElement createAccountButton = Driver.FindElement(By.CssSelector("#form button"));

            //Se completa el formulario
            mrRadioButton.Click();
            passwordTextbox.SendKeys("123456Aa");
            daySelect.SendKeys("13");
            monthSelect.SendKeys("May");
            yearSelect.SendKeys("1996");
            //Se agregó esta línea ya que en una de las pruebas un anuncio cargó un iframe (que no volvió a aparecer) que no permitia interactuar con ciertos elementos y arrojaba un error
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", newsLetterCheckBox);
            newsLetterCheckBox.Click();
            specialOffersCheckBox.Click();
            firstNameTextbox.SendKeys("Dixon");
            lastNameTextbox.SendKeys("Chavarria Vargas");
            companyTextbox.SendKeys("Company Test");
            adress1Textbox.SendKeys("San Jose");
            adress2Textbox.SendKeys("Perez Zeledon");
            countrySelect.SendKeys("United States");
            stateTextBox.SendKeys("San Jose");
            cityTextBox.SendKeys("Perez Zeledon");
            zipCodeTextBox.SendKeys("11901");
            mobileNumberTextBox.SendKeys("88888888");

            //Se hace click en el botón Create Account
            createAccountButton.Click();

            //Se crea el elemento para validar el mensaje de éxito al crear el usuario
            IWebElement accountCreatedText = Driver.FindElement(By.CssSelector(".title b"));

            Assert.That(accountCreatedText.Text, Is.EqualTo("ACCOUNT CREATED!"));

            //Se crea el elemento del botón Continue y la validación de si se inició sesión con éxito
            IWebElement continueButton = Driver.FindElement(By.ClassName("btn-primary"));
            continueButton.Click();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement logoutLink = wait.Until(d => d.FindElement(By.CssSelector("a[href=\"/logout\"]")));

            Assert.That(logoutLink.Displayed);
        }

        [Test]
        public void Should_LoginExistingUser()
        {
            //Se llama al método que realiza el inicio de sesión
            Login();

            //Se definen los elementos para validar que se haya iniciado sesión y se crea la validación
            string loggedInTextActualResult = Driver.FindElement(By.XPath("//li[10]/a")).Text;

            Assert.That(loggedInTextActualResult, Is.EqualTo("Logged in as DixonC"));
        }

        [Test]
        public void Should_AddItemsToCartAndVerifyTotal()
        {
            //Se llama al método que realiza el inicio de sesión
            Login();

            //Se definen los elementos de la pantalla principal
            IWebElement productsLink = Driver.FindElement(By.CssSelector("a[href=\"/products\"]"));
            //Se presiona el botón Products y se espera a que carguen los elementos de la pantalla
            productsLink.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Se definen los elementos de la pantalla de productos y va al carrito
            IWebElement addToCart1Button = Driver.FindElement(By.CssSelector(".productinfo a[data-product-id=\"1\"]"));
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", addToCart1Button);
            addToCart1Button.Click();
            Driver.FindElement(By.ClassName("btn-success")).Click();//Se cierra el pop up de Added

            IWebElement addToCart2Button = Driver.FindElement(By.CssSelector(".productinfo a[data-product-id=\"2\"]"));
            addToCart2Button.Click();
            Driver.FindElement(By.CssSelector("p a[href=\"/view_cart\"]")).Click(); //Se hace click en el enlace View cart del pop up de Added
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Se define el elemento botón checkout y se presiona
            IWebElement checkoutButton = Driver.FindElement(By.CssSelector(".check_out"));
            checkoutButton.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Se definen los elementos que contienen los precios de los productos y se obtiene el valor de cada uno para validar el total
            int price1Value = Convert.ToInt32(Driver.FindElement(By.CssSelector("#product-1 .cart_total_price")).Text.Remove(0,4));
            int price2Value = Convert.ToInt32(Driver.FindElement(By.CssSelector("#product-2 .cart_total_price")).Text.Remove(0,4));
            string totalPriceActualResult = (price1Value + price2Value).ToString();
            string totalPriceExpectedResult = Driver.FindElement(By.XPath("//td[4]/p")).Text.Remove(0,4);

            Assert.That(totalPriceActualResult, Is.EqualTo(totalPriceExpectedResult));
        }

        [Test]
        public void Should_SendContactForm()
        {
            //Se definen los elementos de la pantalla principal
            IWebElement contactUsLink = Driver.FindElement(By.CssSelector("a[href=\"/contact_us\"]"));
            //Se presiona el botón Contact us y se espera a que carguen los elementos de la pantalla
            contactUsLink.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Se definen los elementos de la pantalla de contact us
            IWebElement nameTextbox = Driver.FindElement(By.Name("name"));
            IWebElement emailTextbox = Driver.FindElement(By.Name("email"));
            IWebElement subjectTextbox = Driver.FindElement(By.Name("subject"));
            IWebElement messageTextbox = Driver.FindElement(By.Id("message"));
            IWebElement uploadFileInput = Driver.FindElement(By.Name("upload_file"));
            IWebElement submitButton = Driver.FindElement(By.Name("submit"));

            //Se interactua con los elementos de la pantalla contact us
            nameTextbox.SendKeys("Dixon C");
            emailTextbox.SendKeys(_emailLogin);
            subjectTextbox.SendKeys("Subject Test Text");
            messageTextbox.SendKeys("Message Test Text");
            uploadFileInput.SendKeys(GetFilePathUpload());
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", submitButton);
            submitButton.Click();

            //Se le a aceptar a la alerta
            Driver.SwitchTo().Alert().Accept();

            //Se valida el mensaje de éxito
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            string alertSuccessActualText = wait.Until(d => d.FindElement(By.ClassName("alert-success")).Text);

            Assert.That(alertSuccessActualText, Is.EqualTo("Success! Your details have been submitted successfully."));
        }

        [Test]
        public void Should_SubscribeToNewsletter()
        {
            //Se desplaza hasta el final de la página
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

            //Se definen los elementos necesarios para suscribirse al newsletter
            IWebElement subscribeEmailTextbox = Driver.FindElement(By.Id("susbscribe_email"));
            IWebElement subscribeButton = Driver.FindElement(By.Id("subscribe"));

            //Se ingresa el correo y se presiona el botón
            subscribeEmailTextbox.SendKeys("dchavarriaca@ucenfotec.ac.cr");
            subscribeButton.Click();

            //Se valida el mensaje de confirmación
            string successMessage = Driver.FindElement(By.ClassName("alert-success")).Text;

            Assert.That(successMessage, Is.EqualTo("You have been successfully subscribed!"));
        }
        #endregion

        #region Métodos
        private void Login()
        {
            //Se definen los elementos de la pantalla principal
            IWebElement loginLink = Driver.FindElement(By.CssSelector("li a[href=\"/login\"]"));
            //Se presiona el botón Signup / Login y se espera a que carguen los elementos de la pantalla login
            loginLink.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Se definen los elementos de la pantalla de login
            IWebElement loginEmailTextbox = Driver.FindElement(By.CssSelector("form[action=\"/login\"] input[name=\"email\"]"));
            IWebElement loginPasswordTextbox = Driver.FindElement(By.Name("password"));
            IWebElement loginButton = Driver.FindElement(By.CssSelector("form[action=\"/login\"] button"));

            //Se llenan los campos email address y password, se presiona el botón Login y se espera a que carguen los elementos de la pantalla de inicio
            loginEmailTextbox.SendKeys(_emailLogin);
            loginPasswordTextbox.SendKeys(_password);
            loginButton.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        private string GetFilePathUpload()
        {
            string baseDirectory = AppContext.BaseDirectory;
            string relativePath = "../../../capybara.png";
            return Path.GetFullPath(Path.Combine(baseDirectory, relativePath));
        }
        #endregion
    }
}
