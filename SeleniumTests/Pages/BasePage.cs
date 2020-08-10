using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Selenium.Pages
{
    public class BasePage
    {
        protected static PageManager _pageManager;
        public BasePage(PageManager pageManager)
        {
            // Wait until pages will be fully loaded
            _pageManager = pageManager;
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        // Make an assumption that title should contain WW as logotype
        // Waiting until title will have a text value
        public string Title()
        {
            var wait = new WebDriverWait(_pageManager.Driver, TimeSpan.FromSeconds(5));
            wait.Until(x => _pageManager.Driver.Title.Contains("WW"));
            return _pageManager.Driver.Title;
        }
    }
}
