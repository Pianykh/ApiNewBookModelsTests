﻿using System.Linq;
using ApiNewBookModelsTests;
using HW12.POM;

using NUnit.Framework;
using OpenQA.Selenium;

using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowTestProject.Steps.UI
{
    [Binding]
    public class SignInSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly SignInPage _singInPage;

        public SignInSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            _singInPage = new SignInPage(webDriver);
        }

        [Given(@"Sign in page is opened")]
        public void GivenSignInPageIsOpened()
        {
            _singInPage.GoToSignInPage();
        }

        [When(@"I input email of created client in email field")]
        public void WhenIInputEmailOfCreatedClientInEmailField()
        {
            var user = _scenarioContext.Get<ClientAuthModel>(Context.User);
            _singInPage.SetEmail(user.User.Email);
        }

        [When(@"I input password of created client in password field")]
        public void WhenIInputPasswordOfCreatedClientInEmailField()
        {
            _singInPage.SetPassword(Constants.Password);
        }

        [When(@"I click Log in button")]
        public void WhenIClickLogInButton()
        {
            _singInPage.ClickLoginButton();
        }

        [When(@"I login with data")]
        public void ILoginWithData(Table table)
        {
            var loginModels = table.CreateSet<LoginModel>().ToList();

            _singInPage.SetEmail(loginModels[0].Email);
            _singInPage.SetPassword(loginModels[0].Password);
            _singInPage.ClickLoginButton();
        }

        [Then(@"Unsuccessfuly login in NewBookModels with invalid data")]
        public void ThenSuccessfullyLoggedInNewBookModelAsCreatedClient()
        {
            Assert.IsTrue(_singInPage.IsSignInPageIsOpen());
        }

        [Then(@"(.*) invalid email message is displayed")]
        public void ThenInvalidEmailMessageIsDisplayed(string invalidEmailmessage)
        {
            Assert.AreEqual(invalidEmailmessage, _singInPage.GetInvalidEmailMessage());
        }

        [Then(@"(.*) invalid password message is displayed")]
        public void ThenInvalidPasswordMessageIsDisplayed(string invalidPasswordMessage)
        {
            Assert.AreEqual(invalidPasswordMessage, _singInPage.GetInvalidPasswordMessage());
        }
        public class LoginModel
        {
            public string Email{ get; set; }
            public string Password { get; set; }
        }    
    }
}