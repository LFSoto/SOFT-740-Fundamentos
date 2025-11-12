using DixonProyectoFinal.Tests.Pages;
using DixonProyectoFinal.Tests.Utils;
using OpenQA.Selenium;
using Reqnroll;

namespace DixonProyectoFinal.Tests.StepDefinitions
{
    [Binding]
    internal class CartSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private InventoryPage _inventoryPage;
        private CartPage _cartPage;

        public CartSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
            _inventoryPage = new InventoryPage(_driver);
            _cartPage = new CartPage(_driver);
        }

        [Given(@"I validate that there's at least one item in the cart")]
        public void ValidateThatTheresItems()
        {
            _inventoryPage.AddItemsToCart(Constants.ItemsPositions.ThreeItems);
            Assert.IsTrue(_inventoryPage.ValidatedItemsAdded(Constants.ItemsPositions.ThreeItems.Length), "There's no items");
        }

        [When(@"I navigate to the Cart Page: ""(.*)""")]
        public void NavigateToTheCartPage(string url)
        {
            _inventoryPage.GoToShoppingCart();
            Assert.That(_driver.Url.Contains(url), "Not navigated to cart page");
        }

        [When("I remove all the items from the cart")]
        public void RemoveAllItemsFromTheCart()
        {
            _cartPage.RemoveItemsFromTheCart();
        }

        [Then("There's no items in the cart")]
        public void ValidateThatTheresNoItems()
        {
            Assert.IsTrue(!_cartPage.ValidateTheresItemsInTheCart(), "One or more items were not removed");
        }
    }
}
