using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace SpecflowTestProject
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;


        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario("ui")]
        public void BeforeScenario()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            var driver = new ChromeDriver();            
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            _scenarioContext.Add(Context.WebDriver, driver);
        }

        [AfterScenario("ui")]
        public void AfterScenario()
        {
            _scenarioContext.Get<IWebDriver>(Context.WebDriver).Close();
            _scenarioContext.Get<IWebDriver>(Context.WebDriver).Quit();
        }
        [AfterStep("ui")]
        public void AfterStep()
        {
            if (_scenarioContext.TestError != null)
            {
                Screenshot screenshot = ((ITakesScreenshot)_scenarioContext.Get<IWebDriver>(Context.WebDriver)).GetScreenshot();
                screenshot.SaveAsFile(@"C:/temp/Screenshot.png", ScreenshotImageFormat.Png);
                Allure.Commons.AllureLifecycle.Instance.AddAttachment(@"C:/temp/Screenshot.png", "screen");
            }
        }
    }
}