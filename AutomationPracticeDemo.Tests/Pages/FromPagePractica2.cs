using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Pages
{
    public class FromPagePractica2
    {
        //Variables

        public string ValorNombre { get; private set; }
        public string ValorCorreo { get; private set; }
        public string ValorTelefono { get; private set; }
        public string ValorDireccion { get; private set; }
        public string TextoAlerta { get; private set; }
        public string TextoField2 { get; set; }


        private readonly IWebDriver _driver;
        private string diaActual = DateTime.Now.Day.ToString();
        

        private IWebElement NameInput => _driver.FindElement(By.Id("name"));
        private IWebElement EmailInput => _driver.FindElement(By.Id("email"));
        private IWebElement PhoneInput => _driver.FindElement(By.Id("phone"));
        private IWebElement AddressInpunt => _driver.FindElement(By.Id("textarea"));
        private IWebElement CountryDropdown => _driver.FindElement(By.Id("country"));
        private IWebElement CopyButton => _driver.FindElement(By.CssSelector("div.widget-content button[ondblclick='myFunction1()']"));
        private IWebElement RadioButtons => _driver.FindElement(By.Id("female"));
        private IWebElement ColorDropdown => _driver.FindElement(By.Id("colors"));
        private IWebElement AnimalDropdown => _driver.FindElement(By.Id("animals"));
        private IWebElement date1DataPickerClic => _driver.FindElement(By.Id("datepicker"));
        private IWebElement date1Selectday => _driver.FindElement(By.CssSelector($"table.ui-datepicker-calendar td a.ui-state-default[data-date='{diaActual}']"));
        private IWebElement simpleAlertInpunt => _driver.FindElement(By.Id("alertBtn"));
        private IWebElement field2Inpunt => _driver.FindElement(By.CssSelector("div.widget-content input[id='field2']"));


        //Construtores
        public FromPagePractica2(IWebDriver driver)
        {
            _driver = driver;
        }


        //Metodos
        public void Txt_Box(string name, string email, string phone, string address)
        {
            NameInput.SendKeys(name);
            EmailInput.SendKeys(email);
            PhoneInput.SendKeys(phone);
            AddressInpunt.SendKeys(address);
        }

        public void Cargar_Valores_Txt_Box() 
        {
            ValorNombre = NameInput.GetAttribute("value") ?? string.Empty;
            ValorCorreo = EmailInput.GetAttribute("value") ?? string.Empty;
            ValorTelefono = PhoneInput.GetAttribute("value") ?? string.Empty;
            ValorDireccion = AddressInpunt.GetAttribute("value") ?? string.Empty;
        }

        public void Drop_Downs() 
        {
            CountryDropdown.SendKeys("France");
            SelectElement selectColor = new SelectElement(ColorDropdown);
            selectColor.SelectByText("Green");
            SelectElement selectAnimal = new SelectElement(AnimalDropdown);
            selectAnimal.SelectByText("Lion");
        }

        public void Ck_box_dia() 
        {
            List<string> checkboxId = new List<string> { "tuesday", "wednesday", "thursday" };
            foreach (string id in checkboxId)
            {
                IWebElement checkbox = _driver.FindElement(By.Id(id));
                    checkbox.Click();           
            }
        }

        public void rb_ClickGender()
        {
            RadioButtons.Click();
        }

        public void put_Date1() 
        {
            date1DataPickerClic.Click();
            date1Selectday.Click();
        }

        public void put_simpleAlert() 
        {
            simpleAlertInpunt.Click();
        }

        public void validate_Alert() {
            try
            {
                IAlert alert = _driver.SwitchTo().Alert();
                System.Threading.Thread.Sleep(2000);
                TextoAlerta = alert.Text ?? string.Empty;
                alert.Accept();
                
            }
            catch (NoAlertPresentException)
            {
               
            }

        }

        public void copy_btn() 
        {
            Actions actions = new Actions(_driver);
            actions.DoubleClick(CopyButton).Perform();  
        }

        public void fiel2_txt() 
        {
            TextoField2 = field2Inpunt.GetAttribute("value") ?? string.Empty;
        }



    }

}
