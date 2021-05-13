using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNewBookModelsTests.Models
{
    class ChangedPhoneModel
    {
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
