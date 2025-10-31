using Microsoft.VisualBasic.FileIO;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Pages
{
    public class SignUpPage
    {
        private readonly IWebDriver _driver;
        public SignUpPage(IWebDriver driver)
        {
            _driver = driver;
        }
        private IWebElement SignButtom => _driver.FindElement(By.CssSelector("a[href='/login']"));
        private IWebElement NameInput => _driver.FindElement(By.CssSelector("input[data-qa='signup-name']"));
        private IWebElement EmailInput => _driver.FindElement(By.CssSelector("input[data-qa='signup-email']"));
        private IWebElement SubmitButton => _driver.FindElement(By.CssSelector("button[data-qa='signup-button']"));
        private IWebElement GenderFemale => _driver.FindElement(By.Id("id_gender2"));
        private IWebElement PasswordInput => _driver.FindElement(By.Id("password"));
        private IWebElement DaysInput => _driver.FindElement(By.Id("days"));
        private IWebElement MonthsInput => _driver.FindElement(By.Id("months"));
        private IWebElement YearsInput => _driver.FindElement(By.Id("years"));
        private IWebElement SpecialOffersCheckbox => _driver.FindElement(By.Id("optin"));
        private IWebElement FirstNameInput => _driver.FindElement(By.Id("first_name"));
        private IWebElement LastNameInput => _driver.FindElement(By.Id("last_name"));
        private IWebElement CompanyInput => _driver.FindElement(By.Id("company"));
        private IWebElement AddressInput => _driver.FindElement(By.Id("address1"));
        private IWebElement CountryInput => _driver.FindElement(By.Id("country"));
        private IWebElement StateInput => _driver.FindElement(By.Id("state"));
        private IWebElement CityInput => _driver.FindElement(By.Id("city"));
        private IWebElement ZipInput => _driver.FindElement(By.Id("zipcode"));
        private IWebElement PhoneInput => _driver.FindElement(By.Id("mobile_number"));
        private IWebElement CreateAccountButton => _driver.FindElement(By.CssSelector("button[data-qa='create-account']"));
        private IWebElement SuccessMessage => _driver.FindElement(By.CssSelector("h2[data-qa='account-created']"));
        private IWebElement ConfirmationLogin => _driver.FindElement(By.XPath("//a[contains(text(), 'Logged in as')]\r\n"));

        //Abre la página de sign up
        public void SignupOpen()
        {
            SignButtom.Click();
        }
        //Llena los datos básicos
        public void FillBasicData(string name, string email)
        {
            NameInput.SendKeys(name);
            EmailInput.SendKeys(email);
        }

        public void SubmitSignup()
        {
            SubmitButton.Click();
        }

        //Llena los detalles de la cuenta o usuario a registrar
        public void FillAccountDetails(string password, string day, string month,string year)
        {
            GenderFemale.Click();
            PasswordInput.SendKeys(password);
            DaysInput.SendKeys(day);
            MonthsInput.SendKeys(month);
            YearsInput.SendKeys(year);
            SpecialOffersCheckbox.Click();
        }

        //Llena la información de dirección
        public void FillAddressInfo(string firstname, string lastname, string company, string address, string country, string state, string city, string zip, string phone)
        {
            FirstNameInput.SendKeys(firstname);
            LastNameInput.SendKeys(lastname);
            CompanyInput.SendKeys(company);
            AddressInput.SendKeys(address);
            CountryInput.SendKeys(country);
            StateInput.SendKeys(state);
            CityInput.SendKeys(city);
            ZipInput.SendKeys(zip);
            PhoneInput.SendKeys(phone);
        }

        public void CreateAccount()
        {
            CreateAccountButton.Click();
        }

        public string GetSuccessMessage()
        {
            return SuccessMessage.Text;
        }
        public void Continue()
        {
            var continueButton = _driver.FindElement(By.CssSelector("a[data-qa='continue-button']"));
            continueButton.Click();

        }
        public string GetConfirmationLogin()
        {
            return ConfirmationLogin.Text;
        }
    }
}
