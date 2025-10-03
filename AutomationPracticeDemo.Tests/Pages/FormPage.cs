using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutomationPracticeDemo.Tests.Pages
{
    public class FormPage
    {
        private readonly IWebDriver _driver;//se define como lectura

        public FormPage(IWebDriver driver) //contructor
        {
            _driver = driver;
        }
      

        private IWebElement NameInput => _driver.FindElement(By.Id("name"));//#name o input[id´='name']
        private IWebElement EmailInput => _driver.FindElement(By.Id("email"));
        private IWebElement PhoneInput => _driver.FindElement(By.Id("phone"));
        private IWebElement CountryDropdown => _driver.FindElement(By.Id("country"));
        private IWebElement SubmitButton => _driver.FindElement(By.ClassName("submit-btn"));//.submit-btn

        private IWebElement GenderRadioButton => _driver.FindElement(By.Id("male"));
        private IWebElement AddressInput => _driver.FindElement(By.Id("textarea"));
        //despliega el calendario.
        private IWebElement _DatePicker1Input => _driver.FindElement(By.Id("datepicker"));
        //selecciona el día 23.
        private IWebElement DatePicker1_SelectDia => _driver.FindElement(By.CssSelector("#ui-datepicker-div > table > tbody > tr:nth-child(4) > td:nth-child(5)"));

        //Ubica el elemento <select> de la lista.
        public IWebElement SortedList => _driver.FindElement(By.Id("animals"));




        public void FillForm(string name, string email, string phone, string country)
        {
            NameInput.SendKeys(name); //simula que escribe en el elemento - que teclee
            EmailInput.SendKeys(email);
            PhoneInput.SendKeys(phone);
            CountryDropdown.SendKeys(country);
            Thread.Sleep(4000);
            // _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        public void RadButtom()
        {
            GenderRadioButton.Click();
            Thread.Sleep(4000);
        }
        public void _AddressInput()
        {
            AddressInput.SendKeys("Hola este es el texto para la prueba.");
            Thread.Sleep(4000);
        }
        public void DateTimePicker1()
        {
            _DatePicker1Input.Click();
            DatePicker1_SelectDia.Click();
            Thread.Sleep(4000);
        }
        public void SelectSortedList()
        {
            //Instanciar SelectElement: Crea un objeto de la clase SelectElement,
            //pasando el IWebElement del menú desplegable encontrado. 
            SelectElement selectElement = new SelectElement(SortedList);
            //Seleccionamos por índice.
            selectElement.SelectByIndex(3); // Selecciona la 4 opción
            Thread.Sleep(4000);
        }
        public void Submit()
        {
            SubmitButton.Click();
        }
    }
}
