using ApiNewBookModelsTests;
using ApiNewBookModelsTests.ApiRequests.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowTestProject;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowTestProject.Steps.API
{
    [Binding]
    public class ApiEditUserInformationSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly string _email = $"asda2sd2asd{DateTime.Now:ddyyyymmHHmmssffff}@asdasd.ert";
        private readonly string _firstName = "Bruce";
        private readonly string _lastName = "Willis";
        private readonly string _phone = "3453453454";

        public ApiEditUserInformationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;            
        }

        [Given(@"New Client is created")]
        public void GivenNewClientIsCreated()
        {
            var createUser = CreateUserApiRequest.SendRequestCreateUser(_email, _firstName, _lastName, Constants.Password, _phone);
            _scenarioContext.Add(Context.User, createUser);
        }


        [When(@"I send POST request https://api\.newbookmodels\.com/api/v1/client/change_email/ with '(.*)'")]
        public void WhenISendPOSTRequestHttpsApi_Newbookmodels_ComApiVClientChange_Email(string uniqueEmail)
        {
            var user = _scenarioContext.Get<ClientAuthModel>(Context.User);
            var newEmail = ChangeEmailApiRequest.SendRequestChangeEmail(Constants.Password, uniqueEmail, user.TokenData.Token);
            _scenarioContext.Add(Context.NewEmail, newEmail);    
        }
        
        [Then(@"Then Client email was changed to '(.*)' in NewBookModels Account")]
        public void ThenThenClientEmailWasChangedInNewBookModelsAccount(string usedUniqueEmail)
        {
            var actualEmail = _scenarioContext.Get<string>(Context.NewEmail);
            Assert.AreEqual(usedUniqueEmail, actualEmail);
        }
    }
}
