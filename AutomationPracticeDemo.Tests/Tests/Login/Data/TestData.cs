using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Pages.AutomationExercisePage;
using AutomationPracticeDemo.Tests.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using System.IO;
using System.Collections;
namespace AutomationPracticeDemo.Tests.Tests.Login.Data
{
    public class TestData
    {
        public static IEnumerable LoginUsers
        {
            get
            {
                //Cargar el archivo JSON
                var json = File.ReadAllText("Test/Data/LoginUsers.json");
                var users = JsonConvert.DeserializeObject<dynamic>(json);
                foreach (var u in users) yield return new object[] { u };
            }
        }

    }
}
