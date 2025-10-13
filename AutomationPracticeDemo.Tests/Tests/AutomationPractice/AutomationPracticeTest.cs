using AutomationPracticeDemo.Tests.Pages.AutomationExercise;
using AutomationPracticeDemo.Tests.Utils;

namespace AutomationPracticeDemo.Tests.Tests.AutomationPractice
{
    public class AutomationPracticeTest : TestBase
    {
        [Test]
        public void newUserSignupTest()
        {
            var navBarPage = new NavBarPage(Driver);
            //Hacer click en Signup/Login
            navBarPage.ClickSignupLogin();
            var loginPage = new LoginPage(Driver);
            //Rellenar el formulario de registro
            loginPage.NewUserSignup("Melvin");
            //Rellenar el formulario de información de la cuenta
            var accountInformationPage = new AccountInformationPage(Driver);
            accountInformationPage.FillAccountInformation("Mr", "password123", "Melvin", "Marin", "123 Main St", "United States",
                "California", "Los Angeles", "90001", "1234567890");
            //Se valida el mensaje de cuenta creada
            var expectedMessage = "ACCOUNT CREATED!";
            Assert.That(expectedMessage, Is.EqualTo(accountInformationPage.GetAccountCreatedMessage()), "El mensaje actual:" + accountInformationPage.GetAccountCreatedMessage() + " no es el esperado: " + expectedMessage);
            //Hacer click en Continue
            accountInformationPage.ClickContinueButton();
            var homePage = new HomePage(Driver);
            Assert.That(homePage.IsHomePageDisplayed(), Is.True, "No se encuentra en el Home Page");
            //Se valida que el usuario ha iniciado sesión
            var expectedLoggedInAs = "Logged in as "+loginPage.GetGeneratedUser();
            Assert.That(expectedLoggedInAs, Is.EqualTo(navBarPage.GetLoggedInAsText()), "El mensaje actual:" + navBarPage.GetLoggedInAsText() + " no es el esperado: " + expectedLoggedInAs);
        }//newUserSignupTest

        [Test]
        public void existingUserLoginTest()
        {
            var navBarPage = new NavBarPage(Driver);
            //Hacer click en Signup/Login
            navBarPage.ClickSignupLogin();
            var loginPage = new LoginPage(Driver);
            //Rellenar el formulario de login
            loginPage.LoginExistingUser("SOFT-740@cenfotec.com", "SOFT-740");
            // Se valida que se encuentre en el home page
            var homePage = new HomePage(Driver);
            Assert.That(homePage.IsHomePageDisplayed(), Is.True, "No se encuentra en el Home Page");
            //Se valida que el usuario ha iniciado sesión
            var expectedLoggedInAs = "Logged in as SOFT-740";
            Assert.That(expectedLoggedInAs, Is.EqualTo(navBarPage.GetLoggedInAsText()), "El mensaje actual:" + navBarPage.GetLoggedInAsText() + " no es el esperado: " + expectedLoggedInAs);
        }//existingUserLoginTest

        [Test]
        public void AddProductsToCartTest()
        {
            var navBarPage = new NavBarPage(Driver);
            //Hacer click en Products
            navBarPage.ClickProducts();
            // Se navega a la página de productos
            var productsPage = new ProductsPage(Driver);
            // Agregar productos al carrito
            productsPage.AddProductsToCart();
            // Calcular el precio total de los productos agregados
            var totalPriceExpected = productsPage.CalculateTotalPrice();
            // Hacer click en el carrito
            navBarPage.ClickCart();
            // Calcular el precio total del carrito
            var ShoppingCartPage = new ShoppingCartPage(Driver);
            var totalPriceActual = ShoppingCartPage.CalculateTotalPriceInCart();
            // Validar que el precio total calculado sea igual al precio total del carrito
            Assert.That(totalPriceExpected, Is.EqualTo(totalPriceActual), "El precio total esperado: " + totalPriceExpected + " no es igual al precio total actual en el carrito: " + totalPriceActual);
        }//AddProductsToCartTest


        [Test]
        public void CotactUsValidFormTest()
        {
            var navBarPage = new NavBarPage(Driver);
            //Hacer click en Contact Us
            navBarPage.ClickContactUs();
            var contactUsPage = new ContactUsPage(Driver);
            //Rellenar el formulario de Contact Us
            contactUsPage.FillContactForm("Melvin Marin", "SOFT-740@cenfotec.com", "Test QA Automation",
                "Esto es una prueba de test script con Selenium WebDriver", "Ninja.png");
            //Se acepta el alert de file uploaded
            contactUsPage.AcceptAlert();
            //Se valida el alert de mensaje enviado correctamente
            var expectedAlertText = "Success! Your details have been submitted successfully.";
            Assert.That(expectedAlertText, Is.EqualTo(contactUsPage.GetSuccessMessage()), "El mensaje actual:" + contactUsPage.GetSuccessMessage() + " no es el esperado: " + expectedAlertText);
        }//CotactUsValidFormTest

        [Test]
        public void newsLetterTest()
        {
            var footerPage = new FooterPage(Driver);
            //Suscribirse al newsletter
            footerPage.SubscribeNewsletter("SOFT-740@cenfotec.com");
            //Se valida el mensaje de confirmación
            var expectedMessage = "You have been successfully subscribed!";
            Assert.That(expectedMessage, Is.EqualTo(footerPage.GetConfirmationMessage()), "El mensaje actual:" + footerPage.GetConfirmationMessage() + " no es el esperado: " + expectedMessage);
        }//newsLetterTest
    }//class
}//namespace
