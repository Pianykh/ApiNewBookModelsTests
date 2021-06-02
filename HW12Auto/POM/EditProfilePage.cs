using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HW12.POM
{
    public class EditProfilePage
    {
        private readonly IWebDriver _webDriver;
        

        private readonly By _editGeneralSectionButton = By.CssSelector("nb-account-info-general-information .edit-switcher__icon_type_edit");
        private readonly By _editEmailSectionButton = By.CssSelector("nb-account-info-email-address .edit-switcher__icon_type_edit");
        private readonly By _editPasswordSectionButton = By.CssSelector("nb-account-info-password .edit-switcher__icon_type_edit");
        private readonly By _editPhoneSectionButton = By.CssSelector("nb-account-info-phone .edit-switcher__icon_type_edit");
        private readonly By _logOutButton = By.CssSelector("[type^=logout]");
        private readonly By _saveChangesGeneralButton = By.CssSelector("nb-account-info-general-information .button");
        private readonly By _saveChangesEmailButton = By.CssSelector("nb-account-info-email-address .button");
        private readonly By _saveChangesPasswordButton = By.CssSelector("nb-account-info-password .button");
        private readonly By _saveChangesPhoneButton = By.CssSelector("nb-account-info-phone .button");


        private readonly By _inputFirstNameField = By.CssSelector("input[placeholder^=\"Enter First Name\"]");
        private readonly By _inputLastNameField = By.CssSelector("input[placeholder^=\"Enter Last Name\"]");
        private readonly By _inputLocationField = By.CssSelector("input[placeholder^=\"Enter Company Location\"]");
        private readonly By _inputIndustryField = By.CssSelector("input[placeholder^=\"Enter Industry\"]");
        private readonly By _inputPasswordField = By.CssSelector("input[placeholder^=\"Enter Password\"]");
        private readonly By _inputPhoneField = By.CssSelector("input[placeholder ^=\"555.222.5555\"]");
        private readonly By _inputEmailField = By.CssSelector("input[placeholder^=\"Enter E-mail\"]");
        private readonly By _inputCurrentPasswordField = By.CssSelector("input[placeholder^=\"Enter Current Password\"]");
        private readonly By _inputNewPasswordField = By.CssSelector("input[placeholder^=\"Enter New Password\"]");
        private readonly By _inputNewPasswordConfirmField = By.CssSelector("input[placeholder^=\"Enter New Password\"]");
        private readonly By _inputCardHolderFullNameField = By.CssSelector("input[placeholder^=\"Full name\"]");
        private readonly By _inputCardNumberField = By.CssSelector("[class^=CardNumberField-input-wrapper]");
        private readonly By _inputCardCvvField = By.CssSelector("input[placeholder^=\"CVC\"]");
        private readonly By _inputCardDateField = By.CssSelector("input[placeholder^=\"MM / YY\"]");

        private readonly By _greyElements = By.CssSelector("[class=paragraph_type_gray]");
        private readonly By _actualEmail = By.CssSelector(".paragraph_type_gray div div span");
        private readonly By _phone = By.CssSelector(".paragraph_type_gray span");

        public EditProfilePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        public EditProfilePage GoToEditProfilePage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/account-info/edit");
            return this;
        }

        public EditProfilePage ClickGeneralSectionButton()
        {
            _webDriver.FindElement(_editGeneralSectionButton).Click();
            return this;
        }

        public EditProfilePage ClickEmailSectionButton()
        {
            _webDriver.FindElement(_editEmailSectionButton).Click();
            return this;
        }

        public EditProfilePage ClickPasswordSectionButton()
        {
            _webDriver.FindElement(_editPasswordSectionButton).Click();
            return this;
        }

        public EditProfilePage ClickPhoneSectionButton()
        {
            _webDriver.FindElement(_editPhoneSectionButton).Click();
            return this;
        }

        public void ClicklogOutButton() => _webDriver.FindElement(_logOutButton).Click();

        public void ClickSaveChangesGeneralButton() => _webDriver.FindElement(_saveChangesGeneralButton).Click();

        public void ClickSaveChangesEmailButton() => _webDriver.FindElement(_saveChangesEmailButton).Click();

        public void ClickSaveChangesPasswordButton() => _webDriver.FindElement(_saveChangesPasswordButton).Click();

        public void ClickSaveChangesPhoneButton() => _webDriver.FindElement(_saveChangesPhoneButton).Click();

        public EditProfilePage SetFirstName(string firstName)
        {
            _webDriver.FindElement(_inputFirstNameField).Clear();
            _webDriver.FindElement(_inputFirstNameField).SendKeys(firstName);
            return this;
        }

        public EditProfilePage SetLastNameField(string lastName)
        {
            _webDriver.FindElement(_inputLastNameField).Clear();
            _webDriver.FindElement(_inputLastNameField).SendKeys(lastName);
            return this;
        }
        public EditProfilePage SetLocation(string location)
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            _webDriver.FindElement(_inputLocationField).Clear();
            _webDriver.FindElement(_inputLocationField).SendKeys(location);
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[class=pac-item-query]")));
            _webDriver.FindElement(By.CssSelector("[class=pac-item-query]")).Click();
            return this;
        }
        public EditProfilePage SetIndustry(string industry)
        {
            _webDriver.FindElement(_inputIndustryField).Clear();
            _webDriver.FindElement(_inputIndustryField).SendKeys(industry);
            return this;
        }
        public EditProfilePage SetPassword(string password)
        {
            _webDriver.FindElement(_inputPasswordField).Clear();
            _webDriver.FindElement(_inputPasswordField).SendKeys(password);
            return this;
        }
        public EditProfilePage SetPhone(string phone)
        {
            _webDriver.FindElement(_inputPhoneField).Clear();
            _webDriver.FindElement(_inputPhoneField).SendKeys(phone);
            return this;
        }
        public EditProfilePage SetEmail(string email)
        {
            _webDriver.FindElement(_inputEmailField).Clear();
            _webDriver.FindElement(_inputEmailField).SendKeys(email);
            return this;
        }
        public EditProfilePage SetCurrentPassword(string password)
        {
            _webDriver.FindElement(_inputCurrentPasswordField).Clear();
            _webDriver.FindElement(_inputCurrentPasswordField).SendKeys(password);
            return this;
        }
        public EditProfilePage SetNewPassword(string password)
        {
            _webDriver.FindElements(_inputNewPasswordField)[0].Clear();
            _webDriver.FindElements(_inputNewPasswordField)[0].SendKeys(password);
            _webDriver.FindElements(_inputNewPasswordField)[1].Clear();
            _webDriver.FindElements(_inputNewPasswordField)[1].SendKeys(password);
            return this;
        }

        public EditProfilePage WaitForSave()
        {
            Thread.Sleep(2000);
            return this;
        }

        public string GetFirstAndLastName()
        {
            return _webDriver.FindElements(_greyElements)[1].Text.Trim();
        }

        public string GetLocation()
        {
            return _webDriver.FindElements(_greyElements)[2].Text.Trim();
        }

        public string GetIndustry()
        {
            return _webDriver.FindElements(_greyElements)[3].Text.Trim();
        }

        public string GetEmail()
        {
            return _webDriver.FindElement(_actualEmail).Text.Trim();
        }

        public string GetPhone()
        {
            return _webDriver.FindElements(_phone)[2].Text.Trim().Replace(".", "");
        }

    }
}
