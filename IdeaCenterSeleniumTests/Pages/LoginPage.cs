using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace IdeaCenterSeleniumTests.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }
        public static string Url => 
            BaseUrl + "/Users/Login";

        public IWebElement EmailField => 
            Driver.FindElement(By.XPath("//input[@name='Email']"));

        public IWebElement PasswordField => 
            Driver.FindElement(By.XPath("//input[@name='Password']"));

        public IWebElement LoginButton => 
            Driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg btn-block']"));

        public void Login(string email, string password)
        {
            EmailField.SendKeys(email);
            PasswordField.SendKeys(password);
            LoginButton.Click();
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(Url);
        }
    }
}
