using AutomationPracticeDemo.Tests.Utils;
using OpenQA.Selenium;
using System.ComponentModel.DataAnnotations;

namespace AutomationPracticeDemo.Tests.Pages.AutomationExercisePage
{
    public class contactUsPage
    {
        private readonly IWebDriver _driver;


        // Constructor público para permitir la instanciación desde otras clases
        public contactUsPage(IWebDriver driver)
        {
            _driver = driver;
        }

    
        private IWebElement nameinput => _driver.FindElement(By.CssSelector("input[data-qa='name']"));
        private IWebElement emailinput => _driver.FindElement(By.CssSelector("input[data-qa='email']"));
        private IWebElement subjectinput => _driver.FindElement(By.CssSelector("input[data-qa='subject']"));
        private IWebElement messageinput => _driver.FindElement(By.CssSelector("textarea[data-qa='message']"));
        private IWebElement uploadfileinput => _driver.FindElement(By.Name("upload_file"));
        private IWebElement submitbutton => _driver.FindElement(By.CssSelector("input[data-qa='submit-button']"));
        private IWebElement successmessage => _driver.FindElement(By.CssSelector("div[class='status alert alert-success']"));
        public void contactUs(string name,string email, string subject, string message,string file )
        {
            nameinput.SendKeys(name);
            emailinput.SendKeys(email);
            subjectinput.SendKeys(subject);
            messageinput.SendKeys(message);
            //Se adjunta un archivo
             //var relativePath = Path.Combine("..", "..", "..", "UploadImages", file);
            //var fullPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, relativePath ));
           // var relativePath = Path.GetDirectoryName(file);
           // var fulfilled = Path.GetDirectoryName(relativePath);
          // uploadfileinput.Click();



            submitbutton.Click();
            //Validacion de mensaje de éxito
            //Thread.Sleep(2000);
            


        }
        public string getTexto()
        {

            string texto = successmessage.Text;
            return texto;

        }
    }
}