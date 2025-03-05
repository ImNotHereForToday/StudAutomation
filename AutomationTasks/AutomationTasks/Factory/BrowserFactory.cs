using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace AutomationTasks.Factory
{
    class BrowserFactory
    {
        public static IWebDriver GetDriver(string browser)
        {
            IWebDriver driver;
            switch (browser.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--start-maximized");
                    driver = new ChromeDriver(chromeOptions);
                    break;
                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArgument("--start-maximized");
                    driver = new FirefoxDriver(firefoxOptions);
                    break;
                default:
                    throw new ArgumentException($"Browser '{browser}' is not supported.");
            }

            return driver;
        }
    }
}
