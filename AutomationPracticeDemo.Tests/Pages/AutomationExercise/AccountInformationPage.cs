using OpenQA.Selenium;

namespace AutomationPracticeDemo.Tests.Pages.AutomationExercise
{
    public class AccountInformationPage
    {
        private readonly IWebDriver driver;
        private IWebElement GenderRadio => driver.FindElement(By.Id(genderId));
        private string genderId = "$";
        private IWebElement PasswordInput => driver.FindElement(By.Id("password"));
        private IWebElement FirstNameInput => driver.FindElement(By.Id("first_name"));
        private IWebElement LastNameInput => driver.FindElement(By.Id("last_name"));
        private IWebElement AddressInput => driver.FindElement(By.Id("address1"));
        private IWebElement SelectCountry => driver.FindElement(By.Id("country"));
        private IWebElement InputState => driver.FindElement(By.Id("state"));
        private IWebElement InputCity => driver.FindElement(By.Id("city"));
        private IWebElement InputZipcode => driver.FindElement(By.Id("zipcode"));
        private IWebElement InputMobileNumber => driver.FindElement(By.Id("mobile_number"));
        private IWebElement ButtonCreateAccount => driver.FindElement(By.XPath("//button[@data-qa='create-account']"));

        //ACCOUNT CREATED!
        private IWebElement LabelAccountCreated => driver.FindElement(By.XPath("//h2[@data-qa='account-created']")); //Account Created!
        private IWebElement ButtonContinue => driver.FindElement(By.XPath("//a[@data-qa='continue-button']")); //Continue

        public AccountInformationPage(IWebDriver driver)
        {
            this.driver = driver;
        }//ctor
        public void SetGenderId(string gender)
        {
            if (gender == "Mr")
            {
                genderId = "id_gender1";
            }//if
            else {
                genderId = "id_gender2";
            }
        }//SetGenderId

        public void FillAccountInformation(string gender, string password, string name, string lastname, string address, string country,
            string state, string city, string zipCode, string mobileNumber)
        {
            SetGenderId(gender);
            GenderRadio.Click();
            PasswordInput.SendKeys(password);
            FirstNameInput.SendKeys(name);
            LastNameInput.SendKeys(lastname);
            AddressInput.SendKeys(address);
            SelectCountry.SendKeys(country);
            InputState.SendKeys(state);
            InputCity.SendKeys(city);
            InputZipcode.SendKeys(zipCode);
            InputMobileNumber.SendKeys(mobileNumber);
            // Se hace click en Create Account
            ButtonCreateAccount.Click();
        }//FillAccountInformation

        public string GetAccountCreatedMessage()
        {
            return LabelAccountCreated.Text;
        }//GetAccountCreatedMessage

        public void ClickContinueButton()
        {
            ButtonContinue.Click();
        }//ClickContinueButton
    }//class
}//namespace
