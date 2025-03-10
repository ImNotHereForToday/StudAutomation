using NUnit.Framework;

namespace AutomationTasks.Tests.Module_6_Test
{
    class Module_6_Test : TestBase
    {
        public Module_6_Test() : base("http://the-internet.herokuapp.com/")
        {
        }

        [Test, Order(1)]
        [Property("quit", "true")]
        public void HandlingAlerts()
        {
            module_5_Page.ClickOnLinkPage("/javascript_alerts");
            module_6_Page.ClickOnAlertButton("Alert");
            module_6_Page.AcceptAlert();
            module_6_Page.AssertAlertMessage("You successfully clicked an alert");
            module_6_Page.ClickOnAlertButton("Confirm");
            module_6_Page.DismissAlert();
            module_6_Page.AssertAlertMessage("You clicked: Cancel");
            module_6_Page.ClickOnAlertButton("Prompt");
            module_6_Page.SendKeysToAlert("haloa");
            module_6_Page.AssertAlertMessage("You entered: haloa");
        }
        [Test, Order(2)]
        [Property("quit", "true")]
        public void HandlingFrames()
        {
            module_5_Page.ClickOnLinkPage("/frames");
            module_5_Page.ClickOnLinkPage("/iframe");
            Driver.SwitchTo().Frame("mce_0_ifr");
            module_6_Page.AssertIFrameHeading();
            Driver.SwitchTo().DefaultContent();
        }
        [Test, Order(3)]
        [Property("quit", "true")]
        public void InteractingWithSelectElement()
        {
            module_5_Page.ClickOnLinkPage("/dropdown");
            module_6_Page.SelectDropDownElement("Option 1");
        }

        [Test, Order(4)]
        [Property("quit", "true")]
        public void InteractingWithCheckBoxElement()
        {
            module_5_Page.ClickOnLinkPage("/checkboxes");
            module_5_Page.SelectAndUnselectCheckBoxes();
        }

        [Test, Order(5)]
        [Property("quit", "true")]
        public void InteractingWithRangeElement()
        {
            module_5_Page.ClickOnLinkPage("/horizontal_slider");
            module_6_Page.SetValueInTheRangeInput();
        }

        [Test, Order(6)]
        [Property("quit", "true")]
        public void InteractingWithTextInputElement()
        {
            module_5_Page.ClickOnLinkPage("/inputs");
            module_6_Page.AssertInputNumber("6");
        }

        [Test, Order(7)]
        [Property("quit", "true")]
        public void BasicAuthentication()
        {
            module_5_Page.ClickOnLinkPage("/basic_auth");
            Driver.Navigate().GoToUrl("http://admin:admin@the-internet.herokuapp.com/basic_auth");
            module_6_Page.AssertSucesfullAuth();
        }

        [Test, Order(7)]
        [Property("quit", "true")]
        public void DownloadAFile()
        {
            var fileName = "some-file.txt";
            module_5_Page.ClickOnLinkPage("/download");
            module_5_Page.ClickOnLinkPage("download/some-file.txt");
            module_6_Page.WaitForFileDownload(fileName);
            module_6_Page.AssertAndDeleteDownloadedFile(fileName);
        }

        [Test, Order(8)]
        [Property("quit", "true")]
        public void ValidationOfSortedData()
        {
            module_5_Page.ClickOnLinkPage("/tables");
            module_6_Page.ClickOnFirstNameSort();
            module_6_Page.AssertThatColumnIsSortedAscending(2);
        }

        [Test, Order(9)]
        [Property("quit", "true")]
        public void ValidationOfSortingFunctionality()
        {
            module_5_Page.ClickOnLinkPage("/tables");
            module_6_Page.ClickOnLastNameSort();
            module_6_Page.AssertThatColumnIsSortedAscending(1);
            module_6_Page.ClickOnLastNameSort();
            module_6_Page.AssertThatColumnIsSortedDescending(1);
        }

        [Test, Order(10)]
        [Property("quit", "true")]
        public void ValidateRowData()
        {
            module_5_Page.ClickOnLinkPage("/tables");
            module_6_Page.ValidateRowData();
        }

        [Test, Order(11)]
        [Property("quit", "true")]
        public void NavigateAndReturnToPage()
        {
            module_5_Page.ClickOnLinkPage("/tables");
            Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/hovers");
            var currentUrl = Driver.Url;
            Assert.That(currentUrl, Is.EqualTo("https://the-internet.herokuapp.com/hovers"));
            Driver.Navigate().Back();
            var currentUrlAfterBack = Driver.Url;
            Assert.That(currentUrlAfterBack, Is.EqualTo("https://the-internet.herokuapp.com/tables"));
        }
        [Test, Order(12)]
        [Property("quit", "true")]
        public void ValidateDataSortingWithDueColumn()
        {
            module_5_Page.ClickOnLinkPage("/tables");
            module_6_Page.ClickOnDueSort();
            module_6_Page.ValidateDataSortByDue(4);
        }
    }
}
