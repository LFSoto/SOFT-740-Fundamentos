using DixonProyectoFinal.Tests.Pages;
using OpenQA.Selenium;
using Reqnroll;

namespace DixonProyectoFinal.Tests.StepDefinitions
{
    [Binding]
    public class InventorySteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private InventoryPage _inventoryPage;
        string[]? _itemsPositions;

        public InventorySteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
            _inventoryPage = new InventoryPage(_driver);
        }

        [When(@"I add two items in the postions one and two: ""(.*)""")]
        public void AddTwoItems(string itemsPositions)
        {
            _itemsPositions = itemsPositions.Split(',');
            _inventoryPage.AddItemsToCart(_itemsPositions);
        }

        [Then(@"The items were added")]
        public void ValidateThatTheItemsWereAdded()
        {
            if (_itemsPositions is not null)
            {
                Assert.IsTrue(_inventoryPage.ValidatedItemsAdded(_itemsPositions.Length), "The items were not added");
            }else
            {
                Assert.Throws<ArgumentException>(() => throw new ArgumentException());
            }
        }
    }
}
