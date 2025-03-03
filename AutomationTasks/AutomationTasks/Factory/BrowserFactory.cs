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
                    driver = new OpenQA.Selenium.Chrome.ChromeDriver();
                    break;
                case "firefox":
                    driver = new OpenQA.Selenium.Firefox.FirefoxDriver();
                    break;
                default:
                    throw new Exception("Invalid browser");
            }
            return driver;
        }

    }
}
