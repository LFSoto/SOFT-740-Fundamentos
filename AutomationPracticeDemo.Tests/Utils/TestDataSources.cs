using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using AutomationPracticeDemo.Tests.Models.Login;
using AutomationPracticeDemo.Tests.Models.CheckoutYourInformation;
using NUnit.Framework;

namespace AutomationPracticeDemo.Tests.Utils
{
    public static class TestDataSources
    {
        /// <summary>
        /// Devuelve casos de prueba para login. Soporta:
        /// - Un único objeto JSON { "email": "...", "password":"..."}
        /// - Un array JSON [{ "email":"...","password":"..." }, ...]
        /// </summary>
        public static IEnumerable<TestCaseData> LoginDataCases()
        {
            // Replacing FileIO.GetFullPathFromBase with Path.Combine and Directory.GetCurrentDirectory
            var path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Tests", "DataFiles", "Login", "LoginDataSet.json"));

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
                    yield return new TestCaseData(item.UserName, item.Password);
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
                yield return new TestCaseData(single.UserName, single.Password);
        }//LoginDataCases

        public static LoginData GetTestCaseByIndex(int index)
        {
            var path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Tests", "DataFiles", "Login", "LoginDataSet.json"));
            if (!File.Exists(path))
                throw new FileNotFoundException($"The file at path {path} was not found.");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var json = File.ReadAllText(path);
            List<LoginData>? list = null;
            try
            {
                list = JsonSerializer.Deserialize<List<LoginData>>(json, options);
            }
            catch { }
            if (list != null && index >= 0 && index < list.Count)
                return list[index];
            throw new IndexOutOfRangeException($"No test case found at index {index}.");
        }//GetTestCaseByIndex

        /// <summary>
        /// Devuelve casos de prueba para CheckoutYourInformation. Soporta:
        /// - Un único objeto JSON { "firstName": "...", "lastName":"...", "postalCode":"..."}
        /// - Un array JSON [{ "firstName":"...","lastName":"...", "postalCode":"..." }, ...]
        /// </summary>
        public static IEnumerable<TestCaseData> CheckoutYourInformationDataCases()
        {
            // Replacing FileIO.GetFullPathFromBase with Path.Combine and Directory.GetCurrentDirectory
            var path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Tests", "DataFiles", "Checkout", "CheckoutYourInformationDataSet.json"));

            if (!File.Exists(path))
                yield break;

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            // Read file content
            var json = File.ReadAllText(path);

            // Try to deserialize as list (array)
            List<CheckoutYourInformationData>? list = null;
            try
            {
                list = JsonSerializer.Deserialize<List<CheckoutYourInformationData>>(json, options);
            }
            catch { }

            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                    yield return new TestCaseData(item.FirstName,item.LastName,item.PostalCode);
                yield break;
            }

            // Try to deserialize as single object
            CheckoutYourInformationData? single = null;
            try
            {
                single = JsonSerializer.Deserialize<CheckoutYourInformationData>(json, options);
            }
            catch { }

            if (single != null)
                yield return new TestCaseData(single.FirstName, single.LastName,single.PostalCode);
        }//CheckoutYourInformationData

        public static CheckoutYourInformationData GetTestCaseByIndexCheckout(int index)
        {
            var path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Tests", "DataFiles", "Checkout", "CheckoutYourInformationDataSet.json"));
            if (!File.Exists(path))
                throw new FileNotFoundException($"The file at path {path} was not found.");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var json = File.ReadAllText(path);
            List<CheckoutYourInformationData>? list = null;
            try
            {
                list = JsonSerializer.Deserialize<List<CheckoutYourInformationData>>(json, options);
            }
            catch { }
            if (list != null && index >= 0 && index < list.Count)
                return list[index];
            throw new IndexOutOfRangeException($"No test case found at index {index}.");
        }//GetTestCaseByIndexCheckout

    }//class
}//namespace