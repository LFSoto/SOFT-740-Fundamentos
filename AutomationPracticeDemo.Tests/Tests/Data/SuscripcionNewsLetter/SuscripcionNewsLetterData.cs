using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Tests.Data.SuscripcionNewsLetter
{
    internal class SuscripcionNewsLetterData
    {
        private class Suscripcion
        {
            public string correo { get; set; }
            public string ValorMensajeExitoSuscripcion { get; set; }

        }

        // 🔹 Ya no usamos variable estática
        public object[] getSuscripcionNewsLetterData => CargarDatosDesdeJson();

        // Método auxiliar para leer el archivo JSON y convertirlo a object[]
        private static object[] CargarDatosDesdeJson()
        {
            var filePath = Path.GetFullPath(
            Path.Combine(TestContext.CurrentContext.TestDirectory, @"..", @"..", @"..", "Tests", "Data", "SuscripcionNewsLetter", "JsonSuscripcionNewsLetter", "DataSuscripcionNewsLetter.json"));

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"No se encontró el archivo de datos: {filePath}");

            var json = File.ReadAllText(filePath);

            var datos = JsonSerializer.Deserialize<List<Suscripcion>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Retorna un arreglo de object[]
            return datos?.Select(d => new object[] { d.correo, d.ValorMensajeExitoSuscripcion }).ToArray() ?? Array.Empty<object[]>();
        }
    }
}
