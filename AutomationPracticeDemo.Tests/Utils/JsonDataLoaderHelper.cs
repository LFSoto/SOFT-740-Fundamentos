using AutomationPracticeDemo.Tests.Tests.Practica4.Login.Data;
using Newtonsoft.Json;
using System.Reflection;

namespace AutomationPracticeDemo.Tests.Utils
{
    public static class JsonDataLoaderHelper
    {
        public static LoginDataResult LoadLoginData()
        {
            string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
            string jsonFilePath = Path.Combine(assemblyPath, "Tests\\Practica4\\Login\\Data\\Login.json");
            string jsonString = File.ReadAllText(jsonFilePath);

            var result = JsonConvert.DeserializeObject<LoginDataResult>(jsonString);
            if (result == null)
                throw new InvalidOperationException("Failed to deserialize LoginDataResult from JSON.");
            return result;
        }
    }
}
