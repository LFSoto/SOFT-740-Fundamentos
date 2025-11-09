using System;
using OpenQA.Selenium;
using AutomationPracticeDemo.Tests.Utils;

namespace AutomationSauceDemo.Pages.Products;
public class YourCartPage   
{
    private readonly IWebDriver driver;
    private readonly WaitHelper wait;
    //LOCATORS
    private readonly By ButtonRemoveYourCart = By.CssSelector("button[data-test='remove-sauce-labs-backpack']"); //Remove
    private readonly By LabelProductTitle = By.ClassName("inventory_item_name"); //Sauce Labs Backpack

    public YourCartPage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WaitHelper(driver);
    }//ctor
    public void ClickButtonRemoveYourCart()
    {
        wait.WaitForElementClickable(ButtonRemoveYourCart).Click();

    }//ClickButtonRemoveYourCart
    public bool GetTitleProductYourCart()
        {
        return wait.WaitForElementInvisible(LabelProductTitle);
    }//GetTitleProductYourCart



}//class
