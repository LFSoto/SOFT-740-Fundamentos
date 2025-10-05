using OpenQA.Selenium;

namespace AutomationPracticeDemo.Tests.Utils
{
    public static class ScreenshotHelper
    {
        public static void TakeScreenshot(IWebDriver driver, string fileName)
        {
            // Sube tres niveles: bin -> Debug -> netX.X -> raíz del proyecto AutomationPracticeDemo.Tests
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\.."));

            // Carpeta "Screenshots" dentro del proyecto
            string screenshotsDir = Path.Combine(projectDirectory, "Screenshots", DateTime.Now.ToString("yyyy-MM-dd"));
            Directory.CreateDirectory(screenshotsDir);

            // Nombre de archivo con marca de tiempo, se puede quitar quitando el timestamp del fullPath
            string timestamp = DateTime.Now.ToString("HHmmss");
            string fullPath = Path.Combine(screenshotsDir, $"{fileName}_{timestamp}.png");

            // Toma y guardar el screenshot
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(fullPath);

        }
    }
}
