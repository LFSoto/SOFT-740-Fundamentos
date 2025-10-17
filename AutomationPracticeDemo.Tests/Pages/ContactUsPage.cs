using Bogus;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Globalization;
using System.Text.RegularExpressions;


namespace AutomationPracticeDemo.Tests.Pages
{
    /// <summary>
    /// Clase principal de la página AutomationPage, que encapsula las acciones y elementos
    /// </summary>
    public class ContactUsPage
    {
        // Instancia del controlador WebDriver utilizada para interactuar con el navegador
        private readonly IWebDriver _driver;

        public ContactUsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region GUI Elements: https://automationexercise.com/
        // ==================================================================================================
        // Este bloque agrupa todos los elementos gráficos (GUI) utilizados en la página bajo prueba.
        // Cada región secundaria corresponde a una funcionalidad o formulario específico.
        // Los elementos se localizan usando selectores Id, XPath o CSS, según corresponda.
        // ==================================================================================================

        #region Contacts us elements
        // ==================================================================================================
        // --- Elementos del formulario de contacto ---
        // ==================================================================================================
        private IWebElement ContactUsLink => _driver.FindElement(By.CssSelector("a[href='/contact_us']"));
        private IWebElement NameInput => _driver.FindElement(By.CssSelector("input[data-qa='name']"));
        private IWebElement EmailInput => _driver.FindElement(By.CssSelector("input[data-qa='email']"));
        private IWebElement SubjectInput => _driver.FindElement(By.CssSelector("input[data-qa='subject']"));
        private IWebElement MessageInput => _driver.FindElement(By.Id("message"));
        private IWebElement UploadFileInput => _driver.FindElement(By.CssSelector("input[name='upload_file']"));
        private IWebElement SubnitButton => _driver.FindElement(By.CssSelector("input[data-qa='submit-button']"));
        private IWebElement SuccessMessageContactForm => _driver.FindElement(By.CssSelector(".status.alert.alert-success"));
        #endregion

        #endregion


        /// <summary>
        /// Completa y envía el formulario de contacto.
        /// </summary>
        /// <param name="name">Nombre del remitente.</param>
        /// <param name="email">Correo electrónico del remitente.</param>
        /// <param name="subject">Asunto del mensaje.</param>
        /// <param name="message">Contenido del mensaje.</param>
        /// <param name="file">Nombre del archivo a subir desde la carpeta Resources.</param>
        public void FillOutTheContactForm(string name, string email, string subject, string message, string file)
        {
            // Abre el formulario de contacto
            ContactUsLink.Click();

            // Completa los campos de texto del formulario
            NameInput.SendKeys(name);
            EmailInput.SendKeys(email);
            SubjectInput.SendKeys(subject);
            MessageInput.SendKeys(message);

            // Obtiene la ruta del archivo desde la carpeta Resources y lo adjunta
            var filePath = GetProjectFilePath(file);
            UploadFileInput.SendKeys(filePath);

            // Envía el formulario y acepta la alerta de confirmación
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));

            IWebElement ContinueShoppingButton = wait.Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SubnitButton));

            SubnitButton.Submit();
            _driver.SwitchTo().Alert().Accept();
        }

        /// <summary>
        /// Obtiene la ruta completa de un archivo ubicado en la carpeta "Resources" del proyecto.
        /// </summary>
        /// <param name="fileName">Nombre del archivo dentro de la carpeta Resources.</param>
        /// <returns>Ruta absoluta del archivo dentro del proyecto.</returns>
        public string GetProjectFilePath(string fileName)
        {
            // Obtiene la ruta base del proyecto (subiendo desde /bin)
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = Path.GetFullPath(Path.Combine(basePath, @"..\..\.."));

            // Asume automáticamente que los archivos están en la carpeta "Resources"
            string resourcesPath = Path.Combine(projectRoot, "Resources");

            // Devuelve la ruta completa del archivo
            return Path.Combine(resourcesPath, fileName);
        }

        /// <summary>
        /// Obtiene el texto del mensaje exitoso mostrado tras enviar el formulario de contacto.
        /// </summary>
        /// <returns>Texto del mensaje de éxito del formulario de contacto.</returns>
        public string GetSuccessMessageContactForm()
        {
            // Recupera el texto del elemento que contiene el mensaje de éxito
            var message = SuccessMessageContactForm.Text;
            return message;
        }
    }
}

  