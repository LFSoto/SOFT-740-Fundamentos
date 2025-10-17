using AutomationPracticeDemo.Tests.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace AutomationPracticeDemo.Tests.Tests
{
    public class AutomationPractice:TestBase
    {
        //constantes y variables
        static readonly int random = new Random().Next(1, 1000);
        static readonly string email = "SOFT-740" + random + "@cenfotec.com";
        const string password = "SOFT-740";
        const string price1 = "Rs. 500";
        const string price2 = "Rs. 400";
        const string cant1 = "1";
        const string cant2 = "2";
        const string totalprod1 = "Rs. 500";
        const string totalprod2 = "Rs. 800";
        const string total = "Rs. 1,300";


        [Test]
        public void SignUpTest()
        {
            
            //definición de los web elements
            var signUpButton = Driver.FindElement(By.CssSelector("a[href='/login']"));
            signUpButton.Click();
            //datos de sign up inicial
            var emailInput = Driver.FindElement(By.CssSelector("input[data-qa='signup-email']"));
            var nameInput = Driver.FindElement(By.CssSelector("input[data-qa='signup-name']"));
            var submitSignUpButton = Driver.FindElement(By.CssSelector("button[data-qa='signup-button']"));

            //llenado del formulario de registro
            nameInput.SendKeys("Ale F");
            emailInput.SendKeys(email);

            //clic en el botón de Submit Sign Up
            submitSignUpButton.Click();

            //datos enter account information
            var inputGender = Driver.FindElement(By.Id("id_gender2"));
            var passwordInput = Driver.FindElement(By.Id("password"));
            var daysInput = Driver.FindElement(By.Id("days"));
            var monthsInput = Driver.FindElement(By.Id("months"));
            var yearsInput = Driver.FindElement(By.Id("years"));
            var specialOffersCheckbox = Driver.FindElement(By.Id("optin"));
            //datos de address information
            var firstNameInput = Driver.FindElement(By.Id("first_name"));
            var lastNameInput = Driver.FindElement(By.Id("last_name"));
            var companyInput = Driver.FindElement(By.Id("company"));
            var address1Input = Driver.FindElement(By.Id("address1"));
            var countryInput = Driver.FindElement(By.Id("country"));
            var stateInput = Driver.FindElement(By.Id("state"));
            var cityInput = Driver.FindElement(By.Id("city")); 
            var zipCodeInput = Driver.FindElement(By.Id("zipcode"));
            var mobileNumberInput = Driver.FindElement(By.Id("mobile_number"));
            var createAccountButton = Driver.FindElement(By.CssSelector("button[data-qa='create-account']"));
            

            //llenado del formulario de Account Information
            inputGender.Click();
            passwordInput.SendKeys(password);
            daysInput.SendKeys("10");
            monthsInput.SendKeys("May");
            yearsInput.SendKeys("1990");
            specialOffersCheckbox.Click();

            //llenado del formulario de Address Information
            firstNameInput.SendKeys("Ale");
            lastNameInput.SendKeys("F");
            companyInput.SendKeys("Cenfotec");
            address1Input.SendKeys("Heredia");
            countryInput.SendKeys("Canada");
            stateInput.SendKeys("Heredia");
            cityInput.SendKeys("Heredia");
            zipCodeInput.SendKeys("00000");
            mobileNumberInput.SendKeys("88888844");

            //clic en el botón de Create Account
            createAccountButton.Click();

            var accountCreatedMessage = Driver.FindElement(By.CssSelector("h2[data-qa='account-created']"));
            var continueButton = Driver.FindElement(By.CssSelector("a[data-qa='continue-button']"));

            //validar el mensaje de cuenta creada
            Assert.That(accountCreatedMessage.Text, Is.EqualTo("ACCOUNT CREATED!"));

            //clic en el botón de continuar
            continueButton.Click();
        }

        [Test]
        public void loginTest()
        {
            //definición de los web elements
            var signUpButton = Driver.FindElement(By.CssSelector("a[href='/login']"));

            //clic en el botón de Sign Up/Login
            signUpButton.Click();

            //definición de los web elements
            var loginEmailInput = Driver.FindElement(By.CssSelector("input[data-qa='login-email']"));
            var loginPasswordInput = Driver.FindElement(By.CssSelector("input[data-qa='login-password']"));
            
        

            //llenado del formulario de login
            loginEmailInput.SendKeys("SOFT-740@cenfotec.com");
            loginPasswordInput.SendKeys(password);

            var loginButton = Driver.FindElement(By.CssSelector("button[data-qa='login-button']"));
            //clic en el botón de Login
            loginButton.Click();
            var loggedInAsMessage = Driver.FindElement(By.XPath("//a[i[@class='fa fa-user']]"));        

            //validar el mensaje de usuario logueado
            Assert.That(loggedInAsMessage.Text, Is.EqualTo("Logged in as SOFT-740"));
        }

        [Test]
        public void addProductsTest() 
        {
            //se invoca empty cart para iniciar sin productos y a su vez invoca al loginTest para ingresaru
            EmptyCart();
            var cartButton = Driver.FindElement(By.CssSelector("a[href=\"/view_cart\"]"));
            cartButton.Click();
            
            //ingresar a la opción de Products
            var productsButton = Driver.FindElement(By.CssSelector("a[href='/products']"));
            productsButton.Click();
            //agregar primer producto
            var addProduct1 = Driver.FindElement(By.CssSelector("a[data-product-id='1']"));
            addProduct1.Click();
            //botón de continuar comprando
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            // Esperar hasta que el botón sea visible
            IWebElement continueShoppingButton = wait.Until(
                ExpectedConditions.ElementIsVisible(By.CssSelector("button.btn.btn-success.close-modal.btn-block"))
            );
            continueShoppingButton.Click();

            //agregar otro artículo, dos unidades, hecho por mí, con leve ayuda de IA
            string[] twoproducts = { "2", "2" }; // mismo producto dos veces
            foreach (var id in twoproducts)
            {
                var addProduct = Driver.FindElement(By.CssSelector($"a[data-product-id='{id}']"));
                addProduct.Click();

                IWebElement continueShoppingButton2 = wait.Until(
                    SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                        By.CssSelector("button.btn.btn-success.close-modal.btn-block"))
                );
                continueShoppingButton2.Click();
            }
            //ir al carrito
            var cartButton1 = Driver.FindElement(By.CssSelector("a[href=\"/view_cart\"]"));
            cartButton1.Click();

            //validar precios de los productos estén en el carrito
            var precioProducto1 = Driver.FindElement(By.XPath("//td[@class='cart_price']/p[contains(text(),'Rs. 500')]"));
            Assert.That(precioProducto1.Text, Is.EqualTo(price1));
            var precioProducto2 = Driver.FindElement(By.XPath("//td[@class='cart_price']/p[contains(text(),'Rs. 400')]"));
            Assert.That(precioProducto2.Text, Is.EqualTo(price2));
            var cantProd1 = Driver.FindElement(By.CssSelector("#product-1 > td.cart_quantity > button"));
            Assert.That(cantProd1.Text, Is.EqualTo(cant1));
            var cantProd2 = Driver.FindElement(By.CssSelector("#product-2 > td.cart_quantity > button"));
            Assert.That(cantProd2.Text, Is.EqualTo(cant2));
            var totalProd1 = Driver.FindElement(By.XPath("//td[@class='cart_total']/p[contains(text(),'Rs. 500')]"));
            Assert.That(totalProd1.Text, Is.EqualTo(totalprod1));
            var totalProd2 = Driver.FindElement(By.XPath("//td[@class='cart_total']/p[contains(text(),'Rs. 800')]"));
            Assert.That(totalProd2.Text, Is.EqualTo(totalprod2));
        }

        [Test]
        public void contactUsTest()
        {
            //definición de los web elements
            var contactUsButton = Driver.FindElement(By.CssSelector("a[href='/contact_us']"));
            contactUsButton.Click();
            var nameInput = Driver.FindElement(By.CssSelector("input[data-qa='name']"));
            nameInput.SendKeys("Ale F");
            var emailInput = Driver.FindElement(By.CssSelector("input[data-qa='email']"));
            emailInput.SendKeys(email);
            var subjectInput = Driver.FindElement(By.CssSelector("input[data-qa='subject']"));
            subjectInput.SendKeys("Test Subject");
            var messageInput = Driver.FindElement(By.CssSelector("textarea[data-qa='message']"));
            messageInput.SendKeys("This is a test message.");
            var uploadFileInput = Driver.FindElement(By.CssSelector("input[name='upload_file']"));
            uploadFileInput.SendKeys("C:\\Users\\LENOVO\\OneDrive\\Escritorio\\QA.jpeg");
            var submitButton = Driver.FindElement(By.CssSelector("input[data-qa='submit-button']"));
            submitButton.Click();
            Driver.SwitchTo().Alert().Accept();
            var successMessage = Driver.FindElement(By.CssSelector("div[class='status alert alert-success']"));
            Assert.That(successMessage.Text, Is.EqualTo("Success! Your details have been submitted successfully."));

        }

        [Test]
        public void newsLetterSubscriptionTest()
        {
            //definición de los web elements
            var subscribeElementInput = Driver.FindElement(By.Id("susbscribe_email"));
            var subscribeButton = Driver.FindElement(By.Id("subscribe"));
            var subscribeMessage = Driver.FindElement(By.CssSelector("div[class=\"alert-success alert\"]"));

            //envío de email
            subscribeElementInput.SendKeys(email);

            //clic en el botón de suscripción
            subscribeButton.Click();

            //validar el mensaje de suscripción
            Assert.That(subscribeMessage.Text, Is.EqualTo("You have been successfully subscribed!"));
            
        }

        [Test]
        public void EmptyCart() {
            {   //se invoca login para ingresar, reutilizando el test
                loginTest();
                var cartButton = Driver.FindElement(By.CssSelector("a[href=\"/view_cart\"]"));
                cartButton.Click();

                IWebElement? findProd2 = null;
                IWebElement? deleteProd2 = null;
                try
                {
                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(4));
                    findProd2 = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#product-2 > td.cart_description > h4 > a")));
                    deleteProd2 = Driver.FindElement(By.CssSelector("#product-2 > td.cart_delete > a > i"));
                    if (findProd2 != null && findProd2.Displayed.Equals(true) && deleteProd2 != null)
                    {
                        deleteProd2.Click();
                    }
                }
                catch (WebDriverTimeoutException)
                {
                    // El elemento no existe
                }

                IWebElement? findProd1 = null;
                IWebElement? deleteProd1 = null;
                try
                {
                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(4));
                    findProd1 = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#product-1 > td.cart_description > h4 > a")));
                    deleteProd1 = Driver.FindElement(By.CssSelector("#product-1 > td.cart_delete > a > i"));
                    if (findProd1 != null && findProd1.Displayed.Equals(true) && deleteProd1 != null)
                    {
                        deleteProd1.Click();
                      
                        
                    }
                }
                catch (WebDriverTimeoutException)
                {
                    // El elemento no existe
                }
            }
        }
    }
}
