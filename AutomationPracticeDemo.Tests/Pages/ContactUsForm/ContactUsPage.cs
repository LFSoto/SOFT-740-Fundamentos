using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Pages.ContactUsForm
{
    public class ContactUsPage
    {

        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public ContactUsPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement contactUsFormBtn => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector("li a[href=\"/contact_us\"]")));
        private IWebElement tituloContactUs => _driver.FindElement(By.CssSelector("h2.title.text-center"));
        
        //2. Completar nombre, email, asunto y mensaje. 

        private IWebElement _inputName => _driver.FindElement(By.CssSelector("input[data-qa='name']"));
        private IWebElement _inputEmail => _driver.FindElement(By.CssSelector("input[data-qa='email']"));
        private IWebElement _inputSubject => _driver.FindElement(By.CssSelector("input[data-qa='subject']"));
        private IWebElement _inputMessage => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector("textarea[data-qa='message']")));

        public void contactUsForm()
        {
            contactUsFormBtn.Click();
        }
        public string Get_titleContactUs()
        {//Verificamos que la cuenta se haya creado de forma exitosa.

            var user = tituloContactUs.Text;
            return user;
        }
        public void fillOutFormContactUs(string inputName, string inputEmail, string inputSubject, string inputMessage)
        {
            _inputName.SendKeys(inputName);
            _inputEmail.SendKeys(inputEmail);
            _inputSubject.SendKeys(inputSubject);
            _inputMessage.SendKeys(inputMessage);
        }
        public void subirArchivo()
        {
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Utils\Practica3.pdf");
            var uploadFileInput = _driver.FindElement(By.CssSelector("input[name='upload_file']"));
            uploadFileInput.SendKeys(Path.GetFullPath(rutaArchivo));
        }
        public void submitButtonContactUs()
        {
            var submitBtn = _driver.FindElement(By.CssSelector("input[data-qa='submit-button']"));
            submitBtn.Click();
        }
        public string Get_textAlert()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());

            var alert = _driver.SwitchTo().Alert();
            return alert?.Text ?? string.Empty;


           //return _driver.SwitchTo().Alert().Text;
        }
        public void AcceptAlert()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            _driver.SwitchTo().Alert().Accept();
        }
        public string validateSuccessMesaje()
        {
            var successMessage = _driver.FindElement(By.CssSelector("div.status.alert.alert-success"));

            return successMessage.Text.Trim();
        }
    }
}
