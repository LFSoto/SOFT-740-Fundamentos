
using System.Text.Json.Serialization;

namespace AutomationPracticeDemo.Tests.Tests.Login.Data
{
    public class LoginData
    {
        [JsonPropertyName("Name")]
        public string? TestName { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }


        [JsonPropertyName("password")]
        public string? Password { get; set; }


        [JsonPropertyName("textoEsperado")]
        public string? textoEsperado { get; set; }

        [JsonPropertyName("IdentificadorTest")]
        public string? IdentificadorTest { get; set; }
    }

}