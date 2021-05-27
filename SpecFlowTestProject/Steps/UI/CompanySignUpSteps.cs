using HW12.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Steps.UI
{
    [Binding]
    public class CompanySignUpSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;
        private readonly SignUpSecondPage _signUpSecondPage;

        public CompanySignUpSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            _signUpSecondPage = new SignUpSecondPage(_webDriver);
        }

        [Then(@"Successfully logged in NewBookModels as created client")]
        public void ThenSuccessfullyLoggedInNewBookModelAsCreatedClient()
        {
            
            Assert.IsTrue(_signUpSecondPage.IsSignUpSecondIsOpen());
        }
    }
}