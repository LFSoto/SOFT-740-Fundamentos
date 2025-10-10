
using AutomationPracticeDemo.Tests.Utils;
using System;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutomationPracticeDemo.Tests.Tests
{

    public class AutomationPractice:TestBase

    {
            const string email = "SOFT-7400@cenfotec.com";
            const string password = "SOFT-7400";

        

        [Test]
        public void newsLetterTest()
        {
            //Se definen los WebElements
            var subscribenElementInput = Driver.FindElement(By.Id("susbscribe_email"));
            //var suscribeButton = Driver.FindElement(By.Id("susbscribe_email"));
            var suscribeMessage = Driver.FindElement(By.CssSelector("div[class=\"alert-success alert\"] "));

            //Se escribe el correo
            subscribenElementInput.SendKeys(email);

            //Se da click en el botón de suscribir

           // suscribeButton.Click();

            //se valida msj de suscripcíón

            Assert.That(suscribeMessage.Text, Is.EqualTo("You have been successfully subscribed!"));
        }
    
    }
}
