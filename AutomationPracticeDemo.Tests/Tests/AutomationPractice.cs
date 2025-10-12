using AutomationPracticeDemo.Tests.Utils;
using OpenQA.Selenium;
namespace AutomationPracticeDemo.Tests.Tests
{

    public class AutomationPractice : TestBase

    {
        static readonly int random = new Random().Next(1, 1000);
        static readonly string email = "SOFT-740" + random + "@cenfotec.com";
        const string password = "SOFT-7400";
        const string preciounitario = "Rs. 278";
        const string preciototal = "Rs. 556";


        [Test]
        public void SignupLogin()
        {
            //Se definen los WebElements
            var SignupLogin = Driver.FindElement(By.CssSelector("a[href='/login']"));
            //Se da click en Signup/Login
            SignupLogin.Click();
            //Se definen los WebElements
            var emailinput = Driver.FindElement(By.CssSelector("input[data-qa='signup-email']"));
            var nameinput = Driver.FindElement(By.CssSelector("input[data-qa='signup-name']"));
            var signupbutton = Driver.FindElement(By.CssSelector("button[data-qa='signup-button']"));
            //Se ingresan los datos nombre y correo
            nameinput.SendKeys("Tamara");
            emailinput.SendKeys(email);
            //click en Signup
            signupbutton.Click();

            //SELECCIONAR Title
            var titleradio = Driver.FindElement(By.Id("id_gender1"));
            var passwordinput = Driver.FindElement(By.Id("password"));
            var dayselect = Driver.FindElement(By.Id("days"));
            var monthselect = Driver.FindElement(By.Id("months"));
            var yearselect = Driver.FindElement(By.Id("years"));
            var newslettercheckbox = Driver.FindElement(By.Id("newsletter"));
            var firstnameinput = Driver.FindElement(By.Id("first_name"));
            var lastnameinput = Driver.FindElement(By.Id("last_name"));
            var companyinput = Driver.FindElement(By.Id("company"));
            var address1input = Driver.FindElement(By.Id("address1"));
            var address2input = Driver.FindElement(By.Id("address2"));
            var countryselect = Driver.FindElement(By.Id("country"));
            var stateinput = Driver.FindElement(By.Id("state"));
            var cityinput = Driver.FindElement(By.Id("city"));
            var zipcodeinput = Driver.FindElement(By.Id("zipcode"));
            var mobilenumberinput = Driver.FindElement(By.Id("mobile_number"));
            var createaccountbutton = Driver.FindElement(By.CssSelector("button[data-qa='create-account']"));

            //Se ingresan los datos del formulario
            titleradio.Click();
            passwordinput.SendKeys(password);
            dayselect.SendKeys("19");
            monthselect.SendKeys("November");
            yearselect.SendKeys("1990");
            newslettercheckbox.Click();
            firstnameinput.SendKeys("Tamara");
            lastnameinput.SendKeys("Salazar");
            companyinput.SendKeys("BCR");
            address1input.SendKeys("Company name");
            address2input.SendKeys("Costa Rica");
            countryselect.SendKeys("India");
            stateinput.SendKeys("San Jose");
            cityinput.SendKeys("SanJOSE");
            zipcodeinput.SendKeys("10101");
            mobilenumberinput.SendKeys("83853030");
            //Click en Create Account
            createaccountbutton.Click();
            //Validacion de cuenta creada
            var accountcreatedmessage = Driver.FindElement(By.CssSelector("h2[data-qa='account-created']"));
            var continuebutton = Driver.FindElement(By.XPath("//a[@data-qa='continue-button']"));


            if (accountcreatedmessage.Displayed)
            {
                ScreenshotHelper.TakeScreenshot(Driver, "account_created.png");
                Assert.Pass("Cuenta creada exitosamente.");
            }
            else
            {
                ScreenshotHelper.TakeScreenshot(Driver, "account_not_created.png");
                Assert.Fail("No se pudo crear la cuenta.");
            }

            //click en continue

            continuebutton.Click();

            //Validacion de login
            var loggedinasmessage = Driver.FindElement(By.CssSelector("a[href='/logout']"));
            if (loggedinasmessage.Displayed)
            {
                ScreenshotHelper.TakeScreenshot(Driver, "logged_in.png");
                Assert.Pass("Login exitoso.");
            }
            else
            {
                ScreenshotHelper.TakeScreenshot(Driver, "not_logged_in.png");
                Assert.Fail("No se inicio sesion de manera correcta.");
            }
        }
        [Test]
        public void NewUserLoginexistingemail()
        {
            //Se definen los WebElements
            var SignupLogin = Driver.FindElement(By.CssSelector("a[href='/login']"));
            //Se da click en Signup/Login
            SignupLogin.Click();

            var emailinput = Driver.FindElement(By.CssSelector("input[data-qa='signup-email']"));
            var nameinput = Driver.FindElement(By.CssSelector("input[data-qa='signup-name']"));
            var signupbutton = Driver.FindElement(By.CssSelector("button[data-qa='signup-button']"));
            //Se ingresan los datos nombre y correo
            nameinput.SendKeys("Tamara");
            emailinput.SendKeys("SOFT-7401@cenfotec.com");
            //click en Signup
            signupbutton.Click();

            ScreenshotHelper.TakeScreenshot(Driver, "form_test.png");
            Assert.Pass("Email Address already exist!.");

        }
        [Test]
        public void loginexistente()
        {
            //Se definen los WebElements
            var SignupLogin = Driver.FindElement(By.CssSelector("a[href='/login']"));
            //Se da click en Signup/Login
            SignupLogin.Click();

            var emailinput = Driver.FindElement(By.CssSelector("input[data-qa='login-email']"));
            var passwordinput = Driver.FindElement(By.CssSelector("input[data-qa='login-password']"));
            var Loginbutton = Driver.FindElement(By.CssSelector("button[data-qa='login-button']"));
            //Se ingresan los datos  correo y password
            emailinput.SendKeys("SOFT-7401@cenfotec.com");
            passwordinput.SendKeys("SOFT-7400");

            //click en Login
            Loginbutton.Click();

            //VALIDACION DE LOGIN
            var loginMessage = Driver.FindElement(By.XPath("//a[i[@class='fa fa-user']]"));

            Assert.That(loginMessage.Text, Is.EqualTo("Logged in as tamara"));
            Assert.Pass("Login exitoso.");

        }
        [Test]
        public void CART()
        {

            //Se definen los WebElements
            var productos = Driver.FindElement(By.CssSelector("a[href='/products']"));
            //Se da click en Signup/Login
            productos.Click();

            var addtocart1 = Driver.FindElement(By.CssSelector("a[data-product-id='13']"));
            // var addtocart2 = Driver.FindElement(By.CssSelector("a[data-product-id='13']"));
            var viewcartbutton = Driver.FindElement(By.CssSelector("a[href='/view_cart']"));
            var continuebutton = Driver.FindElement(By.CssSelector("button[class='btn btn-success close-modal btn-block']"));
            var cartbutton = Driver.FindElement(By.CssSelector("a[href='/view_cart']"));
            //Se agrega primer articulo al carrito
            addtocart1.Click();
            Thread.Sleep(2000);
            //se da click en continue shopping  
            continuebutton.Click();
            //se agrega segundo articulo al carrito
            addtocart1.Click();
            // Thread.Sleep(500);
            //se da click en view cart
            cartbutton.Click();


            //validar precios unitarios de los productos estén en el carrito
            var precioProductounitario = Driver.FindElement(By.ClassName("cart_price"));
            Assert.That(precioProductounitario.Text, Is.EqualTo(preciounitario));

            //validar precios totales de los productos estén en el carrito
            var precioProductototal = Driver.FindElement(By.ClassName("cart_total_price"));
            Assert.That(precioProductototal.Text, Is.EqualTo(preciototal));
        }
        [Test]
        public void contactUs()

        {
            //Se definen los WebElements
            var contactus = Driver.FindElement(By.CssSelector("a[href='/contact_us']"));
            //Se da click en Contact Us
            contactus.Click();

            //Se definen los WebElements del formulario
            var nameinput = Driver.FindElement(By.CssSelector("input[data-qa='name']"));
            var emailinput = Driver.FindElement(By.CssSelector("input[data-qa='email']"));
            var subjectinput = Driver.FindElement(By.CssSelector("input[data-qa='subject']"));
            var messageinput = Driver.FindElement(By.CssSelector("textarea[data-qa='message']"));
            var uploadfileinput = Driver.FindElement(By.CssSelector("input[name='upload_file']"));
            var submitbutton = Driver.FindElement(By.CssSelector("input[data-qa='submit-button']"));

            //Se ingresan los datos del formulario
            nameinput.SendKeys("Tamara");
            emailinput.SendKeys("tsalazarzuniga@gmail.com");
            subjectinput.SendKeys("validar el envío correcto del formulario de contacto. ");
            messageinput.SendKeys("Este es un mensaje de prueba para validar el envío correcto del formulario de contacto.");
            //Se adjunta un archivo
            uploadfileinput.SendKeys("C:\\Users\\Kenneth\\OneDrive\\Documentos\\Curso automatización\\SOFT-740-Fundamentos\\AutomationPracticeDemo.Tests\\Selenium_Logo.png");
            //click en Submit
            submitbutton.Click();
            //Validacion de mensaje de éxito
            Thread.Sleep(2000);
            //Alerta
            Driver.SwitchTo().Alert().Accept();
            //Validacion de mensaje de éxito
            var successmessage = Driver.FindElement(By.CssSelector("div[class='status alert alert-success']"));
            Assert.Pass("Success! Your details have been submitted successfully.");

        }

        [Test]
        public void Suscripciónnewsletter()
        {
            //Se definen los WebElements
            var subscribenElementInput = Driver.FindElement(By.Id("susbscribe_email"));
            //var suscribeButton = Driver.FindElement(By.Id("susbscribe_email"));
            var suscribeMessage = Driver.FindElement(By.CssSelector("div[class=\"alert-success alert\"] "));
            var suscribtn = Driver.FindElement(By.Id("subscribe"));
            //Se escribe el correo
            subscribenElementInput.SendKeys(email);

            //Se da click en el botón de suscribir

            suscribtn.Click();

            //se valida msj de suscripcíón

            Assert.That(suscribeMessage.Text, Is.EqualTo("You have been successfully subscribed!"));

        }
    }

}




