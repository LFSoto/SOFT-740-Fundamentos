using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Tests.CartProducts.Data;
using AutomationPracticeDemo.Tests.Tests.ContactUs.Data;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using Reqnroll.CommonModels;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.StepDefinitions.ContactUsSteps
{
    [Binding]
    public class ContactUsSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly ContactUsPage _contactUsPage;
        private ContactUsData _testData;
        //private string _name = "";
        //private string _email = "";
        //private string _subject = "";
        //private string _message = "";
        //private string _filePath = "";
        //private string _successMessage = "";

        public ContactUsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
            _contactUsPage = new ContactUsPage(_driver);
        }

        private void LoadTestData()
        {
            if (_testData == null)
            {
                _testData = ContactUsData.TestCases().First();
                // Store in ScenarioContext so other steps can access it
                _scenarioContext.Set(_testData, "ContactUsTestData");
            }
        }

        [Given(@"The user is on the home page")]
        public void GivenTheUserIsOnTheHomePage()
        {
            Assert.That(_driver.Url, Does.Contain("automationexercise.com"));
        }
        [When(@"The user clicks on Contact Us buttom")]
        public void WhenTheUserGoToTheContactUsPage()
        {
                _contactUsPage.OpenContactUsPage();
            Assert.That(_driver.Url, Does.Contain("contact_us"));
        }

        [Then(@"The contact form is displayed")]
        public void ThenTheContactFormIsDisplayed()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_contactUsPage.EmailImputDisplayed, Is.True);
                Assert.That(_contactUsPage.NameImputDisplayed, Is.True);
                Assert.That(_contactUsPage.SubjectImputDisplayed, Is.True);
            });
        }

        [When(@"The user fills in the contact form from testdata")]
        public void WhenTheUserFillInTheContactForm()
        {
            LoadTestData();
            var path = TestContext.CurrentContext.TestDirectory + _testData.FilePath;
            _contactUsPage.FillForm(_testData.Name, _testData.Email, _testData.Subject, _testData.Message, path);
        }

        [When(@"The user clicks the submit button")]
        public void WhenTheUserClicksTheSubmitButton()
        {
            _contactUsPage.SubmitForm();
        }

        [Then(@"An alert is displayed for confirmation")]
        public void ThenAnAlertIsDisplayedForConfirmation()
        {
            Assert.That(() => _driver.SwitchTo().Alert(), Throws.Nothing);
        }

        [When(@"The user accepts the alert")]
        public void WhenTheUserAcceptsTheAlert()
        {
            _contactUsPage.AcceptAlert();
        }

        [Then(@"A success message (.*) is displayed")]
        public void ThenAsuccessMessageIsDisplayed(string successMsgField)
        {
            var successMessage=_contactUsPage.GetSuccessMessage();
            Assert.That(successMessage, Does.Contain(_testData.SuccessMessage));
        }

    }
}
