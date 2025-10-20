using AutomationPracticeDemo.Tests.Utils;

namespace AutomationPracticeDemo.Tests.Tests.Practica4.Login.Data
{
    //Clase que contiene los métodos para extraer la data de archivo .json
    public static class LoginData
    {
        public static List<User> UserTestData()
        {
            var data = JsonDataLoaderHelper.LoadLoginData();
            List<User> users = new List<User>();

            foreach (var user in data.Users)
            {
                users.Add(user);
            }

            return users;
        }

        public static List<SignUp> SignUpTestData()
        {
            var data = JsonDataLoaderHelper.LoadLoginData();
            List<SignUp> signUpData = new List<SignUp>();

            foreach (var signUp in data.SignUpData)
            {
                signUpData.Add(signUp);
            }

            return signUpData;
        }
    }

    //Se define los campos para la entidad de User
    public class User
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public bool IsValid { get; set; }
    }

    //Se define los campos para la entidad de User
    public class SignUp
    {
        public required string Name { get; set; }
        public required string Password { get; set; }
        public required string Day { get; set; }
        public required string Month { get; set; }
        public required string Year { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Company { get; set; }
        public required string Address1 { get; set; }
        public required string Address2 { get; set; }
        public required string Country { get; set; }
        public required string State { get; set; }
        public required string City { get; set; }
        public required string ZipCode { get; set; }
        public required string MobileNumber { get; set; }
        public required string TestCaseNumber { get; set; }
    }

    public class LoginDataResult
    {
        public required List<User> Users { get; set; }
        public required List<SignUp> SignUpData { get; set; }
    }
}
