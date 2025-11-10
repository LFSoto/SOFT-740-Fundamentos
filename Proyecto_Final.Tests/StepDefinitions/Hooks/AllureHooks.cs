using System;
using System.IO;
using Allure.Net.Commons;
using OpenQA.Selenium;
using Reqnroll;

namespace Proyecto_SwagLabs.Tests.StepDefinitions.Hooks
{
    /// <summary>
    /// Hook que toma capturas de pantalla al fallar un paso y las adjunta al reporte de Allure.
    /// Compatible con la API moderna de Allure (AllureApi).
    /// </summary>
    [Binding]
    public class AllureHooks
    {
        private readonly ScenarioContext _scenarioContext;

        public AllureHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [AfterStep]
        public void CaptureScreenshotOnFailure()
        {
            if (_scenarioContext.TestError == null)
                return;

            if (!_scenarioContext.TryGetValue("WebDriver", out IWebDriver? driver) || driver == null)
                return;

            try
            {
                // Captura el screenshot en memoria
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                var screenshotBytes = screenshot.AsByteArray;

                var fileName = $"screenshot_{DateTime.Now:yyyyMMdd_HHmmssfff}.png";

                // Adjunta directamente el contenido al reporte Allure
                AllureApi.AddAttachment(
                    name: fileName,
                    type: "image/png",
                    content: screenshotBytes
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[AllureHooks] Error al capturar screenshot: {ex.Message}");
            }
        }
    }
}
