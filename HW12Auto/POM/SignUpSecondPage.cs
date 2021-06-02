using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW12.POM
{
    public class SignUpSecondPage
    {
        private readonly IWebDriver _webDriver;

        private readonly By _inputCompanyName = By.CssSelector("[name=company_name]");
        private readonly By _inputCompanySite = By.CssSelector("[name=company_website]");
        private readonly By _inputCompanyLocation = By.CssSelector("[name=location]");
        private readonly By _locationListButton = By.CssSelector("div[class ='pac-item']");
        private readonly By _industryOpenListButton = By.CssSelector("[class^=Select__container]");
        private readonly By _industryChooseButton = By.CssSelector("[class^=Select__option]");
        private readonly By _signUpButton = By.CssSelector("[class^=SignupCompanyForm__submitButton]");

        public SignUpSecondPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public SignUpSecondPage GoToSignUpPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join/company");
            return this;
        }

        public SignUpSecondPage SetCompanyName(string companyName)
        {
            _webDriver.FindElement(_inputCompanyName).SendKeys(companyName);
            return this;
        }

        public SignUpSecondPage SetCompanySite(string companySite)
        {
            _webDriver.FindElement(_inputCompanySite).SendKeys(companySite);
            return this;
        }

        public SignUpSecondPage SetLocation(string companyLocation)
        {
            _webDriver.FindElement(_inputCompanyLocation).SendKeys(companyLocation);
            _webDriver.FindElement(_locationListButton).Click();
            return this;
        }

        public SignUpSecondPage SetIndustry()
        {
            _webDriver.FindElement(_industryOpenListButton).Click();
            _webDriver.FindElement(_industryChooseButton).Click();
            return this;
        }
        public bool IsPageTitleVisible()
        {
            return true;
        }

        public void ClickSignUpButton()
        {
            _webDriver.FindElement(_signUpButton).Click();
        }
        public bool IsSignUpSecondIsOpen()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.UrlToBe("https://newbookmodels.com/join/company?goBackUrl=%2Fexplore"));
            if (_webDriver.Url == "https://newbookmodels.com/join/company?goBackUrl=%2Fexplore")
                return true;
            return false;
        }
    }
}
