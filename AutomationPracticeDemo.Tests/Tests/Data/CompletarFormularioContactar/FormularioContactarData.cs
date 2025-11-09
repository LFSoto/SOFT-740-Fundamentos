using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Tests.Data.CompletarFormularioContactar
{
    internal class FormularioContactarData
    {
        private class Formulario
        {
            public string correo { get; set; }
            public string nombre { get; set; }
            public string subject { get; set; }
            public string mensaje { get; set; }
            public string valorTextUrl { get; set; }
            public string valorTextoAlerta { get; set; }
            public string valorMensajeExitoCorreo { get; set; }

        }

        // 🔹 Ya no usamos variable estática
        public object[] getCompletarFormularioContactarData => CargarDatosDesdeJson();

        // Método auxiliar para leer el archivo JSON y convertirlo a object[]
        private static object[] CargarDatosDesdeJson()
        {
            var filePath = Path.GetFullPath(
            Path.Combine(TestContext.CurrentContext.TestDirectory, @"..", @"..", @"..", "Tests", "Data", "CompletarFormularioContactar", "JsonFormularioContactar", "DataFormularioContactar.json"));
            
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"No se encontró el archivo de datos: {filePath}");

            var json = File.ReadAllText(filePath);

            var datos = JsonSerializer.Deserialize<List<Formulario>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Retorna un arreglo de object[]
            return datos?.Select(d => new object[] { d.correo, d.nombre, d.subject, d.mensaje, d.valorTextUrl, d.valorTextoAlerta, d.valorMensajeExitoCorreo }).ToArray() ?? Array.Empty<object[]>();
        }
    }
}
