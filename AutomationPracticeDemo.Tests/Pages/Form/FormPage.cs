using OpenQA.Selenium;

namespace AutomationPracticeDemo.Tests.Pages.Form
{
    public class FormPage
    {
        private readonly IWebDriver _driver;

        public FormPage(IWebDriver driver)
        {
            _driver = driver;
        }//ctor

        private IWebElement LabelTitle => _driver.FindElement(By.ClassName("title"));
        private IWebElement NameInput => _driver.FindElement(By.Id("name"));
        private IWebElement EmailInput => _driver.FindElement(By.Id("email"));
        private IWebElement PhoneInput => _driver.FindElement(By.Id("phone"));
        private IWebElement AddressInput => _driver.FindElement(By.Id("textarea"));
        private IWebElement GenderRadio => _driver.FindElement(By.Id(_genderMaleId));
        private string _genderMaleId = "$";
        private IWebElement DayCheckBox => _driver.FindElement(By.Id(_dayId));
        private string _dayId = "$"; //Dynamic value
        private IWebElement ColorList => _driver.FindElement(By.XPath("//select[@id='colors']//option[@value='"+_colorId+"']"));
        private string _colorId = "$"; //Dynamic value
        private IWebElement AnimalList => _driver.FindElement(By.XPath("//select[@id='animals']//option[@value='"+_AnimalId+"']"));
        private string _AnimalId = "$"; //Dynamic value
        private IWebElement DatePicker1 => _driver.FindElement(By.Id("datepicker"));
        private IWebElement DatePicker2 => _driver.FindElement(By.Id("txtDate"));
        private IWebElement DatePicker2DaySelectorId => _driver.FindElement(By.XPath("//a[@data-date='"+_datePicker2DaySelectorId+"']"));
        private string _datePicker2DaySelectorId = "$"; //Dynamic value
        private IWebElement CountryDropdown => _driver.FindElement(By.Id("country"));
        private IWebElement SubmitButton => _driver.FindElement(By.ClassName("submit-btn"));

        public void FillForm(string name, string email, string phone, string country)
        {
            NameInput.SendKeys(name);
            EmailInput.SendKeys(email);
            PhoneInput.SendKeys(phone);
            CountryDropdown.SendKeys(country);
        }//FillForm

        public void FillForm2(string name, string email, string phone, string address, string gender, 
            string day, string country, string color, string animal, string date)
        {
            NameInput.SendKeys(name);
            EmailInput.SendKeys(email);
            PhoneInput.SendKeys(phone);
            AddressInput.SendKeys(address);
            CountryDropdown.SendKeys(country);
            SetGenderId(gender);
            SetDayId(day);
            SetColorId(color);
            SetAnimalId(animal);
            SetDate2(date);
            SetDate1();
        }//FillForm

        public void SetGenderId(string gender)
        {
            _genderMaleId = gender.ToLower();
            GenderRadio.Click();
        }//SetGenderId

        public void SetDayId(string day)
        {
            _dayId = day.ToLower();
            DayCheckBox.Click();
        }//SetDayId

        public void SetColorId(string color)
        {
            _colorId = color.ToLower();
            ColorList.Click();
        }//SetColorId

        public void SetAnimalId(string animal)
        {
            _AnimalId = animal.ToLower();
            AnimalList.Click();
        }//SetAnimalId

        public void SetDate1()
        {
            var date = DateTime.Now.ToString("MM/dd/yyyy");
            DatePicker1.SendKeys(date);
        }//SetDate1
        public void SetDate2(string date)
        {
            //dd/mm/yyyy
            DatePicker2.Click();
            _datePicker2DaySelectorId = date.Split('/')[0]; //Get day
            Console.WriteLine("DIA!!!: "+_datePicker2DaySelectorId);
            DatePicker2DaySelectorId.Click();
        }//SetDate2
        public void Submit()
        {
            SubmitButton.Click();
        }//Submit

        public string GetLabelTitle()
        {
            return LabelTitle.Text;
        }//GetLabelTitle

        public string GetName()
        {
            return NameInput.GetAttribute("value") ?? string.Empty;
        }//GetName

        public string GetAddress()
        {
            return AddressInput.GetAttribute("value") ?? string.Empty;
        }//GetAddress

        public string GetPhone()
        {
            return PhoneInput.GetAttribute("value") ?? string.Empty;
        }//GetPhone

        public string GetEmail()
        {
            return EmailInput.GetAttribute("value") ?? string.Empty;
        }//GetEmail

        public string GetGender()
        {
            return  GenderRadio.GetAttribute("value") ?? string.Empty;
        }//GetGender

        public string GetDay()
        {
            return DayCheckBox.GetAttribute("value") ?? string.Empty;
        }//GetDay

        public string GetCountry()
        {
            return CountryDropdown.GetAttribute("value") ?? string.Empty;
        }//GetCountry
    }//class
}//namespace
