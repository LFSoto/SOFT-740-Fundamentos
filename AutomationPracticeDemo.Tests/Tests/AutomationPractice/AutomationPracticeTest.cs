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
        }//newUserSignupTest

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
