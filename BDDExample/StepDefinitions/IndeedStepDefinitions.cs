using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BDDExample.StepDefinitions
{
    [Binding]
    public sealed class IndeedStepDefinitions
    {

        private IWebDriver driver;

        public IndeedStepDefinitions(IWebDriver driver)
        {
            this.driver = driver; 
        }

        [Given(@"Indeed Home Page")]
        public void IndeedHomePage()
        {
            driver = new ChromeDriver();
            
        }

        [When(@"Search for Software Tester job post")]
        public void SearchforSoftwareTesterjobpost()
        {
            driver.Url = "https://in.indeed.com/";
            driver.FindElement(By.Id("text-input-what")).Click();
            driver.FindElement(By.Id("text-input-what")).Clear();
            driver.FindElement(By.Id("text-input-what")).SendKeys("software tester");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }
        [When(@"Search for Software Developer job post")]
        public void WhenSearchForSoftwareDeveloperJobPost()
        {
            driver.Url = "https://in.indeed.com/";
            driver.FindElement(By.Id("text-input-what")).Click();
            driver.FindElement(By.Id("text-input-what")).Clear();
            driver.FindElement(By.Id("text-input-what")).SendKeys("software Developer");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }


        [Then(@"related Results Should display")]
        public void relatedResultsShoulddisplay()
        {
            Thread.Sleep(1000);
            driver.Quit();
        }

    }
}
