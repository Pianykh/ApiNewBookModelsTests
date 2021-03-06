using ApiNewBookModelsTests;
using ApiNewBookModelsTests.ApiRequests;
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

        [When(@"I send POST request https://api\.newbookmodels\.com/api/v1/client/change_phone/ with '(.*)'")]
        public void WhenISendPOSTRequestHttpsApi_Newbookmodels_ComApiVClientChange_PhoneWith(string newPhone)
        {
            var user = _scenarioContext.Get<ClientAuthModel>(Context.User);
            var changedPhone = ChangePhoneApiRequest.SendRequestChangePhone(Constants.Password, newPhone, user.TokenData.Token);
            _scenarioContext.Add(Context.NewPhone, changedPhone);
        }

        [Then(@"Then Client phone was changed to '(.*)' in NewBookModels Account")]
        public void ThenThenClientPhoneWasChangedToInNewBookModelsAccount(string newPhone)
        {
            var actualPhone = _scenarioContext.Get<string>(Context.NewPhone);
            Assert.AreEqual(newPhone, actualPhone);
        }

        [When(@"I send POST request https://api\.newbookmodels\.com/api/v1/password/change/ with '(.*)'")]
        public void WhenISendPOSTRequestHttpsApi_Newbookmodels_ComApiVPasswordChangeWith(string newPassword)
        {
            var user = _scenarioContext.Get<ClientAuthModel>(Context.User);
            var changedToken = ChangePhoneApiRequest.SendRequestChangePhone(Constants.Password, newPassword, user.TokenData.Token);
            _scenarioContext.Add(Context.NewToken, changedToken);
        }

        [Then(@"Then Client password was changed in NewBookModels Account")]
        public void ThenThenClientPasswordWasChangedToInNewBookModelsAccount()
        {
            var actualToken = _scenarioContext.Get<string>(Context.NewToken);
            Assert.AreNotEqual(_scenarioContext.Get<ClientAuthModel>(Context.User).TokenData.Token, actualToken);
        }

        [When(@"I send PATCH request https://api\.newbookmodels\.com/api/v1/client/self/ with '(.*)' and '(.*)'")]
        public void WhenISendPATCHRequestHttpsApi_Newbookmodels_ComApiVClientSelfWithAnd(string newFirstName, string newLastName)
        {
            var user = _scenarioContext.Get<ClientAuthModel>(Context.User);
            var changedPrimaryAccountHolderNameModel = ChangePrimaryAccountHolderNameApiRequest.SendRequestChangePrimaryAccountHolderName(newFirstName, newLastName, user.TokenData.Token);
            var newPrimaryAccountHolderName = changedPrimaryAccountHolderNameModel.FirstName + " " + changedPrimaryAccountHolderNameModel.LastName;
            _scenarioContext.Add(Context.NewPrimaryAccountHolderName, newPrimaryAccountHolderName);
        }

        [Then(@"Then Client Primary Account Holder Name was changed to '(.*)' in NewBookModels Account")]
        public void ThenThenClientPrimaryAccountHolderNameWasChangedInNewBookModelsAccount(string newName)
        {
            var actualnewPrimaryAccountHolderName = _scenarioContext.Get<string>(Context.NewPrimaryAccountHolderName);
            Assert.AreEqual(newName, actualnewPrimaryAccountHolderName);
        }

    }
}
