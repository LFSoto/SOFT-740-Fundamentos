using DixonProyectoFinal.Tests.Pages;
using DixonProyectoFinal.Tests.Pages.Checkout;
using OpenQA.Selenium;
using Reqnroll;

namespace DixonProyectoFinal.Tests.StepDefinitions
{
    [Binding]
    public class CheckoutSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private CartPage _cartPage;
        private CheckoutStepOnePage _checkoutStepOnePage;
        private CheckoutStepTwoPage _checkoutStepTwoPage;
        private CheckoutCompletePage _checkoutCompletePage;

        public CheckoutSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
            _cartPage = new CartPage(_driver);
            _checkoutStepOnePage = new CheckoutStepOnePage(_driver);
            _checkoutStepTwoPage = new CheckoutStepTwoPage(_driver);
            _checkoutCompletePage = new CheckoutCompletePage(_driver);
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

        [When(@"I validate the total price of the items")]
        public void ValidateItemsTotalPrice()
        {
            Assert.IsTrue(_checkoutStepTwoPage.ValidateItemsTotalPrice(), "The total price of the items is not correct");
        }

        [When(@"I click the Finish button")]
        public void FinishCheckOut()
        {
            _checkoutStepTwoPage.FinishCheckOut();
        }

        [Then(@"I'm on the check out complete page: ""(.*)""")]
        public void ValidatePageUrl(string url)
        {
            Assert.That(_driver.Url.Contains(url), "Not navigated to check out complete page");
        }

        [Then(@"I see the Checkout complete text")]
        public void ValidateCheckoutCompleteText()
        {
            Assert.That(_checkoutCompletePage.ValidateCheckOutComplete(), "Checkout: Complete!");
        }
    }
}
