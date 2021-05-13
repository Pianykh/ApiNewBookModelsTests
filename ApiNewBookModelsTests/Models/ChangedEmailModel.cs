using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNewBookModelsTests.ApiRequests.Models
{
    public class ChangedEmailModel
    {
        
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}

