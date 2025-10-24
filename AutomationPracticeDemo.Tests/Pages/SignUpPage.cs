using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationPracticeDemo.Tests.Pages
{
    public class SignUpPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public SignUpPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement MrRadioButton => _driver.FindElement(By.Id("id_gender1"));
        public IWebElement PasswordTextbox => _driver.FindElement(By.Id("password"));
        public IWebElement DaySelect => _driver.FindElement(By.Id("days"));
        public IWebElement MonthSelect => _driver.FindElement(By.Id("months"));
        public IWebElement YearSelect => _driver.FindElement(By.Id("years"));
        public IWebElement NewsLetterCheckBox => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("newsletter")));
        public IWebElement SpecialOffersCheckBox => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("optin")));
        public IWebElement FirstNameTextbox => _driver.FindElement(By.Id("first_name"));
        public IWebElement LastNameTextbox => _driver.FindElement(By.Id("last_name"));
        public IWebElement CompanyTextbox => _driver.FindElement(By.Id("company"));
        public IWebElement Adress1Textbox => _driver.FindElement(By.Id("address1"));
        public IWebElement Adress2Textbox => _driver.FindElement(By.Id("address2"));
        public IWebElement CountrySelect => _driver.FindElement(By.Id("country"));
        public IWebElement StateTextBox => _driver.FindElement(By.Id("state"));
        public IWebElement CityTextBox => _driver.FindElement(By.Id("city"));
        public IWebElement ZipCodeTextBox => _driver.FindElement(By.Id("zipcode"));
        public IWebElement MobileNumberTextBox => _driver.FindElement(By.Id("mobile_number"));
        public IWebElement CreateAccountButton => _driver.FindElement(By.CssSelector("#form button"));
        public string AccountCreatedText => _driver.FindElement(By.CssSelector(".title b")).Text;
        public IWebElement ContinueButton => _driver.FindElement(By.ClassName("btn-primary"));
    }
}
