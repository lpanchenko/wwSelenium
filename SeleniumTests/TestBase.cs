using NUnit.Framework;
using Selenium.Pages;
using Serilog;

namespace Selenium
{
    [TestFixture]
    public class TestBase
    {
        protected PageManager Pages { get; private set; }
        protected static ILogger Logger { get; private set; }

        static TestBase()
        {
            var loggerConfiguration = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .WriteTo.Console(Serilog.Events.LogEventLevel.Information, "{Message:lj}{NewLine}");
                        
            Logger = loggerConfiguration.CreateLogger();
        }
        
        [SetUp]
        public void StartApplication()
        {
            var baseUrl = "https://www.weightwatchers.com/us/";
            var browser = "chrome";
            Pages = new PageManager(browser, baseUrl);
        }

        [TearDown]
        public void StopApplication()
        {
            Pages.Driver.Quit();
        }
    }
}
