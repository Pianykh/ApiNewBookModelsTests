using ApiNewBookModelsTests.ApiRequests;
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
    public class ChangePasswordTests : TestsConfig
    {
        [Test]
        public void ChangePassword_ShouldChangePassword()
        {
            var oldToken = _user.TokenData.Token;
            var newToken = ChangePasswordApiRequest.SendRequestChangePassword(_validPassword, _validNewPassword, _user.TokenData.Token);

            Assert.AreNotEqual(oldToken, newToken);     
        }
    }
}
