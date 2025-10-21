using AutomationPracticeDemo.Tests.Tests.Login.Data;
using AutomationPracticeDemo.Tests.Tests.signupPage.TestDatasignup;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection.Emit;
using System.Text.Json;

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
        public static IEnumerable<TestCaseData> TestCaseSignup()
        {
            var path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Tests", "signupLogin", "SignupLoginUsers.json"));
            if (!File.Exists(path))
                yield break;

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var json = File.ReadAllText(path);

            // Deserializar como lista de SignupData
            List<SignupData>? list = null;
            try
            {
                list = JsonSerializer.Deserialize<List<SignupData>>(json, options);
            }
            catch { }

            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                   
                    yield return new TestCaseData(
                        item.Password,
                        item.TextoEsperado,
                        item.FirstName,
                        item.LastName,
                        item.Company,
                        item.Address1,
                        item.Address2,
                        item.Country,
                        item.State,
                        item.City,
                        item.Zipcode,
                        item.MobileNumber,
                        item.Day,
                        item.Month,
                        item.Year,
                        item.Name
                    ).SetName(item.Name ?? item.Email ?? "Signup");
                }
                yield break;
            }

            // Deserializar como objeto único
            SignupData? single = null;
            try
            {
                single = JsonSerializer.Deserialize<SignupData>(json, options);
            }
            catch { }

            if (single != null)
                yield return new TestCaseData(
                    single.Password,
                    single.TextoEsperado,
                    single.FirstName,
                    single.LastName,
                    single.Company,
                    single.Address1,
                    single.Address2,
                    single.Country,
                    single.State,
                    single.City,
                    single.Zipcode,
                    single.MobileNumber,
                    single.Day,
                    single.Month,
                    single.Year,
                    single.Name
                ).SetName(single.Name ?? single.Email ?? "Signup");
        }//SignupDataCases
    }
}