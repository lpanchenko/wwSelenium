using OpenQA.Selenium;
using Selenium.Infrastructure;
using Selenium.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium.Pages
{
    public partial class LocationPage : BasePage
    {
        public LocationPage(PageManager pageManager)
            : base(pageManager)
        { 
        }

        public IWebElement LocationName => _pageManager.Driver.TryToFindElement(By.ClassName("locationName-1jro_"));

        public IWebElement LocationAdress => _pageManager.Driver.TryToFindElement(By.ClassName("address-2PZwW"));

        private string CurrentWeekDay => DateTime.Today.DayOfWeek.ToString();

        // Should return time for each meeting for selected day divided by new line
        // 7:00 AM
        // 10:00 AM
        public string GetTodayOperationTime()
        {
            var meetings = GetMeetings(CurrentWeekDay);
            if (meetings.Count == 0) return "No workouts for this location today";

            var builder = new StringBuilder();
            foreach (var m in meetings)
            {
                builder.AppendLine(m.Time);
            }
            return builder.ToString();
        }

        public string PrintTodaysWorkoutsAmount()
        {
            var meetings = GetMeetings(CurrentWeekDay);
            if (meetings.Count == 0) return "No workouts for this location today";

            var dictionary = new Dictionary<string, int>();

            foreach (var m in meetings)
            {
                if (dictionary.ContainsKey(m.Couch))
                    dictionary[m.Couch] += 1;
                else
                    dictionary.Add(m.Couch, 1);
            }

            var builder = new StringBuilder();
            foreach (var d in dictionary)
            {
                builder.AppendLine($"{d.Key} {d.Value}");
            }
            return builder.ToString();
        }

        private static List<Meeting> GetMeetings(string weekDay)
        {
            var meetingsWebElements = _pageManager.Driver.TryToFindElement(By.XPath($"//span[contains(text(),'{weekDay.Substring(0, 3).ToUpper()}')]"))
                                      .FindElement(By.XPath(".."))
                                      .FindElements(By.ClassName("meeting-14qIm"));
            var  meetings = new List<Meeting>();
            foreach (var meetingWebElement in meetingsWebElements)
            {
                meetings.Add(new Meeting(meetingWebElement));                
            }
            return meetings;
        }
    }
}
