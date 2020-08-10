using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;

namespace Selenium.Infrastructure
{
    public class WebDriverFactory
    {
        public static IWebDriver GetDriver(string browser)
        {
            return browser switch
            {
                "firefox" => new FirefoxDriver(),
                "chrome" => new ChromeDriver(),
                _ => throw new Exception("Unrecognized browser type: " + browser),
            };
        }
    }
}