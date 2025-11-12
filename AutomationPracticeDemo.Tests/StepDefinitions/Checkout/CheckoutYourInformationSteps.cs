using AutomationPracticeDemo.Tests.Constants;
using AutomationPracticeDemo.Tests.Models.Login;
using AutomationPracticeDemo.Tests.Pages.Login;
using AutomationPracticeDemo.Tests.Pages.Products;
using AutomationPracticeDemo.Tests.Utils;
using AutomationSauceDemo.Pages.Products;
using Io.Cucumber.Messages.Types;
using OpenQA.Selenium;
using Reqnroll;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutomationSauceDemo.StepDefinitions.Products;

[Binding]
public class CheckoutYourInformationSteps
{
    private readonly ScenarioContext scenarioContext;
    private IWebDriver driver;
    private LoginPage loginPage;
    private ProductsPage productsPage;
    private YourCartPage yourCartPage;
    private CheckoutYourInfoPage checkoutYourInfoPage;
    private LoginData? loginData;
    private CheckoutOVerviewPage checkoutOVerviewPage;

    public CheckoutYourInformationSteps(ScenarioContext scenarioContext)
    {
        this.scenarioContext = scenarioContext;
        this.driver = scenarioContext.Get<IWebDriver>();
        this.loginPage = new LoginPage(driver);
        this.productsPage = new ProductsPage(driver);
        this.yourCartPage = new YourCartPage(driver);
        this.checkoutYourInfoPage = new CheckoutYourInfoPage(driver);
        this.checkoutOVerviewPage = new CheckoutOVerviewPage(driver);
    }//ctor

    public void LoadLoginData(int index)
    {
        this.loginData = TestDataSources.GetTestCaseByIndex(index);
        // Store in ScenarioContext so other steps can access it
        scenarioContext.Set(loginData, "LoginData");
    }//LoadLoginData

    /********************************************************
    Scenario: Steps to complete purchase with valid data
    ********************************************************/

    [Given(@"Complete the product page")]
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

    [Given(@"Complete the cart page")]
    // Add product to cart
    public void GivenTheUserIsOnTheYourCartPage()
    {
        productsPage.ClickButtonAddToCart();
        productsPage.ClickButtonShoppingCart();
    }//GivenTheUserIsOnTheYourCartPage

    [Given(@"I am on the Checkout: Your Information page")]
    public void GivenTheUserIsOnTheCheckoutYourInformationPage()
    {
        yourCartPage.ClickButtoncheckout();
        var checkoutYourInfoTitle = checkoutYourInfoPage.GetTitleCheckoutYourInformation();
        Assert.That(checkoutYourInfoTitle, Is.EqualTo(ProjectConstants.TITLE_CHECKOUT_YOUR_INFORMATION), "The Checkout: Your Information page title does not match the expected value.");
    }//GivenTheUserIsOnTheCheckoutYourInformationPage

    [When(@"I enter valid First Name, Last Name, and Postal Code")]
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

    [When(@"I click Continue button")]
    public void WhenIclickContinuebutton()
    {
        checkoutYourInfoPage.ClickButtonContinue();
    }//WhenIclicktheContinuebutton

    [Then(@"I should be redirected to the Checkout: Overview page")]
    public void ThefollowingCheckoutSummaryscreenshouldbedisplayed()
    {
        var checkoutOverviewTitle = checkoutOVerviewPage.GetTitleCheckoutOverview();
        Assert.That(checkoutOverviewTitle, Is.EqualTo(ProjectConstants.TITLE_CHECKOUT_OVERVIEW), "The Checkout: Overview page title does not match the expected value.");
        // Take screenshot
        ScreenshotHelper.TakeScreenshot(driver, "CheckoutOverviewPage.png");
    }//ThefollowingCheckoutSummaryscreenshouldbedisplayed

    /********************************************************
    Scenario:Valid information (cancel button)
    ********************************************************/

    [When(@"I click Cancel button")]
    public void WhenIclickCancelbutton()
    {
        checkoutYourInfoPage.ClickButtonCacel();

    }//WhenIclicktheCancelbutton
    [Then(@"I should be redirected to Your Cart page")]
    public void IShoulRedirectedToTheCartScreen()
    {
        var yourCartTitle = yourCartPage.GetLabelYourCartTitle();
        Assert.That(yourCartTitle, Is.EqualTo(ProjectConstants.TITLE_YOUR_CART), "The Your Cart page title does not match the expected value.");
        // Take screenshot
        ScreenshotHelper.TakeScreenshot(driver, "YourCartPageAfterCancel.png");
    }//IShoulRedirectedToTheCartScreen

    /********************************************************
    Steps to complete purchase with invalid data
    ********************************************************/

    [Then(@"An error message should be displayed on the screen")]
    public void AnErrorMessageShouldBeDisplayedOnTheScreen()
    {
        var errorMessage = checkoutYourInfoPage.GetLabelErrorMessage();
        Assert.That(errorMessage, Is.EqualTo(ProjectConstants.ERROR_MESSAGE_CHECKOUT_YOUR_INFORMATION), "The error message does not match the expected value.");
        // Take screenshot
        ScreenshotHelper.TakeScreenshot(driver, "ErrorMessageCheckoutYourInformation.png");
    }//AnErrorMessageShouldBeDisplayedOnTheScreen
}//class