using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Links_SpecFlowProject.Pages
{
    class HomePage
    {
        private IWebDriver _webDriver { get; }

        public HomePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        //UI elements
        public IWebElement lnkHomePage => _webDriver.FindElement(By.XPath("/html/body/div[5]/div[1]/div[2]/div/div[1]/a/img"));
        public IWebElement lnkRegister => _webDriver.FindElement(By.XPath("//*[@id='header-white']//a/span[contains(.,'Registrirajte se')]"));
        public IWebElement lnkLogin => _webDriver.FindElement(By.LinkText("Log In"));

        //Navigation methods
        public RegistrationPage NavigateToRegistrationForm()
        {
            lnkRegister.Click();
            RegistrationPage registrationPage = new RegistrationPage(_webDriver);
            Assert.That(registrationPage.IsRegistrationPageDisplayed, Is.True);
            return registrationPage;
        }

        public LoginPage NavigateToLoginForm()
        {
            lnkLogin.Click();
            LoginPage loginPage = new LoginPage(_webDriver);
            return loginPage;
        }

        //HomePage load check
        public bool IsHomePageDisplayed() => lnkHomePage.Displayed;
    }
}
