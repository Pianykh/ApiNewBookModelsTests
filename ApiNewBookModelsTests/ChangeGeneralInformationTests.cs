using ApiNewBookModelsTests.ApiRequests;
using ApiNewBookModelsTests.ApiRequests.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace ApiNewBookModelsTests
{
    class ChangeGeneralInformationTests
    {
        private static string _uniqueNumber = DateTime.Now.ToString("yyyyMMddhhmmss");
        private static string _validFirstName = "John";
        private static string _validSecondName = "Tribiani";
        private static string _validPassword = "1Qazxcdew46109(";
        private static string _validEmail = $"qweqweqweqweqwe{_uniqueNumber}@gmail.com";
        private static string _validNewEmail = $"rtyrtyrtyrtyrty{_uniqueNumber}@gmail.com";
        private static string _validPhone = "1231231212";
        private static string _validNewFirstName = "Bruce";
        private static string _validNewSecondName = "Willis";

        [Test]
        public void ChangeGeneralInformation_ShouldChangeGeneralInformation()
        {
            var user = new CreateUserApiRequest().CreateUserViaApi(_validEmail, _validFirstName, _validSecondName, _validPassword, _validPhone);
            var newPrimaryAccountHolderName = ChangePrimaryAccountHolderNameApiRequest.SendRequestChangePrimaryAccountHolderName(_validNewFirstName, _validNewSecondName, user.TokenData.Token);
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            var webDriver = new ChromeDriver();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            IJavaScriptExecutor js = webDriver;
            webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
            js.ExecuteScript($"localStorage.setItem('access_token','{user.TokenData.Token}')");
        }
    }
}
