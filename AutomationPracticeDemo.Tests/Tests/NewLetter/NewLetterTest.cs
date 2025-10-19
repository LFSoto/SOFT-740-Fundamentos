using AutomationPracticeDemo.Tests.Tests.Data;
using AutomationPracticeDemo.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Tests.NewLetter
{
    public class NewLetterTest : TestBase
    {

        [Test, TestCaseSource(typeof(GetUserData), nameof(GetUserData.UserNewLetterData))]
        public void newsLetterTest(string emailText)
        {
            var NewLetterPage = new Pages.NewLetterForm.NewLetterPage(Driver);
            NewLetterPage.newLetter(emailText);
            //Se valida el mensaje de suscripción
            var subscribeMessage = NewLetterPage.ObtenerMensajeSuscripcion();
            Assert.That(subscribeMessage, Is.EqualTo("You have been successfully subscribed!"));
        }
    }
}
