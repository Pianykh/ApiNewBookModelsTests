using ApiNewBookModelsTests.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNewBookModelsTests.ApiRequests
{
    public static class UploadImageApiRequest
    {
        public static UploadImageModel SendRequestUploadImage(string token)
        {            
            var client = new RestClient("https://api.newbookmodels.com/api/images/upload/");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AlwaysMultipartFormData = true;
            request.AddHeader("authorization", token);
            request.AddHeader("Content-Disposition", "form-data; name=\"file\"; filename=\"file.jpg\"");
            request.AddFile("file", "D:\\file.jpg", "image/jpeg");
            
            var response = client.Execute(request);
            var uploadImage = JsonConvert.DeserializeObject<UploadImageModel>(response.Content);           

            return uploadImage;            
        }
        
    }
}
