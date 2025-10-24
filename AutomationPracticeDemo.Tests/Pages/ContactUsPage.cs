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

        public IWebElement NameTextbox => _driver.FindElement(By.Name("name"));
        public IWebElement EmailTextbox => _driver.FindElement(By.Name("email"));
        public IWebElement SubjectTextbox => _driver.FindElement(By.Name("subject"));
        public IWebElement MessageTextbox => _driver.FindElement(By.Id("message"));
        public IWebElement UploadFileInput => _driver.FindElement(By.Name("upload_file"));
        public IWebElement SubmitButton => _driver.FindElement(By.Name("submit"));
        public string AlertSuccessActualText => _wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("alert-success"))).Text;
    }
}
