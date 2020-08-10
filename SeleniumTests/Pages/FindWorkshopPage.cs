using OpenQA.Selenium;
using System.Linq;
using Selenium.Infrastructure;
using System;
using System.Threading;

namespace Selenium.Pages
{
    public class FindWorkshopPage : BasePage
    {
        public string url = "https://www.weightwatchers.com/us/find-a-workshop/";
        public FindWorkshopPage(PageManager pageManager) 
            : base(pageManager)
        { 
        }

        public IWebElement EnterlocationTextBox => _pageManager.Driver.TryToFindElement(By.Id("location-search"));

        public IWebElement SubmitButton => _pageManager.Driver.TryToFindElement(By.Id("location-search-cta"));

        public FindWorkshopPage Open()
        {
            _pageManager.Driver.Navigate().GoToUrl(url);
            return this;
        }

        public void FindLocation(string location)
        {
            EnterlocationTextBox.SendKeys(location);
            SubmitButton.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        public IWebElement GetAdressForLocation(int idx)
        {
            return _pageManager.Driver.TryToFindElement(By.Id("search-results"))
                .FindElements(By.ClassName("container-3SE46"))
                .ElementAt(idx)
                .FindElement(By.ClassName("address-3-YC0"));
        }        

        public IWebElement GetDistanceForLocation(int idx)
        {
            return _pageManager.Driver.TryToFindElement(By.Id("search-results"))
                .FindElements(By.ClassName("container-3SE46"))
                .ElementAt(idx)
                .FindElement(By.ClassName("distance-OhP63"));
        }

        public void OpenLocation(int idx)
        {
            _pageManager.Driver.TryToFindElement(By.Id("search-results"))
                .FindElements(By.ClassName("container-3SE46"))
                .ElementAt(idx)
                .FindElement(By.ClassName("linkContainer-1NkqM")).Click();
        }

        internal IWebElement GetLocationName(int idx)
        {
            return _pageManager.Driver.TryToFindElement(By.Id("search-results"))
                .FindElements(By.ClassName("container-3SE46"))
                .ElementAt(idx)
                .FindElement(By.ClassName("linkUnderline-1_h4g"));
        }
    }
}