using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Links_SpecFlowProject.Pages
{
    class LoginPage
    {
        private IWebDriver _webDriver { get; }

        public LoginPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
    }
}
