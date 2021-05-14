using Links_SpecFlowProject.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Links_SpecFlowProject.Hooks
{
    [Binding]
    public sealed class HookInitialization
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private readonly ScenarioContext _scenarioContext;

        private HookInitialization(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [BeforeScenario]
        public void BeforeScenario()
        {
            //TODO: implement logic that has to run before executing each scenario
            SeleniumDriver seleniumDriver = new SeleniumDriver(_scenarioContext);
            _scenarioContext.Set(seleniumDriver, "SeleniumDriver");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            Console.WriteLine("Selenimu webdriver quit");
            //_scenarioContext.Get<IWebDriver>("SeleniumDriver").Quit();
            //SeleniumDriver seleniumDriver = new SeleniumDriver(_scenarioContext);
            //seleniumDriver.DriverDispose();
            //ClientRegistrationStepDefinition clientRegistrationStepDefinition;
            //clientRegistrationStepDefinition.driver.Dispose();
        }
    }
}
