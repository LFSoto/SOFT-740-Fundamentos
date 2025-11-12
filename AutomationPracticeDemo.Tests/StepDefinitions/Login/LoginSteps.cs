using AutomationPracticeDemo.Tests.Constants;
using AutomationPracticeDemo.Tests.Models.Login;
using AutomationPracticeDemo.Tests.Pages.Login;
using AutomationPracticeDemo.Tests.Pages.Products;
using AutomationPracticeDemo.Tests.Utils;
using OpenQA.Selenium;
using Reqnroll;

namespace AutomationSauceDemo.StepDefinitions.Login;

[Binding]
public class LoginSteps
{
    private readonly ScenarioContext scenarioContext;
    private IWebDriver driver;
    private LoginPage loginPage;
    private ProductsPage productsPage;
    private LoginData? loginData;
    public LoginSteps(ScenarioContext scenarioContext)
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
    Scenario: Successful login with valid credentials
    ********************************************************/

    [Given(@"I am on the Login page")]
    public void GivenTheUserIsOnTheLoginPage()
    {
        driver.Navigate().GoToUrl(ProjectConstants.BASE_URL);
    }//GivenTheUserIsOnTheLoginPage

    [When(@"I enter valid Username and Password")]
    public void WhenIEnterValidUsernameAndPassword()
    {
        // Load login data (assuming index 0 for the first test case)
        LoadLoginData(0);
        // Validate that loginData is not null
        if (loginData is null)
            throw new InvalidOperationException("Login data was not loaded.");
            // Perform login
            loginPage.LoginExistingUser(loginData.UserName, loginData.Password);
    }//WhenIEnterValidUsernameAndPassword

    [When(@"I click the login button")]
    public void WhenIClickTheLoginButton()
    {
        loginPage.ClickLoginButton();
    }//WhenIClickTheLoginButton

    [Then(@"I should be redirected to the home page")]
    public void ThenIShouldSeeTheLoginPage()
    {
        var productsPageText = productsPage.GetProductsPageText();
        Assert.That(productsPageText, Is.EqualTo(ProjectConstants.PAGE_TITLE_LOGIN), "The login page text does not match the expected value.");
        // Tomar captura de pantalla
        ScreenshotHelper.TakeScreenshot(driver, "SuccessfulLoginWithValidCredentialsTest.png");
    }//ThenIShouldSeeTheLoginPage

    /********************************************************
     Scenario: Unsuccessful login with invalid credentials
     ********************************************************/
    [When(@"I enter invalid Username and Password")]
    public void WhenIEnterInvalidUsernameAndPassword()
    {
        // Load login data (assuming index 1 for the invalid test case)
        LoadLoginData(1);
        // Validate that loginData is not null
        if (loginData is null)
            throw new InvalidOperationException("Login data was not loaded.");
            // Perform login
            loginPage.LoginExistingUser(loginData.UserName, loginData.Password);
    }//WhenIEnterInvalidUsernameAndPassword

    [Then(@"I should see an error message indicating invalid credentials")]
    public void ThenIShouldSeeAnErrorMessage()
    {
        var errorMessageText = loginPage.GetErrorMessageText();
        Assert.That(errorMessageText, Is.EqualTo(ProjectConstants.LOGIN_ERROR_MESSAGE), "The error message does not match the expected value.");
        // Tomar captura de pantalla
        ScreenshotHelper.TakeScreenshot(driver, "UnsuccessfulLoginWithInvalidCredentialsTest.png");
    }//ThenIShouldSeeAnErrorMessage
}//class