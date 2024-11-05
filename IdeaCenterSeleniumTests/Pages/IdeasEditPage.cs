using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace IdeaCenterSeleniumTests.Pages
{
    public class IdeasEditPage : BasePage
    {
        public IdeasEditPage(IWebDriver driver) : base(driver)
        {
            
        }

        public string Url = BaseUrl + "/Ideas/Create";

        public IWebElement IdeaTitle =>
           Driver.FindElement(By.XPath("//input[@id='form3Example1c']"));

        public IWebElement IdeaDescription =>
           Driver.FindElement(By.XPath("//textarea[@id='form3Example4cd']"));

        public IWebElement EditButton =>
           Driver.FindElement(By.XPath("//button[text()='Edit']"));
    }
}
