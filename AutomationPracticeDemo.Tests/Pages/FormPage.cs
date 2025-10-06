using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationPracticeDemo.Tests.Pages
{
    public class FormPage
    {
        private readonly IWebDriver _driver;

        public FormPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement NameInput => _driver.FindElement(By.Id("name"));
        private IWebElement EmailInput => _driver.FindElement(By.Id("email"));
        private IWebElement PhoneInput => _driver.FindElement(By.Id("phone"));
        private IWebElement CountryDropdown => _driver.FindElement(By.Id("country"));
        private IWebElement SubmitButton => _driver.FindElement(By.ClassName("submit-btn"));

        private IWebElement SearchWikipediaInput => _driver.FindElement(By.Id("Wikipedia1_wikipedia-search-input"));
        private IWebElement WikipediaSearchButton => _driver.FindElement(By.ClassName("wikipedia-search-button"));
        private IWebElement WikipediaSearchResult => new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElement(By.XPath("//*[@id=\"wikipedia-search-result-link\"][1]/a[1]")));
        private IWebElement StartStopButton => _driver.FindElement(By.CssSelector(".start, .stop"));
        private IWebElement ConfirmButton => _driver.FindElement(By.Id("confirmBtn"));
        private IAlert ConfirmAlert => _driver.SwitchTo().Alert();
        private IWebElement ConfirmAlertResultText => _driver.FindElement(By.Id("demo"));
        private IWebElement SingleFileInput => _driver.FindElement(By.Id("singleFileInput")); 
        private IWebElement SingleFileStatus => _driver.FindElement(By.Id("singleFileStatus"));
        private IWebElement UploadSingleFileButton => _driver.FindElement(By.CssSelector("#singleFileForm > button"));


        public string GetFilePathScreenShots()
        {
            string baseDirectory = AppContext.BaseDirectory;
            string relativePath = "../../../Screenshots/";
            string fullFilePath = Path.Combine(baseDirectory, relativePath);

            if (!Directory.Exists(fullFilePath))
            {
                Directory.CreateDirectory(fullFilePath);
            }
            return fullFilePath;
        }

        public void FillForm(string name, string email, string phone, string country)
        {
            NameInput.SendKeys(name);
            EmailInput.SendKeys(email);
            PhoneInput.SendKeys(phone);
            CountryDropdown.SendKeys(country);
        }

        public void Submit()
        {
            SubmitButton.Click();
        }

        public void FillWikipediaSearchInput(string text)
        {
            SearchWikipediaInput.SendKeys(text);
        }

        public void SubmitWikipediaInput()
        {
            WikipediaSearchButton.Click();
        }

        public string GetWikipediaSearchResult()
        {
            return WikipediaSearchResult.Text;
        }

        public void ClickStartStopButton()
        {
            StartStopButton.Click();
        }

        public string GetStartStopButtonValue()
        {
            return StartStopButton.Text;
        }

        public void ClickConfirmButton()
        {
            ConfirmButton.Click();
        }


        public bool ValidateAlertIsOpen()
        {
            try
            {
                string? alertText = ConfirmAlert.Text;
                if (!string.IsNullOrEmpty(alertText) && alertText.Equals("Press a button!"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public void ClickAlertAcceptButton()
        {
            ConfirmAlert.Accept();
        }

        public string GetConfirmAlertResultText()
        {
            return ConfirmAlertResultText.Text;
        }

        private string GetFilePathUpload()
        {
            string baseDirectory = AppContext.BaseDirectory;
            string relativePath = "../../../capybara.png";
            return Path.GetFullPath(Path.Combine(baseDirectory, relativePath));
        }

        public void UploadSingleFileInput()
        {
            SingleFileInput.SendKeys(GetFilePathUpload());
        }

        public void ClickUploadSingleFileButton()
        {
            UploadSingleFileButton.Click();
        }

        public string GetSingleFileStatusText()
        {
            return SingleFileStatus.Text;
        }
    }
}
