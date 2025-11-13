using System;
using OpenQA.Selenium;
using AutomationPracticeDemo.Tests.Utils;
using AutomationPracticeDemo.Tests.Models.Cart;

namespace AutomationPracticeDemo.Tests.Pages.Products;
public class ProductsPage
{
    private readonly IWebDriver driver;
    private readonly WaitHelper wait;
    //LOCATORS
    private readonly By LabelPageTittle = By.ClassName("app_logo"); //Swag Labs
    private readonly By LabelProducts = By.ClassName("title"); //Products
    private readonly By ButtonAddToCart1 = By.CssSelector("button[data-test='add-to-cart-sauce-labs-backpack']"); //Add to cart
    private readonly By ButtonRemove = By.CssSelector("button[data-test='remove-sauce-labs-backpack']"); //Remove
    private readonly By ButtonShoppingCart = By.ClassName("shopping_cart_link"); //Shopping cart
    private readonly By LabelCartBadge = By.ClassName("shopping_cart_badge"); //added products
    private readonly By LabelTitleProduct= By.ClassName("inventory_item_name"); //Sauce Labs Backpack
    public ProductsPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WaitHelper(driver);
    }//ctor

    public By GetProductLocator(string productName)
    {
        return By.CssSelector($"button[data-test='add-to-cart-sauce-labs-{productName}']");
    }//GetProductLocator
    public string GetProductsPageText()
    {
        return wait.WaitForElementVisible(LabelPageTittle).Text;
    }//GetProductsPageText

    public void ClickButtonAddToCart()
    {
        wait.WaitForElementClickable(ButtonAddToCart1).Click();
      
    }//ClickButtonAddToCart
    public void AddMultipleProductsToShoppingCart(List<ProductsData> products)
    {
        foreach (var product in products)
        {
            var productLocator = GetProductLocator(product.ProductName!.ToLower().Replace(" ", "-"));
            wait.WaitForElementClickable(productLocator).Click();
        }//foreach
    }//ClickButtonAddToCart

    public string GetCartBadge()
    {
        return wait.WaitForElementVisible(LabelCartBadge).Text;
    }//GetCartBadge

    public void ClickButtonRemove()
    {
        wait.WaitForElementClickable(ButtonRemove).Click();

    }//ClickButtonRemove

    public void ClickButtonShoppingCart()
    {
        wait.WaitForElementClickable(ButtonShoppingCart).Click();
    }//ClickButtonShoppingCart

    public string GetTitleProduct()
    {
        return wait.WaitForElementVisible(LabelTitleProduct).Text;
    }//GetCartBadge

}//class

