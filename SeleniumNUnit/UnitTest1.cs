using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using NUnit.Framework.Legacy;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Net.NetworkInformation;

namespace SeleniumNUnit
{
    public class Keyboard_Testing
    {
        private IWebDriver driver;
        private ExtentReports extent;
        private ExtentTest test;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // Initialize ExtentReports
            extent = new ExtentReports();
            var htmlReporter = new ExtentSparkReporter("\"C:\\Users\\USER\\source\\repos\\Testing selenium\\SeleniumNUnit\\test result\"");
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Tested by", ".......");
            extent.AddSystemInfo("Browser", "Chrome");
            extent.AddSystemInfo("OS", "Windows");
        }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void KeyDown()
        {

            driver.Url = "https://selenium.dev/selenium/web/single_text_input.html";

            new Actions(driver)
                .KeyDown(Keys.Shift)
                .SendKeys("a")
                .Perform();

            IWebElement textField = driver.FindElement(By.Id("textInput"));
            ClassicAssert.AreEqual("A", textField.GetAttribute("value"));
        }

        [Test]
        public void KeyUp()
        {
            driver.Url = "https://selenium.dev/selenium/web/single_text_input.html";

            new Actions(driver)
                .KeyDown(Keys.Shift)
                .SendKeys("a")
                .KeyUp(Keys.Shift)
                .SendKeys("b")
                .Perform();

            IWebElement textField = driver.FindElement(By.Id("textInput"));
            ClassicAssert.AreEqual("Ab", textField.GetAttribute("value"));
        }

        [Test]
        public void SendKeysToActiveElement()
        {
            driver.Url = "https://selenium.dev/selenium/web/single_text_input.html";

            new Actions(driver)
                .SendKeys("abc")
                .Perform();

            IWebElement textField = driver.FindElement(By.Id("textInput"));
            ClassicAssert.AreEqual("abc", textField.GetAttribute("value"));
        }

        [Test]
        public void SendKeysToDesignatedElement()
        {
            driver.Url = "https://selenium.dev/selenium/web/single_text_input.html";
            driver.FindElement(By.TagName("body")).Click();

            IWebElement textField = driver.FindElement(By.Id("textInput"));
            new Actions(driver)
                .SendKeys(textField, "abc")
                .Perform();

            ClassicAssert.AreEqual("abc", textField.GetAttribute("value"));
        }


        [TearDown]
        public void Teardown()
        {
            Thread.Sleep(1000);
            driver.Quit();
            //extent.Flush();
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;

            switch (status)
            {
                case NUnit.Framework.Interfaces.TestStatus.Failed:
                    test.Log(Status.Fail, "Test Failed");
                    test.Log(Status.Error, errorMessage);
                    test.Log(Status.Error, stackTrace);
                    break;
                case NUnit.Framework.Interfaces.TestStatus.Passed:
                    test.Log(Status.Pass, "Test Passed");
                    break;
                case NUnit.Framework.Interfaces.TestStatus.Skipped:
                    test.Log(Status.Skip, "Test Skipped");
                    break;
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Close the ExtentReports
            extent.Flush();
           
        }
    }
}