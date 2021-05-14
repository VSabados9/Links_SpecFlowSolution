using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Links_SpecFlowProject.Pages
{
    public class RegistrationPage
    {
        private IWebDriver WebDriver { get; }

        public RegistrationPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        //UI elements
        public IWebElement lnkRegistrationPageBreadcrumb => WebDriver.FindElement(By.XPath("//*[@id='category-breadcrumb']/li[@class='category-breadcrumb-root-item']/span"));
        public IWebElement lblBillingWarning => WebDriver.FindElement(By.XPath("/html/body/div//form//div/div[contains(.,'*Za dobivanje R1 računa potrebno se registrirati kao pravna osoba sa podacima tvrtke ili obrta')]"));
        public IWebElement cbRregisterAsCompany => WebDriver.FindElement(By.XPath("//*[@id='RegisterAsCompany']"));

        //Form Elements
        public IWebElement rbtnGenderMale => WebDriver.FindElement(By.XPath("//*[@id='gender-male']"));
        public IWebElement rbtnGenderFemale => WebDriver.FindElement(By.Id("gender - female"));
        public IWebElement txtFirstName => WebDriver.FindElement(By.Id("FirstName"));
        public IWebElement txtLastName => WebDriver.FindElement(By.Id("LastName"));
        public IWebElement ddDateOfBirthDay => WebDriver.FindElement(By.XPath("//select[@name='DateOfBirthDay']"));    ////*[@name='DateOfBirthDay'][@class='valid']
        public IWebElement ddDateOfBirthMonth => WebDriver.FindElement(By.XPath("//select[@name='DateOfBirthMonth']"));
        public IWebElement ddDateOfBirthYear => WebDriver.FindElement(By.XPath("//select[@name='DateOfBirthYear']"));
        public IWebElement txtEmail => WebDriver.FindElement(By.Id("Email"));
        public IWebElement txtAddress => WebDriver.FindElement(By.Id("StreetAddress"));
        public IWebElement txtZipPostalCode => WebDriver.FindElement(By.XPath("//input[@id='ZipPostalCode']/preceding-sibling::input[@type='text']"));
        public IWebElement noviSadZipPostalCode => WebDriver.FindElement(By.XPath("//a[contains(.,'21 000 Novi Sad, Serbia')]"));
        public IWebElement txtCity => WebDriver.FindElement(By.XPath("//input[@id='City']/preceding-sibling::input[@type='text']"));
        public IWebElement ddCountryId => WebDriver.FindElement(By.Id("CountryId_dropdown"));
        public IWebElement txtPhone => WebDriver.FindElement(By.Id("Phone"));
        public IWebElement cbNewsletter => WebDriver.FindElement(By.Id("Newsletter"));
        public IWebElement txtPassword => WebDriver.FindElement(By.Id("Password"));
        public IWebElement txtConfirmPassword => WebDriver.FindElement(By.Id("ConfirmPassword"));

        //Company information elements (are displayed only when the "Regiester as a Company" check-box is selected)
        public IWebElement txtCompanyName => WebDriver.FindElement(By.Id("Company"));
        public IWebElement txtCompanyOIB => WebDriver.FindElement(By.Id("CompanyOIB"));
        public IWebElement txtCompanyEmail => WebDriver.FindElement(By.Id("CompanyEmail"));
        public IWebElement txtCompanyTelephone => WebDriver.FindElement(By.Id("CompanyTelephone"));
        public IWebElement txtCompanyContactPerson => WebDriver.FindElement(By.Id("CompanyContactPerson"));
        public IWebElement txtCompanyAddress => WebDriver.FindElement(By.Id("CompanyAddress"));
        public IWebElement txtCompanyZipPostalCode => WebDriver.FindElement(By.XPath("//input[@id='CompanyZipPostalCode']/preceding-sibling::input[@type='text']"));
        public IWebElement txtCompanyCity => WebDriver.FindElement(By.XPath("//input[@id='CompanyCity']/preceding-sibling::input[@type='text']"));
        public IWebElement txtCompanyCityValue => WebDriver.FindElement(By.XPath("//input[@id='CompanyCity']"));
        public IWebElement ddCompanyCountryId => WebDriver.FindElement(By.Id("CompanyCountryId_dropdown"));
        public IWebElement btnRegister => WebDriver.FindElement(By.Id("register-button"));
        public IWebElement successfullRegistrationMessage => WebDriver.FindElement(By.XPath("//div[@class='result'][contains(.,'Poslan vam je e-mail koji sadrži upute za aktivaciju članstva.')]"));

        //Variables
        public enum Gender
        {
            M,
            F
        }

        private static Random random = new Random();
        
        //Methods
        public void FillInFormForAPrivateIndividual(string gender, string firstName, string lastName, DateTime dateOfBirth, string email, string address, string zipPostalCode, string city, string country, string phone, string newsletter, string password, string confirmPassword)
        {
            Actions actions = new Actions(WebDriver);
            actions.MoveToElement(txtAddress);
            actions.Build().Perform();

            if (gender.Equals(Gender.M.ToString()))
            {
                rbtnGenderMale.Click();
            }
            else if (gender.Equals(Gender.F.ToString()))
            {
                rbtnGenderFemale.Click();
            }

            txtFirstName.SendKeys(firstName);
            txtLastName.SendKeys(lastName);

            int DateOfBirthDay = dateOfBirth.Day;
            int DateOfBirthMonth = dateOfBirth.Month;
            int DateOfBirthYear = dateOfBirth.Year;

            actions.MoveToElement(ddCountryId);
            actions.Build().Perform();

            ddDateOfBirthDay.Click();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            string specificDayXPath = ".//option[contains(text(), " + DateOfBirthDay.ToString() + ")]";
            ddDateOfBirthDay.FindElement(By.XPath(specificDayXPath)).Click();

            ddDateOfBirthMonth.Click();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            string specificMonthXPath = "//select[@name='DateOfBirthMonth']/option[@value='" + DateOfBirthMonth.ToString() + "']";
            ddDateOfBirthMonth.FindElement(By.XPath(specificMonthXPath)).Click();

            ddDateOfBirthYear.Click();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            string specificYearXPath = ".//option[contains(text(), " + DateOfBirthYear.ToString() + ")]";
            ddDateOfBirthYear.FindElement(By.XPath(specificYearXPath)).Click();

            int emailUniqueNum = random.Next(10000);
            string randomEmailPerson = "test" + emailUniqueNum + "@test.com";

            //txtEmail.SendKeys(email);
            txtEmail.SendKeys(randomEmailPerson);
            txtAddress.SendKeys(address);

            actions.MoveToElement(cbNewsletter);
            actions.Build().Perform();
            
            txtZipPostalCode.SendKeys(zipPostalCode);
            txtCity.SendKeys(city);
            var CountryId = ddCountryId.GetAttribute("value");
            txtPhone.SendKeys(phone);
            
            actions.MoveToElement(WebDriver.FindElement(By.XPath("//p[contains(.,'Novosti')]")));
            actions.Build().Perform();            
            
            cbNewsletter.Click();
            txtPassword.SendKeys(password);
            txtConfirmPassword.SendKeys(confirmPassword);
        }

        public void FillInFormForACompany(string companyName, string companyOIB, string companyTelephone, string companyContactPerson, string companyAddress, string companyZipPostalCode, string companyCity)
        {

            Actions actions = new Actions(WebDriver);
            actions.MoveToElement(cbRregisterAsCompany);
            actions.Build().Perform();

            cbRregisterAsCompany.Click();

            actions.MoveToElement(rbtnGenderMale);
            actions.Build().Perform();

            txtCompanyName.SendKeys(companyName);
            txtCompanyOIB.SendKeys(companyOIB);
            int emailUniqueNum2 = random.Next(10000);
            string randomEmailCompany = "test" + emailUniqueNum2 + "@test.com";
            //txtCompanyEmail.SendKeys(companyEmail);
            txtCompanyEmail.SendKeys(randomEmailCompany);
            txtCompanyTelephone.SendKeys(companyTelephone);
            txtCompanyContactPerson.SendKeys(companyContactPerson);
            txtCompanyAddress.SendKeys(companyAddress);
            txtCompanyZipPostalCode.SendKeys(companyZipPostalCode);
            txtCompanyCity.Click();
            //Assert.That(txtCompanyCityValue.Text.Equals("Novi Sad"));
            
            //txtCompanyCity.SendKeys(companyCity);
            //var CompanyCountryId = ddCompanyCountryId.GetAttribute("value");

            FillInFormForAPrivateIndividual("M", "David", "Parker", new DateTime(1985, 12, 25), "test@test.com", "Blok 3, ulica prva", "25221", "Sombor", "Serbia", "0642345678", "Y", "TestPassword", "TestPassword");
        }

        public void SubmitRegisration() => btnRegister.Submit();
        public bool IsRegistrationPageDisplayed() => lnkRegistrationPageBreadcrumb.Displayed;
        public bool IsRegistrationSubmitted() => successfullRegistrationMessage.Displayed;      
    }
}
