using AutomationPracticeDemo.Tests.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Xml.Linq;

namespace AutomationPracticeDemo.Tests.Pages
{

    public class SignupPage
    {
        private readonly IWebDriver _driver;
        public SignupPage(IWebDriver driver)
        {
            _driver = driver;
        }



        private IWebElement signupemailinput => _driver.FindElement(By.CssSelector("input[data-qa='signup-email']"));
        private IWebElement signupnameinput => _driver.FindElement(By.CssSelector("input[data-qa='signup-name']"));
        private IWebElement signupbutton => _driver.FindElement(By.CssSelector("button[data-qa='signup-button']"));
        private IWebElement titleradio => _driver.FindElement(By.Id("id_gender1"));
        private IWebElement passwordinput => _driver.FindElement(By.Id("password"));
        private IWebElement dayselect => _driver.FindElement(By.Id("days"));
        private IWebElement monthselect => _driver.FindElement(By.Id("months"));
        private IWebElement yearselect => _driver.FindElement(By.Id("years"));
        private IWebElement newslettercheckbox => _driver.FindElement(By.Id("newsletter"));
        private IWebElement firstnameinput => _driver.FindElement(By.Id("first_name"));
        private IWebElement lastnameinput => _driver.FindElement(By.Id("last_name"));
        private IWebElement companyinput => _driver.FindElement(By.Id("company"));
        private IWebElement address1input => _driver.FindElement(By.Id("address1"));
        private IWebElement address2input => _driver.FindElement(By.Id("address2"));
        private IWebElement countryselect => _driver.FindElement(By.Id("country"));
        private IWebElement IWebElementar => _driver.FindElement(By.Id("state"));
        private IWebElement cityinput => _driver.FindElement(By.Id("city"));
        private IWebElement zipcodeinput => _driver.FindElement(By.Id("zipcode"));
        private IWebElement mobilenumberinput => _driver.FindElement(By.Id("mobile_number"));
        private IWebElement createaccountbutton => _driver.FindElement(By.CssSelector("button[data-qa='create-account']"));
        private IWebElement stateinput => _driver.FindElement(By.Id("state"));
        private IWebElement continuebutton => _driver.FindElement(By.ClassName("btn btn-primary"));
        private IWebElement accountcreatedmessage => _driver.FindElement(By.XPath("//b[contains(text(), 'Account Created!')]"));
        private IWebElement loginMessageError => _driver.FindElement(By.XPath("//p[contains(text(), 'Email Address already exist!')]"));



        public void Signup(string name, string email)
        {

            //Se ingresan los datos nombre y correo
            signupnameinput.SendKeys(name);
            signupemailinput.SendKeys(email);
            //click en Signup
            signupbutton.Click();
           
        }

        public void Datosformulario(
    string password,
    string firstName,
    string lastName,
    string company,
    string address1,
    string address2,
    string country,
    string state,
    string city,
    string zipcode,
    string mobileNumber,
    string day = "19",
    string month = "November",
    string year = "1990"
)
{
    //Se ingresan los datos del formulario
    titleradio.Click();
    passwordinput.SendKeys(password);
    dayselect.SendKeys(day);
    monthselect.SendKeys(month);
    yearselect.SendKeys(year);
    newslettercheckbox.Click();
    firstnameinput.SendKeys(firstName);
    lastnameinput.SendKeys(lastName);
    companyinput.SendKeys(company);
    address1input.SendKeys(address1);
    address2input.SendKeys(address2);
    countryselect.SendKeys(country);
    stateinput.SendKeys(state);
    cityinput.SendKeys(city);
    zipcodeinput.SendKeys(zipcode);
    mobilenumberinput.SendKeys(mobileNumber);
    //Click en Create Account
    createaccountbutton.Click();
    //click en continue
    //continuebutton.Click();


}

        public string getTexto()
        {

            string texto = accountcreatedmessage.Text;
            return texto;

        }


        public void continuar()
        {

            continuebutton.Click();

        }
        public string getTextoFallido()
        {

            string texto = loginMessageError.Text;
            return texto;

        }

    }




    }

