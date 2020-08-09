using OpenQA.Selenium;
using Selenium.Infrastructure;

namespace Selenium.Pages
{
    public class HomePage : BasePage
    {
        public string url = "https://www.weightwatchers.com/";
        public HomePage(PageManager pageManager) 
            : base(pageManager)
        {
        }

        public IWebElement FindWorkshopLink => _pageManager.Driver.TryToFindElement(By.LinkText("Find a Workshop"));

        public HomePage Open()
        {
            _pageManager.Driver.Navigate().GoToUrl(url);
            return this;
        }

        public void ClickFindWorkshopLink()
        {
            FindWorkshopLink.Click();
        }
    }
}
