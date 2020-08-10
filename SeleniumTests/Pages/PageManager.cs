using OpenQA.Selenium;
using Selenium.Infrastructure;

namespace Selenium.Pages
{
    // Access object for pages. Will initialize them for furher work    
    public class PageManager
    {
        public PageManager(string browser, string baseUrl)
        {
            Driver = WebDriverFactory.GetDriver(browser);

            if (!Driver.Url.StartsWith(baseUrl))
            {
                Driver.Navigate().GoToUrl(baseUrl);
            }

            Home = new HomePage(this);
            FindWorkshop = new FindWorkshopPage(this);
            Location = new LocationPage(this);
        }
        public IWebDriver Driver { get; private set; }
        public FindWorkshopPage FindWorkshop { get; private set; }
        public HomePage Home { get; private set; }
        public LocationPage Location { get; private set; }
    }
}
