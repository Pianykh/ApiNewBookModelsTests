using ApiNewBookModelsTests.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNewBookModelsTests.ApiRequests
{
    class ChangeIndustryApiRequest
    {
        public static string SendRequestChangeIndustry(string indusrty, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/profile/");
            var request = new RestRequest(Method.PATCH);
            var newIndustryModel = new Dictionary<string, string>
            {
                { "industry", indusrty },                
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newIndustryModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var newGeneralInfo = JsonConvert.DeserializeObject<ChangedGeneralInformationModel>(response.Content);

            return newGeneralInfo.Industry;
        }
    }
}
