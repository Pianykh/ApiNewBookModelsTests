using HW12.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Steps.UI
{
    [Binding]
    class EditUserInformationSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;
        private readonly EditProfilePage _editProfilePage;
        private SignInPage _signInPage;
        

        public EditUserInformationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            _editProfilePage = new EditProfilePage(_webDriver);
        }

        [Given(@"Account settings page is opened")]
        public void GivenAccountSettingsPageIsOpened()
        {
            _editProfilePage.GoToEditProfilePage();
        }

        [When(@"I open edit email adress block")]
        public void WhenIOpenEditGeneralIformationBlock()
        {
            _editProfilePage.ClickEmailSectionButton();
        }

        [When(@"I input '(.*)' in Current Password field")]
        public void WhenIInputInNewFirstNameField(string password)
        {
            _editProfilePage.SetPassword(password);
        }

        [When(@"I input '(.*)' in New E-mail Address field")]
        public void WhenIInputInNewLastNameField(string newEmail)
        {
            _editProfilePage.SetEmail(newEmail);
        }

        [When(@"I save changes in edit email adress block")]
        public void WhenISaveSchanges()
        {
            _editProfilePage.ClickSaveChangesEmailButton();
            _editProfilePage.WaitForSave();
        }

        [Then(@"Email is changed to '(.*)'")]
        public void ThenPrimaryAccountHolderNameIsChangedTo(string email)
        {
            var actualEmail = _editProfilePage.GetEmail();

            Assert.AreEqual(email, actualEmail);
        }

        [When(@"I open edit phone block")]
        public void WhenIOpenEditPhoneBlock()
        {
            _editProfilePage.ClickPhoneSectionButton();
        }

        [When(@"I input '(.*)' in New Phone Number field")]
        public void WhenIInputInNewPhoneNumberField(string newPhone)
        {
            _editProfilePage.SetPhone(newPhone);
        }

        [When(@"I save changes in edit phone block")]
        public void WhenISaveChangesInEditPhoneBlock()
        {
            _editProfilePage.ClickSaveChangesPhoneButton();
            _editProfilePage.WaitForSave();
        }

        [Then(@"Phone number is changed to '(.*)'")]
        public void ThenPhoneNumberIsChangedTo(string newPhone)
        {
            var actualPhone = _editProfilePage.GetPhone();
            Assert.AreEqual(newPhone, actualPhone);
        }

        [When(@"I open edit password block")]
        public void WhenIOpenEditPasswordBlock()
        {
            _editProfilePage.ClickPasswordSectionButton();
        }

        [When(@"I input '(.*)' in Current Password field in Edit Password block")]
        public void WhenIInputInCurrentPasswordFieldInEditPasswordBlock(string newPassword)
        {
            _editProfilePage.SetCurrentPassword(newPassword);
        }


        [When(@"I input '(.*)' in New Password field and Re-type New Password field")]
        public void WhenIInputInNewPasswordField(string newPassword)
        {
            _editProfilePage.SetNewPassword(newPassword);
        }      

        [When(@"I save changes in edit password block")]
        public void WhenISaveChangesInEditPasswordBlock()
        {
            _editProfilePage.ClickSaveChangesPasswordButton();
        }

        [When(@"I log out")]
        public void WhenILogOut()
        {
            _editProfilePage.ClicklogOutButton();
        }

        [When(@"I open Sign In page")]
        public void WhenIOpenSignInPage()
        {
            _signInPage = new SignInPage(_webDriver);
            _signInPage.GoToSignInPage();
        }

        [When(@"I input new password '(.*)' in Password field")]
        public void WhenIInputNewPasswordInPasswordField(string newPassword)
        {
            _signInPage.SetPassword(newPassword);
        }

        [When(@"I click log in button")]
        public void WhenICkickLogInButton()
        {
            _signInPage.ClickLoginButton();
        }

    }
}
