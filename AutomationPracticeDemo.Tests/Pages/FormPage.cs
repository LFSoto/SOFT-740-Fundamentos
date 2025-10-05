using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Xml.Linq;

namespace AutomationPracticeDemo.Tests.Pages
{
    public class FormPage
    {
        private readonly IWebDriver _driver;
       

        public FormPage(IWebDriver driver)
        {
            _driver = driver;
            
            
        }

        private IWebElement NameInput => _driver.FindElement(By.Id("name"));
        private IWebElement EmailInput => _driver.FindElement(By.Id("email"));
        private IWebElement PhoneInput => _driver.FindElement(By.Id("phone"));
        private IWebElement CountryDropdown => _driver.FindElement(By.Id("country"));
        private IWebElement SubmitButton => _driver.FindElement(By.ClassName("submit-btn"));
        private IWebElement maleGenderRadioButtons=> _driver.FindElement(By.Id("male"));
        private IWebElement femaleGenderRadioButtons => _driver.FindElement(By.Id("female"));
        private IWebElement selectfile=> _driver.FindElement(By.Id("singleFileInput"));
        private IWebElement buttonfile => _driver.FindElement(By.CssSelector("#singleFileForm button"));
        //private IWebElement colorsselect => _driver.FindElement(By.Id("colors"));
        private IWebElement colorRedsselect => _driver.FindElement(By.CssSelector("option[value=red]"));
        private IWebElement colorYellowsselect => _driver.FindElement(By.CssSelector("option[value=yellow]"));
        private IWebElement colorGreensselect => _driver.FindElement(By.CssSelector("option[value=green]"));
        private IWebElement colorBluesselect => _driver.FindElement(By.CssSelector("option[value=blue]"));
        private IWebElement colorWhitesselect => _driver.FindElement(By.CssSelector("option[value=white]"));
        private IWebElement Field2Input => _driver.FindElement(By.Id("field2"));
        
   

            public void FillForm(string name, string email, string phone, string country)
        {
            NameInput.SendKeys(name);
            EmailInput.SendKeys(email);
            PhoneInput.SendKeys(phone);
            CountryDropdown.SendKeys(country);
           
                
        }
        public void Gender(string gender)
        {

            if (gender.Equals("male"))
            {
                maleGenderRadioButtons.Click();
            }
            else { femaleGenderRadioButtons.Click(); }
        }

        public void Selectfile(string rutaImagen = @"C:\Users\Kenneth\OneDrive\Imágenes\Selenium_Logo.png")
        {

            selectfile.SendKeys(rutaImagen);
        }

        public void field2Input(string Field,string Field2)
        {
           
            Field2Input.SendKeys(Field);
            Field2Input.Clear();
            Field2Input.SendKeys(Field2);

        }

        public void Colorsselect(string COLOR)
        {
            


            if (COLOR.Equals("Red"))
            {
                colorRedsselect.Click();
            }
            else if (COLOR.Equals("blue"))
            {
                colorBluesselect.Click();
            }
            else if (COLOR.Equals("green"))
            {
                colorGreensselect.Click();
            }
            else if (COLOR.Equals("yellow"))
            {
                colorYellowsselect.Click();

            }
            else if (COLOR.Equals("white"));
            {
                colorWhitesselect.Click();

            }

        }



        public void Submit()
        {
            SubmitButton.Click();
        }
       
    }
}
