using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using static AutomationTasks.Utility.Browsers;


namespace AutomationTasks.Factory
{
    class BrowserFactory 
    {

        // To use browsers separately
        // constructur should be like this :
        // public "TestName(Browser browser)" : base(browser, "URL") { }
        // And add [TestFixture(Browser."Browser Name")] , add Fixture for each browser you want to use

        // Default is chrome so the constructor can be like this if you want to use just chrome :
        // public "Test Name()" : base("URL")
        public static string downloadDirectory { get; private set; }

        public static IWebDriver GetDriver(Browser browser = Browser.Chrome)
        {
            downloadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "DownloadTestFolder");
            if (!Directory.Exists(downloadDirectory))
            {
                Directory.CreateDirectory(downloadDirectory);
            }
            IWebDriver driver;
            switch (browser)
            {
                case Browser.Chrome:
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--start-maximized");
                    chromeOptions.AddUserProfilePreference("download.default_directory", downloadDirectory);
                    chromeOptions.AddUserProfilePreference("profile.default_content_settings.popups", 0);
                    driver = new ChromeDriver(chromeOptions);
                    break;

                case Browser.Firefox:
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArgument("--start-maximized");
                    var firefoxProfile = new FirefoxProfile();
                    firefoxProfile.SetPreference("browser.download.dir", downloadDirectory);
                    firefoxProfile.SetPreference("browser.download.folderList", 2);
                    firefoxProfile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/pdf");
                    firefoxOptions.Profile = firefoxProfile;
                    driver = new FirefoxDriver(firefoxOptions);
                    break;
                default:
                    throw new ArgumentException($"Browser '{browser}' is not supported.");
            }

            return driver;
        }
    }
}
