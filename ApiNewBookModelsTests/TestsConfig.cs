﻿using ApiNewBookModelsTests.ApiRequests.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNewBookModelsTests
{
    public class TestsConfig
    {
        protected static string _uniqueNumber = DateTime.Now.ToString("yyyyMMddhhmmss");
        protected static string _validFirstName = "John";
        protected static string _validSecondName = "Tribiani";
        protected static string _validPassword = "1Qazxcdew46109(";
        protected static string _validEmail = $"qweqweqweqweqwe{_uniqueNumber}@gmail.com";
        protected static string _validNewEmail = $"rtyrtyrtyrtyrty{_uniqueNumber}@gmail.com";
        protected static string _validPhone = "1231231212";
        protected static string _validNewFirstName = "Bruce";
        protected static string _validNewSecondName = "Willis";
        protected static ClientAuthModel _user;

        [SetUp]
        public void Setup()
        {
            _user =CreateUserApiRequest.SendRequestCreateUser(_validEmail, _validFirstName, _validSecondName, _validPassword, _validPhone);
        }
    }
}