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
    public class ChangeEmailTests : TestsConfig
    {        
        [Test]
        public void ChangeEmail_ShouldChangeEmail()
        {            
            var newEmail = ChangeEmailApiRequest.SendRequestChangeEmail(_validPassword, _validNewEmail, _user.TokenData.Token);

            Assert.AreEqual(newEmail, _validNewEmail);
        }        
    }
}