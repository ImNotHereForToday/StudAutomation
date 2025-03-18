using AutomationTasks.Factory;
using AutomationTasks.Pages;
using AutomationTasks.Pages.Authentication;
using AutomationTasks.Pages.Module_1_Page;
using AutomationTasks.Pages.Module_2_Page;
using AutomationTasks.Pages.Module_3_Page;
using AutomationTasks.Pages.Module_5_Page;
using AutomationTasks.Pages.Module_6_Page;
using AutomationTasks.Pages.Module_8_Page;
using AutomationTasks.Utility;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using static AutomationTasks.Utility.Browsers;

class TestBase
{
    private ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
    public Browser browser;
    public string url;

    protected SauceDemoLogin sauceDemoLogin;
    protected HerokuappLogin herokuappLogin;
    protected Module_1_Page module_1_Page;
    protected Module_2_Page module_2_Page;
    protected Module_3_Page module_3_Page;
    protected Module_5_Page module_5_Page;
    protected Module_6_Page module_6_Page;
    protected Module_8_Page module_8_Page;

    protected TestBase(string url) : this(Browser.Chrome, url)
    {
    }

    public TestBase(Browsers.Browser browser, string url)
    {
        this.browser = browser;
        this.url = url;
    }

    public IWebDriver Driver => driver.Value;

    [SetUp]
    public void Setup()
    {
        driver.Value = BrowserFactory.GetDriver(browser);
        Driver.Navigate().GoToUrl(url);

        if (driver.Value != null)
        {
            sauceDemoLogin = new SauceDemoLogin(Driver);
            herokuappLogin = new HerokuappLogin(Driver);
            module_1_Page = new Module_1_Page(Driver);
            module_2_Page = new Module_2_Page(Driver);
            module_3_Page = new Module_3_Page(Driver);
            module_5_Page = new Module_5_Page(Driver);
            module_6_Page = new Module_6_Page(Driver);
            module_8_Page = new Module_8_Page(Driver);
        }
    }

    [TearDown]
    public void TearDown()
    {
        if (TestContext.CurrentContext.Test.Properties.ContainsKey("quit") && driver.Value != null)
        {
            driver.Value.Quit();
            driver.Value = null;
        }
    }
}