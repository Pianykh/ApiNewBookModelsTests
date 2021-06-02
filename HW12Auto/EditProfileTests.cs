using HW12.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW12
{
    public class EditProfileTests : TestConfiguration
    {
        private static string _uniqueNumber = DateTime.Now.ToString("yyyyMMddhhmmss");
        private string _validFirstName = "Dylan";
        private string _validLastName = "Tribiani";
        private string _validEmail = $"tribianidylan{_uniqueNumber}@gmail.com";
        private string _validPassword = "1Asdfghjkl(((@@@46109";
        private string _validNewPassword = "1Asdfghjkl(((@@@46109461";
        private string _validPhoneName = "4563217542";
        private string _validNewPhoneName = "1231231212";
        private string _companyName = "ItalGas";
        private string _companyWebsite = "https://italgas.it/";
        private string _validAdress = "a";

        [SetUp]
        public void EditTestsSetup()
        {
            var signUpPage = new SignUpPage(webDriver);
            signUpPage.GoToSignUpPage()
                .SetFirstName(_validFirstName)
                .SetLastName(_validLastName)
                .SetEmail(_validEmail)
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
        }

        [Test]
        public void ChangeName_ShouldChangeName()
        {
            var editProfilePage = new EditProfilePage(webDriver);
            editProfilePage.GoToEditProfilePage()
                .ClickGeneralSectionButton()
                .SetFirstName("Bruce")
                .SetLastNameField("Willis")
                .ClickSaveChangesGeneralButton();
            editProfilePage.WaitForSave();
            var expectedFirstAndLastName = "Bruce Willis";
            var actualFirstAndLastName = editProfilePage.GetFirstAndLastName();

            Assert.AreEqual(expectedFirstAndLastName, actualFirstAndLastName);            
        }

        [Test]
        public void ChangeLocation_ShouldChangeLocation()
        {
            var editProfilePage = new EditProfilePage(webDriver);
            editProfilePage.GoToEditProfilePage()
                .ClickGeneralSectionButton()
                .SetLocation("Boston, MA, USA")
                .ClickSaveChangesGeneralButton();
            editProfilePage.WaitForSave();
            var expectedLocation = "Boston, MA, USA";
            var actualLocation = editProfilePage.GetLocation();

            Assert.AreEqual(expectedLocation, actualLocation);
        }

        [Test]
        public void ChangeIndustry_ShouldChangeIndustry()
        {
            var editProfilePage = new EditProfilePage(webDriver);
            editProfilePage.GoToEditProfilePage()
                .ClickGeneralSectionButton()
                .SetIndustry("Fashion")
                .ClickSaveChangesGeneralButton();
            editProfilePage.WaitForSave();

            var expectedIndustry = "Fashion";
            var actualIndustry = editProfilePage.GetIndustry();

            Assert.AreEqual(expectedIndustry, actualIndustry);
        }

        [Test]
        public void ChangeEmail_ShouldChangeEmail()
        {
            var editProfilePage = new EditProfilePage(webDriver);
            editProfilePage.GoToEditProfilePage()
                .ClickEmailSectionButton()
                .SetPassword(_validPassword)
                .SetEmail("new" + _validEmail)
                .ClickSaveChangesEmailButton();
            editProfilePage.WaitForSave();

            var expectedEmail = "new" + _validEmail;
            var actualEmail = editProfilePage.GetEmail();

            Assert.AreEqual(expectedEmail, actualEmail);
        }

        [Test]
        public void ChangePassword_ShouldChangePassword()
        {
            var editProfilePage = new EditProfilePage(webDriver);
            editProfilePage.GoToEditProfilePage()
                .ClickPasswordSectionButton()
                .SetCurrentPassword(_validPassword)
                .SetNewPassword(_validNewPassword)
                .ClickSaveChangesPasswordButton();
            editProfilePage.WaitForSave();
            editProfilePage.ClicklogOutButton();
            var signInPage = new SignInPage(webDriver);
            signInPage.GoToSignInPage()
                .SetEmail(_validEmail)
                .SetPassword(_validNewPassword)
                .ClickLoginButton();
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.UrlToBe("https://newbookmodels.com/explore"));
            var actualUrl = webDriver.Url;

            Assert.AreEqual("https://newbookmodels.com/explore", actualUrl);
        }

        [Test]
        public void AddCard_ShouldAddCard()
        {
            
        }

        [Test]
        public void ChangePhone_ShouldChangePhone()
        {
            var editProfilePage = new EditProfilePage(webDriver);
            editProfilePage.GoToEditProfilePage()
                .ClickPhoneSectionButton()
                .SetPassword(_validPassword)
                .SetPhone(_validNewPhoneName)
                .ClickSaveChangesPhoneButton();
            editProfilePage.WaitForSave();

            var expectedPhone = _validNewPhoneName;
            var actualPhone = editProfilePage.GetPhone();

            Assert.AreEqual(expectedPhone, actualPhone);
        }
    }
}
