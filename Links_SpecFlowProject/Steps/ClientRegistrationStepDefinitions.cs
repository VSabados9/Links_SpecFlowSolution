using Links_SpecFlowProject.Drivers;
using Links_SpecFlowProject.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using static Links_SpecFlowProject.Pages.RegistrationPage;

namespace Links_SpecFlowProject.Steps
{
    [Binding]
    public sealed class ClientRegistrationStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        IWebDriver driver;

        private readonly ScenarioContext _scenarioContext;

        public ClientRegistrationStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"The user navigates to the web application Home page")]
        public void GivenTheUserNavigatesToTheWebApplicationHomePage()
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").SetupChrome();
            driver.Url = "https://www.links.hr";
        }

        //[Given(@"The user navigates to the web application Home page on (.*)")]
        //public void GivenTheUserNavigatesToTheWebApplicationHomePageOn(string p0)
        //{
        //    if (p0 == "firefox")
        //    {
        //        driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").SetupFirefox();
        //    } else if (p0 == "chrome")
        //    {
        //        driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").SetupChrome();
        //    }

        //    driver.Url = "https://www.links.hr";
        //}

        [Given(@"The user naviagates to the registration form")]
        public void GivenTheUserNaviagatesToTheRegistrationForm()
        {
            HomePage homePage = new HomePage(driver);
            _ = homePage.NavigateToRegistrationForm();
        }

        //[When(@"The user fills in all the information on the registration form '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)'")]
        //public void WhenTheUserFillsInAllPrivateIndividualInformationOnTheRegistrationForm(string p0, string p1, string p2, DateTime p3, string p4, string p5, string p6, string p7, string p8, string p9, string p10, string p11, string p12)
        //{
        //    RegistrationPage registrationPage = new RegistrationPage(driver);
        //    registrationPage.FillInFormForAPrivateIndividual(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);
        //}

        [When(@"The user fills in all private individual information on the registration form '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)'")]
        public void WhenTheUserFillsInAllPrivateIndividualInformationOnTheRegistrationForm(string p0, string p1, string p2, DateTime p3, string p4, string p5, string p6, string p7, string p8, string p9, string p10, string p11, string p12)
        {
            RegistrationPage registrationPage = new RegistrationPage(driver);
            registrationPage.FillInFormForAPrivateIndividual(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);
        }

        //[When(@"The user fills in all legal entity information on the registration form '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)'")]
        //public void WhenTheUserFillsInAllLegalEntityInformationOnTheRegistrationForm(string p0, string p1, string p2, DateTime p3, string p4, string p5, string p6, string p7, string p8, string p9, string p10, string p11, string p12, string p13, string p14, string p15, string p16, string p17, string p18, string p19)
        //{
        //    RegistrationPage registrationPage = new RegistrationPage(driver);
        //    registrationPage.FillInFormForACompany(p13, p14, p15, p16, p17, p18, p19);
        //    //registrationPage.FillInFormForAPrivateIndividual(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);
        //}

        [When(@"The user fills in all legal entity information on the registration form '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)'")]
        public void WhenTheUserFillsInAllLegalEntityInformationOnTheRegistrationForm(string p0, string p1, string p2, string p3, string p4, int p5, string p6, string p7, int p8, string p9, string p10, string p11, string p12, string p13, string p14, string p15, string p16, string p17, string p18)
        {
            RegistrationPage registrationPage = new RegistrationPage(driver);
            registrationPage.FillInFormForACompany(p12, p13, p14, p15, p16, p17, p18);
        }



        [When(@"He clicks on the Submit Registration button")]
        public void WhenHeClicksOnTheSubmitRegistrationButton()
        {
            RegistrationPage registrationPage = new RegistrationPage(driver);
            registrationPage.SubmitRegisration();
        }

        [Then(@"The user shoul se the successfull registration message")]
        public void ThenTheUserShoulSeTheSuccessfullRegistrationMessage()
        {
            //WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            RegistrationPage registrationPage = new RegistrationPage(driver);
            Assert.That(registrationPage.IsRegistrationSubmitted(), Is.True);
            driver.Quit();
        }
    }
}
