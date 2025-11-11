namespace AutomationSauceDemo.CalculatorLib;
public class Products
{
    private string productName;
    private decimal productPrice;

    public Products(string name, decimal price)
    {
        productName = name;
        productPrice = price;
    }//ctor
    public string GetProductName()
    {
        return productName;
    }//method
    public decimal GetProductPrice()
    {
        return productPrice;
    }//method
}//class
