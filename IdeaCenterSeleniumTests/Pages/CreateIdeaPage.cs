using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;


namespace IdeaCenterSeleniumTests.Pages
{
    public class CreateIdeaPage : BasePage
    {
        public CreateIdeaPage(IWebDriver driver) : base(driver)
        {
            
        }
        public string Url = BaseUrl + "/Ideas/Create";
            
        public IWebElement TitleInput => 
            Driver.FindElement(By.XPath("//input[@name='Title']"));

        public IWebElement ImageInput => 
            Driver.FindElement(By.XPath("//input[@name='Url']"));

        public IWebElement DescriptionInput => 
            Driver.FindElement(By.XPath("//textarea[@name='Description']"));

        public IWebElement CreateButton => 
            Driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']"));

        public IWebElement MainMessage => 
            Driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']//li"));

        public IWebElement TitleErrorMsg => 
            Driver.FindElements(By.XPath("//span[@class='text-danger field-validation-error']"))[0];

        public IWebElement DescriptionErrorMsg => 
            Driver.FindElements(By.XPath("//span[@class='text-danger field-validation-error']"))[1];

        public void CreateIdea(string title, string image, string description)
        {
            TitleInput.SendKeys(title);
            ImageInput.SendKeys(image);
            DescriptionInput.SendKeys(description);
            CreateButton.Click();
        }

        public void AssertErrorMessages()
        {
            Assert.That(MainMessage.Text.Equals("Unable to create new Idea!"), Is.True, "Main message is not as expected!");
            Assert.That(TitleErrorMsg.Text.Equals("The Title field is required."), Is.True, "Title message is not as expected!");
            Assert.That(DescriptionErrorMsg.Text.Equals("The Description field is required."), Is.True, "Description message is not as expected!");
        }

        public void OpenPage()
        {
            Driver.Navigate().GoToUrl(Url);
        }

    }
}
