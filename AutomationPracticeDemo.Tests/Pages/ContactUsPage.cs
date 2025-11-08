using AutomationPracticeDemo.Tests.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationPracticeDemo.Tests.Pages
{
    public class ContactUsPage
    {
        private readonly IWebDriver _driver;
        private WebDriverWait _wait;

        public ContactUsPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement _nameTextbox => _driver.FindElement(By.Name("name"));
        public IWebElement _emailTextbox => _driver.FindElement(By.Name("email"));
        public IWebElement _subjectTextbox => _driver.FindElement(By.Name("subject"));
        public IWebElement _messageTextbox => _driver.FindElement(By.Id("message"));
        public IWebElement _uploadFileInput => _driver.FindElement(By.Name("upload_file"));
        public IWebElement _submitButton => _driver.FindElement(By.Name("submit"));
        public IWebElement _alertSuccess => _wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("alert-success")));

        public void FillForm(string name, string email, string subject, string message)
        {
            _nameTextbox.SendKeys(name);
            _emailTextbox.SendKeys(email);
            _subjectTextbox.SendKeys(subject);
            _messageTextbox.SendKeys(message);
        }

        public void AttachFile(string fileName)
        {
            GetPathHelper getPathHelper = new GetPathHelper();
            _uploadFileInput.SendKeys(getPathHelper.GetFilePathUpload(fileName));
        }

        public void SubmitForm()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", _submitButton);
            _submitButton.Click();
        }

        public void ConfirmAlertMessage()
        {
            _driver.SwitchTo().Alert().Accept();
        }

        public string GetAlertSuccessActualText()
        {
            return _alertSuccess.Text;
        }
    }
}
