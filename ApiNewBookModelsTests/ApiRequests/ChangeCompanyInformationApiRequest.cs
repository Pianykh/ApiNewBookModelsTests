using ApiNewBookModelsTests.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNewBookModelsTests.ApiRequests
{
    public static class ChangeCompanyInformationApiRequest
    {
        public static ChangedCompanyInformationModel SendRequestChangeCompanyInformation(string companyName, string companySite, string companyDescription, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/profile/");
            var request = new RestRequest(Method.PATCH);
            var newCompnyInformationModel = new Dictionary<string, string>
            {
                { "company_description", companyDescription },
                { "company_name", companyName },
                { "company_website", companySite },
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newCompnyInformationModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var newCompanyInformation = JsonConvert.DeserializeObject<ChangedCompanyInformationModel>(response.Content);

            return newCompanyInformation;
        }
    }
}
