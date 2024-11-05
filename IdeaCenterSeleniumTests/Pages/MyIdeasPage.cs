using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace IdeaCenterSeleniumTests.Pages
{
    public class MyIdeasPage : BasePage
    {
        public MyIdeasPage(IWebDriver driver) : base(driver)
        {
            
        }

        public string Url = BaseUrl + "/Ideas/MyIdeas";

        public ReadOnlyCollection<IWebElement> IdeasCards => 
            Driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));

        public IWebElement ViewButtonLastIdea => 
            IdeasCards.Last().FindElement(By.XPath(".//a[contains(@href, '/Ideas/Read')]"));

        public IWebElement EditButtonLastIdea =>
           IdeasCards.Last().FindElement(By.XPath(".//a[contains(@href, '/Ideas/Edit')]"));

        public IWebElement DeleteButtonLastIdea =>
           IdeasCards.Last().FindElement(By.CssSelector("a[href*='/Ideas/Delete']"));

        public IWebElement DescriptionLastIdea =>
          IdeasCards.Last().FindElement(By.XPath(".//p[@class='card-text']"));

        public void OpenPage()
        {
            Driver.Navigate().GoToUrl(Url);
        }
    }
}
