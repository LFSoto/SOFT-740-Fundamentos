using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Utils;
using OpenQA.Selenium;
using System;

namespace AutomationPracticeDemo.Tests.Tests
{
    public class AutomationPractice : TestBase
    {
        static readonly int random = new Random().Next(1, 1000);
        string emailRandom = "PracticaAUT" + random + "@cenfotec.com";
        const string email = "SOFT-740@cenfotec.com";
        const string password = "SOFT-740";

        /// <summary>
        /// 
        /// Validar la suscripción al newsletter en la página principal, Ejemplo hecho por el profesor
        [Test]
        public void newsLetterTest()
        {
            var subscribreElementInput = Driver.FindElement(By.Id("susbscribe_email"));
            var suscribeButton = Driver.FindElement(By.Id("subscribe"));
            var susbscribreMessage = Driver.FindElement(By.CssSelector("div[class=\"alert-success alert\"]"));
            subscribreElementInput.SendKeys(email);
            suscribeButton.Click();
            Assert.That(susbscribreMessage.Text, Is.EqualTo("You have been successfully subscribed!"));
        }

        /// <summary>
        /// Ejercicio 1: Registro de usuario nuevo
        /// </summary
        [Test]
        public void SingupTest()
        {
            //Declaración de variables
            var homePage = new HomePage(Driver);
            var loginPage = new LoginPage(Driver);

            // Navegación a la página de registro
            homePage.ClickSignUpLogin();
            Assert.That(loginPage.GetTitleNewUserSignup(), Is.EqualTo("New User Signup!"));

            //Navegación al formulario de registro
            loginPage.FillSignup("UsuarioPracticaAUT", emailRandom);
            loginPage.SubmitSignup();
            Assert.That(loginPage.GetTitleEnterAccountInfo(), Is.EqualTo("ENTER ACCOUNT INFORMATION"));

            //Llenado del formulario de registro
            loginPage.FillAccountInformation("UsuarioPracticaAUT", "Mr", "ContraseñaTestAUT", "3", "November", "1993");
            Assert.That(loginPage.ShouldValidatedTextEmailInput(), Is.EqualTo(emailRandom));
            ScreenshotHelper.TakeScreenshot(Driver, "AccountInformation_test.png");

            loginPage.FillAddressInformation("José", "Arias", "Banco de Costa Rica", "San Jose, Perez Zeledon,San Isidro", "Pejibaye", "Canada", "San Jose", "San Isidro", "1191", "50612345678");
            ScreenshotHelper.TakeScreenshot(Driver, "AddressInformation_test.png");
            loginPage.SubmitCreateAccount();

            //Validación de cuenta creada
            Assert.That(loginPage.GetAccountCreatedTitle(), Is.EqualTo("ACCOUNT CREATED!"));
            Assert.That(loginPage.GetAccountCreatedMessage, Does.Contain("Congratulations! Your new account has been successfully created! " +
            "You can now take advantage of member privileges to enhance your online shopping experience with us."));
            ScreenshotHelper.TakeScreenshot(Driver, "AccountCreated_test.png");

            //Continuar a la página principal
            loginPage.SumitContinue();

            //Validar que el usuario se ha logueado correctamente
            Assert.That(homePage.validatedUserLogout(), Is.EqualTo("Logout"));
        }

        /// <summary>
        /// Ejercicio 2: Login con usuario existente
        /// </summary
        [Test]
        public void LoginTest()
        {
            var homePage = new HomePage(Driver);
            var loginPage = new LoginPage(Driver);

            // Navegación a la página de registro
            homePage.ClickSignUpLogin();
            Assert.That(loginPage.GetTitleLoginAccount, Is.EqualTo("Login to your account"));

            //Llenado del formulario de login
            loginPage.FillLogin(email, password);
            loginPage.SubmitLogin();
            ScreenshotHelper.TakeScreenshot(Driver, "Login_test.png");

            //Validar que el usuario se ha logueado correctamente
            Assert.That(homePage.validatedUserLogout(), Is.EqualTo("Logout"));
            ScreenshotHelper.TakeScreenshot(Driver, "Logout_test.png");
        }

        /// <summary>
        /// Ejercicio 3: Agregar productos al carrito y verificar total
        /// </summary
        [Test]
        public void AddProductsToCartTest()
        {
            var homePage = new HomePage(Driver);
            var productsPage = new ProductsPage(Driver);

            // Navegación a la página de productos
            homePage.ClickProductOption();
            Assert.That(productsPage.ValidatedProductsPage, Is.EqualTo("ALL PRODUCTS"));
            ScreenshotHelper.TakeScreenshot(Driver, "ProductsPage_test.png");

            //Obtener detalles del primer producto y validarlos
            var (firstProductType, firstProductPrice) = productsPage.GetFirstProductDetails();
            Assert.Multiple(() =>
            {
                Assert.That(firstProductType, Is.EqualTo("Blue Top"));
                Assert.That(firstProductPrice, Is.EqualTo("Rs. 500"));
            });

            //Agregar el primer producto al carrito
            productsPage.AddFirstProductToCart();

            //Validar modal de producto agregado
            var (modalTitle, modalMessage) = productsPage.ValidateProductAddedModal();
            Assert.Multiple(() =>
            {
                Assert.That(modalTitle, Is.EqualTo("Added!"));
                Assert.That(modalMessage, Is.EqualTo("Your product has been added to cart."));
            });
            ScreenshotHelper.TakeScreenshot(Driver, "ProductAddedModal_test.png");
            productsPage.ContinueShopping();

            //Obtener detalles del segundo producto y validarlos
            var (secondProductType, secondProductPrice) = productsPage.GetSecondProductDetails();
            Assert.Multiple(() =>
            {
                Assert.That(secondProductType, Is.EqualTo("Men Tshirt"));
                Assert.That(secondProductPrice, Is.EqualTo("Rs. 400"));
            });

            //Agregar el segundo producto al carrito
            productsPage.AddSecondProductToCart();

            //visualizar el carrito
            productsPage.SummitViewCart();
            ScreenshotHelper.TakeScreenshot(Driver, "ViewCart_test.png");

            //Validar que los productos están en el carrito con el precio correcto y el total es correcto
            productsPage.ValidateProductInCart(firstProductType);
            productsPage.ValidateProductInCart(secondProductType);
        }
        /// <summary>
        /// Ejercicio 4: Contact Us form
        /// </summary
        /// 
        [Test]
        public void ContactUsTest()
        {
            var homePage = new HomePage(Driver);
            var contactUsPage = new ContactUSPage(Driver);

            //Ruta del archivo a subir
            string rutaImagen = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Resource\Paisaje.jpg"));
            
            // Navegación a la página de Contact Us
            homePage.ClickContactUsOption();
            Assert.That(contactUsPage.GetTitleContactUSPage, Is.EqualTo("CONTACT US"));

            //Llenado del formulario de Contact Us
            contactUsPage.FillContactForm("Maximino",email,"Practica #3","Se realizo la practica usando POM");

            //Subir un archivo (opcional)
            contactUsPage.UploadFile(rutaImagen);

            //contactUsPage.UploadFile("C:\\Users\\maxim");
            ScreenshotHelper.TakeScreenshot(Driver, "ContactUs_test.png");
            contactUsPage.SubmitContactForm();
            
            //Validar mensaje de éxito
            Assert.That(contactUsPage.GetAlertMessage(), Is.EqualTo("Press OK to proceed!"));
            contactUsPage.AcceptAlert();

            //Validar mensaje de éxito
            Assert.That(contactUsPage.GetSuccessMessage(), Is.EqualTo("Success! Your details have been submitted successfully."));
        }


        /// <summary>
        /// Ejercicio 5: Sucripción al newsletter
        /// </summary
        [Test]
        public void suscriptionNewLetterTest()
        {
            var homePage = new HomePage(Driver);
            // Suscripción al newsletter
            homePage.FillSuscribeInput(email);
            homePage.SumitSuscibeButton();
            ScreenshotHelper.TakeScreenshot(Driver, "Suscription_test.png");

            //Validar mensaje de éxito
            Assert.That(homePage.GetSuscribeMessage(), Is.EqualTo("You have been successfully subscribed!"));
        }

    }

}
