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
    class ChangeCompanyInformationTests : TestsConfig
    {
        [Test]
        public void ChangeCompanyInformation_ShouldChangeCompanyInformation()
        {
            var newCompanyInformation = ChangeCompanyInformationApiRequest.SendRequestChangeCompanyInformation(_validCompanyName, _validCompanySite, _validCompanyDescription, _user.TokenData.Token);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(_validCompanyName, newCompanyInformation.CompanyName);
                Assert.AreEqual(_validCompanySite, newCompanyInformation.CompanyWebsite);
                Assert.AreEqual(_validCompanyDescription, newCompanyInformation.CompanyDescription);
            });
        }
    }
}
