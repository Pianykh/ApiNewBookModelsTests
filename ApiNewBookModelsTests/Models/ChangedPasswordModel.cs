using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNewBookModelsTests.Models
{
    class ChangedPasswordModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
