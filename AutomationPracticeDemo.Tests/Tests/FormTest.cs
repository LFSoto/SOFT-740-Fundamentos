using AutomationPracticeDemo.Tests.Pages;
using AutomationPracticeDemo.Tests.Utils;

namespace AutomationPracticeDemo.Tests.Tests
{
    public class FormTests : TestBase
    {
        [TestCase(
            "Juan Perez", "juan@test.com", "88888888", "Brasilia", "Brazil",
            "Male", "Monday,Wednesday", "Blue", "Dog", "10/10/2025", "11/11/2025"
        )]
        [TestCase(
            "Maria Gomez", "maria@test.com", "99999999", "Paris", "France",
            "Female", "Sunday,Friday,Monday", "Green", "Cat", "01/01/2026", "02/02/2026"
        )]
        public void Should_Fill_And_Submit_Form_Parametrized(
            string fullName, string email, string phone, string city, string country, string gender,
             string days, string color, string pet, string startDate, string endDate)
        {
            // Crea una instancia de la página
            var formPage = new FormPage(Driver);

            // Separar los días en una lista
            var daysList = days.Split(',').ToList();

            // Llena el formulario con todos los parámetros
            formPage.FillForm(
                fullName, email, phone, city, country, gender,
                daysList, color, pet, startDate, endDate
            );

            // Enviar el formulario
            formPage.Submit();

            // Obtiene el texto de resultado mostrado tras enviar el formulario
            var result = formPage.ResultText();

            // Mensaje esperado
            var message = "You selected a range of 32 days.";

            //Validaciones y capturas
            Assert.That(result, Is.EqualTo(message));
            ScreenshotHelper.TakeScreenshot(Driver, $"form_test_{fullName.Replace(" ", "_")}.png");

            // Marcar la prueba como exitosa
            Assert.Pass("Should Fill And Submit Form Test Success.");
        }

        [Test]
        public void Dynamic_Button_Test()
        {
            // Crea una instancia de la página
            var formPage = new FormPage(Driver);

            // Validar que inicialmente el texto del botón sea "START"
            Assert.That(formPage.GetTextDynamicButton(), Is.EqualTo("START"));
            ScreenshotHelper.TakeScreenshot(Driver, "form_test_Dynamic_Button1.png");

            // Hacer clic en el botón para cambiar su estado
            formPage.ClickDynamicButton();

            // Validar que ahora el texto sea "STOP"
            Assert.That(formPage.GetTextDynamicButton(), Is.EqualTo("STOP"));
            ScreenshotHelper.TakeScreenshot(Driver, "form_test_Dynamic_Button2.png");

            // Hacer clic nuevamente para volver al estado inicial
            formPage.ClickDynamicButton();

            // Validar que el texto regresa a "START"
            Assert.That(formPage.GetTextDynamicButton(), Is.EqualTo("START"));
            ScreenshotHelper.TakeScreenshot(Driver, "form_test_Dynamic_Button3.png");

            // Marcar la prueba como exitosa
            Assert.Pass("Dynamic Button Test Success.");
        }

        [Test]
        public void Simple_Alert_Button_Test()
        {
            // Crea una instancia de la página
            var formPage = new FormPage(Driver);

            // Hace clic en el botón que muestra la alerta y capturar el mensaje mostrado
            var messageAlert = formPage.ClickSimpleAlert();

            // Tomar captura de pantalla tras mostrar la alerta
            ScreenshotHelper.TakeScreenshot(Driver, "form_test_Simple_Alert.png");

            // Validar que el texto de la alerta sea el esperado
            Assert.That(messageAlert, Is.EqualTo("I am an alert box!"));

            // Marcar la prueba como exitosa
            Assert.Pass("Simple Alert Button Test Success.");
        }
        [Test]
        public void Confirmation_Alert_Button_Test()
        {
            // Crear una instancia de la página
            var formPage = new FormPage(Driver);

            // Hacer clic en el botón que muestra la alerta de confirmación
            formPage.ClicKConfirmationAlert();
            var messageAlert = formPage.GetTextConfirmationAlert();

            // Validar que el texto de la alerta sea el esperado
            Assert.That(messageAlert, Is.EqualTo("Press a button!"));

            // Tomar captura de pantalla tras mostrar la alerta
            ScreenshotHelper.TakeScreenshot(Driver, "form_test_Confirmation_Alert_Button_Test.png");

            // Marcar la prueba como exitosa
            Assert.Pass("Confirmation Alert Button Test Success.");
        }
        [Test]
        [TestCase("Firefox")]
        public void Dynamic_Web_Table_Get_Disk_Value_Test(string browserName)
        {
            // Crear una instancia de la página
            var formPage = new FormPage(Driver);

            // Obtiene el valor de la columna "Disk (MB/s)" según el navegador especificado
            var diskValueBrowser = formPage.GetDiskValueByBrowserName(browserName);

            // Obtiene el valor esperado Disk (MB/s) del resumen (Valor fuera tabla)
            var diskValueResult = formPage.GetDiskValueResult();

            //Compara que los valores sean iguales
            Assert.That(diskValueBrowser, Is.EqualTo(diskValueResult));

            // Tomar captura de pantalla para evidencia visual
            ScreenshotHelper.TakeScreenshot(Driver, "form_test_Dynamic_Web_Table_Get_Disk_Value.png");

            // Marcar la prueba como exitosa
            Assert.Pass("Dynamic Web Table Get Disk Value by Browser  Test Success.");
        }
        [Test]
        [TestCase("13/11/2025")]
        public void Date_Picker_Test(string date)
        {
            // Crear una instancia de la página
            var formPage = new FormPage(Driver);

            //Establece la fecha en los inputs de los DatePickers
            formPage.SetDateDatePicker(date);   
            formPage.SelectDateFromDatePicker(date);

            //Obtiene el valor de la fecha ingresado en los DatePickers
            var convertedDate = formPage.ConvertDateFormat(date);
            var dateDatePicker1 = formPage.GetValueDateDatePicker1();
            var dateDatePicker2 = formPage.GetValueDateDatePicker2();

            //Valida el valor de los DatePicker con los valores esperados
            Assert.That(convertedDate, Is.EqualTo(dateDatePicker1));
            Assert.That(date, Is.EqualTo(dateDatePicker2));

            // Tomar captura de pantalla del resultado
            ScreenshotHelper.TakeScreenshot(Driver, "form_test_Data_Picker_Test.png");

            // Marcar la prueba como exitosa
            Assert.Pass("DatePicker Test Success.");
        }
    }
}
