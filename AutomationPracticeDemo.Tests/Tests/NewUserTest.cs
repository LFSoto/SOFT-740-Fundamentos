using AutomationPracticeDemo.Tests.Pages.AccountInformation;
using AutomationPracticeDemo.Tests.Pages.Home;
using AutomationPracticeDemo.Tests.Pages.Login;
using AutomationPracticeDemo.Tests.Pages.NavBar;
using AutomationPracticeDemo.Tests.Utils;

namespace AutomationPracticeDemo.Tests.Tests
{
    public class NewUserTest : TestBase
    {
        [Test]
        [TestCaseSource(typeof(TestDataSources), nameof(TestDataSources.NewUserDataCases))]
        public void NewUserSignupTest(string name, string lastname, string gender, string newPassword,
            string address, string country, string state, string city, string zipCode, string mobileNumber)
        {
            var navBarPage = new NavBarPage(Driver);
            //Hacer click en Signup/Login
            navBarPage.ClickSignupLogin();
            var loginPage = new LoginPage(Driver);
            //Rellenar el formulario de registro
            loginPage.NewUserSignup(name);
            //Rellenar el formulario de información de la cuenta
            var accountInformationPage = new AccountInformationPage(Driver);
            accountInformationPage.FillAccountInformation(gender, newPassword, name, lastname, address, country,
                state, city, zipCode, mobileNumber);
            //Se valida el mensaje de cuenta creada
            var expectedMessage = "ACCOUNT CREATED!";
            Assert.That(expectedMessage, Is.EqualTo(accountInformationPage.GetAccountCreatedMessage()), "El mensaje actual:" + accountInformationPage.GetAccountCreatedMessage() + " no es el esperado: " + expectedMessage);
            //Hacer click en Continue
            accountInformationPage.ClickContinueButton();
            var homePage = new HomePage(Driver);
            Assert.That(homePage.IsHomePageDisplayed(), Is.True, "No se encuentra en el Home Page");
            //Se valida que el usuario ha iniciado sesión
            var expectedLoggedInAs = "Logged in as " + loginPage.GetGeneratedUser();
            Assert.That(expectedLoggedInAs, Is.EqualTo(navBarPage.GetLoggedInAsText()), "El mensaje actual:" + navBarPage.GetLoggedInAsText() + " no es el esperado: " + expectedLoggedInAs);
            //Tomar screenshot
            ScreenshotHelper.TakeScreenshot(Driver, "NewUserSignupTest.png");
        }//NewUserSignupTest
    }//class
}//namespace
