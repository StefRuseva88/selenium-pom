using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace IdeaCenterSeleniumTests.Tests
{
    public class IdeaCenterTest : BaseTest
    {
        public string lastCreatedIdeaTitle;
        public string lastCreatedIdeaDescription;


        [Test, Order(1)]
        public void CreateIdeaWithInvalidDataTest()
        {
            createIdeaPage.OpenPage();

            createIdeaPage.CreateIdea("", "", "");

            createIdeaPage.AssertErrorMessages();
        }

        [Test, Order(2)]
        public void CreateRandomIdeaTest()
        {
            lastCreatedIdeaTitle = "Idea" + GenerateRandomString(6);
            lastCreatedIdeaDescription = "Description" + GenerateRandomString(10);

            createIdeaPage.OpenPage();

            createIdeaPage.CreateIdea(lastCreatedIdeaTitle, "", lastCreatedIdeaDescription);

            Assert.That(driver.Url, Is.EqualTo(myIdeasPage.Url), "URL is not correct");
            Assert.That(myIdeasPage.DescriptionLastIdea.Text.Trim(),
                Is.EqualTo(lastCreatedIdeaDescription), "Descriptions don't match");
        }

        [Test, Order(3)]
        public void ViewLastCreatedIdeaTest()
        { 
            myIdeasPage.OpenPage();

            Assert.That(myIdeasPage.IdeasCards.Count, Is.GreaterThan(0), "There are no ideas");

            myIdeasPage.ViewButtonLastIdea.Click();

            Assert.That(ideasReadPage.IdeaTitle.Text,
                Is.EqualTo(lastCreatedIdeaTitle), "Titles don't match");
            Assert.That(ideasReadPage.IdeaDescription.Text,
                Is.EqualTo(lastCreatedIdeaDescription), "Descriptions don't match");
        }

        [Test, Order(4)]
        public void EditLastCreatedIdeaTitleTest()
        {
            myIdeasPage.OpenPage();

            myIdeasPage.EditButtonLastIdea.Click();

            string newTitle = "NewTitle:" + lastCreatedIdeaTitle;

            ideasEditPage.IdeaTitle.Clear();

            ideasEditPage.IdeaTitle.SendKeys(newTitle);

            ideasEditPage.EditButton.Click();

            Assert.That(driver.Url, Is.EqualTo(myIdeasPage.Url), "Not correctly redirected");

            myIdeasPage.ViewButtonLastIdea.Click();

            Assert.That(ideasReadPage.IdeaTitle.Text,
                Is.EqualTo(newTitle), "Titles don't match");
        }

        [Test, Order(5)]
        public void EditLastCreatedIdeaDescriptionTest()
        {
            myIdeasPage.OpenPage();

            myIdeasPage.EditButtonLastIdea.Click();

            string newDescription = "NewDescription:" + lastCreatedIdeaDescription;

            ideasEditPage.IdeaDescription.Clear();

            ideasEditPage.IdeaDescription.SendKeys(newDescription);

            ideasEditPage.EditButton.Click();

            Assert.That(driver.Url, Is.EqualTo(myIdeasPage.Url), "Not correctly redirected");

            myIdeasPage.ViewButtonLastIdea.Click();

            Assert.That(ideasReadPage.IdeaDescription.Text,
                Is.EqualTo(newDescription), "Descriptions don't match");
        }

        [Test, Order(6)]
        public void DeleteLastCreatedIdeaTest()
        {
            myIdeasPage.OpenPage();

            myIdeasPage.DeleteButtonLastIdea.Click();

            bool isIdeaDeleted = myIdeasPage.IdeasCards.All(x => x.Text.Contains(lastCreatedIdeaTitle));

            Assert.IsTrue(isIdeaDeleted, "Idea is not deleted");
        }
    }
}
