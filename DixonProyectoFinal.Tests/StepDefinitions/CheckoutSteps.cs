using DixonProyectoFinal.Tests.Pages;
using DixonProyectoFinal.Tests.Pages.Checkout;
using OpenQA.Selenium;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DixonProyectoFinal.Tests.StepDefinitions
{
    [Binding]
    public class CheckoutSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private CartPage _cartPage;
        private CheckoutStepOnePage _checkoutStepOnePage;

        public CheckoutSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
            _cartPage = new CartPage(_driver);
            _checkoutStepOnePage = new CheckoutStepOnePage(_driver);
        }

        [When(@"I navigate to the Checkout step one page: ""(.*)""")]
        public void ClickCheckoutButton(string url)
        {
            _cartPage.GoToCheckOut();
            Assert.That(_driver.Url.Contains(url), "Not navigated to check out step one page");
        }

        [When(@"I enter my ""(.*)"", my ""(.*)"" and my ""(.*)""")]
        public void FillForm(string firstName, string lastName, string postalCode)
        {
            _checkoutStepOnePage.FillForm(firstName, lastName, postalCode);
        }

        [When("I click the Continue button")]
        public void ClickContinueButton()
        {
            _checkoutStepOnePage.SubmitForm();
        }

        [Then(@"I'm on the Checkout step two page: ""(.*)""")]
        public void ValidatePageUrlCheckoutStepTwo(string url)
        {
            Assert.That(_driver.Url.Contains(url), "Not navigated to check out step two page");
        }

    }
}
