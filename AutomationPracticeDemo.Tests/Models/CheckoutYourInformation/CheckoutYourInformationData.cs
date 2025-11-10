using System.Text.Json.Serialization;

namespace AutomationPracticeDemo.Tests.Models.CheckoutYourInformation
{
    public class CheckoutYourInformationData
    {
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        [JsonPropertyName("postalCode")]
        public string? PostalCode { get; set; }
    }//class
}//namespace