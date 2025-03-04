using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTasks.Factory
{
    class BrowserFactory
    {
        public static IWebDriver GetDriver(string browser)
        {
            IWebDriver driver;
            switch (browser)
            {
                case "chrome":
                    var chromeOptions = new OpenQA.Selenium.Chrome.ChromeOptions();
                    chromeOptions.AddArgument("--start-maximized");
                    driver = new OpenQA.Selenium.Chrome.ChromeDriver(chromeOptions);
                    break;
                case "firefox":
                    var firefoxOptions = new OpenQA.Selenium.Firefox.FirefoxOptions();
                    firefoxOptions.AddArgument("--start-maximized");
                    driver = new OpenQA.Selenium.Firefox.FirefoxDriver(firefoxOptions);
                    break;
                default:
                    throw new Exception("Invalid browser");
            }

            return driver;
        }
    }
}
