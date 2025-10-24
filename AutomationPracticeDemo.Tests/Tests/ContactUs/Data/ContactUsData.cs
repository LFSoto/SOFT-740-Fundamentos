using AutomationPracticeDemo.Tests.Tests.CartProducts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Tests.ContactUs.Data
{
    public class ContactUsData
    {
        public string Name { get; init; } = "";
        public string Email { get; init; } = "";
        public string Subject { get; init; } = "";
        public string Message { get; init; } = "";
        public string FilePath { get; init; } = "";
        public string SuccessMessage { get; init; } = "";

        public static IEnumerable<ContactUsData> TestCases()
        {
            // ruta relativa desde el directorio de ejecución de las pruebas
            var baseDir = TestContext.CurrentContext.TestDirectory;
            var path = Path.Combine(baseDir, "Tests", "ContactUs", "Data", "ContactUsData.json");

            if (!File.Exists(path))
            {
                // intenta una ruta alternativa en el proyecto (útil al ejecutar desde IDE)
                path = Path.Combine(Directory.GetCurrentDirectory(), "Tests", "ContactUs", "Data", "ContactUsData.json");
            }

            var json = File.ReadAllText(path);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var list = JsonSerializer.Deserialize<List<ContactUsData>>(json, options) ?? new List<ContactUsData>();
            return list;
        }
    }
}
