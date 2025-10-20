using AutomationPracticeDemo.Tests.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Xml.Linq;

namespace AutomationPracticeDemo.Tests.Pages
{

    public class LoginPage 
    {
        private readonly IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }



        private IWebElement signupemailinput => _driver.FindElement(By.CssSelector("input[data-qa='signup-email']"));
        private IWebElement signupnameinput => _driver.FindElement(By.CssSelector("input[data-qa='signup-name']"));
        private IWebElement signupbutton => _driver.FindElement(By.CssSelector("button[data-qa='signup-button']"));

        private IWebElement Loginemail => _driver.FindElement(By.CssSelector("input[data-qa='login-email']"));
        private IWebElement Loginpassword => _driver.FindElement(By.CssSelector("input[data-qa='login-password']"));
        private IWebElement Loginbutton => _driver.FindElement(By.CssSelector("button[data-qa='login-button']"));
        private IWebElement loginMessage => _driver.FindElement(By.XPath("//a[i[@class='fa fa-user']]"));

        private IWebElement loginMessageError => _driver.FindElement(By.XPath("//p[contains(text(), 'Your email or password is incorrect!')]"));


        public void Signup(string name, string email)
       {

            //Se ingresan los datos nombre y correo
            signupnameinput.SendKeys(name);
            signupemailinput.SendKeys(email);
            //click en Signup
            signupbutton.Click();
        }
    public void Login(string email, string password)
        {

            //Se ingresan los datos email y password
            Loginemail.SendKeys(email);
            Loginpassword.SendKeys(password);
            //click en Signup
            Loginbutton.Click();
        }


        public string getTexto() 
        {

            string texto = loginMessage.Text;
            return texto;

        }
        public string getTextoFallido()
        {

            string texto = loginMessageError.Text;
            return texto;

        }

        public string getSignuplogin()
        {

            string texto = loginMessageError.Text;
            return texto;

        }

    }
}
