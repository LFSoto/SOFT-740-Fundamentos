using DixonProyectoFinal.Tests.StepDefinitions.Login;
using Newtonsoft.Json;

namespace DixonProyectoFinal.Tests.Utils
{
    /// <summary>
    /// Contiene los métodos necesarios para desearilizar los datos dentros de los archivos .json
    /// </summary>
    public static class JsonLoaderDataHelper
    {
        /// <summary>
        /// Deserealiza los objetos del archivo .json y los asigna a un objeto de tipo LoginDataResult
        /// </summary>
        /// <returns>Un objeto del tipo LoginDataResult</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static LoginDataResult LoadLoginData()
        {
            GetPathHelper getPathHelper = new GetPathHelper();
            string jsonString = getPathHelper.GetJsonFile(Constants.Paths.LoginJsonFile);

            var result = JsonConvert.DeserializeObject<LoginDataResult>(jsonString);

            if (result == null)
                throw new InvalidOperationException("Failed to deserialize LoginDataResult from JSON.");
            return result;
        }
    }
}
