using HW12.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace HW12
{
    public class RegistrationTests : TestConfiguration
    {
        private string _validFirstName = "Dylan";
        private string _validLastName = "Tribiani";       
        private string _validemail = $"tribianidylan{DateTime.Now.ToString().Replace(" ", "").Replace(".", "").Replace(":", "")}@gmail.com";
        private string _validPassword = "1Asdfghjkl(((@@@46109";        
        private string _validPhoneName = "4563217542";
        private string _companyName = "ItalGas";
        private string _companyWebsite = "https://italgas.it/";
        private string _validAdress = "a";
               

        [Test]
        public void Registration_ShouldRegisterUserIfInputValidData()
        {
            var signUpPage = new SignUpPage(webDriver);
            signUpPage.GoToSignUpPage()
                .SetFirstName(_validFirstName)
                .SetLastName(_validLastName)
                .SetEmail(_validemail)
                .SetPassword(_validPassword)
                .SetConfirmPassword(_validPassword)
                .SetPhoneNumber(_validPhoneName)
                .ClickNextButton();
            var signUpSecondPage = new SignUpSecondPage(webDriver);
            signUpSecondPage.SetCompanyName(_companyName)
                .SetCompanySite(_companyWebsite)
                .SetLocation(_validAdress)
                .SetIndustry()
                .ClickSignUpButton();
            
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.UrlToBe("https://newbookmodels.com/explore"));
            var actualUrl = webDriver.Url;            
            
            Assert.AreEqual("https://newbookmodels.com/explore", actualUrl);
        }
    }
}
