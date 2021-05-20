using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNewBookModelsTests.ApiRequests
{
    public static class SignInUserApiRequest
    {
        public static ClientAuthModel SendRequestSignInUser(string email, string password)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/auth/signin/");
            var request = new RestRequest(Method.POST);

            var user = new Dictionary<string, string>()
            {
                {"email", email},                
                {"password", password},                
            };
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(user);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var authorizedUser = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);

            return authorizedUser;
        }
    }
}
