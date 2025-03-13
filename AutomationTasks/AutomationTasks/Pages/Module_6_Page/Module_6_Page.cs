using AutomationTasks.Factory;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace AutomationTasks.Pages.Module_6_Page
{
    class Module_6_Page : PageBase
    {
        private IWebElement ResultBox => driver.FindElement(By.Id("result"));
        private IWebElement FirstNameHeader => driver.FindElement(By.XPath("//table[@id='table1']//span[contains(text(),'First Name')]"));
        private IWebElement LastNameHeader => driver.FindElement(By.XPath("//table[@id='table1']//span[contains(text(),'Last Name')]"));
        private IWebElement DueHeader => driver.FindElement(By.XPath("//table[@id='table1']//span[contains(text(),'Due')]"));
        private IWebElement Example1Table => driver.FindElement(By.Id("table1"));

        public Module_6_Page(IWebDriver driver) : base(driver)
        {
        }

        public Module_6_Page ClickOnAlertButton(string alertType)
        {
            driver.FindElement(By.XPath($"//button[contains(text(),'Click for JS {alertType}')]")).Click();
            
            return this;
        }

        public Module_6_Page AcceptAlert()
        {
            driver.SwitchTo().Alert().Accept();
            
            return this;
        }

        public Module_6_Page DismissAlert()
        {
            driver.SwitchTo().Alert().Dismiss();
            
            return this;
        }

        public Module_6_Page SendKeysToAlert(string keys)
        {
            var alert = driver.SwitchTo().Alert();
            alert.SendKeys(keys);
            alert.Accept();
            
            return this;
        }

        public Module_6_Page AssertAlertMessage(string promptText)
        {
            Assert.That(ResultBox.Text, Is.EqualTo(promptText));
            
            return this;
        }

        public Module_6_Page AssertIFrameHeading()
        {
            Assert.That(driver.FindElement(By.XPath("//p[contains(text(),'Your content goes here.')]")).Displayed, Is.True);
            
            return this;
        }

        public Module_6_Page SelectDropDownElement(string optionText)
        {
            var select = new SelectElement(driver.FindElement(By.Id("dropdown")));
            select.SelectByText(optionText);
            Assert.That(select.SelectedOption.Text, Is.EqualTo(optionText));
            
            return this;
        }

        public Module_6_Page SetValueInTheRangeInput()
        {
            var rangeInput = driver.FindElement(By.XPath("//input[@type='range']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].value = arguments[1]; arguments[0].dispatchEvent(new Event('change'));", rangeInput, "3");
            Assert.That(rangeInput.GetAttribute("value"), Is.EqualTo("3"));
            
            return this;
        }

        public Module_6_Page AssertInputNumber(string inputText)
        {
            var inputArea = driver.FindElement(By.XPath("//input[@type='number']"));
            inputArea.SendKeys(inputText);
            Assert.That(inputArea.GetAttribute("value"), Is.EqualTo(inputText));
            
            return this;
        }

        public Module_6_Page AssertSucesfullAuth()
        {
            var authMessage = driver.FindElement(By.XPath("//p"));
            Assert.That(authMessage.Text, Is.EqualTo("Congratulations! You must have the proper credentials."));
            
            return this;
        }

        public void AssertAndDeleteDownloadedFile(string fileNameSubstring)
        {
            try
            {
                string downloadedFilePath = FindDownloadedFile(fileNameSubstring);
                Assert.That(File.Exists(downloadedFilePath), "The file with the expected name was not downloaded.");
                File.Delete(downloadedFilePath);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Error during assertion and deletion: {ex.Message}");
            }
        }

        private string FindDownloadedFile(string fileNameSubstring)
        {
            var files = Directory.GetFiles(BrowserFactory.downloadDirectory);
            foreach (var file in files)
            {
                if (file.Contains(fileNameSubstring))
                {

                    return file;
                }
            }
            throw new FileNotFoundException($"No file with the substring '{fileNameSubstring}' was found in the download folder.");
        }

        public void WaitForFileDownload(string fileNameSubstring)
        {
            bool isFileDownloading = false;
            SpinWait.SpinUntil(() =>
            {
                var files = Directory.GetFiles(BrowserFactory.downloadDirectory);
                isFileDownloading = files.Any(file => file.Contains(fileNameSubstring));

                return isFileDownloading;
            }, TimeSpan.FromSeconds(10));
            if (!isFileDownloading)
            {
                throw new FileNotFoundException($"The file containing '{fileNameSubstring}' was not found.");
            }
        }

        public Module_6_Page ClickOnLastNameSort()
        {
            LastNameHeader.Click();
            
            return this;
        }

        public Module_6_Page ClickOnFirstNameSort()
        {
            FirstNameHeader.Click();
            
            return this;
        }

        public Module_6_Page ClickOnDueSort()
        {
            DueHeader.Click();
            
            return this;
        }

        public Module_6_Page AssertThatColumnIsSortedAscending(int column)
        {
            var values = Example1Table
                .FindElements(By.XPath($".//tr/td[{column}]"))
                .Select(cell => cell.Text).ToList();

            Assert.That(values, Is.EqualTo(values.OrderBy(v => v).ToList()));
            
            return this;
        }

        public Module_6_Page AssertThatColumnIsSortedDescending(int column)
        {
            var values = Example1Table
                .FindElements(By.XPath($".//tr/td[{column}]"))
                .Select(cell => cell.Text)
                .ToList();

            Assert.That(values, Is.EqualTo(values.OrderByDescending(v => v).ToList()));
            
            return this;
        }

        public Module_6_Page ValidateRowData()
        {
            var lastNameData = driver.FindElements(By.XPath("//table[@id='table2']//td[@class='last-name']"))
                .Select(cell => cell.Text)
                .ToList();

            Assert.That(lastNameData, Is.EqualTo(new List<string> 
            { 
                "Smith", "Bach", "Doe", "Conway"
            }));
            
            return this;
        }

        public Module_6_Page ValidateDataSortByDue(int column)
        {
            var result = Example1Table
                .FindElements(By.XPath($".//tr/td[{column}]"))
                .Select(name => Convert.ToDouble(name.Text.Replace("$", "")))
                .OrderBy(x => x)
                .ToList();

            Assert.That(result, Is.EqualTo(new List<double> { 50.00, 50.00, 51.00, 100.00 }));
            
            return this;
        }
    }
}