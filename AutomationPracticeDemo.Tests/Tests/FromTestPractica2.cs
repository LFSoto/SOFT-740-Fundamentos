
using AutomationPracticeDemo.Tests.Utils;
using AutomationPracticeDemo.Tests.Pages;


namespace AutomationPracticeDemo.Tests.Tests
{
    public class FromTestPractica2 : TestBase
    {

        [TestCase("Yeison Rojas", "yeison@test.com", "88888888", "Alajuela")]
        [Ignore("Este test está deshabilitado temporalmente")]
        public void Test_Validar_Interaccion_Elementos(string nombre, string correo, string phone, string addres) {

            var formpage = new FromPagePractica2(Driver);

            //Interacción con los text boxes
            formpage.Txt_Box(nombre, correo, phone, addres);
            formpage.Cargar_Valores_Txt_Box();
            System.Threading.Thread.Sleep(2000);
            ScreenshotHelper.TakeScreenshot(Driver, "test_textBox.png");

            //Interacción con los radio buttons y check box
            formpage.rb_ClickGender();
            formpage.Ck_box_dia();
            System.Threading.Thread.Sleep(2000);
            ScreenshotHelper.TakeScreenshot(Driver, "test_radioButtons_checkBox.png");

            //Interacción con los dropdown
            formpage.Drop_Downs();
            System.Threading.Thread.Sleep(2000);
            ScreenshotHelper.TakeScreenshot(Driver, "test_dropDowns.png");

            //Interacción con datepicker
            formpage.put_Date1();
            System.Threading.Thread.Sleep(2000);
            ScreenshotHelper.TakeScreenshot(Driver, "test_datePicker.png");

            //Interacción con las Alertas
            formpage.put_simpleAlert();
            formpage.validate_Alert();
            System.Threading.Thread.Sleep(1000);
            ScreenshotHelper.TakeScreenshot(Driver, "test_alert.png");

            //Interacción con los botones
            formpage.copy_btn();
            System.Threading.Thread.Sleep(2000);
            ScreenshotHelper.TakeScreenshot(Driver, "test_button.png");

            //Interacción con el campo de texto field 2 para confirmar el doble clic del botón
            formpage.fiel2_txt();
            System.Threading.Thread.Sleep(2000);
            ScreenshotHelper.TakeScreenshot(Driver, "test_get_text.png");



            //Assert para confirmar que los datos de parámetros son los mismos que los esperados - Text Boxes
            Assert.That(formpage.ValorNombre, Is.EqualTo(nombre));
            Assert.That(formpage.ValorCorreo, Is.EqualTo(correo));
            Assert.That(formpage.ValorTelefono, Is.EqualTo(phone));
            Assert.That(formpage.ValorDireccion, Is.EqualTo(addres));

            //Assert para confirmar que el mensaje de la alerta sea el esperado
            Assert.That(formpage.TextoAlerta, Is.EqualTo("I am an alert box!"));

            //Assert para confirmar que se realizo la acción de doble clic sobre el botón
            Assert.That(formpage.TextoField2, Is.EqualTo("Hello World!"));

            //Assert para confirmar que el formulario se completo los datos y las acciones
            Assert.Pass("La información del formulario esta completa y validada");
            

        }

    }
}
