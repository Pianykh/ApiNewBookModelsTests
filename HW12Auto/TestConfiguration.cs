using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace HW12
{
    public class TestConfiguration
    {
        protected IWebDriver webDriver;

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            webDriver = new ChromeDriver();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);           
        }

        [TearDown]
        public void TearDown()
        {
           webDriver.Quit();
        }
    }
}
