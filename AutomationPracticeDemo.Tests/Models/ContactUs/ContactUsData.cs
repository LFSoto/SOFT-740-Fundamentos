using System.Text.Json.Serialization;

namespace AutomationPracticeDemo.Tests.Models.ContactUs
{
    public class ContactUsData
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        
        [JsonPropertyName("email")]
        public string? Email { get; set; }
        
        [JsonPropertyName("subject")]
        public string? Subject { get; set; }
        
        [JsonPropertyName("message")]
        public string? Message { get; set; }
        
        [JsonPropertyName("fileName")]
        public string? FileName { get; set; }

        [JsonPropertyName("testName")]
        public string? TestName { get; set; }

        [JsonPropertyName("expectedMessage")]
        public string? ExpectedMessage { get; set; }
    }//class
}//namespace
