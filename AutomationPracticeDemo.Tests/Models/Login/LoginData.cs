using System.Text.Json.Serialization;

namespace AutomationPracticeDemo.Tests.Models.Login
{
    public class LoginData
    {
        [JsonPropertyName("userName")]
        public string? UserName { get; set; }

        [JsonPropertyName("password")]
        public string? Password { get; set; }
    }//class
}//namespace