using NUnit.Framework;
using OpenQA.Selenium;

namespace UnitTestProject
{
    class BaseTest
    {
        private IWebDriver driver;
        private const string LIPSUM_URL = "https://lipsum.com";
        public BaseTest(IWebDriver driver)
        {
            this.driver = driver;
        }
        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl(LIPSUM_URL);
            driver.Manage().Window.Maximize();        
        }
        [TearDown]
        public void TearDown()
        {
            //driver.Quit();
        }
    }
    
}
