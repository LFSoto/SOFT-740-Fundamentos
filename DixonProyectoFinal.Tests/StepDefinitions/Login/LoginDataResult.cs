using DixonProyectoFinal.Tests.Utils;

namespace DixonProyectoFinal.Tests.StepDefinitions.Login
{
    public class LoginDataResult
    {
        public required List<LoginData> LoginData { get; set; }
    }

    public class LoginData
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }

}
