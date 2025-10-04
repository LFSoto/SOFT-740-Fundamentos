using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Utils;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using System.Xml.Linq;

namespace AutomationPracticeDemo.Tests.Tests
{
    public class FormTests : TestBase
    {
        [TestCase(
            "Juan Perez",
            "juan@test.com",
            "88888888",
            "Brasilia",
            "Brazil",
            "Male",
            "Monday,Wednesday",
            "Blue",
            "Dog",
            "10/10/2025",
            "11/11/2025"
        )]
        [TestCase(
            "Maria Gomez",
            "maria@test.com",
            "99999999",
            "Paris",
            "France",
            "Female",
            "Sunday,Friday",
            "Green",
            "Cat",
            "01/01/2026",
            "02/02/2026"
        )]
        public void Should_Fill_And_Submit_Form_Parametrized(
            string fullName,
            string email,
            string phone,
            string city,
            string country,
            string gender,
            string days, 
            string color,
            string pet,
            string startDate,
            string endDate)
        {
            var formPage = new FormPage(Driver);
            var daysList = days.Split(',').ToList();

            formPage.FillForm(
                fullName,
                email,
                phone,
                city,
                country,
                gender,
                daysList,
                color,
                pet,
                startDate,
                endDate
            );

            formPage.Submit();
            var result = formPage.ResultText();
            var message = "You selected a range of 32 days.";

            Assert.That(result, Is.EqualTo(message));
            ScreenshotHelper.TakeScreenshot(Driver, $"form_test_{fullName.Replace(" ", "_")}.png");
            Assert.Pass("Should Fill And Submit Form Test Success.");
        }

        [Test]
        public void Dynamic_Button_Test()
        {
            var formPage = new FormPage(Driver);
            Assert.That(formPage.GetTextDynamicButton(), Is.EqualTo("START"));
            ScreenshotHelper.TakeScreenshot(Driver, "form_test_Dynamic_Button1.png");

            formPage.ClickDynamicButton();
            Assert.That(formPage.GetTextDynamicButton(), Is.EqualTo("STOP"));
            ScreenshotHelper.TakeScreenshot(Driver, "form_test_Dynamic_Button2.png");

            formPage.ClickDynamicButton();
            Assert.That(formPage.GetTextDynamicButton(), Is.EqualTo("START"));
            ScreenshotHelper.TakeScreenshot(Driver, "form_test_Dynamic_Button3.png");
            Assert.Pass("Dynamic Button Test Success.");
        }

        [Test]
        public void Simple_Alert_Button_Test()
        {
            var formPage = new FormPage(Driver);
            var messageAlert = formPage.ClickSimpleAlert();
            ScreenshotHelper.TakeScreenshot(Driver, "form_test_Simple_Alert.png");
            Assert.That(messageAlert, Is.EqualTo("I am an alert box!"));
            Assert.Pass("Simple Alert Button Test Success.");
        }
        [Test]
        public void Confirmation_Alert_Button_Test()
        {
            var formPage = new FormPage(Driver);
            formPage.ClicKConfirmationAlert();
            var messageAlert = formPage.GetTextConfirmationAlert();
            Assert.That(messageAlert, Is.EqualTo("Press a button!"));
            ScreenshotHelper.TakeScreenshot(Driver, "form_test_Confirmation_Alert_Button_Test.png");
            Assert.Pass("Confirmation Alert Button Test Success.");
        }
        [Test]
        [TestCase("Firefox")]
        public void Dynamic_Web_Table_Get_Disk_Value_Test(string browserName)
        {
            var formPage = new FormPage(Driver);
            var diskValueBrowser = formPage.GetDiskValueByBrowserName(browserName);
            var diskValueResult = formPage.GetDiskValueResult();
            Assert.That(diskValueBrowser, Is.EqualTo(diskValueResult));
            ScreenshotHelper.TakeScreenshot(Driver, "form_test_Dynamic_Web_Table_Get_Disk_Value.png");
            Assert.Pass("Dynamic Web Table Get Disk Value by Browser  Test Success.");
        }
    }
}
