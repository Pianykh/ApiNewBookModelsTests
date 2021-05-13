using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNewBookModelsTests.ApiRequests.Models
{
    public class CreateUserApiRequest
    {
        public ClientAuthModel CreateUserViaApi(string email, string firstName, string lastName, string password, string phoneNumber)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/auth/client/signup/");
            var request = new RestRequest(Method.POST);

            var user = new Dictionary<string, string>()
            {
                {"email", email},
                {"first_name", firstName},
                {"last_name", lastName},
                {"password", password},
                {"phone_number", phoneNumber},
            };
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(user);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var createdUser = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);

            return createdUser;
        }

    }
}
