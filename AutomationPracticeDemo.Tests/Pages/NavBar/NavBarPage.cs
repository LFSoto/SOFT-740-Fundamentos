using OpenQA.Selenium;

namespace AutomationPracticeDemo.Tests.Pages.NavBar
{
    public class NavBarPage
    {
        private readonly IWebDriver driver;
        private IWebElement SignupLoginLink => driver.FindElement(By.XPath("//a[@href='/login']"));
        private IWebElement LabelLoggedInAs => driver.FindElement(By.XPath("//a[contains(text(),'Logged in as')]"));
        private IWebElement LabelContacUs => driver.FindElement(By.XPath("//a[@href='/contact_us']"));
        private IWebElement LabelProducts => driver.FindElement(By.XPath("//a[@href='/products']"));
        private IWebElement LabelCart => driver.FindElement(By.XPath("//a[@href='/view_cart']"));
        public NavBarPage(IWebDriver driver)
        {
            this.driver = driver;
        }//ctor

        public void ClickSignupLogin()
        {
            SignupLoginLink.Click();
        }//ClickSignupLogin

        public void ClickContactUs()
        {
            LabelContacUs.Click();
        }//ClickContactUs

        public void ClickProducts()
        {
            LabelProducts.Click();
        }//ClickProducts

        public void ClickCart()
        {
            LabelCart.Click();
        }//ClickCart

        public string GetLoggedInAsText()
        {
            Console.WriteLine("Logged in as text: " + LabelLoggedInAs.Text);
            return LabelLoggedInAs.Text;
        }//GetLoggedInAsText
    }//class
}//namespace
