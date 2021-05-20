using ApiNewBookModelsTests.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNewBookModelsTests.ApiRequests
{
    public static class GetAccountAvatarApiRequest
    {
        public static Avatar SendRequestGetAccountAvatar(string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/self/");
            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", token);
            var response = client.Execute(request);
            var clientAvatar = JsonConvert.DeserializeObject<Avatar>(response.Content);

            return clientAvatar;
        }
    }
}
