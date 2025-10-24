using OpenQA.Selenium.DevTools.V138.IndexedDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Tests.Data.LoginUsuarioExistente
{
    internal class LoginData
    {
        private class Credential
        {
            public string usuario { get; set; }
            public string contrasena { get; set; }
            public string valorHome { get; set; }
            public string valorUserLogin { get; set; }
            public string valorLogin { get; set; }

        }

        // 🔹 Ya no usamos variable estática
        public object[] getLoginData => CargarDatosDesdeJson();

        // Método auxiliar para leer el archivo JSON y convertirlo a object[]
        private static object[] CargarDatosDesdeJson()
        {
            string basePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\.."));
            string filePath = Path.GetFullPath(Path.Combine(basePath, "Tests", "Data", "LoginUsuario", "JsonData", "DataLogin.json"));
            //var projectDir = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\.."));
            //var filePath = Path.Combine(projectDir, "Tests", "Data", "LoginUsuario", "JsonData", "DataLogin.json");
            Console.WriteLine($"Ruta usada para el JSON: {filePath}");

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"No se encontró el archivo de datos: {filePath}");

            var json = File.ReadAllText(filePath);

            var datos = JsonSerializer.Deserialize<List<Credential>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Retorna un arreglo de object[]
            return datos?.Select(d => new object[] { d.usuario, d.contrasena, d.valorHome, d.valorUserLogin, d.valorLogin}).ToArray() ?? Array.Empty<object[]>();
        }
    }

}

