using System.Text.Json.Serialization;

namespace AutomationPracticeDemo.Tests.Tests.signupPage.TestDatasignup
{
    public class SignupData
    {
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        [JsonPropertyName("company")]
        public string? Company { get; set; }

        [JsonPropertyName("address1")]
        public string? Address1 { get; set; }

        [JsonPropertyName("address2")]
        public string? Address2 { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }

        [JsonPropertyName("city")]
        public string? City { get; set; }

        [JsonPropertyName("zipcode")]
        public string? Zipcode { get; set; }

        [JsonPropertyName("mobileNumber")]
        public string? MobileNumber { get; set; }

        [JsonPropertyName("day")]
        public string? Day { get; set; }

        [JsonPropertyName("year")]
        public string? Year { get; set; }

        [JsonPropertyName("month")]
        public string? Month { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        // Añadido: campos que espera el TestCaseSource / el test
        [JsonPropertyName("password")]
        public string? Password { get; set; }

        [JsonPropertyName("textoEsperado")]
        public string? TextoEsperado { get; set; }
    }

}