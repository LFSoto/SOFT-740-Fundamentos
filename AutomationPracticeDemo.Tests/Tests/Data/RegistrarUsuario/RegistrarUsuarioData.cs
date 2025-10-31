using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Tests.Data.RegistrarUsuario
{
    internal class RegistrarUsuarioData
    {
        private class Registrar
        {
            public string nombre { get; set; }
            public string pass { get; set; }
            public string AnnoNacimiento { get; set; }
            public string pais { get; set; }
            public string nombrecompleto { get; set; }
            public string apellidos { get; set; }
            public string compania { get; set; }
            public string dprincipal { get; set; }
            public string dsecundaria { get; set; }
            public string estado { get; set; }
            public string ciudad { get; set; }
            public string postal { get; set; }
            public string telefono { get; set; }
            public string valorHome { get; set; }
            public string valorUsuario { get; set; }
            public string valorTituloFormulario { get; set; }
            public string valorMensajeConfirmar { get; set; }
            public string valorLogin { get; set; }

        }

        //Ya no usamos variable estática
        public object[] getRegistrarUsuarioData => CargarDatosDesdeJson();

        // Método auxiliar para leer el archivo JSON y convertirlo a object[]
        private static object[] CargarDatosDesdeJson()
        {
            var filePath = Path.GetFullPath(
            Path.Combine(TestContext.CurrentContext.TestDirectory, @"..", @"..", @"..", "Tests", "Data", "RegistrarUsuario", "JsonRegistroUsuario", "DataRegistroUsuario.json"));

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"No se encontró el archivo de datos: {filePath}");

            var json = File.ReadAllText(filePath);

            var datos = JsonSerializer.Deserialize<List<Registrar>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            //Generar correo aleatorio en memoria
            //foreach (var d in datos)
            //{
            //  if (string.IsNullOrEmpty(d.correo) || d.correo.Contains("Email_random"))
            //{
            //      d.correo = $"usuario{Guid.NewGuid().ToString("N").Substring(0, 8)}@gmail.com";
            // }
            //}

            // Retorna un arreglo de object[]
            return datos?.Select(d => new object[] { d.nombre,d.pass,d.AnnoNacimiento,d.pais,d.nombrecompleto,d.apellidos,d.compania,d.dprincipal,d.dsecundaria,d.estado,d.ciudad,d.postal,d.telefono,d.valorHome,d.valorUsuario,d.valorTituloFormulario,d.valorMensajeConfirmar,d.valorLogin}).ToArray() ?? Array.Empty<object[]>();
        }
    }
}
