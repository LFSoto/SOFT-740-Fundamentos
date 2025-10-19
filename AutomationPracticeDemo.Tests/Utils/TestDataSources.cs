using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using AutomationPracticeDemo.Tests.Models.ContactUs;
using AutomationPracticeDemo.Tests.Models.Login;
using AutomationPracticeDemo.Tests.Models.NewsLetter;
using AutomationPracticeDemo.Tests.Models.User;
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
            var path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Tests", "DataFiles", "LoginDataSet.json"));

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
                    yield return new TestCaseData(item.Email, item.Password, item.ExpectedMessage).SetName(item.TestName);
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
                yield return new TestCaseData(single.Email, single.Password, single.ExpectedMessage).SetName(single.TestName);
        }//LoginDataCases

        public static IEnumerable<TestCaseData> NewUserDataCases()
        {
            var path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Tests", "DataFiles", "NewUserDataSet.json"));
            if (!File.Exists(path))
                yield break;
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var json = File.ReadAllText(path);

            List<NewUserData>? list = null;
            try
            {
                list = JsonSerializer.Deserialize<List<NewUserData>>(json, options);
            }
            catch { }
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                    yield return new TestCaseData(item.Name, item.LastName, item.Gender, item.Password, item.Address, item.Country,
                        item.State, item.City, item.ZipCode, item.MobileNumber).SetName(item.TestName);
                yield break;
            }
            NewUserData? single = null;
            try
            {
                single = JsonSerializer.Deserialize<NewUserData>(json, options);
            }
            catch { }
            if (single != null)
                yield return new TestCaseData(single.Name, single.LastName, single.Gender, single.Password, single.Address, single.Country,
                    single.State, single.City, single.ZipCode, single.MobileNumber).SetName(single.TestName);
        }//NewUserDataCases

        public static IEnumerable<TestCaseData> ContactUsDataCases()
        {
            var path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Tests", "DataFiles", "ContactUsDataSet.json"));
            if (!File.Exists(path))
                yield break;
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var json = File.ReadAllText(path);

            List<ContactUsData>? list = null;
            try
            {
                list = JsonSerializer.Deserialize<List<ContactUsData>>(json, options);
            }
            catch { }
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                    yield return new TestCaseData(item.Name, item.Email, item.Subject, item.Message, item.FileName, item.ExpectedMessage).SetName(item.TestName);
                yield break;
            }
            ContactUsData? single = null;
            try
            {
                single = JsonSerializer.Deserialize<ContactUsData>(json, options);
            }
            catch { }
            if (single != null)
                yield return new TestCaseData(single.Name, single.Email, single.Subject, single.Message, single.FileName, single.ExpectedMessage).SetName(single.TestName);
        }//ContactUsDataCases

        public static IEnumerable<TestCaseData> NewsLetterDataCases()
        {
            var path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Tests", "DataFiles", "NewsLetterDataSet.json"));
            if (!File.Exists(path))
                yield break;
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var json = File.ReadAllText(path);
            List<NewsLetterData>? list = null;
            try
            {
                list = JsonSerializer.Deserialize<List<NewsLetterData>>(json, options);
            }
            catch { }
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                    yield return new TestCaseData(item.Email, item.ExpectedMessage).SetName(item.TestName);
                yield break;
            }
            NewsLetterData? single = null;
            try
            {
                single = JsonSerializer.Deserialize<NewsLetterData>(json, options);
            }
            catch { }
            if (single != null)
                yield return new TestCaseData(single.Email, single.ExpectedMessage).SetName(single.TestName);
        }//NewsLetterDataCases
    }//class
}//namespace