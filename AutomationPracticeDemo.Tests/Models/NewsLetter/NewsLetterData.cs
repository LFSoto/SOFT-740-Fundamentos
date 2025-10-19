using System.Text.Json.Serialization;

namespace AutomationPracticeDemo.Tests.Models.NewsLetter
{
    public class NewsLetterData
    {
        [JsonPropertyName("email")]
        public string? Email { get; set; }
        
        [JsonPropertyName("expectedMessage")]
        public string? ExpectedMessage { get; set; }

        [JsonPropertyName("testName")]
        public string? TestName { get; set; }

    }//class
}//namespace
