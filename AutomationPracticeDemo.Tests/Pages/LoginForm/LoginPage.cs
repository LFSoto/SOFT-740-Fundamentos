using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutomationPracticeDemo.Tests.Pages.LoginForm
{

    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        //SignupLoginTest()
        private IWebElement LoginButton => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector("li a[href='/login']")));
        public string LoginButtonColor => _driver.FindElement(By.CssSelector("li a[href='/login']")).GetCssValue("color");

        //NewUserTest() - Signup
        private IWebElement nameInput => _driver.FindElement(By.CssSelector("input[data-qa='signup-name']"));
        private IWebElement emailInput => _driver.FindElement(By.CssSelector("input[data-qa='signup-email']"));
        private IWebElement submit => _driver.FindElement(By.CssSelector("button[data-qa='signup-button']"));
        //public string GetTexttitleEnterAccount => _driver.FindElement(By.CssSelector("#form > div > div > div > div.login-form > h2 > b")).Text;
        //public string GetTexttitleEnterAccount => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector("#form > div > div > div > div.login-form > h2 > b"))).Text;
        public string GetTexttitleEnterAccount => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("(//div[@class='login-form']//h2)[1]/b"))).Text;

        private IWebElement titleRadButton => _driver.FindElement(By.Id("id_gender2"));
        private IWebElement InputName => _driver.FindElement(By.CssSelector("input[data-qa=\"name\"]"));
        private IWebElement InputPassword => _driver.FindElement(By.CssSelector("input[data-qa=\"password\"]"));
        private IWebElement DropDownDay => _driver.FindElement(By.Id("password"));
        private IWebElement DropDownMonth => _driver.FindElement(By.Id("months"));
        private IWebElement DropDownYear => _driver.FindElement(By.Id("years"));

        //campos del address information
        private IWebElement inputFirstName => _driver.FindElement(By.Id("first_name"));
        private IWebElement inputLastName => _driver.FindElement(By.Id("last_name"));
        private IWebElement inputCompanyName => _driver.FindElement(By.Id("company"));
        private IWebElement inputAddress1 => _driver.FindElement(By.Id("address1"));
        private IWebElement inputAddress2 => _driver.FindElement(By.Id("address2"));
        private IWebElement DropDownCountry => _driver.FindElement(By.Id("country"));
        private IWebElement inputState => _driver.FindElement(By.Id("state"));
        private IWebElement inputCity => _driver.FindElement(By.Id("city"));
        private IWebElement inputZipCode => _driver.FindElement(By.Id("zipcode"));
        private IWebElement inputMobileNumb => _driver.FindElement(By.Id("mobile_number"));

        private IWebElement submitCreateAccount => _driver.FindElement(By.CssSelector("button[data-qa='create-account']"));
        private IWebElement GetSuccessMessage => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//b[normalize-space()='Account Created!']")));

        private IWebElement ContinueButton => _driver.FindElement(By.CssSelector("div a[data-qa='continue-button']"));
        //private IWebElement GetuserLoggued => _driver.FindElement(By.CssSelector("#header > div > div > div > div.col-sm-8 > div > ul > li:nth-child(10) > a > b"));
        private IWebElement GetuserLoggued => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector("#header > div > div > div > div.col-sm-8 > div > ul > li:nth-child(10) > a > b")));

        private IWebElement userLogOut => _driver.FindElement(By.CssSelector("#header > div > div > div > div.col-sm-8 > div > ul > li:nth-child(4) > a"));

        //Campos para ingresar con datos existentes "Login"
        private IWebElement emailInputLogin => _driver.FindElement(By.CssSelector("input[data-qa='login-email']"));
        private IWebElement PasswordInputLogin => _driver.FindElement(By.CssSelector("input[data-qa='login-password']"));
        private IWebElement submitLogin => _driver.FindElement(By.CssSelector("button[data-qa='login-button']"));


        public void SignupLogin()
        {
            LoginButton.Click();
        }
        public void NewUser(string name, string email) 
        {            
            nameInput.SendKeys(name);//se ingresa el nombre
            emailInput.SendKeys(email); //se ingresa el correo          
            submit.Click();//se da click en el botón Signup
        }
        public void EnterAccountInfo(string _password, string _dropDownDay, string _dropDownMonth, string _dropDownYear, string _inputFirstName, string _inputLastName, string _inputCompanyName, string _inputAddress1, string _inputAddress2, string _dropDownCountry, string _inputState, string _inputCity, string _inputZipCode, string _inputMobileNumb)
        {


            //enviamos los campos del "ENTER ACCOUNT INFORMATION"
            titleRadButton.Click();
            InputPassword.SendKeys(_password);
            DropDownDay.SendKeys(_dropDownDay);
            DropDownMonth.SendKeys(_dropDownMonth);
            DropDownYear.SendKeys(_dropDownYear);

            //enviamos los campos del "ADDRESS INFORMATION"
            inputFirstName.SendKeys(_inputFirstName);
            inputLastName.SendKeys(_inputLastName);
            inputCompanyName.SendKeys(_inputCompanyName);
            inputAddress1.SendKeys(_inputAddress1);
            inputAddress2.SendKeys(_inputAddress2);
            DropDownCountry.SendKeys(_dropDownCountry);
            inputState.SendKeys(_inputState);
            inputCity.SendKeys(_inputCity);
            inputZipCode.SendKeys(_inputZipCode);
            inputMobileNumb.SendKeys(_inputMobileNumb);

            //Ubica el botón "Create Account" y se envía el formulario            
            //submitCreateAccount.Click();



        }
        public void _submitCreateAccount()
        {
            //Ubica el botón "Create Account" y se envía el formulario
            submitCreateAccount.Click();
        }
        public string GetCreateAccountMessage()
        {
            var message = GetSuccessMessage.Text;
            return message;
        }

        public string GetUserLoggued()
        {//Verificamos que la cuenta se haya creado de forma exitosa.
     
            var user = GetuserLoggued.Text;
            return user;
        }
        public void ContinueAfterCreateAccount()
        {
            //Continuamos después de crear la cuenta.
            ContinueButton.Click();
        }
        public void closeSession()
        {
            //Cerramos sesión
            userLogOut.Click();
        }
        public void LoginWithUserAccount(string emailTest, string password)
        {
            SignupLogin();//ingresamos al formulario de login.
            
            emailInputLogin.SendKeys(emailTest);//Ingresamos el email, password y click en el botón de "Login".
            PasswordInputLogin.SendKeys(password);
            submitLogin.Click();
        }       
        
    }
}
