using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace Links_SpecFlowProject.Drivers
{
    public class SeleniumDriver
    {
        private IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public SeleniumDriver(ScenarioContext scenarioContext) => scenarioContext = _scenarioContext;

        public IWebDriver SetupFirefox()
        {
            driver = new FirefoxDriver();

            ////Hardcoded FirefoxOption
            //var firefoxOptions = new FirefoxOptions();

            //driver = new RemoteWebDriver(new Uri("https://www.links.hr/hr/register"), firefoxOptions.ToCapabilities());

            //Set the driver
            _scenarioContext.Set(driver, "WebDriver");

            driver.Manage().Window.Maximize();

            return driver;
        }

        public IWebDriver SetupChrome()
        {
            driver = new ChromeDriver();

            ////Hardcoded FirefoxOption
            //var firefoxOptions = new FirefoxOptions();

            //driver = new RemoteWebDriver(new Uri("https://www.links.hr/hr/register"), firefoxOptions.ToCapabilities());

            //Set the driver
            //_scenarioContext.Set(driver, "WebDriver");

            driver.Manage().Window.Maximize();

            return driver;
        }

        public void DriverDispose()
        {
            driver.Dispose();
            //_scenarioContext.Get<IWebDriver>("SeleniumDriver").Quit();
        }

    }
}
