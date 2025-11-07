using System;
using System.Collections.Generic;
using System.IO;
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
            // Use AppContext.BaseDirectory for better compatibility with Reqnroll
            var baseDir = AppContext.BaseDirectory;
            var path = Path.Combine(baseDir, "Tests", "CartProducts", "Data", "CartProducts.json");

            if (!File.Exists(path))
            {
                // Fallback to current directory
                path = Path.Combine(Directory.GetCurrentDirectory(), "Tests", "CartProducts", "Data", "CartProducts.json");
            }

            if (!File.Exists(path))
            {
                // Try relative path from project root
                var projectRoot = Directory.GetParent(baseDir)?.Parent?.Parent?.Parent?.FullName;
                if (projectRoot != null)
                {
                    path = Path.Combine(projectRoot, "Tests", "CartProducts", "Data", "CartProducts.json");
                }
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"CartProducts.json not found. Searched paths: {path}");
            }

            var json = File.ReadAllText(path);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var list = JsonSerializer.Deserialize<List<CartProductsData>>(json, options) ?? new List<CartProductsData>();
            return list;
        }

        // Load a specific test case by index (useful for multiple scenarios)
        public static CartProductsData GetTestCase(int index = 0)
        {
            var testCases = TestCases().ToList();
            if (index >= testCases.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Test case index {index} out of range. Only {testCases.Count} test cases available.");
            }
            return testCases[index];
        }
    }
}
