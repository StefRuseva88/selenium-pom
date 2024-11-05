using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace IdeaCenterSeleniumTests.Pages
{
    public class IdeasReadPage : BasePage
    {
        public IdeasReadPage(IWebDriver driver) : base(driver)
        {
            
        }

        public string Url = BaseUrl + "/Ideas/Read";

        public IWebElement IdeaTitle => 
            Driver.FindElement(By.XPath("//h1[@class='mb-0 h4']"));

        public IWebElement IdeaDescription =>
            Driver.FindElement(By.XPath("//p[@class='offset-lg-3 col-lg-6']"));
    }
}
