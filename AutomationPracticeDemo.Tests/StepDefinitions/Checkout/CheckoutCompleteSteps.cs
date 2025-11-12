using AutomationPracticeDemo.Tests.Constants;
using AutomationPracticeDemo.Tests.Models.Login;
using AutomationPracticeDemo.Tests.Pages.Login;
using AutomationPracticeDemo.Tests.Pages.Products;
using AutomationPracticeDemo.Tests.Utils;
using AutomationSauceDemo.Pages.Products;
using OpenQA.Selenium;
using Reqnroll;
namespace AutomationSauceDemo.StepDefinitions.Products;

[Binding]
public class CheckoutCompleteSteps
{
    private readonly ScenarioContext scenarioContext;
    private IWebDriver driver;
    private LoginPage loginPage;
    private ProductsPage productsPage;
    private YourCartPage yourCartPage;
    private CheckoutYourInfoPage checkoutYourInfoPage;
    private LoginData? loginData;
    private CheckoutOVerviewPage checkoutOVerviewPage;
    private CheckoutCompletePage checkoutCompletePage;


    public CheckoutCompleteSteps(ScenarioContext scenarioContext)
    {
        this.scenarioContext = scenarioContext;
        this.driver = scenarioContext.Get<IWebDriver>();
        this.loginPage = new LoginPage(driver);
        this.productsPage = new ProductsPage(driver);
        this.yourCartPage = new YourCartPage(driver);
        this.checkoutYourInfoPage = new CheckoutYourInfoPage(driver);
        this.checkoutOVerviewPage = new CheckoutOVerviewPage(driver);
        this.checkoutCompletePage = new CheckoutCompletePage(driver);


    }//ctor

    public void LoadLoginData(int index)
    {
        this.loginData = TestDataSources.GetTestCaseByIndex(index);
        // Store in ScenarioContext so other steps can access it
        scenarioContext.Set(loginData, "LoginData");
    }//LoadLoginData


    /********************************************************
    Scenario: Checkout: Complete
    ********************************************************/

    [Given(@"Fill Product page")]
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

    [Given(@"Fill Cart page")]
    // Add product to cart
    public void GivenTheUserIsOnTheYourCartPage()
    {
        productsPage.ClickButtonAddToCart();
        productsPage.ClickButtonShoppingCart();
    }//GivenTheUserIsOnTheYourCartPage

    [Given(@"I am on the Checkout Your Information page")]
    public void GivenTheUserIsOnTheCheckoutYourInformationPage()
    {
        yourCartPage.ClickButtoncheckout();
        var checkoutYourInfoTitle = checkoutYourInfoPage.GetTitleCheckoutYourInformation();
        Assert.That(checkoutYourInfoTitle, Is.EqualTo(ProjectConstants.TITLE_CHECKOUT_YOUR_INFORMATION), "The Checkout: Your Information page title does not match the expected value.");
    }//GivenTheUserIsOnTheCheckoutYourInformationPage

    [When(@"I enter valid First Name,Last Name and Postal Code")]
    public void WhenIEnterValidIFirstNameLastNameandPostalCode()
    {
        // Load checkout your information data (assuming index 0 for the first test case)
        var checkoutYourInfoData = TestDataSources.GetTestCaseByIndexCheckout(0);
        // Validate that checkoutYourInfoData is not null
        if (checkoutYourInfoData is null)
            throw new InvalidOperationException("Checkout Your Information data was not loaded.");
        // Enter checkout your information data
        checkoutYourInfoPage.CheckoutExisting(
        checkoutYourInfoData.FirstName,
        checkoutYourInfoData.LastName,
        checkoutYourInfoData.PostalCode
        );
    }//WhenIEnterValidIFirstNameLastNameandPostalCode

    [When(@"Click continue button")]
    public void WhenIclickContinuebutton()
    {
        checkoutYourInfoPage.ClickButtonContinue();

    }//WhenIclicktheContinuebutton

    [When(@"Click finish button")]
    public void WhenIclickFinishbutton()
    {
        checkoutOVerviewPage.ClickButtonFinish();

    }//WhenIclickFinishbutton

    [Then(@"You should see a thank you message for your purchase")]
    public void AThankYouMessageForYourPurchaseShouldBeDisplayed()
    {
        var checkoutCompleteTitle = checkoutCompletePage.GetTitleCCheckoutComplete();
        Assert.That(checkoutCompleteTitle, Is.EqualTo(ProjectConstants.TITLE_CHECKOUT_COMPLETE), "The Checkout: Complete page title does not match the expected value.");
        // Tomar captura de pantalla
        ScreenshotHelper.TakeScreenshot(driver, "PurchaseCompleteTest.png");
    }//AThankYouMessageForYourPurchaseShouldBeDisplayed

    /********************************************************
    Scenario: Redirect to homepage
    ********************************************************/

    [When(@"Click Homepage button")]
    public void WhenIclickHomepagebutton()
    {
        checkoutCompletePage.ClickBackHomeButton();
    }//WhenIclickHomepagebutton

    [Then(@"You should be redirected to the homepage")]
    public void YouShouldBeRedirectedToTheHomepage()
    {
        var productsPageText = productsPage.GetProductsPageText();
        Assert.That(productsPageText, Is.EqualTo(ProjectConstants.PAGE_TITLE_LOGIN), "The login page text does not match the expected value.");
        // Tomar captura de pantalla
        ScreenshotHelper.TakeScreenshot(driver, "RedirectToHomepageTest.png");
    }//YouShouldBeRedirectedToTheHomepage
}//class