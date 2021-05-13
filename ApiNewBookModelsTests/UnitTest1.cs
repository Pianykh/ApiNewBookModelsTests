using ApiNewBookModelsTests.ApiRequests.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace ApiNewBookModelsTests
{
    public class Tests
    {
        private static string _uniqueNumber = DateTime.Now.ToString("yyyyMMddhhmmss");
        private static string _validFirstName = "John";
        private static string _validSecondName = "Tribiani";
        private static string _validPassword = "1Qazxcdew46109(";
        private static string _validEmail = $"qweqweqweqweqwe{_uniqueNumber}@gmail.com";
        private static string _validNewEmail = $"rtyrtyrtyrtyrty{_uniqueNumber}@gmail.com";
        private static string _validPhone = "1231231212";        

        [Test]
        public void ChangeEmail_ShouldChangeEmail()
        {
            var user = new CreateUserApiRequest().CreateUserViaApi(_validEmail, _validFirstName, _validSecondName, _validPassword, _validPhone); 
            var newEmail = ChangeEmailApiRequest.SendRequestChangeEmail(_validPassword, _validNewEmail, user.TokenData.Token);

            Assert.AreEqual(newEmail, _validNewEmail);
        }        
    }
}