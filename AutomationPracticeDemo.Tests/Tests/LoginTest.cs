using AutomationPracticeDemo.Tests.Pages.Home;
using AutomationPracticeDemo.Tests.Pages.Login;
using AutomationPracticeDemo.Tests.Pages.NavBar;
using AutomationPracticeDemo.Tests.Utils;

namespace AutomationPracticeDemo.Tests.Tests
{
    public class LoginTest : TestBase
    {
        [Test]
        [TestCaseSource(typeof(TestDataSources), nameof(TestDataSources.LoginDataCases))]
        public void ExistingUserLoginTest(string email, string password, string expectedMessage)
        {
            var navBarPage = new NavBarPage(Driver);
            //Hacer click en Signup/Login
            navBarPage.ClickSignupLogin();
            var loginPage = new LoginPage(Driver);
            //Rellenar el formulario de login con datos del TestCaseSource
            loginPage.LoginExistingUser(email, password);
            // Se valida que se encuentren en el home page
            var homePage = new HomePage(Driver);
            Assert.That(homePage.IsHomePageDisplayed(), Is.True, "No se encuentra en el Home Page");
            //Se valida que el usuario ha iniciado sesión
            Assert.That(expectedMessage, Is.EqualTo(navBarPage.GetLoggedInAsText()), "El mensaje actual:" + navBarPage.GetLoggedInAsText() + " no es el esperado: " + expectedMessage);
            //Tomar screenshot
            ScreenshotHelper.TakeScreenshot(Driver, "ExistingUserLoginTest.png");
        }//ExistingUserLoginTest
    }//class
}//namespace
