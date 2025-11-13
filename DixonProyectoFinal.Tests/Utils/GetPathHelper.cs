namespace DixonProyectoFinal.Tests.Utils
{
    /// <summary>
    /// Contiene los métodos necesarios para obtener la ruta de los archivos dentro del proyecto
    /// </summary>
    public class GetPathHelper
    {
        /// <summary>
        /// Obtiene la ruta donde está almacenado el archivo .json según la ruta relativa que reciba
        /// </summary>
        /// <param name="relativeFilePath"></param>
        /// <returns>El contenido del archivo ,json</returns>
        public string GetJsonFile(string relativeFilePath)
        {
            string jsonFilePath = Path.Combine(AppContext.BaseDirectory, relativeFilePath);
            return File.ReadAllText(jsonFilePath);
        }
    }
}
