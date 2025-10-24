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
            var path = TestContext.CurrentContext.TestDirectory + data.FilePath;
            page.FillForm(data.Name, data.Email, data.Subject, data.Message, path);
            page.SubmitForm();
            page.AcceptAlert();
            ScreenshotHelper.TakeScreenshot(Driver, "ContactUs.png");
            var successMessage = page.GetSuccessMessage();
            Assert.That(successMessage, Does.Contain(data.SuccessMessage));
            
        }
    }
}
