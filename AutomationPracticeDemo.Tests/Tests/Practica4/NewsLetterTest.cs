using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Pages.MainComponents;
using AutomationPracticeDemo.Tests.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Tests.Practica4
{
    //TODO agregar datadriven
    public class NewsLetterTest : TestBase
    {
        [Test]
        public void Should_SubscribeToNewsletter()
        {
            //Se instancian las clases necesarias para ejecutar el test
            HeaderNav headerNav = new HeaderNav(Driver);
            Footer footer = new Footer(Driver);
            GetPathHelper getPathHelper = new GetPathHelper();

            //Se desplaza hasta el final de la página
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

            //Se ingresa el correo y se presiona el botón de subscribe
            footer.subscribeEmailTextbox.SendKeys("dchavarriaca@ucenfotec.ac.cr");
            footer.subscribeButton.Click();

            //Se captura la evidencia del resultado
            ScreenshotHelper.TakeScreenshot(Driver, getPathHelper.GetFilePathScreenShots() + "Should_SubscribeToNewsletter.png");

            //Se valida el mensaje de confirmación

            Assert.That(footer.SuccessMessage, Is.EqualTo("You have been successfully subscribed!"));
        }
    }
}
