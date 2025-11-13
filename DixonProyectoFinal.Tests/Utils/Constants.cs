namespace DixonProyectoFinal.Tests.Utils
{
    /// <summary>
    /// Contiene las constantes utilizadas en todo el proyecto
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Contiene las rutas predefinidas para guardar o extraer archivos dentro del proyecto
        /// </summary>
        public struct Paths
        {
            public const string LoginJsonFile = "../../../StepDefinitions/Login/Login.json";
        }

        /// <summary>
        /// Contiene las constantes que se usaran en gerenal en las Pages
        /// </summary>
        public struct Pages
        {
            public const int TimeOut = 10;
        }

        public struct ItemsPositions
        {
            public static readonly string[] ThreeItems =  ["1","2","3"];
        }
    }
}
