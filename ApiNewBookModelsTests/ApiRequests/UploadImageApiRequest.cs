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
            request.AddHeader("Content-Type", "image/jpeg");
            request.AddHeader("Content-Disposition", "form-data; name=\"file\"; filename=\"file.jpg\"");
            request.AddFile("file", "D:\\file.jpg");
            //request.AddParameter("file", "C:\\Users\\pyanykh\\source\\repos\\ApiNewBookModelsTests\\ApiNewBookModelsTests\\ApiRequests\\file.jpg", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var uploadImage = JsonConvert.DeserializeObject<UploadImageModel>(response.Content);            

            var client1 = new RestClient("https://api.newbookmodels.com/api/v1/client/self/");
            client.Timeout = -1;
            var request1 = new RestRequest(Method.PATCH);
            var image = new Dictionary<string, string>()
            {
                {"avatar_id", uploadImage.Image.Id},                
            };
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(image);
            request.RequestFormat = DataFormat.Json;
            var response1 = client1.Execute(request1);

            return uploadImage;
        }
        
    }
}
