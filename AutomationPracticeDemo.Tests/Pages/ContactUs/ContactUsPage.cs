using System.IO;
using OpenQA.Selenium;
using AutomationPracticeDemo.Tests.Utils;

namespace AutomationPracticeDemo.Tests.Pages.ContactUs
{
    public class ContactUsPage  
    {
        private readonly IWebDriver driver;
        private readonly WaitHelper wait;

        private readonly By InputName = By.Name("name");
        private readonly By InputEmail = By.Name("email");
        private readonly By InputSubject = By.Name("subject");
        private readonly By InputMessage = By.Id("message");
        private readonly By ButtonUploadFile = By.Name("upload_file");
        private readonly By ButtonSubmit = By.Name("submit");
        private readonly By LabelSuccessMessage = By.XPath("//div[@class='status alert alert-success']"); //Success! Your details have been submitted successfully.

        public ContactUsPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WaitHelper(driver);
        }//ctor

        public void FillContactForm(string name, string email, string subject, string message, string fileName)
        {
            // Se construye la ruta completa del archivo a subir
            var relativePath = Path.Combine("..", "..", "..", "UploadImages", fileName);
            var fullPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, relativePath)); //SOFT-740-Fundamentos\AutomationPracticeDemo.Tests\UploadImages

            wait.WaitForElementVisible(InputName).SendKeys(name);
            wait.WaitForElementVisible(InputEmail).SendKeys(email);
            wait.WaitForElementVisible(InputSubject).SendKeys(subject);
            wait.WaitForElementVisible(InputMessage).SendKeys(message);
            wait.WaitForElementVisible(ButtonUploadFile).SendKeys(fullPath);
            wait.WaitForElementClickable(ButtonSubmit).Click();
        }//FillContactForm

        public void AcceptAlert()
        {
            var alert = wait.WaitForAlert();
            alert?.Accept();
        }//AcceptAlert

        public void ClickSubmit()
        {
            wait.WaitForElementClickable(ButtonSubmit).Click();
        }//ClickSubmit

        public string GetSuccessMessage()
        {
            var el = wait.WaitForElementVisible(LabelSuccessMessage);
            return el?.Text ?? string.Empty;
        }//GetSuccessMessage

    }//class
}//namespace
