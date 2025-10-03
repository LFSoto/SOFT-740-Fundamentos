using OpenQA.Selenium;

namespace AutomationPracticeDemo.Tests.Utils
{
    public static class ScreenshotHelper
    {
        public static void TakeScreenshot(IWebDriver driver, string fileName)
        {
            // Genera un nombre de archivo único
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string folderName = $"Evidencias";
            string filePath = Path.Combine(folderName, fileName);


            // Crea la carpeta si no existe
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }

            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(filePath);
        }
    }
}
