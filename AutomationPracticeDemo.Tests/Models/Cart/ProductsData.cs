using System.Text.Json.Serialization;

namespace AutomationPracticeDemo.Tests.Models.Cart;

public class ProductsData
{
    [JsonPropertyName("productName")]
    public string? ProductName { get; set; }
}//class
//namespace