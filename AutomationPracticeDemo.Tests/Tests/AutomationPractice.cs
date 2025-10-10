using AutomationPracticeDemo.Tests.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
        static readonly int random = new Random().Next(1, 1000);
        static readonly string email = "SOFT-740" + random + "@cenfotec.com";
        const string password = "SOFT-740";

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
            loginTest();
            //definición de los web elements

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
    }
}
