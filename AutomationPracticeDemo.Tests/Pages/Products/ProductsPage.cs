using System;
using OpenQA.Selenium;
using AutomationPracticeDemo.Tests.Utils;

namespace AutomationPracticeDemo.Tests.Pages.Products;
public class ProductsPage
{
    private readonly IWebDriver driver;
    private readonly WaitHelper wait;
    //LOCATORS
    private readonly By LabelPageTittle = By.ClassName("app_logo"); //Swag Labs
    private readonly By LabelProducts = By.ClassName("title"); //Products

    public ProductsPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WaitHelper(driver);
    }//ctor
    public string GetProductsPageText()
    {
        return wait.WaitForElementVisible(LabelPageTittle).Text;
    }//GetProductsPageText
}//class

