using AutomationTasks.Factory;
using AutomationTasks.Pages.Module_1_Page;
using AutomationTasks.Pages.Module_2_Page;
using AutomationTasks.Pages.Module_3_Page;
using AutomationTasks.Pages.Module_5_Page;
using AutomationTasks.Pages.Module_6_Page;
using AutomationTasks.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using static AutomationTasks.Factory.BrowserFactory;

class TestBase
{
    private ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
    public Browser browser;
    public string url;

    protected LoginPage loginPage;
    protected Module_1_Page module_1_Page;
    protected Module_2_Page module_2_Page;
    protected Module_3_Page module_3_Page;
    protected Module_5_Page module_5_Page;
    protected Module_6_Page module_6_Page;

    protected TestBase(string url) : this(Browser.Chrome, url)  
    {   
    }

    protected TestBase(Browser browser, string url)
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
            loginPage = new LoginPage(Driver);
            module_1_Page = new Module_1_Page(Driver);
            module_2_Page = new Module_2_Page(Driver);
            module_3_Page = new Module_3_Page(Driver);
            module_5_Page = new Module_5_Page(Driver);
            module_6_Page = new Module_6_Page(Driver);
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
