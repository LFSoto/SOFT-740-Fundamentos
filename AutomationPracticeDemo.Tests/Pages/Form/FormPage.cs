using System;
using OpenQA.Selenium;
using AutomationPracticeDemo.Tests.Utils;

namespace AutomationPracticeDemo.Tests.Pages.Form
{
    public class FormPage
    {
        private readonly IWebDriver _driver;
        private readonly WaitHelper _wait;

        public FormPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WaitHelper(driver);
        }//ctor

        private By LabelTitle => By.ClassName("title");
        private By NameInput => By.Id("name");
        private By EmailInput => By.Id("email");
        private By PhoneInput => By.Id("phone");
        private By AddressInput => By.Id("textarea");
        private By GenderRadio => By.Id(_genderMaleId);
        private string _genderMaleId = "$";
        private By DayCheckBox => By.Id(_dayId);
        private string _dayId = "$"; //Dynamic value
        private By ColorList => By.XPath("//select[@id='colors']//option[@value='"+_colorId+"']");
        private string _colorId = "$"; //Dynamic value
        private By AnimalList => By.XPath("//select[@id='animals']//option[@value='"+_AnimalId+"']");
        private string _AnimalId = "$"; //Dynamic value
        private By DatePicker1 => By.Id("datepicker");
        private By DatePicker2 => By.Id("txtDate");
        private By DatePicker2DaySelectorId => By.XPath("//a[@data-date='"+_datePicker2DaySelectorId+"']");
        private string _datePicker2DaySelectorId = "$"; //Dynamic value
        private By CountryDropdown => By.Id("country");
        private By SubmitButton => By.ClassName("submit-btn");

        public void FillForm(string name, string email, string phone, string country)
        {
            _wait.WaitForElementVisible(NameInput).SendKeys(name);
            _wait.WaitForElementVisible(EmailInput).SendKeys(email);
            _wait.WaitForElementVisible(PhoneInput).SendKeys(phone);
            _wait.WaitForElementVisible(CountryDropdown).SendKeys(country);
        }//FillForm

        public void FillForm2(string name, string email, string phone, string address, string gender, 
            string day, string country, string color, string animal, string date)
        {
            _wait.WaitForElementVisible(NameInput).SendKeys(name);
            _wait.WaitForElementVisible(EmailInput).SendKeys(email);
            _wait.WaitForElementVisible(PhoneInput).SendKeys(phone);
            _wait.WaitForElementVisible(AddressInput).SendKeys(address);
            _wait.WaitForElementVisible(CountryDropdown).SendKeys(country);
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
            _wait.WaitForElementClickable(GenderRadio).Click();
        }//SetGenderId

        public void SetDayId(string day)
        {
            _dayId = day.ToLower();
            _wait.WaitForElementClickable(DayCheckBox).Click();
        }//SetDayId

        public void SetColorId(string color)
        {
            _colorId = color.ToLower();
            _wait.WaitForElementClickable(ColorList).Click();
        }//SetColorId

        public void SetAnimalId(string animal)
        {
            _AnimalId = animal.ToLower();
            _wait.WaitForElementClickable(AnimalList).Click();
        }//SetAnimalId

        public void SetDate1()
        {
            var date = DateTime.Now.ToString("MM/dd/yyyy");
            _wait.WaitForElementVisible(DatePicker1).SendKeys(date);
        }//SetDate1
        public void SetDate2(string date)
        {
            //dd/mm/yyyy
            _wait.WaitForElementClickable(DatePicker2).Click();
            _datePicker2DaySelectorId = date.Split('/')[0]; //Get day
            Console.WriteLine("DIA!!!: "+_datePicker2DaySelectorId);
            _wait.WaitForElementClickable(DatePicker2DaySelectorId).Click();
        }//SetDate2
        public void Submit()
        {
            _wait.WaitForElementClickable(SubmitButton).Click();
        }//Submit

        public string GetLabelTitle()
        {
            return _wait.WaitForElementVisible(LabelTitle).Text;
        }//GetLabelTitle

        public string GetName()
        {
            return _wait.WaitForElementVisible(NameInput).GetAttribute("value") ?? string.Empty;
        }//GetName

        public string GetAddress()
        {
            return _wait.WaitForElementVisible(AddressInput).GetAttribute("value") ?? string.Empty;
        }//GetAddress

        public string GetPhone()
        {
            return _wait.WaitForElementVisible(PhoneInput).GetAttribute("value") ?? string.Empty;
        }//GetPhone

        public string GetEmail()
        {
            return _wait.WaitForElementVisible(EmailInput).GetAttribute("value") ?? string.Empty;
        }//GetEmail

        public string GetGender()
        {
            return  _wait.WaitForElementVisible(GenderRadio).GetAttribute("value") ?? string.Empty;
        }//GetGender

        public string GetDay()
        {
            return _wait.WaitForElementVisible(DayCheckBox).GetAttribute("value") ?? string.Empty;
        }//GetDay

        public string GetCountry()
        {
            return _wait.WaitForElementVisible(CountryDropdown).GetAttribute("value") ?? string.Empty;
        }//GetCountry
    }//class
}//namespace
