using OpenQA.Selenium;

namespace AutomationPracticeDemo.Tests.Pages.AutomationExercise
{
    public class ContactUsPage
    {
        private readonly IWebDriver driver;
        private IWebElement InputName => driver.FindElement(By.Name("name"));
        private IWebElement InputEmail => driver.FindElement(By.Name("email"));
        private IWebElement InputSubject => driver.FindElement(By.Name("subject"));
        private IWebElement InputMessage => driver.FindElement(By.Id("message"));
        private IWebElement ButtonUploadFile => driver.FindElement(By.Name("upload_file"));
        private IWebElement ButtonSubmit => driver.FindElement(By.Name("submit"));
        private IWebElement LabelSuccessMessage => driver.FindElement(By.XPath("//div[@class='status alert alert-success']")); //Success! Your details have been submitted successfully.

        public ContactUsPage(IWebDriver driver)
        {
            this.driver = driver;
        }//ctor

        public void FillContactForm(string name, string email, string subject, string message, string fileName)
        {
            // Se construye la ruta completa del archivo a subir
            var relativePath = Path.Combine("..", "..", "..", "UploadImages", fileName);
            var fullPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, relativePath)); //SOFT-740-Fundamentos\AutomationPracticeDemo.Tests\UploadImages
            InputName.SendKeys(name);
            InputEmail.SendKeys(email);
            InputSubject.SendKeys(subject);
            InputMessage.SendKeys(message);
            ButtonUploadFile.SendKeys(fullPath);
            ButtonSubmit.Click();
        }//FillContactForm

        public void AcceptAlert()
        {
            var alert = driver.SwitchTo().Alert();
            alert.Accept();
        }//AcceptAlert

        public void ClickSubmit()
        {
            ButtonSubmit.Click();
        }//ClickSubmit

        public string GetSuccessMessage()
        {
            return LabelSuccessMessage.Text;
        }//GetSuccessMessage

    }//class
}//namespace
