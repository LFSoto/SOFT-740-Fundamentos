using AutomationPracticeDemo.Tests.Tests.Login.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Tests.CartProducts.Data
{
    public class CartProductsData
    {
        public string Email { get; init; } = "";
        public string Password { get; init; } = "";
        public string Price1 { get; init; } = "";
        public string Price2 { get; init; } = "";
        public string Cant1 { get; init; } = "";
        public string Cant2 { get; init; } = "";
        public string TotalProd1 { get; init; } = "";
        public string TotalProd2 { get; init; } = "";
        public string Total { get; init; } = "";
        public int IdProduct1 { get; init; }
        public int IdProduct2 { get; init; }


        public static IEnumerable<CartProductsData> TestCases()
        {
            // ruta relativa desde el directorio de ejecución de las pruebas
            var baseDir = TestContext.CurrentContext.WorkDirectory;
            var path = Path.Combine(baseDir, "Tests", "CartProducts", "Data", "CartProducts.json");

            if (!File.Exists(path))
            {
                // intenta una ruta alternativa en el proyecto (útil al ejecutar desde IDE)
                path = Path.Combine(Directory.GetCurrentDirectory(), "Tests", "CartProducts", "Data", "CartProducts.json");
            }

            var json = File.ReadAllText(path);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var list = JsonSerializer.Deserialize<List<CartProductsData>>(json, options) ?? new List<CartProductsData>();
            return list;
        }

    }
}
