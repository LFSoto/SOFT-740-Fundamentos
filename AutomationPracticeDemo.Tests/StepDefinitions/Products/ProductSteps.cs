using AutomationPracticeDemo.Tests.Constants;
using AutomationPracticeDemo.Tests.Models.Login;
using AutomationPracticeDemo.Tests.Pages.Login;
using AutomationPracticeDemo.Tests.Pages.Products;
using AutomationPracticeDemo.Tests.Utils;
using Io.Cucumber.Messages.Types;
using OpenQA.Selenium;
using Reqnroll;

namespace AutomationSauceDemo.StepDefinitions.Products;

[Binding]
public class ProductSteps
{
    private readonly ScenarioContext scenarioContext;
    private IWebDriver driver;
    private LoginPage loginPage;
    private ProductsPage productsPage;
    private LoginData? loginData;
    public ProductSteps(ScenarioContext scenarioContext)
    {
        this.scenarioContext = scenarioContext;
        this.driver = scenarioContext.Get<IWebDriver>();
        this.loginPage = new LoginPage(driver);
        this.productsPage = new ProductsPage(driver);

    }//ctor

    public void LoadLoginData(int index)
    {
        this.loginData = TestDataSources.GetTestCaseByIndex(index);
        // Store in ScenarioContext so other steps can access it
        scenarioContext.Set(loginData, "LoginData");
    }//LoadLoginData


    /********************************************************
    Scenario: Add Products
    ********************************************************/

    [Given(@"I am on the products page")]
    public void GivenTheUserIsOnTheproductsPage()
    {
        driver.Navigate().GoToUrl(ProjectConstants.BASE_URL);
        // Load login data (assuming index 0 for the first test case)
        LoadLoginData(0);

        // Validate that loginData is not null
        if (loginData is null)
            throw new InvalidOperationException("Login data was not loaded.");

        // Perform login
        loginPage.LoginExistingUser(loginData.UserName, loginData.Password);
        loginPage.ClickLoginButton();
        var productsPageText = productsPage.GetProductsPageText();
        Assert.That(productsPageText, Is.EqualTo(ProjectConstants.PAGE_TITLE_LOGIN), "The login page text does not match the expected value.");

        // Tomar captura de pantalla
        ScreenshotHelper.TakeScreenshot(driver, "SuccessfulLoginWithValidCredentialsTest.png");
    }

    [When(@"I Click Add Product")]
    public void WhenIClickTheAddProductbutton()
    {
        productsPage.ClickButtonAddToCart();
    }//WhenIClickTheProductButton

    [Then(@"The added product should be added to the cart icon")]
    public void ThenTheProductsAreAddedToTheCart()
    {
        var cartBadge = productsPage.GetCartBadge();
        Assert.That(cartBadge, Is.EqualTo(ProjectConstants.CART_BADGE), "The cart badge does not match the expected value.");
    }//ThenTheProductsAreAddedToTheCart

    [When(@"I click the cart button")]
    public void WhenIClickTheAddcartbutton()
    {
        productsPage.ClickButtonShoppingCart();
    }//WhenIClickThecartButton

    [Then(@"The added product should be there")]
    public void ThenTheProductIsAddedToYourCart()
    {
        var titleProduct = productsPage.GetTitleProduct();
        Assert.That(titleProduct, Is.EqualTo(ProjectConstants.TITLE_PRODUCT), "The product title does not match the expected value.");
    }//ThenTheProductsAreAddedToTheYourCart

    /********************************************************
   Scenario: Remove Products
   ********************************************************/


    [When(@"I click Add three products")]
    public void WhenIClickTheAddProducstbutton()
    {
        productsPage.ClickTheAddMultipleProductsToCartButton();
    }//WhenIClickTheAddProducstbutton


    [Then(@"The added products should appear in the cart icon")]
    public void ThenTheProductsAreAddedToTheYourCart()
    {
        var cartBadge = productsPage.GetCartBadge();
        Assert.That(cartBadge, Is.EqualTo(ProjectConstants.BEFORE_REMOVING_ART_BADGE), "The cart badge does not match the expected value for three products.");
    }//ThenTheProductsAreAddedToTheYourCart

    [When(@"I click the remove button")]
    public void WhenIClickTheRemovebutton()
    {
        productsPage.ClickButtonRemove();
    }//WhenIClickTheRemovebutton

    [Then(@"The added products should appear updated in the cart icon")]
    public void TheProductsAreThenUpdatedInTheCart()
        {
        var cartBadge = productsPage.GetCartBadge();
        Assert.That(cartBadge, Is.EqualTo(ProjectConstants.CART_BADGE_REMOVE), "The cart badge does not match the expected value after removing a product.");
    }//TheProductsAreThenUpdatedInTheCart


}