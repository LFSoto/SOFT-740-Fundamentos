using System;
using System.IO;
using System.Text.Json;
using AutomationPracticeDemo.Tests.Models.Login;

namespace AutomationPracticeDemo.Tests.Utils
{
    /// <summary>
    /// Helper para cargar datos de prueba desde archivos JSON.
    /// </summary>
    public static class DataLoader
    {
        /// <summary>
        /// Carga el LoginData desde el archivo por defecto:
        /// Tests/AutomationPractice/Data/LoginData.json (relativo a AppContext.BaseDirectory).
        /// </summary>
        public static LoginData LoadLoginData()
        {
            var fullPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Tests", "DataFiles", "LoginDataSet.json"));
            if (!File.Exists(fullPath))
                throw new FileNotFoundException($"Login data file not found: {fullPath}");

            var json = File.ReadAllText(fullPath);
            var loginData = JsonSerializer.Deserialize<LoginData>(json)
                ?? throw new InvalidOperationException("LoginData.json no contiene datos válidos");

            return loginData;
        }
    }
}
