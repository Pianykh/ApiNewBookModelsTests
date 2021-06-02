using HW12.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace HW12
{
    public class SignInTests : TestConfiguration
    {       
                
        [Test]
        public void Login_ShouldLoginUser()
        {
            var signInPage = new SignInPage(webDriver);
            signInPage.GoToSignInPage()
                .SetEmail("tribianidylan05052021130904@gmail.com")
                .SetPassword("1Asdfghjkl(((@@@46109")
                .ClickLoginButton();
            var actualTitle = webDriver.FindElement(By.CssSelector("[class^=Section__title]"));

            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.UrlToBe("https://newbookmodels.com/explore"));
            var actualUrl = webDriver.Url;

            Assert.AreEqual("https://newbookmodels.com/explore", actualUrl);
        }

        [Test]
        public void Login_ShouldDisplayErrorMeggaseIfUserIsBlocked()
        {
            var signInPage = new SignInPage(webDriver);
            signInPage.GoToSignInPage()
                .SetEmail("pyanykh@ukr.net")
                .SetPassword("1Qazxcdew(((@@@46109")
                .ClickLoginButton();
            var actualErrorMessage = signInPage.GetBlockedUserErrorMessage();
            
            Assert.AreEqual("User account is blocked.", actualErrorMessage);
        }
    }
}