using AutomationPracticeDemo.Tests.Utils;
using OpenQA.Selenium;

namespace AutomationSauceDemo.Pages.Products;
public class CheckoutCompletePage
{
    private readonly IWebDriver driver;
    private readonly WaitHelper wait;
    //LOCATORS
    private readonly By LabelCheckoutCompleteTitle = By.ClassName("title"); //Checkout: Complete!
    private readonly By ButtonBackHome = By.CssSelector("button[data-test='back-to-products']"); //Back Home Button (data-test selector)

    public CheckoutCompletePage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WaitHelper(driver);
    }//ctor
    public string GetTitleCCheckoutComplete()
    {
        return wait.WaitForElementVisible(LabelCheckoutCompleteTitle).Text;
    }//GetTitleCCheckoutComplete

    public void ClickBackHomeButton()
    {
        wait.WaitForElementClickable(ButtonBackHome).Click();
    }//ClickBackHomeButton
} //class
