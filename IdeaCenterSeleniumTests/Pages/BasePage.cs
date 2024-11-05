using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace IdeaCenterSeleniumTests.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;
        protected WebDriverWait wait;
        protected static readonly string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:83";

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement HomeLink => 
            Driver.FindElement(By.XPath("//img[@class='rounded-circle']"));

        public IWebElement MyProfileLink => 
            Driver.FindElement(By.XPath("//a[@class='nav-link' and text()='My Profile']"));

        public IWebElement MyIdeasLink => 
            Driver.FindElement(By.XPath("//a[@class='nav-link' and text()='My Ideas']"));

        public IWebElement CreateIdeaLink => 
            Driver.FindElement(By.XPath("//a[@class='nav-link' and text()='Create Idea']"));

        public IWebElement LogOutLink => 
            Driver.FindElement(By.XPath(" //a[@class='btn btn-primary me-3']"));

        public IWebElement LoginButton => 
            Driver.FindElement(By.XPath("//a[@class='btn btn-outline-info px-3 me-2']"));

    }
}
