using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
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
        #region GUI Elements
        private IWebElement NameInput => _driver.FindElement(By.Id("name"));
        private IWebElement EmailInput => _driver.FindElement(By.Id("email"));
        private IWebElement PhoneInput => _driver.FindElement(By.Id("phone"));
        private IWebElement AddressTextTarea => _driver.FindElement(By.Id("textarea"));
        private IWebElement CountryDropdown => _driver.FindElement(By.Id("country"));
        private IWebElement SubmitButton => _driver.FindElement(By.ClassName("submit-btn"));
        private IWebElement MaleGender => _driver.FindElement(By.Id("male"));
        private IWebElement FemaleGender => _driver.FindElement(By.Id("female"));
        private IWebElement ColorSelect => _driver.FindElement(By.Id("colors"));
        private IWebElement AnimalSelect => _driver.FindElement(By.Id("animals"));
        private IWebElement DataPicker1 => _driver.FindElement(By.Id("datepicker"));
        private IWebElement DataPicker2 => _driver.FindElement(By.Id("start-date"));
        private IWebElement DataPicker3 => _driver.FindElement(By.Id("end-date"));
        private IWebElement ResultInput => _driver.FindElement(By.Id("result"));
        private IWebElement DynamicButton => _driver.FindElement(By.XPath("//button[@onclick=\"toggleButton(this)\"]"));
        private IWebElement SimpleAlertButton => _driver.FindElement(By.Id("alertBtn"));
        private IWebElement ConfirmationAlertButton => _driver.FindElement(By.Id("confirmBtn"));

        #endregion

        public void FillForm(string name, string email, string phone, string address, string country,
            string gender, List<string> days, string color, string animal, string date1, string date2)
        {
            NameInput.SendKeys(name);
            EmailInput.SendKeys(email);
            PhoneInput.SendKeys(phone);
            AddressTextTarea.SendKeys(address);
            CountryDropdown.SendKeys(country);
            SelectGender(gender);
            SelectCheckboxesForDays(days);
            SelectElement selectColor = new(ColorSelect);
            selectColor.SelectByText(color);
            SelectElement selectAnimal = new(AnimalSelect);
            selectAnimal.SelectByText(animal);
            DataPicker1.SendKeys(date1 + Keys.Enter);
            DataPicker2.SendKeys(date1);
            DataPicker3.SendKeys(date2);
        }

        public void Submit()
        {
            SubmitButton.Click();
        }
        public void SelectGender(string gender)
        {
            gender = gender.ToLower();

            switch (gender)
            {
                case "male":
                    MaleGender.Click();
                    break;
                case "female":
                    FemaleGender.Click();
                    break;
                default:
                    throw new ArgumentException("Género no válido. Debe ser 'male' o 'female'.");
            }
        }

        public void SelectCheckboxesForDays(List<string> daysOfWeek)
        {
            foreach (var day in daysOfWeek)
            {
                string dayId = day.ToLower();

                var checkbox = _driver.FindElement(By.Id(dayId));

                if (!checkbox.Selected)
                {
                    checkbox.Click();
                }
            }
        }
        public string ResultText()
        {
            return ResultInput.Text;
        }
        public void ClickDynamicButton()
        {
            DynamicButton.Click();
        }
        public string GetTextDynamicButton()
        {
            return DynamicButton.Text;
        }
        public string ClickSimpleAlert()
        {
            SimpleAlertButton.Click();
            IAlert alert = _driver.SwitchTo().Alert();
            string mensajeAlerta = alert.Text;
            alert.Accept();
            return mensajeAlerta;
        }
        public void ClicKConfirmationAlert()
        {
            ConfirmationAlertButton.Click();
        }
        public string GetTextConfirmationAlert()
        {
            IAlert alert = _driver.SwitchTo().Alert();
            string textAlertMessage = alert.Text;
            alert.Accept();
            return textAlertMessage;
        }
        public string GetDiskValueResult()
        {
            var diskValueResult = _driver.FindElement(By.XPath("//strong[@class='firefox-disk']"));
            return diskValueResult.Text;
        }
        public string GetDiskValueByBrowserName(string browserName)
        {
            try
            {
                var headers = _driver.FindElements(By.CssSelector("#taskTable thead th"));
                int diskColumnIndex = headers.ToList().FindIndex(header => header.Text.Contains("Disk (MB/s)"));

                if (diskColumnIndex == -1)
                {
                    throw new Exception("No se encontró la columna 'Disk (MB/s)'.");
                }

                var row = _driver.FindElement(By.XPath("//table[@id='taskTable']//tr[td[1][contains(text(), '" + browserName + "')]]"));
                var cells = row.FindElements(By.TagName("td"));

                if (diskColumnIndex >= 0 && diskColumnIndex < cells.Count)
                {
                    return cells[diskColumnIndex].Text;
                }
                else
                {
                    return null;
                }
            }
            catch (NoSuchElementException)
            {
                return null;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
