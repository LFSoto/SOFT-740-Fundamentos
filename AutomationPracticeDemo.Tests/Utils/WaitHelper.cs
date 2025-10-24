using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationPracticeDemo.Tests.Utils
{
    public class WaitHelper
    {
        private readonly IWebDriver driver;

        // Global default timeout (seconds). Can be configured at test startup.
        public static int GlobalDefaultTimeoutSeconds { get; set; } = 10;

        public TimeSpan DefaultTimeout { get; set; }

        public WaitHelper(IWebDriver driver, int? defaultTimeoutSeconds = null)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            // Use provided timeout if given, otherwise use global default
            DefaultTimeout = TimeSpan.FromSeconds(defaultTimeoutSeconds ?? GlobalDefaultTimeoutSeconds);
        }

        private TimeSpan GetTimeout(int? seconds) => seconds.HasValue ? TimeSpan.FromSeconds(seconds.Value) : DefaultTimeout;

        public IWebElement WaitForElementVisible(By locator, int? timeoutSeconds = null)
        {
            var wait = new WebDriverWait(driver, GetTimeout(timeoutSeconds));
            return wait.Until(d =>
            {
                try
                {
                    var el = d.FindElement(locator);
                    return el.Displayed ? el : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            });
        }

        public ReadOnlyCollection<IWebElement> WaitForElementsPresent(By locator, int? timeoutSeconds = null)
        {
            var wait = new WebDriverWait(driver, GetTimeout(timeoutSeconds));
            return wait.Until(d =>
            {
                try
                {
                    var elems = d.FindElements(locator);
                    return elems.Count > 0 ? elems : null;
                }
                catch
                {
                    return null;
                }
            });
        }

        public IWebElement WaitForElementClickable(By locator, int? timeoutSeconds = null)
        {
            var wait = new WebDriverWait(driver, GetTimeout(timeoutSeconds));
            return wait.Until(d =>
            {
                try
                {
                    var el = d.FindElement(locator);
                    return (el.Displayed && el.Enabled) ? el : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            });
        }

        public bool WaitForElementInvisible(By locator, int? timeoutSeconds = null)
        {
            var wait = new WebDriverWait(driver, GetTimeout(timeoutSeconds));
            return wait.Until(d =>
            {
                try
                {
                    var el = d.FindElement(locator);
                    return !el.Displayed;
                }
                catch (NoSuchElementException)
                {
                    // Element not present means invisible
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            });
        }

        public IAlert WaitForAlert(int? timeoutSeconds = null)
        {
            var wait = new WebDriverWait(driver, GetTimeout(timeoutSeconds));
            return wait.Until(d =>
            {
                try
                {
                    return d.SwitchTo().Alert();
                }
                catch (NoAlertPresentException)
                {
                    return null;
                }
            });
        }

        public bool WaitForTextInElement(By locator, string text, int? timeoutSeconds = null)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            var wait = new WebDriverWait(driver, GetTimeout(timeoutSeconds));
            return wait.Until(d =>
            {
                try
                {
                    var el = d.FindElement(locator);
                    return el.Text != null && el.Text.Contains(text);
                }
                catch
                {
                    return false;
                }
            });
        }

        public bool WaitForPageReady(int? timeoutSeconds = null)
        {
            var wait = new WebDriverWait(driver, GetTimeout(timeoutSeconds));
            return wait.Until(d =>
            {
                try
                {
                    var js = (IJavaScriptExecutor)d;
                    var readyState = js.ExecuteScript("return document.readyState")?.ToString();
                    return string.Equals(readyState, "complete", StringComparison.OrdinalIgnoreCase);
                }
                catch
                {
                    return false;
                }
            });
        }
    }
}
