using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Tests.Login.Data
{
    public class LoginData
    {
        public string Email { get; init; } = "";
        public string Password { get; init; } = "";

        public string Result { get; init; } = "";

        public static IEnumerable<LoginData> TestCases()
        {
            // ruta relativa desde el directorio de ejecución de las pruebas
            var baseDir = TestContext.CurrentContext.WorkDirectory;
            var path = Path.Combine(baseDir,"Tests", "Login", "Data", "LoginData.json");

            if (!File.Exists(path))
            {
                // intenta una ruta alternativa en el proyecto (útil al ejecutar desde IDE)
                path = Path.Combine(Directory.GetCurrentDirectory(), "Tests", "Login", "Data", "LoginData.json");
            }

            var json = File.ReadAllText(path);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var list = JsonSerializer.Deserialize<List<LoginData>>(json, options) ?? new List<LoginData>();
            return list;
        }
        public bool IsValid => Result.Contains("Logged in as");
    }
}
