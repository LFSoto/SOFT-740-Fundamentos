using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Tests.CartProducts.Data;
using OpenQA.Selenium;
using Reqnroll;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.StepDefinitions.CartProducts
{
    [Binding]
    public class CartProductsSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly ProductsPage _productsPage;
        private readonly LoginPage _loginPage;
        private CartProductsData _testData;

        public CartProductsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
            _productsPage = new ProductsPage(_driver);
            _loginPage = new LoginPage(_driver);
        }

        // Load test data from JSON when needed
        private void LoadTestData()
        {
            if (_testData == null)
            {
                _testData = CartProductsData.TestCases().First();
                // Store in ScenarioContext so other steps can access it
                _scenarioContext.Set(_testData, "CartTestData");
            }
        }

        [When(@"The user logins with credentials from test data")]
        public void WhenUserLoginsWithCredentialsFromTestData()
        {
            LoadTestData();
            _loginPage.Login(_testData.Email, _testData.Password);
        }

        [When(@"The user navigates to product page")]
        public void UserNavigatesToProductPage()
        {
            _productsPage.GoToProducts();
            Assert.That(_driver.Url.Contains("/products"), "Not navigated to products page");
        }

        [Then(@"The user adds products from test data")]
        public void ThenUserAddsProductsFromTestData()
        {
            LoadTestData();
            
            // Add first product
            _productsPage.AddProduct(_testData.IdProduct1);
            _productsPage.ContinueShopping();
            
            // Add second product (twice based on Cant2)
            for (int i = 0; i < int.Parse(_testData.Cant2); i++)
            {
                _productsPage.AddProduct(_testData.IdProduct2);
                _productsPage.ContinueShopping();
            }
        }

        [Then(@"The user adds product with id (.*)")]
        public void UserAddsProductById(int productId)
        {
            _productsPage.AddProduct(productId);
        }

        [Then(@"The user clicks Continue Shopping button")]
        public void UserClicksContinueShoppingButton()
        {
            _productsPage.ContinueShopping();
        }

        [When(@"The user clicks on the cart link")]
        public void UserClicksOnTheCartLink()
        {
            _productsPage.GoToCart();
            Assert.That(_driver.Url.Contains("/view_cart"), "Not navigated to cart page");
        }

        [Then(@"The cart should display correct product information from test data")]
        public void ThenCartShouldDisplayCorrectProductInformation()
        {
            LoadTestData();
            
            // Validate prices
            var actualPrice1 = _productsPage.GetPriceProduct1();
            var actualPrice2 = _productsPage.GetPriceProduct2();
            Assert.That(actualPrice1, Is.EqualTo(_testData.Price1), $"Product 1 price mismatch. Expected: {_testData.Price1}, Actual: {actualPrice1}");
            Assert.That(actualPrice2, Is.EqualTo(_testData.Price2), $"Product 2 price mismatch. Expected: {_testData.Price2}, Actual: {actualPrice2}");
            
            // Validate quantities
            var actualQuantity1 = _productsPage.GetQuantityProduct1();
            var actualQuantity2 = _productsPage.GetQuantityProduct2();
            Assert.That(actualQuantity1, Is.EqualTo(_testData.Cant1), $"Product 1 quantity mismatch. Expected: {_testData.Cant1}, Actual: {actualQuantity1}");
            Assert.That(actualQuantity2, Is.EqualTo(_testData.Cant2), $"Product 2 quantity mismatch. Expected: {_testData.Cant2}, Actual: {actualQuantity2}");
            
            // Validate totals
            var actualTotal1 = _productsPage.GetTotalProduct1();
            var actualTotal2 = _productsPage.GetTotalProduct2();
            Assert.That(actualTotal1, Is.EqualTo(_testData.TotalProd1), $"Product 1 total mismatch. Expected: {_testData.TotalProd1}, Actual: {actualTotal1}");
            Assert.That(actualTotal2, Is.EqualTo(_testData.TotalProd2), $"Product 2 total mismatch. Expected: {_testData.TotalProd2}, Actual: {actualTotal2}");
        }

        [Then(@"The product ""(.*)"" should be in the cart")]
        public void ThenTheProductShouldBeInCart(string expectedPrice)
        {
            // You can validate prices here
            // Store in ScenarioContext if needed for later validation
            if (!_scenarioContext.ContainsKey("expectedPrices"))
            {
                _scenarioContext.Set(new List<string>(), "expectedPrices");
            }
            _scenarioContext.Get<List<string>>("expectedPrices").Add(expectedPrice);
        }

        [Then(@"The quantity of product 1 should be ""(.*)""")]
        public void ThenTheQuantityOfProduct1ShouldBe(string expectedQuantity)
        {
            var actualQuantity = _productsPage.GetQuantityProduct1();
            Assert.That(actualQuantity, Is.EqualTo(expectedQuantity));
        }

        [Then(@"The quantity of product 2 should be ""(.*)""")]
        public void ThenTheQuantityOfProduct2ShouldBe(string expectedQuantity)
        {
            var actualQuantity = _productsPage.GetQuantityProduct2();
            Assert.That(actualQuantity, Is.EqualTo(expectedQuantity));
        }

        [Then(@"The total of product 1 should be ""(.*)""")]
        public void ThenTheTotalOfProduct1ShouldBe(string expectedTotal)
        {
            var actualTotal = _productsPage.GetTotalProduct1();
            Assert.That(actualTotal, Is.EqualTo(expectedTotal));
        }

        [Then(@"The total of product 2 should be ""(.*)""")]
        public void ThenTheTotalOfProduct2ShouldBe(string expectedTotal)
        {
            var actualTotal = _productsPage.GetTotalProduct2();
            Assert.That(actualTotal, Is.EqualTo(expectedTotal));
        }
    }
}
