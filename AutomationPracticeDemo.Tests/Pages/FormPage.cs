using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static System.Runtime.InteropServices.JavaScript.JSType;


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
        //Datos del formulario parte 1
        private IWebElement NameInput => _driver.FindElement(By.Id("name"));
        private IWebElement EmailInput => _driver.FindElement(By.Id("email"));
        private IWebElement PhoneInput => _driver.FindElement(By.Id("phone"));
        private IWebElement AddressTextTarea => _driver.FindElement(By.Id("textarea"));
        private IWebElement MaleGender => _driver.FindElement(By.Id("male"));
        private IWebElement FemaleGender => _driver.FindElement(By.Id("female"));
        //Datos del formulario parte 2
        private IWebElement CountryDropdown => _driver.FindElement(By.Id("country"));
        private IWebElement ColorSelect => _driver.FindElement(By.Id("colors"));
        private IWebElement AnimalSelect => _driver.FindElement(By.Id("animals"));

        //Fechas del formulario
        private IWebElement DataPicker1 => _driver.FindElement(By.Id("datepicker"));
        private IWebElement DataPicker2 => _driver.FindElement(By.Id("txtDate"));
        private IWebElement DataPicker3 => _driver.FindElement(By.Id("start-date"));
        private IWebElement DataPicker4 => _driver.FindElement(By.Id("end-date"));
        private IWebElement ResultInput => _driver.FindElement(By.Id("result"));

        //Bot�n del formulario
        private IWebElement SubmitButton => _driver.FindElement(By.ClassName("submit-btn"));

        //Elementos din�micos y alertas
        private IWebElement DynamicButton => _driver.FindElement(By.XPath("//button[@onclick=\"toggleButton(this)\"]"));
        private IWebElement SimpleAlertButton => _driver.FindElement(By.Id("alertBtn"));
        private IWebElement ConfirmationAlertButton => _driver.FindElement(By.Id("confirmBtn"));
        #endregion

        public void FillForm(string name, string email, string phone, string address, string country,
            string gender, List<string> days, string color, string animal, string date1, string date2)
        {
            // Ingresa informaci�n (Nombre, correo, celular, direcci�n, genero)
            NameInput.SendKeys(name);
            EmailInput.SendKeys(email);
            PhoneInput.SendKeys(phone);
            AddressTextTarea.SendKeys(address);
            SelectGender(gender);

            // Ingresa informaci�n adicional (D�as, pa�s)
            SelectCheckboxesForDays(days);
            CountryDropdown.SendKeys(country);

            // Selecciona informaci�n adicional (Color, animal)
            SelectElement selectColor = new(ColorSelect);
            selectColor.SelectByText(color);

            SelectElement selectAnimal = new(AnimalSelect);
            selectAnimal.SelectByText(animal);

            //Ingresa informaci�n de las fechas a comparar
            DataPicker1.SendKeys(date1 + Keys.Enter);
            SelectDateFromDatePicker(date2);

            DataPicker3.SendKeys(date1);
            DataPicker4.SendKeys(date2);
        }

        public void Submit()
        {
            //Realiza un clic sobre el bot�n Submit del formulario.
            SubmitButton.Click();
        }
        public void SelectGender(string gender)
        {
            // Convertir el valor de entrada a min�sculas para la comparaci�n
            gender = gender.ToLower();

            // Selecciona el radio button correspondiente al g�nero
            switch (gender)
            {
                case "male":
                    MaleGender.Click();
                    break;
                case "female":
                    FemaleGender.Click();
                    break;
                default:
                    // Lanza una excepci�n si el valor no es reconocido
                    throw new ArgumentException("G�nero no v�lido. Debe ser 'male' o 'female'.");
            }
        }

        public void SelectCheckboxesForDays(List<string> daysOfWeek)
        {
            // Recorrer cada d�a en la lista recibida
            foreach (var day in daysOfWeek)
            {
                // Convertir el nombre del d�a a min�sculas para que coincida con el ID del checkbox
                string dayId = day.ToLower();

                // Buscar el checkbox correspondiente al d�a por su atributo id
                var checkbox = _driver.FindElement(By.Id(dayId));

                // Si el checkbox no est� seleccionado, hacer clic para seleccionarlo
                if (!checkbox.Selected)
                {
                    checkbox.Click();
                }
            }
        }
        public string ResultText()
        {
            //Obtiene el texto actual del elemento que se muestra al comparar fechas del formulario
            return ResultInput.Text;
        }

        public void ClickDynamicButton()
        {
            //Realiza un clic sobre el bot�n DynamicButton (STAR - STOP).
            DynamicButton.Click();
        }

        public string GetTextDynamicButton()
        {
            // Obtiene el texto actual del elemento DynamicButton (STAR o STOP).
            return DynamicButton.Text;
        }

        public string ClickSimpleAlert()
        {
            // Hace clic en el bot�n que genera la alerta simple
            SimpleAlertButton.Click();

            // Cambia el foco del WebDriver a la alerta emergente
            IAlert alert = _driver.SwitchTo().Alert();

            // Obtiene el texto que muestra la alerta
            string alertMessageText = alert.Text;

            // Acepta la alerta y devuelve el texto capturado para la verificaci�n
            alert.Accept();
            return alertMessageText;
        }
        public void ClicKConfirmationAlert()
        {
            ConfirmationAlertButton.Click();
        }
        public string GetTextConfirmationAlert()
        {
            // Cambia el foco del WebDriver al contexto de la alerta emergente del navegador
            IAlert alert = _driver.SwitchTo().Alert();

            // Lee el texto del mensaje que se muestra en la alerta
            string alertMessageText = alert.Text;

            // Acepta la alerta y devuelve el texto capturado para la verificaci�n
            alert.Accept();
            return alertMessageText;
        }
        public string GetDiskValueResult()
        {
            // Buscar el elemento que contieneel resultado del Firefox Disk (MB/s)
            var diskValueResult = _driver.FindElement(By.XPath("//strong[@class='firefox-disk']"));

            // Retornar el texto contenido en dicho elemento
            return diskValueResult.Text;
        }

        public string? GetDiskValueByBrowserName(string browserName)
        {
            try
            {
                // Busca todas las cabeceras de la tabla (th) dentro del thead
                var headers = _driver.FindElements(By.CssSelector("#taskTable thead th"));

                // Busca el �ndice de la columna cuyo encabezado contiene el texto "Disk (MB/s)"
                int diskColumnIndex = headers.ToList().FindIndex(header => header.Text.Contains("Disk (MB/s)"));

                // Si no se encuentra la columna, lanzar una excepci�n controlada
                if (diskColumnIndex == -1)
                {
                    throw new Exception("No se encontr� la columna 'Disk (MB/s)'.");
                }

                // Buscar la fila (tr) que contenga el nombre del navegador (browserName) en la primera celda (td[1])
                var row = _driver.FindElement(By.XPath("//table[@id='taskTable']//tr[td[1][contains(text(), '" + browserName + "')]]"));

                // Obtener todas las celdas (td) de esa fila
                var cells = row.FindElements(By.TagName("td"));

                // Validar que el �ndice de la columna est� dentro del rango y devolver el valor de la celda
                if (diskColumnIndex >= 0 && diskColumnIndex < cells.Count)
                {
                    return cells[diskColumnIndex].Text;
                }
                else
                {
                    // El �ndice est� fuera de rango (m�s columnas que celdas), devolver null
                    return null;
                }
            }
            catch (NoSuchElementException)
            {
                // Si no se encuentra la fila del navegador, devolver null 
                return null;
            }
            catch (Exception ex)
            {
                // Para cualquier otro error inesperado, devolver el mensaje como string para diagn�stico
                return $"Error: {ex.Message}";
            }
        }

        public void SelectDateFromDatePicker(string date)
        {
            // Dividir la cadena de fecha en partes separadas usando "/" como delimitador.
            var dateParts = date.Split('/');

            // Eliminar ceros a la izquierda convirtiendo a entero y de nuevo a string
            string day = int.Parse(dateParts[0]).ToString();   // "04" -> "4"
            string month = dateParts[1];
            string year = dateParts[2];

            // Hacer clic en el input para mostrar el calendario
            var dateInput = _driver.FindElement(By.Id("txtDate"));
            dateInput.Click();

            // Seleccionar mes y a�o en el DatePicker
            SelectMonthAndYear(month, year);

            // Seleccionar el d�a espec�fico
            SelectDay(day);
        }

        public void SelectMonthAndYear(string month, string year)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            // 1. Seleccionar el mes
            IWebElement monthSelect = _driver.FindElement(By.ClassName("ui-datepicker-month"));
            new SelectElement(monthSelect).SelectByValue((int.Parse(month) - 1).ToString());

            // 2. Esperar y obtener el select del a�o (puede haberse actualizado despu�s de seleccionar el mes)
            IWebElement yearSelect = wait.Until(d =>
            {
                var elem = d.FindElement(By.ClassName("ui-datepicker-year"));
                return (elem.Displayed && elem.Enabled) ? elem : null;
            });

            // 3. Intentar seleccionar el a�o con reintentos
            int attempts = 0;
            while (attempts < 3)
            {
                try
                {
                    new SelectElement(yearSelect).SelectByValue(year);
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    // Si el elemento cambi�, volver a localizarlo
                    Thread.Sleep(200); // Peque�a espera antes de intentar de nuevo
                    yearSelect = _driver.FindElement(By.ClassName("ui-datepicker-year"));
                }
                attempts++;
            }
            // Esperar que el calendario se actualice
            System.Threading.Thread.Sleep(300);
        }

        public void SelectDay(string day)
        {
            // Buscar el d�a en la tabla del calendario usando XPath
            var dayElement = _driver.FindElement(By.XPath( $"//table[contains(@class, 'ui-datepicker-calendar')]//a[text()='{day}']"));

            // Hacer clic en el d�a para seleccionarlo
            dayElement.Click();
        }

        public void SetDateDatePicker(string date)
        {

            // Dividir la cadena de fecha en partes separadas usando "/" como delimitador.
            //    Por ejemplo, si date = "18/04/2025":
            //    - dateParts[0] = "18"  -> d�a
            //    - dateParts[1] = "04"  -> mes
            //    - dateParts[2] = "2025" -> a�o
            var dateParts = date.Split('/');

            //Extrae los segmentos de la fecha
            string day = dateParts[0];
            string month = dateParts[1];
            string year = dateParts[2];

            //Reformatea la fecha y la env�a al elemento
            var dateFormatted = month + "/" + day + "/" + year;
            DataPicker1.SendKeys(dateFormatted + Keys.Enter);
        }
        public string ConvertDateFormat (string date)
        {

            // Dividir la cadena de fecha en partes separadas usando "/" como delimitador.
            var dateParts = date.Split('/');

            //Extrae los segmentos de la fecha
            string day = dateParts[0];
            string month = dateParts[1];
            string year = dateParts[2];

            //Reformatea la fecha y la guarda en una variable
            var dateFormatted = month + "/" + day + "/" + year;

            //Retorna la fecha formateada para su validaci�n
            return dateFormatted;
        }
        public string GetValueDateDatePicker1()
        {
            //Obtiene el valor actual del primer campo de tipo DatePicker
            var date = DataPicker1.GetAttribute("value");

            //Retorna el valor de la fecha en formato texto
            return date.ToString();
        }
        public string GetValueDateDatePicker2()
        {
            //Obtiene el valor actual del primer campo de tipo DatePicker
            var date = DataPicker2.GetAttribute("value");

            //Retorna el valor de la fecha en formato texto
            return date.ToString();
        }
    }
}
