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
    private readonly By Buttoncontinueshopping = By.Id("continue-shopping"); //Continue Shopping
    private readonly By Buttoncheckout = By.Id("checkout"); //Checkout


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

    public void ClickButtoncontinueshopping()
    {
        wait.WaitForElementClickable(Buttoncontinueshopping).Click();
    }//GetButtoncontinueshopping

    public void ClickButtoncheckout()
    {
        wait.WaitForElementClickable(Buttoncheckout).Click();
    }//GetTitleProductYourCart



}//class
