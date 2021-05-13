using ApiNewBookModelsTests.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNewBookModelsTests.ApiRequests
{
    public static class ChangePrimaryAccountHolderNameApiRequest
    {
        public static string SendRequestChangePrimaryAccountHolderName(string firstName, string lastName, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/self/");
            var request = new RestRequest(Method.PATCH);
            var newPrimaryAccountHolderNameModel = new Dictionary<string, string>
            {
                {"first_name", firstName },
                {"last_name", lastName },
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newPrimaryAccountHolderNameModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var newGeneralInfo = JsonConvert.DeserializeObject<ChangedPrimaryAccountHolderNameModel>(response.Content);

            return newGeneralInfo.ToString();        // ????????///??/??/
        }
    }
}
