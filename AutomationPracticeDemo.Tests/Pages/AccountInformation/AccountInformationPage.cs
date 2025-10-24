using OpenQA.Selenium;
using AutomationPracticeDemo.Tests.Utils;

namespace AutomationPracticeDemo.Tests.Pages.AccountInformation
{
    public class AccountInformationPage
    {
        private readonly IWebDriver driver;
        private readonly WaitHelper wait;
        private By GenderRadio => By.Id(genderId);
        private string genderId = "$";
        private readonly By PasswordInput = By.Id("password");
        private readonly By FirstNameInput = By.Id("first_name");
        private readonly By LastNameInput = By.Id("last_name");
        private readonly By AddressInput = By.Id("address1");
        private readonly By SelectCountry = By.Id("country");
        private readonly By InputState = By.Id("state");
        private readonly By InputCity = By.Id("city");
        private readonly By InputZipcode = By.Id("zipcode");
        private readonly By InputMobileNumber = By.Id("mobile_number");
        private readonly By ButtonCreateAccount = By.XPath("//button[@data-qa='create-account']");

        //ACCOUNT CREATED!
        private readonly By LabelAccountCreated = By.XPath("//h2[@data-qa='account-created']"); //Account Created!
        private readonly By ButtonContinue = By.XPath("//a[@data-qa='continue-button']"); //Continue

        public AccountInformationPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WaitHelper(driver);
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
            wait.WaitForElementClickable(GenderRadio).Click();
            wait.WaitForElementVisible(PasswordInput).SendKeys(password);
            wait.WaitForElementVisible(FirstNameInput).SendKeys(name);
            wait.WaitForElementVisible(LastNameInput).SendKeys(lastname);
            wait.WaitForElementVisible(AddressInput).SendKeys(address);
            wait.WaitForElementVisible(SelectCountry).SendKeys(country);
            wait.WaitForElementVisible(InputState).SendKeys(state);
            wait.WaitForElementVisible(InputCity).SendKeys(city);
            wait.WaitForElementVisible(InputZipcode).SendKeys(zipCode);
            wait.WaitForElementVisible(InputMobileNumber).SendKeys(mobileNumber);
            // Se hace click en Create Account
            wait.WaitForElementClickable(ButtonCreateAccount).Click();
        }//FillAccountInformation

        public string GetAccountCreatedMessage()
        {
            return wait.WaitForElementVisible(LabelAccountCreated).Text;
        }//GetAccountCreatedMessage

        public void ClickContinueButton()
        {
            wait.WaitForElementClickable(ButtonContinue).Click();
        }//ClickContinueButton
    }//class
}//namespace
