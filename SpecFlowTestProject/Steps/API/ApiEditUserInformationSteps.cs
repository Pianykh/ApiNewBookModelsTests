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

        public ApiEditUserInformationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;            
        }

        [When(@"I send POST request https://api\.newbookmodels\.com/api/v(.*)/client/change_email/ with '(.*)'")]
        public void WhenISendPOSTRequestHttpsApi_Newbookmodels_ComApiVClientChange_Email(string uniqueEmail)
        {
            var user = _scenarioContext.Get<ClientAuthModel>(Context.User);
            var newEmail = ChangeEmailApiRequest.SendRequestChangeEmail(Constants.Password, uniqueEmail, user.TokenData.Token);
        }
        
        [Then(@"Then Client email was changed to '(.*)' in NewBookModels Account")]
        public void ThenThenClientEmailWasChangedInNewBookModelsAccount(string usedUniqueEmail)
        {
            var user = _scenarioContext.Get<ClientAuthModel>(Context.User);
            var actualEmail = user.User.Email;
            Assert.AreEqual(usedUniqueEmail, actualEmail);
        }
    }
}
