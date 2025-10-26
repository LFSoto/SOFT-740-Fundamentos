using System.Text.Json.Serialization;

namespace AutomationPracticeDemo.Tests.Tests.Login
{
    public class CartData
    {
       
        [JsonPropertyName("PrecioUnitario")]
        public string? precioUnitario { get; set; }
        [JsonPropertyName("PrecioTotal")]
        public string? precioTotal { get; set; }

        [JsonPropertyName("identificadorTest")]
        public string? IdentificadorTest { get; set; }

    }

}