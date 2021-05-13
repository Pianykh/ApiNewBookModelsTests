using ApiNewBookModelsTests.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNewBookModelsTests.ApiRequests
{
    class ChangePasswordApiRequest
    {
        public static string SendRequestChangePassword(string oldPassword, string newPassword, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/password/change/");
            var request = new RestRequest(Method.POST);
            var newPasswordModel = new Dictionary<string, string>()
            {
                {"new_password", newPassword },
                {"pld_password", oldPassword },
            };
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newPasswordModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var newChangedPassword = JsonConvert.DeserializeObject<ChangedPasswordModel>(response.Content);
            return newChangedPassword.Token;
        }
    }
}
