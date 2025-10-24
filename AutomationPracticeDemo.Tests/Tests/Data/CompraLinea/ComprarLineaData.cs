using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Tests.Data.CompraLinea
{
    internal class ComprarLineaData
    {
        private class ComprarLinea
        {
            public string correo { get; set; }
            public string contrasenna { get; set; }
            public int Idproducto1 { get; set; }
            public int Idproducto2 { get; set; }
            public string nombre { get; set; }
            public string numTarjeta { get; set; }
            public string cvc { get; set; }
            public string mes { get; set; }
            public string anno { get; set; }
            public string valorHome { get; set; }
            public string valorLogin { get; set; }
            public string valorTituloFormularioProductos { get; set; }
            public string valorTitleProductoAgregado { get; set; }
            public string valorDescripcionproducto1 { get; set; }
            public string valorDescripcionproducto2 { get; set; }
            public string valorConfirmarOrdenFinalizada { get; set; }

        }

        // 🔹 Ya no usamos variable estática
        public object[] getCompraLineaData => CargarDatosDesdeJson();

        // Método auxiliar para leer el archivo JSON y convertirlo a object[]
        private static object[] CargarDatosDesdeJson()
        {
             string basePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\.."));
             string filePath = Path.GetFullPath(Path.Combine(basePath, "Tests", "Data", "CompraLinea", "JsonComprarLinea", "DataCompraLinea.json"));

            //var projectDir = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\.."));
            //var filePath = Path.Combine(projectDir, "Tests", "Data", "CompraLinea", "JsonComprarLinea", "DataCompraLinea.json");

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"No se encontró el archivo de datos: {filePath}");

            var json = File.ReadAllText(filePath);

            var datos = JsonSerializer.Deserialize<List<ComprarLinea>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Retorna un arreglo de object[]
            return datos?.Select(d => new object[] { d.correo, d.contrasenna, d.Idproducto1, d.Idproducto2, d.nombre, d.numTarjeta, d.cvc, d.mes, d.anno, d.valorHome, d.valorLogin, d.valorTituloFormularioProductos, d.valorTitleProductoAgregado, d.valorDescripcionproducto1, d.valorDescripcionproducto2, d.valorConfirmarOrdenFinalizada }).ToArray() ?? Array.Empty<object[]>();
        }
    }
}
