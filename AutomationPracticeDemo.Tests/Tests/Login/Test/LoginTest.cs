using AutomationPracticeDemo.Tests.Tests.Login.Data;
using AutomationPracticeDemo.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Tests.Login.Test
{
    public class LoginTest:TestBase
    {
        [Test, TestCaseSource(typeof(LoginData), nameof(LoginData.TestCases))]
        public void LoginTests(LoginData data)
        {
            var page = new Pages.LoginPage(Driver);
            //abrir la página de login

            page.Login(data.Email, data.Password);
            if (data.IsValid)
            {
                ScreenshotHelper.TakeScreenshot(Driver, "LoginSuccess.png");
                //validar que el usuario haya iniciado sesión correctamente
                var loggedInUser = page.GetLoggedInUser();
                Assert.That(loggedInUser, Is.EqualTo(data.Result));
            }
            else
            {
                //validar el mensaje de error al intentar iniciar sesión
                ScreenshotHelper.TakeScreenshot(Driver, "LoginFailed.png");
                var loginErrorMessage = page.GetLoginErrorMessage();
                Assert.That(loginErrorMessage, Is.EqualTo(data.Result));
            }
        }
    }
}
