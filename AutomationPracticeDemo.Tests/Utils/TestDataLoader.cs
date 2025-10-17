using Newtonsoft.Json.Linq;

namespace AutomationPracticeDemo.Tests.Utils
{
    /// <summary>
    /// Clase auxiliar para la carga de datos de prueba desde archivos JSON.
    /// </summary>
    public static class TestDataLoader
    {
        // Ruta relativa al archivo TestData.json dentro del proyecto
        private static readonly string _filePath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Tests\TestData\TestData.json");

        /// <summary>
        /// Carga el archivo <c>TestData.json</c> y devuelve su contenido como un objeto dinámico.
        /// </summary>
        /// <returns>Objeto <see cref="JObject"/> con los datos del archivo JSON.</returns>
        /// <exception cref="FileNotFoundException">Si el archivo no existe en la ruta indicada.</exception>
        /// <exception cref="JsonReaderException">Si el contenido del archivo no tiene formato JSON válido.</exception>
        public static dynamic LoadTestData()
        {
            // Lee el contenido del archivo
            var json = File.ReadAllText(_filePath);

            // Convierte el texto JSON en un objeto dinámico
            return JObject.Parse(json);
        }
    }
}
