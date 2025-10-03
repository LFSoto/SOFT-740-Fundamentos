using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Pages
{
    public class FromPagePractica2
    {
        private readonly IWebDriver _driver;

        public FromPagePractica2(IWebDriver driver) {

            _driver = driver;
        }

        private IWebElement NameInput => _driver.FindElement(By.Id("name"));
        private IWebElement EmailInput => _driver.FindElement(By.Id("email"));
        private IWebElement PhoneInput => _driver.FindElement(By.Id("phone"));
        private IWebElement AddressInpunt => _driver.FindElement(By.Id("textarea"));
        private IWebElement CountryDropdown => _driver.FindElement(By.Id("country"));
        private IWebElement SubmitButton => _driver.FindElement(By.ClassName("submit-btn"));
        private IWebElement RadioButtons => _driver.FindElement(By.Id("female"));

        private IWebElement ColorDropdown => _driver.FindElement(By.Id("colors"));

        private IWebElement AnimalDropdown => _driver.FindElement(By.Id("animals"));


        public void Frm_Complete(string name, string email, string phone, string address,string country)
        {
            NameInput.SendKeys(name);
            EmailInput.SendKeys(email);
            PhoneInput.SendKeys(phone);
            AddressInpunt.SendKeys(address);
            CountryDropdown.SendKeys(country);
        }


        public void Ck_box_dia() {

            List<string> checkboxId = new List<string> { "tuesday", "wednesday", "thursday" };


            foreach (string id in checkboxId)
            {
                IWebElement checkbox = _driver.FindElement(By.Id(id));

                    checkbox.Click();           
            }

        }


        public void rb_ClickGender() {

            RadioButtons.Click();
        
        }

        public void drop_Color() {

            SelectElement selectColor = new SelectElement(ColorDropdown);
            selectColor.SelectByText("Green");
            
        }


        public void drop_Animal()
        {

            SelectElement selectColor = new SelectElement(AnimalDropdown);
            selectColor.SelectByText("Lion");

        }

    }

}
