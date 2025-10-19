using System.Text.Json.Serialization;

namespace AutomationPracticeDemo.Tests.Models.Login
{
    public class LoginData
    {
        [JsonPropertyName("testName")]
        public string? TestName { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("password")]
        public string? Password { get; set; }

        [JsonPropertyName("expectedMessage")]
        public string? ExpectedMessage { get; set; }
    }//class
}//namespace