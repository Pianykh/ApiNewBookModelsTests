using ApiNewBookModelsTests;
using ApiNewBookModelsTests.ApiRequests.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Steps.API
{
    [Binding]
    public class AuthSingInSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;
        private readonly string _email = $"asda2sd2asd{DateTime.Now:ddyyyymmHHmmssffff}@asdasd.ert";
        private readonly string _firstName = "Bruce";
        private readonly string _lastName = "Willis";
        private readonly string _phone = "3453453454";

        public AuthSingInSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
        }

        [Given(@"Client is created")]
        public void GivenClientIsCreated()
        {
            var createUser = CreateUserApiRequest.SendRequestCreateUser(_email, _firstName, _lastName, Constants.Password, _phone);
            _scenarioContext.Add(Context.User, createUser);            
        }

        [Given(@"Client is authorized")]
        public void GivenClientIsAuthorized()
        {
           _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
           IJavaScriptExecutor js = (IJavaScriptExecutor)_webDriver;           
           js.ExecuteScript($"localStorage.setItem('access_token','{_scenarioContext.Get<ClientAuthModel>(Context.User).TokenData.Token}')");
        }
    }
}