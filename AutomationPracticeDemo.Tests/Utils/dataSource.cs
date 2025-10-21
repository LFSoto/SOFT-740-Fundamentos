using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using AutomationPracticeDemo.Tests.Tests.Login.Data;

namespace AutomationPracticeDemo.Tests.Utils
{
    public static class dataSources
    {
        public static IEnumerable<TestCaseData> TestCaseLogin()
        {
            var path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Tests", "Login", "Data", "LoginUsers.json"));
            if (!File.Exists(path))
                yield break;

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            // Read file content
            var json = File.ReadAllText(path);

            // Try to deserialize as list (array)
            List<LoginData>? list = null;
            try
            {
                list = JsonSerializer.Deserialize<List<LoginData>>(json, options);
            }
            catch { }

            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                    yield return new TestCaseData(item.Email, item.Password, item.textoEsperado).SetName(item.IdentificadorTest);
                yield break;
            }

            // Try to deserialize as single object
            LoginData? single = null;
            try
            {
                single = JsonSerializer.Deserialize<LoginData>(json, options);
            }
            catch { }

            if (single != null)
                yield return new TestCaseData(single.Email, single.Password, single.textoEsperado).SetName(single.IdentificadorTest);
        }//LoginDataCases



    }
}