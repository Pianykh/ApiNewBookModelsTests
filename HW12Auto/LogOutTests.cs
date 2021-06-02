using HW12.POM;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW12
{
    class LogOutTests : EditProfileTests
    {
        [Test]
        public void LogOut_ShouldLogOutUser()
        {
            var editProfilePage = new EditProfilePage(webDriver);
            editProfilePage.GoToEditProfilePage()
                .ClicklogOutButton();
            editProfilePage.WaitForSave();

            var actualUrl = webDriver.Url;

            Assert.AreEqual("https://newbookmodels.com/auth/signin", actualUrl);
        }
    }
}
