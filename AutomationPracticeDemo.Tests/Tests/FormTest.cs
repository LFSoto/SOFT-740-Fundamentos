using NUnit.Framework;
using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Utils;

namespace AutomationPracticeDemo.Tests.Tests
{
    public class FormTests : TestBase
    {
        [Test]
        public void Should_FillAndSubmitForm()
        {
            var formPage = new FormPage(Driver);
            formPage.FillForm("Juan Perez", "juan@test.com", "88888888", "Costa Rica");
            formPage.Submit();

            ScreenshotHelper.TakeScreenshot(Driver, formPage.GetFilePathScreenShots() + "form_test.png");
            Assert.Pass("Formulario llenado y enviado.");
        }

        [Test]
        public void Should_FillAndSubmitWikipediaInput()
        {
            var formPage = new FormPage(Driver);
            formPage.FillWikipediaSearchInput("Selenium");          
            formPage.SubmitWikipediaInput();

            ScreenshotHelper.TakeScreenshot(Driver, formPage.GetFilePathScreenShots() + "wikipedia_search_test.png");
            Assert.That(formPage.GetWikipediaSearchResult(), Is.EqualTo("Selenium"));
        }

        [Test]
        public void Should_ClickStartStopButton()
        {
            var formPage = new FormPage(Driver);

            formPage.ClickStartStopButton();

            ScreenshotHelper.TakeScreenshot(Driver, formPage.GetFilePathScreenShots() + "1-stop_button_test.png");
            Assert.That(formPage.GetStartStopButtonValue(), Is.EqualTo("STOP"));

            formPage.ClickStartStopButton();

            ScreenshotHelper.TakeScreenshot(Driver, formPage.GetFilePathScreenShots() + "2-start_button_test.png");
            Assert.That(formPage.GetStartStopButtonValue(), Is.EqualTo("START"));
        }

        [Test]
        public void Should_OpenAndCloseConfirmAlert()
        {
            var formPage = new FormPage(Driver);

            formPage.ClickConfirmButton();
            Assert.That(formPage.ValidateAlertIsOpen(), Is.True);

            formPage.ClickAlertAcceptButton();

            ScreenshotHelper.TakeScreenshot(Driver, formPage.GetFilePathScreenShots() + "confirm_alert_test.png");
            Assert.That(formPage.ValidateAlertIsOpen(), Is.False);
            Assert.That(formPage.GetConfirmAlertResultText(), Is.EqualTo("You pressed OK!"));
        }

        [Test]
        public void Should_UploadSingleFile()
        {
            var formPage = new FormPage(Driver);
            formPage.UploadSingleFileInput();
            formPage.ClickUploadSingleFileButton();

            ScreenshotHelper.TakeScreenshot(Driver, formPage.GetFilePathScreenShots() + "upload_single_file_test.png");
            Assert.That(formPage.GetSingleFileStatusText, Is.EqualTo("Single file selected: capybara.png, Size: 95746 bytes, Type: image/png"));
        }
    }
}
