using Newtonsoft.Json.Linq;

namespace Proyecto_SwagLabs.Tests.Utils
{
    /// <summary>
    /// Utilidad para cargar archivos JSON de la carpeta Tests/TestData.
    /// </summary>
    public static class TestDataLoader
    {
        private static readonly string BasePath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            @"..\..\..\Tests\TestData");

        /// <summary>
        /// Carga un archivo JSON relativo a la carpeta TestData y lo devuelve como <see cref="JObject"/>.
        /// </summary>
        /// <param name="relativePath">Ruta relativa al JSON, por ejemplo <c>"Login/loginUser.json"</c>.</param>
        public static JObject Load(string relativePath)
        {
            var fullPath = Path.Combine(BasePath, relativePath);

            if (!File.Exists(fullPath))
                throw new FileNotFoundException($"No se encontró el archivo JSON: {fullPath}", fullPath);

            var json = File.ReadAllText(fullPath);
            return JObject.Parse(json);
        }
    }
}

