using ApiNewBookModelsTests.ApiRequests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNewBookModelsTests
{
    public class ChangePhoneTests : TestsConfig
    {
        [Test]
        public void ChangePhone_ShouldChangePhone()
        {
            var expectedPhone = "3213213232";
            var newPhone = ChangePhoneApiRequest.SendRequestChangePhone(_validPassword, expectedPhone, _user.TokenData.Token);
            Assert.AreEqual(expectedPhone, newPhone);
        }
    }
}
