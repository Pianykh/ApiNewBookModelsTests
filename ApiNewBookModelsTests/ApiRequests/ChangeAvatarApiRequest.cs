using ApiNewBookModelsTests.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNewBookModelsTests.ApiRequests
{
    public static class ChangeAvatarApiRequest
    {
        public static Avatar SendRequestChangeAvatar(string token, string imageId)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/self/");
            client.Timeout = -1;
            var request = new RestRequest(Method.PATCH);
            var image = new Dictionary<string, string>()
            {
                {"avatar_id", imageId},
            };
            request.AddHeader("authorization", token);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(image);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            var clientProfile = JsonConvert.DeserializeObject<Avatar>(response.Content);

            return clientProfile;
        }
    }
}
