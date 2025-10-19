using AutomationPracticeDemo.Tests.Tests.Data;
using AutomationPracticeDemo.Tests.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Tests.Login
{
    public class LoginTest: TestBase
    {
        static readonly int random = new Random().Next(1, 1000);
        static readonly string email = "SOFT-740" + random + "@cenfotec.com";
        const string name = "SOFT-740";


        [Test]
        public void SignupLogin_Test() 
        {
            var LoginPage = new Pages.LoginForm.LoginPage(Driver);

            LoginPage.SignupLogin();
            Assert.That(LoginPage.LoginButtonColor, Is.EqualTo("rgba(255, 165, 0, 1)"));

        }
        //NewUserTest()
        [Test, TestCaseSource(typeof(GetUserData), nameof(GetUserData.NewUserLogin))]
        public void CreateUser_Test(string password, string dropDownDay, string dropDownMonth, string dropDownYear, string inputFirstName, string inputLastName, string inputCompanyName, string inputAddress1, string inputAddress2, string dropDownCountry, string inputState, string inputCity, string inputZipCode, string inputMobileNumb)
        {
            var LoginPage = new Pages.LoginForm.LoginPage(Driver);

            //Se busca el botón SignupLogin y se da click.
            LoginPage.SignupLogin();

            //Se ingresa un nuevo usuario.
            LoginPage.NewUser(name, email);

            //Verificamos que se muestre el texto "ENTER ACCOUNT INFORMATION".
            Assert.That(LoginPage.GetTexttitleEnterAccount, Is.EqualTo("ENTER ACCOUNT INFORMATION"));
            ScreenshotHelper.TakeScreenshot(Driver, "NewUserTest.png");

            if (LoginPage.GetTexttitleEnterAccount == "ENTER ACCOUNT INFORMATION")  // Acción si se cumple la condición.
            {              
                LoginPage.EnterAccountInfo(password, dropDownDay, dropDownMonth, dropDownYear, inputFirstName, inputLastName, inputCompanyName, inputAddress1, inputAddress2, dropDownCountry, inputState, inputCity, inputZipCode, inputMobileNumb);

                var message = LoginPage.GetCreateAccountMessage();

                Assert.That(message, Is.EqualTo("ACCOUNT CREATED!"));

                LoginPage.ContinueAfterCreateAccount();

                var textUserLogged = LoginPage.GetUserLoggued();
                Assert.That(textUserLogged, Is.EqualTo(name));

                LoginPage.closeSession();

            }

        }

        [Test, TestCaseSource(typeof(GetUserData), nameof(GetUserData.UserLogin))]
        public void LoginWithExistingUser_Test(string emailTest, string password)
        {
            var LoginPage = new Pages.LoginForm.LoginPage(Driver);
            LoginPage.LoginWithUserAccount(emailTest, password);

            //Verificamos que el usuario se haya logueado de forma exitosa.
            var textUserLogged = LoginPage.GetUserLoggued();
            Assert.That(textUserLogged, Is.EqualTo(name));
        }

    }
}
