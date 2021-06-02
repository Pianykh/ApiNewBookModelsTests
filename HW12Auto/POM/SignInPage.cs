using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW12.POM
{
    public class SignInPage
    {
        private readonly IWebDriver _webDriver;

        private readonly static By _emailField = By.CssSelector("input[type=email]");
        private readonly static By _passwordField = By.CssSelector("input[type=password]");
        private readonly static By _loginButton = By.CssSelector("[class^=SignInForm__submitButton]");
        private readonly static By _blockedUserMessage = By.CssSelector("[class^=FormErrorText__error]>div");
        private static readonly By _invalidMessages = By.CssSelector("[class^=FormErrorText]");

        public SignInPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public SignInPage GoToSignInPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
            return this;
        }

        public SignInPage SetEmail(string email)
        {
            _webDriver.FindElement(_emailField).SendKeys(email);
            return this;
        }

        public SignInPage SetPassword(string password)
        {
            _webDriver.FindElement(_passwordField).SendKeys(password);
            return this;
        }
        public void ClickLoginButton()
        {
            _webDriver.FindElement(_loginButton).Click();            
        }
        public string GetBlockedUserErrorMessage()
        {
            return _webDriver.FindElement(_blockedUserMessage).Text.Trim();
        }

        public string GetInvalidEmailMessage()
        {
            return _webDriver.FindElements(_invalidMessages)[0].Text;
        }

        public string GetInvalidPasswordMessage()
        {
            return _webDriver.FindElements(_invalidMessages)[1].Text;
        }

        public bool IsSignInPageIsOpen()
        {
            if (_webDriver.Url == "https://newbookmodels.com/auth/signin")
                return true;
            return false;
        }
    }


}
