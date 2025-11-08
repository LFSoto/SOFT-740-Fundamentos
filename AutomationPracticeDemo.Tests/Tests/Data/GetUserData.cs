using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Tests.Data
{

    public static class GetUserData
    {

        /*===============================================================*/
        //Datos de prueba para loguearse con un usuario existente
        /*===============================================================*/
        public class LoginData
        {
            public string emailText { get; set; } = string.Empty;
            public string password { get; set; } = string.Empty;
        }
        public static List<LoginData> UserLoginList
        {
            get
            {
                var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Tests/Data", "UserLoginData.json");
                var file = File.ReadAllText(path);
                var jsonObject = JObject.Parse(file);

                return jsonObject["ExistingUserLogin"]?.ToObject<List<LoginData>>() ?? new List<LoginData>();
            }
        }
       /* public static object[] UserLogin
        {
            get
            {
                var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Tests/Data", "UserLoginData.json");
                var file = File.ReadAllText(path);

                var jsonObject = JObject.Parse(file);
                var userArray = jsonObject["ExistingUserLogin"]?.ToObject<List<LoginData>>() ?? new List<LoginData>();

                return userArray
                    .Where(x => x.emailText != null && x.password != null)
                    .Select(x => new object[] { x.emailText ?? "", x.password ?? "" })
                    .ToArray();
            }
        }*/
        /*===============================================================*/
        //Datos de prueba para Crerar un nuevo usuario
        /*===============================================================*/
        public class NewUserLoginData
        {
            public string password { get; set; } = string.Empty;
            public string dropDownDay { get; set; } = string.Empty;
            public string dropDownMonth { get; set; } = string.Empty;
            public string dropDownYear { get; set; } = string.Empty;
            public string inputFirstName { get; set; } = string.Empty;
            public string inputLastName { get; set; } = string.Empty;
            public string inputCompanyName { get; set; } = string.Empty;
            public string inputAddress1 { get; set; } = string.Empty;
            public string inputAddress2 { get; set; } = string.Empty;
            public string dropDownCountry { get; set; } = string.Empty;
            public string inputState { get; set; } = string.Empty;
            public string inputCity { get; set; } = string.Empty;
            public string inputZipCode { get; set; } = string.Empty;
            public string inputMobileNumb { get; set; } = string.Empty;
        }

        public static List<NewUserLoginData> NewUserLoginList
        {
            get
            {
                var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Tests/Data", "UserLoginData.json");
                var file = File.ReadAllText(path);
                var jsonObject = JObject.Parse(file);

                return jsonObject["CreateNewUser"]?.ToObject<List<NewUserLoginData>>() ?? new List<NewUserLoginData>();
            }
        }

       

        /*===============================================================*/
        //Datos de prueba para Contact Us
        /*===============================================================*/
        public class ContactData
        {
            public string? inputName { get; set; }
            public string? inputEmail { get; set; }
            public string? inputSubject { get; set; }
            public string? inputMessage { get; set; }

            //Datos para el login para ingresar a Contact Us
            public string? emailText { get; set; }
            public string? password { get; set; }
        }

        public static object[] UserContactData
        {
            get
            {
                var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Tests/Data", "UserLoginData.json");
                var file = File.ReadAllText(path);

                var jsonObject = JObject.Parse(file);
                var getContactUsData = jsonObject["ContactUs"]?.ToObject<List<ContactData>>() ?? new List<ContactData>();

                return getContactUsData
                    .Where(x => x.inputName != null && x.inputEmail != null && x.inputSubject != null && x.inputMessage != null && x.emailText != null && x.password != null)
                    .Select(x => new object[] { x.inputName ?? "", x.inputEmail ?? "", x.inputSubject ?? "", x.inputMessage ?? "", x.emailText ?? "", x.password ?? "" })
                    .ToArray();
            }
        }

        /*===============================================================*/
        //Datos de prueba para NewsLetter
        /*===============================================================*/
        public class NewLetterData
        {
            public string? emailText { get; set; }
        }

        public static object[] UserNewLetterData
        {
            get
            {
                var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Tests/Data", "UserLoginData.json");
                var file = File.ReadAllText(path);

                var jsonObject = JObject.Parse(file);
                var getNewLetterData = jsonObject["NewLetter"]?.ToObject<List<ContactData>>() ?? new List<ContactData>();

                return getNewLetterData
                    .Where(x => x.emailText != null)
                    .Select(x => new object[] { x.emailText ?? "" })
                    .ToArray();
            }
        }
    }


}
