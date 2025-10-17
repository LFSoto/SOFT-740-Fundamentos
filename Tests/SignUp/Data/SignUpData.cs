using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using NUnit.Framework;

namespace AutomationPracticeDemo.Tests.Tests.SignUp.Data
{
    public class SignUpData
    {
        public string Name { get; init; } = "";
        public string Email { get; init; } = "";
        public string Password { get; init; } = "";
        public string Day { get; init; } = "";
        public string Month { get; init; } = "";
        public string Year { get; init; } = "";
        public bool SpecialOffers { get; init; }
        public string FirstName { get; init; } = "";
        public string LastName { get; init; } = "";
        public string Company { get; init; } = "";
        public string Address1 { get; init; } = "";
        public string Country { get; init; } = "";
        public string State { get; init; } = "";
        public string City { get; init; } = "";
        public string ZipCode { get; init; } = "";
        public string MobileNumber { get; init; } = "";

        // Método estático que NUnit usará como TestCaseSource
        public static IEnumerable<SignUpData> TestCases()
        {
            // ruta relativa desde el directorio de ejecución de las pruebas
            var baseDir = TestContext.CurrentContext.WorkDirectory;
            var path = Path.Combine(baseDir, "Tests", "SignUp", "Data", "signups.json");

            if (!File.Exists(path))
            {
                // intenta una ruta alternativa en el proyecto (útil al ejecutar desde IDE)
                path = Path.Combine(Directory.GetCurrentDirectory(), "Tests", "SignUp", "Data", "signups.json");
            }

            var json = File.ReadAllText(path);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var list = JsonSerializer.Deserialize<List<SignUpData>>(json, options) ?? new List<SignUpData>();
            return list;
        }
    }
}