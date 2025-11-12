using AutomationPracticeDemo.Tests.Utils;
using OpenQA.Selenium;

namespace AutomationSauceDemo.Pages.Products;
public class CheckoutOVerviewPage
{
    private readonly IWebDriver driver;
    private readonly WaitHelper wait;
    //LOCATORS
    private readonly By LabelCheckoutOverviewTitle = By.ClassName("title"); //Checkout: Overview
    private readonly By ButtonFinish = By.CssSelector("button[data-test='finish']"); //Finish
    private readonly By ButtonCancel = By.CssSelector("button[data-test='cancel']"); //Cancel
    public CheckoutOVerviewPage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WaitHelper(driver);
    }//ctor

    public string GetTitleCheckoutOverview()
    {
        return wait.WaitForElementVisible(LabelCheckoutOverviewTitle).Text;
    }//GetTitleCheckoutOverview

    public void ClickButtonFinish()
    {
        wait.WaitForElementClickable(ButtonFinish).Click();

    }//ClickButtonFinish

    public void ClickButtonCancelh()
    {
        wait.WaitForElementClickable(ButtonCancel).Click();

    }//ClickButtonCancelh
}//class