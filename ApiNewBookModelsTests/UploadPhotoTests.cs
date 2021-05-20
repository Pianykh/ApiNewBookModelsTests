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
    class UploadPhotoTests : TestsConfig
    {
        [Test]
        public void UploadPhoto_ShouldUploadPhoto()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            var webDriver = new ChromeDriver();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            IJavaScriptExecutor js = webDriver;
            webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
            js.ExecuteScript($"localStorage.setItem('access_token','{_user.TokenData.Token}')");
            var newCompanyInformation = ChangeCompanyInformationApiRequest.SendRequestChangeCompanyInformation(_validCompanyName, _validCompanySite, _validCompanyDescription, _user.TokenData.Token);
            var uploadImageModel = UploadImageApiRequest.SendRequestUploadImage(_user.TokenData.Token);
        }
    }
}
