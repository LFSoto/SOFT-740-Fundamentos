using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Pages
{
    public class ContactUsPage
    {
        private readonly IWebDriver _driver;
        public ContactUsPage(IWebDriver driver)
        {
            _driver = driver;
        }
        private IWebElement ContactUsButton => _driver.FindElement(By.CssSelector("a[href='/contact_us']"));
        private IWebElement NameImput => _driver.FindElement(By.CssSelector("input[data-qa='name']"));
        private IWebElement EmailImput => _driver.FindElement(By.CssSelector("input[data-qa='email']"));
        private IWebElement SubjectImput => _driver.FindElement(By.CssSelector("input[data-qa='subject']"));
        private IWebElement MessageImput => _driver.FindElement(By.CssSelector("textarea[data-qa='message']"));
        private IWebElement UploadFileImput => _driver.FindElement(By.CssSelector("input[name='upload_file']"));
        private IWebElement SubmitButton => _driver.FindElement(By.CssSelector("input[data-qa='submit-button']"));
        private IWebElement SuccessMessage => _driver.FindElement(By.CssSelector("div.status.alert.alert-success"));

        public void OpenContactUsPage()
        {
            ContactUsButton.Click();
        }

        public bool EmailImputDisplayed()
        {
            return EmailImput.Displayed;
        }

        public bool NameImputDisplayed()
        {
            return EmailImput.Displayed;
        }

        public bool SubjectImputDisplayed()
        {
            return SubjectImput.Displayed;
        }

        //Llena los datos del formulario
        public void FillForm(string name, string email, string subject, string message, string filePath)
        {
            NameImput.SendKeys(name);
            EmailImput.SendKeys(email);
            SubjectImput.SendKeys(subject);
            MessageImput.SendKeys(message);
            UploadFileImput.SendKeys(filePath);
        }

        //Envía el formulario y acepta la alerta

        public void SubmitForm()
        {
            SubmitButton.Click();
        }

        public void AcceptAlert()
        {
            _driver.SwitchTo().Alert().Accept();
        }

        public string GetSuccessMessage()
        {
            return SuccessMessage.Text;
        }
    }


}
