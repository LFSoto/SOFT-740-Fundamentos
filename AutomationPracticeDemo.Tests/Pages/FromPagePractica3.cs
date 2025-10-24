using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutomationPracticeDemo.Tests.Pages
{
    public class FromPagePractica3
    {
        //Variables para pasar datos a FromTestPractica3
        public string Valorhome { get; private set; }
        public string ValorUserSingup { get; private set; }
        public string ValorTitleForm { get; private set; }
        public string ValorAnnoNacimiento { get; private set; }
        public string ValorPais { get; private set; }
        public string ValorValidarMensajeConfirmar { get; private set; }
        public string ValorLoggin { get; private set; }
        public string ValorUserLogin { get; private set; }
        public string ValorNombreLogin { get; private set; }
        public string ValorTituloFormularioProductos { get; private set; }
        public int ValorIdProducto { get; private set; }
        public string ValorTitleProductoAgregado { get; private set; }
        public string ValorTextUrl { get; private set; }
        public string ValorTextoAlerta { get; private set; }
        public string ValorMensajeExitoCorreo { get; private set; }
        public string ValorMensajeExitoSuscripcion { get; private set; }
        public string ValorDescripcionproducto1 { get; private set; }
        public string ValorDescripcionproducto2 { get; private set; }
        public string ValorTotalDesdeElSistema { get; private set; }
        public string ValorTotalEsperadoXFormula { get; private set; }
        public string ValorTxtNombreProducto1 { get; private set; }
        public string ValorConfirmarOrdenFinalizada { get; private set; }
        public int IdProductoTabla1 { get; private set; }
        public int IdProductoTabla2 { get; private set; }

        //Variables locales que sirven de auxiliares
        private readonly IWebDriver _driver;
        private WebDriverWait _wait;
        private string XpathTitleForm = "//section[@id='form']/div[@class='container']/div[@class='row']/div[@class='col-sm-4 col-sm-offset-1']/div[@class='login-form']/h2[@class='title text-center']/b";
        private string cssTextLogin = "//div[@class=\"shop-menu pull-right\"]//ul[@class=\"nav navbar-nav\"]//a//b";
        private string diaActual = DateTime.Now.Day.ToString();
        private string mesActual = DateTime.Now.Month.ToString();

        //Variables -> ValidarCargaHome
        private IWebElement txtHome => _driver.FindElement(By.CssSelector("div.shop-menu.pull-right a[href = '/']"));
        private IWebElement ClicIframe => _driver.FindElement(By.CssSelector("div.grippy-host"));

        //Variables -> SuscripcionUsuarioNuevo
        private IWebElement txtUserSigup => _driver.FindElement(By.CssSelector("div.signup-form h2"));
        private IWebElement iconLogin => _driver.FindElement(By.CssSelector("div.shop-menu.pull-right ul.nav.navbar-nav i.fa.fa-lock"));
        private IWebElement txt_Name => _driver.FindElement(By.Name("name"));
        private IWebElement txt_Email => _driver.FindElement(By.CssSelector("input[data-qa='signup-email']"));
        private IWebElement btn_singup => _driver.FindElement(By.CssSelector("button[data-qa='signup-button']"));

        //Variables -> CompletarFormularioUsuarioNuevo
        private IWebElement txtTitleForm => _driver.FindElement(By.XPath(XpathTitleForm));
        private IWebElement rd_gender => _driver.FindElement(By.CssSelector("label[for='id_gender1']"));
        private IWebElement txtPass => _driver.FindElement(By.Id("password"));
        private IWebElement dropdownDia => _driver.FindElement(By.Id("uniform-days"));
        private IWebElement listDia => _driver.FindElement(By.CssSelector($"select[id='days'] option[value='{diaActual}']"));
        private IWebElement dropdownMes => _driver.FindElement(By.Id("uniform-months"));
        private IWebElement listMes => _driver.FindElement(By.CssSelector($"select[id='months'] option[value='{mesActual}']"));
        private IWebElement dropdownAnno => _driver.FindElement(By.Id("uniform-years"));
        private IWebElement listAnno => _driver.FindElement(By.CssSelector($"select[id='years'] option[value='{ValorAnnoNacimiento}']"));
        private IWebElement chk_suscripcion => _driver.FindElement(By.Id("newsletter"));
        private IWebElement chk_ofertas => _driver.FindElement(By.Id("optin"));
        private IWebElement txtName => _driver.FindElement(By.Id("first_name"));
        private IWebElement txtApellido => _driver.FindElement(By.Id("last_name"));
        private IWebElement txtCompania => _driver.FindElement(By.Id("company"));
        private IWebElement txtDPrincipal => _driver.FindElement(By.Id("address1"));
        private IWebElement txtDSecundaria => _driver.FindElement(By.Id("address2"));
        private IWebElement dropdownPais => _driver.FindElement(By.Id("country"));
        private IWebElement listPais => _driver.FindElement(By.CssSelector($"select[id='country'] option[value='{ValorPais}']"));
        private IWebElement txtEstado => _driver.FindElement(By.Id("state"));
        private IWebElement txtCiudad => _driver.FindElement(By.Id("city"));
        private IWebElement txtPostal => _driver.FindElement(By.Id("zipcode"));
        private IWebElement txtTelefono => _driver.FindElement(By.Id("mobile_number"));
        private IWebElement btnCrearCuenta => _driver.FindElement(By.CssSelector("button[data-qa='create-account']"));
        private IWebElement lblConfirmarMensaje => _driver.FindElement(By.CssSelector("h2[data-qa='account-created'] b"));
        private IWebElement btnContinuar => _driver.FindElement(By.CssSelector("[data-qa='continue-button']"));
        private IWebElement txtLoggin => _driver.FindElement(By.XPath("//header[@id='header']/div[@class='header-middle']/div[@class='container']/div[@class='row']/div[@class='col-sm-8']/div[@class='shop-menu pull-right']/ul[@class='nav navbar-nav']/li[10]/a"));

        //Variables -> Ingresar Sistema
        private IWebElement txtEmail => _driver.FindElement(By.CssSelector("input[data-qa='login-email']"));
        private IWebElement txtContrasena => _driver.FindElement(By.Name("password"));
        private IWebElement TitleFormLogin => _driver.FindElement(By.CssSelector("div.login-form h2"));
        private IWebElement btnLoggin => _driver.FindElement(By.CssSelector("button[data-qa='login-button']"));
        private IWebElement txtNombreLoggin => _driver.FindElement(By.XPath("//div[@class=\"shop-menu pull-right\"]//ul[@class=\"nav navbar-nav\"]//a//b"));
        private IWebElement txtLoginFail => _driver.FindElement(By.CssSelector("form[action='/login'] p"));

        //Variables -> Agregar Productos al Carrito y Totales
        private IWebElement iconProductos => _driver.FindElement(By.CssSelector("a i.material-icons.card_travel"));
        private IWebElement titleFormularioProductos => _driver.FindElement(By.CssSelector("h2.title.text-center"));
        private IWebElement encontrarProducto => _driver.FindElement(By.CssSelector($"div.product-image-wrapper div.single-products div.productinfo.text-center a[data-product-id='{ValorIdProducto}']"));
        private IWebElement btnProductoAgregadoMensaje => _driver.FindElement(By.CssSelector("div.modal-footer button.btn.btn-success.close-modal.btn-block"));
        private IWebElement titleProductoAgregado => _driver.FindElement(By.XPath("//div[@class='modal-content']//div[@class='modal-body']//p[@class='text-center'] [1]"));
        private IWebElement linkView => _driver.FindElement(By.XPath("//div[@class='modal-content']//div[@class='modal-body']//p[@class='text-center'] [2]"));
        private IWebElement ScrollProducto1 => _driver.FindElement(By.CssSelector("div.product-image-wrapper div.single-products div.productinfo.text-center a[data-product-id='5']"));
        private IWebElement ScrollProducto2 => _driver.FindElement(By.CssSelector("div.product-image-wrapper div.single-products div.productinfo.text-center a[data-product-id='18']"));
        private IWebElement precioProducto1 => _driver.FindElement(By.CssSelector($"table.table.table-condensed tr[id='product-{IdProductoTabla1}'] td.cart_price"));
        private IWebElement precioProducto2 => _driver.FindElement(By.CssSelector($"table.table.table-condensed tr[id='product-{IdProductoTabla2}'] td.cart_price"));
        private IWebElement cantidadProducto1 => _driver.FindElement(By.CssSelector($"table.table.table-condensed tr[id='product-{IdProductoTabla1}'] button.disabled"));
        private IWebElement cantidadProducto2 => _driver.FindElement(By.CssSelector($"table.table.table-condensed tr[id='product-{IdProductoTabla2}'] button.disabled"));
        private IWebElement descripcionProducto1 => _driver.FindElement(By.CssSelector($"table.table.table-condensed tr[id='product-{IdProductoTabla1}'] td.cart_description a"));
        private IWebElement descripcionProducto2 => _driver.FindElement(By.CssSelector($"table.table.table-condensed tr[id='product-{IdProductoTabla2}'] td.cart_description a"));
        private IWebElement btn_procesarCompra => _driver.FindElement(By.CssSelector("a.btn.btn-default.check_out"));
        private IWebElement table_total => _driver.FindElement(By.XPath("//div[@id='cart_info']/table[@class='table table-condensed']/tbody/tr[3]/td[4]/p[@class='cart_total_price']"));
        private IWebElement btn_placeOrder => _driver.FindElement(By.CssSelector("a.btn.btn-default.check_out"));
        private IWebElement txt_nombreTarjeta => _driver.FindElement(By.Name("name_on_card"));
        private IWebElement txt_numeroTarjeta => _driver.FindElement(By.Name("card_number"));
        private IWebElement txt_cvc => _driver.FindElement(By.Name("cvc"));
        private IWebElement txt_mesTarjeta => _driver.FindElement(By.Name("expiry_month"));
        private IWebElement txt_annoTarjeta => _driver.FindElement(By.Name("expiry_year"));
        private IWebElement btnPagar => _driver.FindElement(By.Id("submit"));
        private IWebElement btnSus => _driver.FindElement(By.CssSelector("p.pull-left"));
        private IWebElement txtConfirmacionCompra => _driver.FindElement(By.CssSelector("div.col-sm-9.col-sm-offset-1 p"));
        private IWebElement btnFinalizarOrden => _driver.FindElement(By.CssSelector("div.col-sm-9.col-sm-offset-1 a.btn.btn-primary"));

        //Variables -> Llenar y enviar formulario de contactar
        private IWebElement btn_contacto => _driver.FindElement(By.CssSelector("a[href='/contact_us']"));
        private IWebElement txtNombre =>_driver.FindElement(By.CssSelector("input[data-qa='name']"));
        private IWebElement txtCorreo => _driver.FindElement(By.CssSelector("input[data-qa='email']"));
        private IWebElement txtAsunto => _driver.FindElement(By.CssSelector("input[data-qa='subject']"));
        private IWebElement txtMensaje => _driver.FindElement(By.CssSelector("textarea[data-qa='message']"));
        private IWebElement URLuploadFile => _driver.FindElement(By.Name("upload_file"));
        private IWebElement btn_Enviar => _driver.FindElement(By.Name("submit"));
        private IWebElement MensajeExitoCorreo => _driver.FindElement(By.CssSelector("div[class='status alert alert-success']"));
        private IWebElement btn_home => _driver.FindElement(By.CssSelector("a.btn.btn-success"));

        //Variables -> Enviar suscripción 
        private IWebElement txtEmailSuscipcion => _driver.FindElement(By.Id("susbscribe_email"));
        private IWebElement btn_suscripcion => _driver.FindElement(By.Id("subscribe"));
        private IWebElement MensajeExitoSuscripcion => _driver.FindElement(By.CssSelector("div[class=\"alert-success alert\"]"));



        //Construtores
        public FromPagePractica3(IWebDriver driver)
        {
            _driver = driver;
        }

        //Metodo para cerrar los anuncios del iframe
        public void QuitarPublicidad()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

            try
            {
                IWebElement elemento = wait.Until(driver =>
                {
                    try
                    {
                        var el = driver.FindElement(By.CssSelector("div.grippy-host"));
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

                if (elemento != null)
                {
                    elemento.Click();
                }
                else
                {
                    Console.WriteLine("El elemento de publicidad no apareció, se continúa con el flujo.");
                }
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Timeout: el elemento no apareció en 5 segundos.");
            }
        }



        //Metodo para verificar que el titulo de la pantalla de ingreso de datos para el registro se encuentre presenta
        //por aquello que tarde en cargar la pagina cuando el usuario hace el ingreso para el registro del usuario
        public void waitforExist(string elemento, int time) 
        {
            var wait = new WebDriverWait(_driver,TimeSpan.FromSeconds(time));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(elemento)));
        }

        //Metodo timer para esperar a que el elemento sea visible
        public void waitforDisplayed(IWebElement elemento) 
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => elemento.Displayed);
        }

        public void waitforClick(IWebElement elemento) {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(elemento));
        }

        //Metodo que se encarga de verificar que se encuentre en la pantalla principal de la página sirve para validar que
        //que se encuentra en esa pagina
        public void ValidarCargaHome()
        {
            Valorhome = txtHome.Text;
        }

        //Metodo que se encarga de realizar de llenar los primeros datos solicitados para comenzar con la suscripción del usuario
        public void SuscripcionUsuarioNuevo( string nombre, string email) 
        {
            iconLogin.Click();
            ValorUserSingup = txtUserSigup.Text;
            txt_Name.SendKeys(nombre);
            txt_Email.SendKeys(email);
            btn_singup.Click();
        }

        //Metodo que se encarga de realizar la generación aleatoria de correos, para generar datos de manera automática
        public string GenerarCorreoAleatorio()
        {
            Random random = new Random();
            int numero = random.Next(100, 999);
            return $"SOFT-{numero}@cenfotec.com";
        }

        //Metodo que se encarga de encontrar el producto y dar clic al botón de agregar al carrito
        public void ColocarCursorSobreElemento(int Idproducto)
        {
            this.ValorIdProducto = Idproducto;
            Actions actions = new Actions(_driver);
            actions.ScrollToElement(encontrarProducto).Perform();
            actions.MoveToElement(encontrarProducto).Perform();
            actions.Click(encontrarProducto).Perform();
        }

        //Metodo que se encarga de realizar las acciones para completar los datos del formulario solicitado en el punto 1
        public void CompletarFormularioUsuarioNuevo(string pass, string anno, string pais, string nombre, string apellido, string compania, string dprincipal, string dsecundaria, string estado, string ciudad, string postal, string telefono) 
        {
            this.ValorAnnoNacimiento = anno;
            this.ValorPais = pais;
            waitforExist(XpathTitleForm, 3);
            ValorTitleForm = txtTitleForm.Text;
            rd_gender.Click();
            txtPass.SendKeys(pass);
            HacerScrollElemento(txtName);
            dropdownDia.Click();
            listDia.Click();
            QuitarPublicidad();
            dropdownMes.Click();
            listMes.Click();
            dropdownAnno.Click();
            listAnno.Click();
            chk_suscripcion.Click();
            chk_ofertas.Click();
            HacerScrollElemento(txtEstado);
            txtName.SendKeys(nombre);
            txtApellido.SendKeys(apellido);
            txtCompania.SendKeys(compania);
            txtDPrincipal.SendKeys(dprincipal);
            txtDSecundaria.SendKeys(dsecundaria);
            dropdownPais.Click();
            listPais.Click();
            txtEstado.SendKeys(estado);
            txtCiudad.SendKeys(ciudad);
            txtPostal.SendKeys(postal);
            txtTelefono.SendKeys(telefono);
            btnCrearCuenta.Click();
            ValorValidarMensajeConfirmar = lblConfirmarMensaje.Text;
            QuitarPublicidad();
            btnContinuar.Click();
            ValorLoggin = txtLoggin.Text;
        }

        //Metodo que se encarga de realizar las acciones para el ingreso del sistema solicitado en el punto 2
        public void IngresarPlataforma(string correo, string contrasena) 
        {
            iconLogin.Click();
            ValorUserLogin = TitleFormLogin.Text;
            txtEmail.SendKeys(correo);
            txtContrasena.SendKeys(contrasena);
            btnLoggin.Click();
            waitforExist(cssTextLogin,3);
            ValorNombreLogin = txtNombreLoggin.Text;
            ValorLoggin = txtLoggin.Text;
        }

        //Metodo que se encarga de realizar las acciones para el ingreso del sistema solicitado en el punto 2
        public void IngresarPlataformaFail(string correo, string contrasena)
        {
            iconLogin.Click();
            ValorUserLogin = TitleFormLogin.Text;
            txtEmail.SendKeys(correo);
            txtContrasena.SendKeys(contrasena);
            btnLoggin.Click();
            ValorLoggin = txtLoginFail.Text;
            
        }

        //Metodo para hacer el proceso de compra
        public void LlenarCarritoyTotales(string correo, string contrasena, int Idproducto1, int Idproducto2,string nombre, string numTarjeta, string cvc, string mes, string anno) 
        {
            IdProductoTabla1 = Idproducto1;
            IdProductoTabla2 = Idproducto2;
            IngresarPlataforma(correo, contrasena);
            iconProductos.Click();
            ValorTituloFormularioProductos = titleFormularioProductos.Text;
            HacerScrollElemento(ScrollProducto1);
            ColocarCursorSobreElemento(Idproducto1);
            waitforDisplayed(titleProductoAgregado);
            ValorTitleProductoAgregado = titleProductoAgregado.Text;
            btnProductoAgregadoMensaje.Click();
            HacerScrollElemento(ScrollProducto2);
            ColocarCursorSobreElemento(Idproducto2);
            waitforDisplayed(titleProductoAgregado);
            ValorTitleProductoAgregado = titleProductoAgregado.Text;
            linkView.Click();
            ValorDescripcionproducto1 = descripcionProducto1.Text;
            ValorDescripcionproducto2 = descripcionProducto2.Text;
            SumarCompra();
            btn_procesarCompra.Click();
            HacerScrollElemento(btn_placeOrder);
            ValorTotalDesdeElSistema = table_total.Text;
            string Aux = ValorTotalDesdeElSistema.Replace("Rs. ","");
            ValorTotalDesdeElSistema = Aux;
            btn_placeOrder.Click();
            txt_nombreTarjeta.SendKeys(nombre);
            txt_numeroTarjeta.SendKeys(numTarjeta);
            txt_cvc.SendKeys(cvc);
            txt_mesTarjeta.SendKeys(mes);
            txt_annoTarjeta.SendKeys(anno);
            HacerScrollElemento(btnSus);
            btnPagar.Click();
            System.Threading.Thread.Sleep(2000);
            waitforDisplayed(txtConfirmacionCompra);
            ValorConfirmarOrdenFinalizada = txtConfirmacionCompra.Text;
            btnFinalizarOrden.Click();
        }

        //Metodo que se encarga de realizar los pasos para el escenario de llenar el formulario para contactar
        public void LlenarFormularioContactar(string correo, string nombre, string subjet, string mensaje) 
        {
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Imagen\Foto.jpg");
            ruta = Path.GetFullPath(ruta);

            btn_contacto.Click();
            txtNombre.SendKeys(nombre);
            txtCorreo.SendKeys(correo);
            txtAsunto.SendKeys(subjet);
            txtMensaje.SendKeys(mensaje);
            URLuploadFile.SendKeys(ruta);
            ValorTextUrl = URLuploadFile.GetAttribute("value") ?? string.Empty;
            btn_Enviar.Click();
            ValidarMensajeAlerta();
            ValorMensajeExitoCorreo = MensajeExitoCorreo.Text;
            btn_home.Click();
        }

        //Metodo para validar los mensajes de alerta
        public void ValidarMensajeAlerta()
        {
            try
            {
                IAlert alert = _driver.SwitchTo().Alert();
                System.Threading.Thread.Sleep(2000);
                ValorTextoAlerta = alert.Text ?? string.Empty;
                alert.Accept();

            }
            catch (NoAlertPresentException)
            {

            }

        }

        //Metodo para hacer los pasos para enviar la suscripción
        public void EnviarSuscripcion(string correo) 
        {
            txtEmailSuscipcion.SendKeys(correo);
            btn_suscripcion.Click();

            ValorMensajeExitoSuscripcion = MensajeExitoSuscripcion.Text;
        }

        //Metodo para hacer scroll a un elemento y encontrarlo
        public void HacerScrollElemento(IWebElement elemento)
        {
            Actions actions = new Actions(_driver);
            actions.ScrollToElement(elemento).Perform();
            actions.MoveToElement(elemento).Perform();
        }

        //Metodo que obtiene los valores de los productos, los suma y el resultado lo compara con lo del sistema
        public void SumarCompra() {
            string precio1 = precioProducto1.Text;
            string convertPrecio1 = precio1.Replace("Rs.", "");
            int auxPrecio1 = int.Parse(convertPrecio1);
            string precio2 = precioProducto2.Text;
            string convertPrecio2 = precio2.Replace("Rs.", "");
            int auxPrecio2 = int.Parse(convertPrecio2);
            string cantidad1 = cantidadProducto1.Text;
            string cantidad2 = cantidadProducto2.Text;
            int auxCantidad1 = int.Parse(cantidad1);
            int auxCantidad2 = int.Parse(cantidad2);

            int totalProducto1 = auxCantidad1 * auxPrecio1;
            int totalProducto2 = auxCantidad2 * auxPrecio2;

            int PrecioFinal = totalProducto1 + totalProducto2;

            ValorTotalEsperadoXFormula = PrecioFinal.ToString();
        }

    }
}
