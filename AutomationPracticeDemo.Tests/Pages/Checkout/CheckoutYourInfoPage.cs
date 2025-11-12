using OpenQA.Selenium;
using AutomationPracticeDemo.Tests.Utils;

namespace AutomationSauceDemo.Pages.Products;
public class CheckoutYourInfoPage
{
    private readonly IWebDriver driver;
    private readonly WaitHelper wait;
    //LOCATORS
    private readonly By LabelCheckoutYourInformationTitle = By.ClassName("title"); //Checkout: Your Information
    private readonly By InputFirstName = By.Id("first-name"); //First Name
    private readonly By InputLastName = By.Id("last-name"); //Last Name
    private readonly By InputPostalCode = By.Id("postal-code"); //Postal Code
    private readonly By Buttoncontinue= By.CssSelector("input[data-test='continue']"); //Continue
    private readonly By ButtonCancel = By.CssSelector("button[data-test='cancel']"); //Cancel
    private readonly By LabelErrorMessage = By.CssSelector("h3[data-test='error']"); //Error Message
    public CheckoutYourInfoPage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WaitHelper(driver);
    }//ctor

    public string GetTitleCheckoutYourInformation()
    {
        return wait.WaitForElementVisible(LabelCheckoutYourInformationTitle).Text;
    }//GetTitleCheckoutYourInformation

    public void CheckoutExisting(string firstName, string lastName, string postalCode)
    {
        wait.WaitForElementVisible(InputFirstName).SendKeys(firstName);
        wait.WaitForElementVisible(InputLastName).SendKeys(lastName);
        wait.WaitForElementVisible(InputPostalCode).SendKeys(postalCode);
    }//CheckoutExisting

    public void ClickButtonContinue()
    {
        wait.WaitForElementClickable(Buttoncontinue).Click();

    }//ClickButtonContinue
    public void ClickButtonCacel()
    {
        wait.WaitForElementClickable(ButtonCancel).Click();

    }//ClickButtonCancel

    public string GetLabelErrorMessage()
    {
        return wait.WaitForElementVisible(LabelErrorMessage).Text;
    }//GetTitleCheckoutYourInformation
}//class