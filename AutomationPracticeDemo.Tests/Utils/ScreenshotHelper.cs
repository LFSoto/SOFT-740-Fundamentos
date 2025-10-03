using OpenQA.Selenium;

namespace AutomationPracticeDemo.Tests.Utils
{
    public static class ScreenshotHelper
    {
        private static string screenshotsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Screenshots"); //SOFT-740-Fundamentos\AutomationPracticeDemo.Tests\Screenshots
        private static DateTime now = DateTime.Now;
        public static void TakeScreenshot(IWebDriver driver, string fileName)
        {          
            fileName = $"{now:yyyyMMdd_HHmmss}_{fileName}";
            Directory.CreateDirectory(screenshotsDirectory); // Ensure directory exists
            var screenshotPath = Path.Combine(screenshotsDirectory, fileName);
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(screenshotPath);
        }// TakeScreenshot
    }//class
}//namespace
