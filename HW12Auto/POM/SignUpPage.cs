using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW12.POM
{
    public class SignUpPage
    {
        private readonly IWebDriver _webDriver;

        private readonly static By _firstNameField = By.CssSelector("[name^=first_name]");
        private readonly static By _lastNameField = By.CssSelector("[name^=last_name]");
        private readonly static By _emailField = By.CssSelector("[name^=email]");
        private readonly static By _passwordField = By.CssSelector("[name=password]");
        private readonly static By _passwordConfirm = By.CssSelector("[name^=password_confirm]");
        private readonly static By _phoneNumberField = By.CssSelector("[name=phone_number]");
        private readonly static By _nextButton = By.CssSelector("[class^=SignupForm__submitButton]");

        public SignUpPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public SignUpPage GoToSignUpPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join");
            return this;
        }

        public SignUpPage SetFirstName(string firstName)
        {
            _webDriver.FindElement(_firstNameField).SendKeys(firstName);
            return this;
        }

        public SignUpPage SetLastName(string secondName)
        {
            _webDriver.FindElement(_lastNameField).SendKeys(secondName);
            return this;
        }

        public SignUpPage SetEmail(string email)
        {
            _webDriver.FindElement(_emailField).SendKeys(email);
            return this;
        }

        public SignUpPage SetPassword(string password)
        {
            _webDriver.FindElement(_passwordField).SendKeys(password);
            return this;
        }

        public SignUpPage SetConfirmPassword(string password)
        {
            _webDriver.FindElement(_passwordConfirm).SendKeys(password);
            return this;
        }

        public SignUpPage SetPhoneNumber(string phone)
        {
            _webDriver.FindElement(_phoneNumberField).SendKeys(phone);
            return this;
        }
        public void ClickNextButton() =>
            _webDriver.FindElement(_nextButton).Click();
    }
}
