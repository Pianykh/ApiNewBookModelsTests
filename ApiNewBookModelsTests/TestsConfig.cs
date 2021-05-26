using ApiNewBookModelsTests.ApiRequests.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNewBookModelsTests
{
    public class TestsConfig
    {
        protected static string _validFirstName = "John";
        protected static string _validSecondName = "Tribiani";
        protected static string _validPassword = "1Qazxcdew46109(";
        protected static string _validNewPassword = "1Qazxcdew46109(@";
        protected string _validEmail = $"qweqweqweqweqwe{DateTime.Now.ToString("yyyyMMddhhmmssfffffff")}@gmail.com";
        protected string _validNewEmail = $"rtyrtyrtyrtyrty{DateTime.Now.ToString("yyyyMMddhhmmssfffffff")}@gmail.com";
        protected static string _validPhone = "1231231212";
        protected static string _validNewFirstName = "Bruce";
        protected static string _validNewSecondName = "Willis";
        protected  ClientAuthModel _user;
        protected static string _validCompanyName = "Italgas";
        protected static string _validCompanySite = "http://Italgas.it";
        protected static string _validCompanyDescription = "ItalGas description";

        [SetUp]
        public void Setup()
        {
            _user = CreateUserApiRequest.SendRequestCreateUser(_validEmail, _validFirstName, _validSecondName, _validPassword, _validPhone);
        }
    }
}
