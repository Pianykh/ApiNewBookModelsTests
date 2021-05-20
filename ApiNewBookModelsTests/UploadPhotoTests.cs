using ApiNewBookModelsTests.ApiRequests;
using ApiNewBookModelsTests.Models;
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
            var uploadImage = UploadImageApiRequest.SendRequestUploadImage(_user.TokenData.Token);
            var changedAvatar = ChangeAvatarApiRequest.SendRequestChangeAvatar(_user.TokenData.Token, uploadImage.Image.Id);
            var excpectedAvatar = GetAccountAvatarApiRequest.SendRequestGetAccountAvatar(_user.TokenData.Token);
            Assert.AreEqual(changedAvatar.Id, excpectedAvatar.Id);            
        }
    }
}
