using OpenQA.Selenium;
using AutomationPracticeDemo.Tests.Utils;

namespace AutomationPracticeDemo.Tests.Pages.Login;
public class LoginPage
{
    private readonly IWebDriver driver;
    private readonly WaitHelper wait;
    //Locators
    private readonly By LabelTittleLoginPage = By.ClassName("login_logo"); //Swag Labs
    private readonly By InputUsername = By.Id("user-name"); //Username
    private readonly By InputPassword = By.Id("password"); //Password
    private readonly By ButtonLogin = By.Id("login-button"); //Login
    private readonly By LabelErrorMessage = By.CssSelector("h3[data-test='error']"); //Epic sadface: Username and password do not match any user in this service

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WaitHelper(driver);
        //Esperamos a que la pagina de login este visible
        wait.WaitForElementVisible(LabelTittleLoginPage);
    }//ctor

    public void LoginExistingUser(string userName, string password)
    {
        wait.WaitForElementVisible(InputUsername).SendKeys(userName);
        wait.WaitForElementVisible(InputPassword).SendKeys(password);
    }//LoginExistingUser

    public void ClickLoginButton()
    {
        wait.WaitForElementClickable(ButtonLogin).Click();
    }//ClickLoginButton

    public string GetLoginPageText()
    {
        return wait.WaitForElementVisible(LabelTittleLoginPage).Text;
    }//GetLoginPageText

    public string GetErrorMessageText()
    {
        return wait.WaitForElementVisible(LabelErrorMessage).Text;
    }//GetErrorMessageText
}//class