using AutomationPracticeDemo.Tests.Constants;
using AutomationPracticeDemo.Tests.Models.Login;
using AutomationPracticeDemo.Tests.Pages.Login;
using AutomationPracticeDemo.Tests.Pages.Products;
using AutomationPracticeDemo.Tests.Utils;
using AutomationSauceDemo.Pages.Products;
using Io.Cucumber.Messages.Types;
using OpenQA.Selenium;
using Reqnroll;
namespace AutomationSauceDemo.StepDefinitions.Products;

[Binding]
public class YourCartSteps
{
    private readonly ScenarioContext scenarioContext;
    private IWebDriver driver;
    private LoginPage loginPage;
    private ProductsPage productsPage;
    private YourCartPage yourCartPage;
    private CheckoutYourInfoPage checkoutYourInfoPage;
    private LoginData? loginData;
    public YourCartSteps(ScenarioContext scenarioContext)
    {
        this.scenarioContext = scenarioContext;
        this.driver = scenarioContext.Get<IWebDriver>();
        this.loginPage = new LoginPage(driver);
        this.productsPage = new ProductsPage(driver);
        this.yourCartPage = new YourCartPage(driver);
        this.checkoutYourInfoPage = new CheckoutYourInfoPage(driver);
    }//ctor

    public void LoadLoginData(int index)
    {
        this.loginData = TestDataSources.GetTestCaseByIndex(index);
        // Store in ScenarioContext so other steps can access it
        scenarioContext.Set(loginData, "LoginData");
    }//LoadLoginData

    /********************************************************
    Scenario: Remove Products from Your Cart
    ********************************************************/

    [Given(@"I am on the product page")]
    public void GivenTheUserIsOnTheProductsPage()
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
    }//GivenTheUserIsOnTheProductsPage

    [Given(@"I am on the Your Cart page")]
    // Add product to cart
    public void GivenTheUserIsOnTheYourCartPage()
    {
        productsPage.ClickButtonAddToCart();
        productsPage.ClickButtonShoppingCart();
    }//GivenTheUserIsOnTheYourCartPage

    [When(@"I click the Remove button")]
    public void WhenIClickTheRemovebutton()
    {
        yourCartPage.ClickButtonRemoveYourCart();
    }//WhenIClickTheRemovebutton

    [Then(@"The product should be removed from the cart")]
    public void TheProductShouldBeRemovedFromTheYourCartPage()
    {
        // GetTitleProductYourCart() devuelve true si el título ya no está visible
        bool isRemoved = yourCartPage.GetTitleProductYourCart();
        Assert.That(isRemoved, Is.True, "El producto NO fue removido del carrito.");
        // Captura opcional para evidencias
        ScreenshotHelper.TakeScreenshot(driver, "ProductRemovedFromCart.png");
    }//TheProductShouldBeRemovedFromTheYourCartPage

    /********************************************************
        Scenario: Functionality: Continue shopping button
     ********************************************************/

    [When(@"I click the continue shopping button")]
    public void WhenIClickThecontinueshoppingbutton()
    {
        yourCartPage.ClickButtoncontinueshopping();
    }//WhenIClickTheRemovebutton

    [Then(@"You should see the products page")]
    public void TheProductShoulseetheproductspage()
    {
        var productsPageText = productsPage.GetProductsPageText();
        Assert.That(productsPageText, Is.EqualTo(ProjectConstants.PAGE_TITLE_LOGIN), "The login page text does not match the expected value.");
        // Tomar captura de pantalla
        ScreenshotHelper.TakeScreenshot(driver, "Testfunctionalityofthecontinueshoppingbutton.png");
    }//TheProductShoulseetheproductspage

    /********************************************************
      Scenario: Functionality: Checkout button
   ********************************************************/

    [When(@"I click the Checkout button")]
    public void WhenIClickTheCheckoutbutton()
    {
        yourCartPage.ClickButtoncheckout();
    }//WhenIClickTheCheckoutbutton

    [Then(@"You should see the Checkout: Your Information page")]
    public void TheProductShoulseetheCheckoutYourInformationpage()
        {
        var checkoutYourInfoPageText = checkoutYourInfoPage.GetTitleCheckoutYourInformation();
        Assert.That(checkoutYourInfoPageText, Is.EqualTo(ProjectConstants.TITLE_CHECKOUT_YOUR_INFORMATION), "The Checkout: Your Information page text does not match the expected value.");
        // Tomar captura de pantalla
        ScreenshotHelper.TakeScreenshot(driver, "TestfunctionalityoftheCheckoutbutton.png");
    }//TheProductShoulseetheCheckoutYourInformationpage
}//class
