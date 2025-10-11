using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace AutomationPracticeDemo.Tests.Pages
{
    public class ProductsPage
    {
        private readonly IWebDriver _driver;
        public ProductsPage(IWebDriver driver) { 
            _driver = driver;
        }

        // Declaración de los elementos de la página
        private IWebElement productsTitle => _driver.FindElement(By.CssSelector("div.features_items >h2.title.text-center"));
        private IWebElement firstProductType => _driver.FindElement(By.CssSelector(" div:nth-child(3)  div.product-overlay  p"));
        private IWebElement cardFirstProductType => _driver.FindElement(By.CssSelector("div.col-sm-9.padding-right > div > div:nth-child(3) > div > div.single-products > div.productinfo.text-center > a"));
        private IWebElement firstProductPrice => _driver.FindElement(By.CssSelector("div:nth-child(3) div.product-overlay h2"));
        private IWebElement addFirstCartButton => _driver.FindElement(By.CssSelector("div.product-overlay a[data-product-id=\"1\"]"));
        private IWebElement secondProductType => _driver.FindElement(By.CssSelector(" div:nth-child(4)  div.product-overlay  p"));
        private IWebElement secondProductPrice => _driver.FindElement(By.CssSelector("div:nth-child(4) div.product-overlay h2"));
        private IWebElement addSecondCartButton => _driver.FindElement(By.CssSelector("div.product-overlay a[data-product-id=\"2\"]"));
        private IWebElement modaAddedlTitle => _driver.FindElement(By.CssSelector("#cartModal h4"));
        private IWebElement modaAddedlMessage => _driver.FindElement(By.CssSelector("#cartModal p"));
        private IWebElement viewCartButton => _driver.FindElement(By.CssSelector("#cartModal a"));
        private IWebElement continueShoppingButton => _driver.FindElement(By.CssSelector("#cartModal button[data-dismiss=\"modal\"]"));

        //Validar que estamos en la página de productos
        public string ValidatedProductsPage()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => productsTitle.Displayed);
            return productsTitle.Text;

        }
        //Obtener el tipo y precio del primer producto
        public (string, string) GetFirstProductDetails()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(cardFirstProductType).Perform();

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));
            wait.Until(driver => firstProductType.Displayed && firstProductPrice.Displayed);
            return (firstProductType.Text, firstProductPrice.Text);
        }

        //Agregar el primer producto al carrito
        public void AddFirstProductToCart()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));
            wait.Until(driver => addFirstCartButton.Enabled && addFirstCartButton.Displayed);
            addFirstCartButton.Click();
        }

        //Validar que el producto se ha agregado al carrito
        public (string, string) ValidateProductAddedModal()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));
            wait.Until(driver => modaAddedlTitle.Displayed && modaAddedlMessage.Displayed);
            return (modaAddedlTitle.Text, modaAddedlMessage.Text);
        }
        //Continuar comprando
        public void ContinueShopping()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));
            wait.Until(driver => continueShoppingButton.Enabled && continueShoppingButton.Displayed);
            continueShoppingButton.Click();
        }

        //Obtener el tipo y precio del segundo producto 
        public (string, string) GetSecondProductDetails()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));
            wait.Until(driver => secondProductType.Displayed && secondProductPrice.Displayed);
            return (secondProductType.Text, secondProductPrice.Text);
        }

        //Agregar el segundo producto al carrito
        public void AddSecondProductToCart()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));
            wait.Until(driver => addSecondCartButton.Enabled && addSecondCartButton.Displayed);
            addSecondCartButton.Click();
        }
        //Ver el carrito de compras
        public void SummitViewCart()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));
            wait.Until(driver => viewCartButton.Enabled && viewCartButton.Displayed);
            viewCartButton.Click();
        }

    }
}
