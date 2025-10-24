using AutomationPracticeDemo.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Tests.ContactUs.Test
{
    public class ContactUsTest:TestBase
    {
        [Test, TestCaseSource(typeof(Data.ContactUsData), nameof(Data.ContactUsData.TestCases))]
        public void ContactUsTests(Data.ContactUsData data)
        {
            var page = new Pages.ContactUsPage(Driver);
            //abrir la página de contacto
            page.OpenContactUsPage();
            page.FillForm(data.Name, data.Email, data.Subject, data.Message, data.FilePath);
            page.SubmitForm();
            page.AcceptAlert();
            ScreenshotHelper.TakeScreenshot(Driver, "ContactUs.png");
            var successMessage = page.GetSuccessMessage();
            Assert.That(successMessage, Does.Contain(data.SuccessMessage));
            //Assert.That(page.GetSuccessMessage(), Is.EqualTo(data.SuccessMessage));
        }
    }
}
