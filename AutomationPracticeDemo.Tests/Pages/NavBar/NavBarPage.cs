using OpenQA.Selenium;
using AutomationPracticeDemo.Tests.Utils;

namespace AutomationPracticeDemo.Tests.Pages.NavBar
{
    public class NavBarPage
    {
        private readonly IWebDriver driver;
        private readonly WaitHelper wait;
        private readonly By SignupLoginLink = By.XPath("//a[@href='/login']");
        private readonly By LabelLoggedInAs = By.XPath("//a[contains(text(),'Logged in as')]");
        private readonly By LabelContacUs = By.XPath("//a[@href='/contact_us']");
        private readonly By LabelProducts = By.XPath("//a[@href='/products']");
        private readonly By LabelCart = By.XPath("//a[@href='/view_cart']");
        public NavBarPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WaitHelper(driver);
        }//ctor

        public void ClickSignupLogin()
        {
            wait.WaitForElementClickable(SignupLoginLink).Click();
        }//ClickSignupLogin

        public void ClickContactUs()
        {
            wait.WaitForElementClickable(LabelContacUs).Click();
        }//ClickContactUs

        public void ClickProducts()
        {
            wait.WaitForElementClickable(LabelProducts).Click();
        }//ClickProducts

        public void ClickCart()
        {
            wait.WaitForElementClickable(LabelCart).Click();
        }//ClickCart

        public string GetLoggedInAsText()
        {
            var el = wait.WaitForElementVisible(LabelLoggedInAs);
            Console.WriteLine("Logged in as text: " + el.Text);
            return el.Text;
        }//GetLoggedInAsText
    }//class
}//namespace
