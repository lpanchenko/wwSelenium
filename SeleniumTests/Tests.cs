using NUnit.Framework;

namespace Selenium
{
    public class Tests : TestBase
    {
        [Test]
        public void OpenHomePage_CheckPageTitle()
        {
            //Precondition
            var title = "WW (Weight Watchers): Weight Loss & Wellness Help | WW USA";

            //Steps
            var homePage = Pages.Home.Open();

            //Result
            Logger.Information($"The Home page title: {homePage.Title()}");
            Assert.AreEqual(title,
                            homePage.Title(),
                            "The page title doesn't correspond the expected");
        }

        [Test]
        public void OpenFindWorkshopPage_CheckPageTitle()
        {
            //Precondition
            var title = "Find WW Studios & Meetings Near You | WW USA";

            //Steps
            var findWorkshopPage = Pages.FindWorkshop.Open();

            //Result
            Logger.Information($"The Find Workshop page title: {findWorkshopPage.Title()}");
            Assert.AreEqual(title,
                            findWorkshopPage.Title(),
                            "The page title doesn't correspond the expected");
        }

        [Test]
        public void FindLocationByZip_CheckAdressAndName()
        {
            var zip = "10011";
            var idx = 0;

            //Precondition
            var findWorkshopPage = Pages.FindWorkshop.Open();

            //Steps
            findWorkshopPage.FindLocation(zip);
 
            Logger.Information($"The distance : {findWorkshopPage.GetDistanceForLocation(idx).Text}");
            Logger.Information($"The title : {findWorkshopPage.GetAdressForLocation(idx).Text}");

            var adress = findWorkshopPage.GetAdressForLocation(idx).Text;
            var name = findWorkshopPage.GetLocationName(idx).Text;

            findWorkshopPage.OpenLocation(idx);
            var locationPage = Pages.Location;

            //Result
            Assert.AreEqual(adress, locationPage.LocationAdress.Text);
            Assert.AreEqual(name, locationPage.LocationName.Text);
        }

        [Test]
        public void OpenLocation_PrintOperationTime()
        {
            var zip = "10011";
            var idx = 0;
            //Precondition
            var findWorkshopPage = Pages.FindWorkshop.Open();

            //Steps
            findWorkshopPage.FindLocation(zip);
            findWorkshopPage.OpenLocation(idx);

            var locationPage = Pages.Location;

            //Result
            Logger.Information("The TODAY’s hours of operation:");
            Logger.Information(locationPage.GetTodayOperationTime());
        }

        [Test]
        public void OpenLocation_PrintMeetingAmountForCoach()
        {
            var zip = "10010";
            var idx = 0;
            //Precondition
            var findWorkshopPage = Pages.FindWorkshop.Open();

            //Steps
            findWorkshopPage.FindLocation(zip);
            findWorkshopPage.OpenLocation(idx);
            var locationPage = Pages.Location;

            //Result
            Logger.Information("The number of meetings:");
            Logger.Information(locationPage.PrintTodaysWorkoutsAmount());
        }
    }
}
