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
        private IWebElement AddressInput => _driver.FindElement(By.Id("textarea"));
        private IWebElement GenderRadio => _driver.FindElement(By.Id("female"));
        private IWebElement DaysCheckbox => _driver.FindElement(By.Id("tuesday"));
        private IWebElement ColorsDropdown => _driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div[2]/div[2]/div[2]/div[2]/div[2]/div/div[4]/div[1]/div/div/div[1]/div[1]/div/div/div/div/div[2]/div[6]/select/option[2]"));
        private IWebElement CountryDropdown => _driver.FindElement(By.Id("country"));
        private IWebElement SubmitButton => _driver.FindElement(By.ClassName("submit-btn"));
        private IWebElement SuccessMessage => _driver.FindElement(By.ClassName("success-msg"));
        private IWebElement UploadFile => _driver.FindElement(By.Id("singleFileInput"));
        private IWebElement UploadButton => _driver.FindElement(By.CssSelector("#singleFileForm button"));
        private IWebElement UploadSuccessMessage => _driver.FindElement(By.Id("singleFileStatus"));

        //
        public void FillForm(string name, string email, string phone, string country)
        {
            NameInput.SendKeys(name);
            EmailInput.SendKeys(email);
            PhoneInput.SendKeys(phone);
            CountryDropdown.SendKeys(country);

        }

        public void FillForm2(string name, string email, string phone, string address, string country)
        {
            NameInput.SendKeys(name);
            EmailInput.SendKeys(email);
            PhoneInput.SendKeys(phone);
            AddressInput.SendKeys(address);
            GenderRadio.Click();
            DaysCheckbox.Click();
            CountryDropdown.SendKeys(country);
            ColorsDropdown.Click();
        }

        public void UploadSingleFile(string url)
        {

            UploadFile.SendKeys(url);
        }

        public void Submit()
        {
            SubmitButton.Click();
        }

        public void Submit2()
        {
            UploadButton.Click();
        }

        public string GetName()
        {
            return NameInput.GetAttribute("value") ?? string.Empty;
        } 
        public string GetEmail()
        {
            return EmailInput.GetAttribute("value") ?? string.Empty;
        }
        public string GetPhone()
        {
            return PhoneInput.GetAttribute("value") ?? string.Empty;
        }
        public string GetAddress()
        {
            return AddressInput.GetAttribute("value") ?? string.Empty;
        }
        public string GetCountry()
        {
            return CountryDropdown.GetAttribute("value") ?? string.Empty;
        }
        public string GetGender()
        {
            return GenderRadio.GetAttribute("value") ?? string.Empty;
        }
        public string GetDays()
        {
            return DaysCheckbox.GetAttribute("value") ?? string.Empty;
        }

        public string GetColors()
        {
            //return ColorsDropdown.GetAttribute("value") ?? string.Empty;
            return ColorsDropdown.Text;
        }

        public string GetSuccessUploadMessage()
        {
            return UploadSuccessMessage.Text;
        }
    }
}
