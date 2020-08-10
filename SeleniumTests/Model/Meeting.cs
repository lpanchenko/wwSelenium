using OpenQA.Selenium;
using System.Linq;

namespace Selenium.Model
{
    public class Meeting
    {
        // taking meeting-14qIm element
        public Meeting(IWebElement webElement)
        {
            var childs = webElement.FindElements(By.XPath(".//*"));
            Time = childs.ElementAt(0).Text;
            Couch = childs.ElementAt(1).Text;
        }

        public string Couch { get; set; }
        public string Time { get; set; }
    }
}
