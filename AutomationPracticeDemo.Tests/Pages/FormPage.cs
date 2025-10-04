using OpenQA.Selenium;

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

        public void FillForm(string name, string email, string phone, string country, string gender)
        {
            NameInput.SendKeys(name);
            EmailInput.SendKeys(email);
            PhoneInput.SendKeys(phone);
            CountryDropdown.SendKeys(country);
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

        public void Submit()
        {
            SubmitButton.Click();
        }
        public void Submit2()
        {
            buttonfile.Click();
        }
    }
}
