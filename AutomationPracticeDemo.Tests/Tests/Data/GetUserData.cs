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
            public string emailText { get; set; }
            public string password { get; set; }
        }

        public static object[] UserLogin
        {
            get
            {
                var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Tests/Data", "UserLoginData.json");
                var file = File.ReadAllText(path);

                var jsonObject = JObject.Parse(file);
                var userArray = jsonObject["ExistingUserLogin"].ToObject<List<LoginData>>();

                return userArray
                    .Where(x => x.emailText != null && x.password != null)
                    .Select(x => new object[] { x.emailText, x.password })
                    .ToArray();
            }
        }
        /*===============================================================*/
        //Datos de prueba para Crerar un nuevo usuario
        /*===============================================================*/
        public class NewUSerLoginData
        {
            public string password { get; set; }
            public string dropDownDay { get; set; }
            public string dropDownMonth { get; set; }
            public string dropDownYear { get; set; }
            public string inputFirstName { get; set; }
            public string inputLastName { get; set; }
            public string inputCompanyName { get; set; }
            public string inputAddress1 { get; set; }
            public string inputAddress2 { get; set; }
            public string dropDownCountry { get; set; }
            public string inputState { get; set; }
            public string inputCity { get; set; }
            public string inputZipCode { get; set; }
            public string inputMobileNumb { get; set; }
        }


        public static object[] NewUserLogin
        {
            get
            {
                var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Tests/Data", "UserLoginData.json");
                var file = File.ReadAllText(path);

                var jsonObject = JObject.Parse(file);
                var getUserData = jsonObject["CreateNewUser"].ToObject<List<NewUSerLoginData>>();

                return getUserData
                    .Where(x => x.password != null
                    && x.dropDownDay != null
                    && x.dropDownMonth != null
                    && x.dropDownYear != null
                    && x.inputFirstName != null
                    && x.inputLastName != null
                    && x.inputCompanyName != null
                    && x.inputAddress1 != null
                    && x.inputAddress2 != null
                    && x.dropDownCountry != null
                    && x.inputState != null
                    && x.inputCity != null
                    && x.inputZipCode != null
                    && x.inputMobileNumb != null)
                    .Select(x => new object[] { x.password,
                    x.dropDownDay,
                    x.dropDownMonth,
                    x.dropDownYear,
                    x.inputFirstName,
                    x.inputLastName,
                    x.inputCompanyName,
                    x.inputAddress1,
                    x.inputAddress2,
                    x.dropDownCountry,
                    x.inputState,
                    x.inputCity,
                    x.inputZipCode,
                    x.inputMobileNumb})
                    .ToArray();
            }
        }

        /*===============================================================*/
        //Datos de prueba para Contact Us
        /*===============================================================*/
        public class ContactData
        {
            public string inputName { get; set; }
            public string inputEmail { get; set; }
            public string inputSubject { get; set; }
            public string inputMessage { get; set; }

            //Datos para el login para ingresar a Contact Us
            public string emailText { get; set; }
            public string password { get; set; }
        }

        public static object[] UserContactData
        {
            get
            {
                var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Tests/Data", "UserLoginData.json");
                var file = File.ReadAllText(path);

                var jsonObject = JObject.Parse(file);
                var getContactUsData = jsonObject["ContactUs"].ToObject<List<ContactData>>();

                return getContactUsData
                    .Where(x => x.inputName != null && x.inputEmail != null && x.inputSubject != null && x.inputMessage != null && x.emailText != null && x.password != null)
                    .Select(x => new object[] { x.inputName, x.inputEmail, x.inputSubject, x.inputMessage, x.emailText, x.password })
                    .ToArray();
            }
        }

        /*===============================================================*/
        //Datos de prueba para NewsLetter
        /*===============================================================*/
        public class NewLetterData
        {
            public string emailText { get; set; }
        }

        public static object[] UserNewLetterData
        {
            get
            {
                var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Tests/Data", "UserLoginData.json");
                var file = File.ReadAllText(path);

                var jsonObject = JObject.Parse(file);
                var getNewLetterData = jsonObject["NewLetter"].ToObject<List<ContactData>>();

                return getNewLetterData
                    .Where(x => x.emailText != null)
                    .Select(x => new object[] { x.emailText })
                    .ToArray();
            }
        }
    }


}
