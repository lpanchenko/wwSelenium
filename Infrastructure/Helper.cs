using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Selenium.Infrastructure
{
    public static class Helper
    {
        internal static IWebElement TryToFindElement(this IWebDriver driver, By condition, int timeoutInSeconds = 5)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            int tries = 1;
            do
            {
                try
                {
                    tries++;
                    return wait.Until(i => driver.FindElement(condition));
                }
                catch (Exception)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(timeoutInSeconds));
                }
            } while (tries < 4); // try a few attempts

            throw new NoSuchElementException($"Element with locator \"{condition}\" is not found");
        }
    }
}
