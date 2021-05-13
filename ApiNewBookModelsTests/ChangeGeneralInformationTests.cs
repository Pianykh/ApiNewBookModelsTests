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
    public class ChangeGeneralInformationTests : TestsConfig
    {       

        [Test]
        public void ChangePrimaryAccountHolderName_ShouldChangePrimaryAccountHolderName()
        {            
            var newPrimaryAccountHolderName = ChangePrimaryAccountHolderNameApiRequest.SendRequestChangePrimaryAccountHolderName(_validNewFirstName, _validNewSecondName, _user.TokenData.Token);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(_validNewFirstName, newPrimaryAccountHolderName.FirstName);
                Assert.AreEqual(_validNewSecondName, newPrimaryAccountHolderName.LastName);
            });
        }

        [Test]
        public void ChangeIndustry_ShouldChangeIndustry()
        {
            var expectedIndustry = "Food";
            var newIndustry = ChangeIndustryApiRequest.SendRequestChangeIndustry(expectedIndustry, _user.TokenData.Token);

            Assert.AreEqual(expectedIndustry, newIndustry);
        }
    }
}