using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNewBookModelsTests.Models
{
    public class ClientProfileModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("facebook_followers")]
        public object FacebookFollowers { get; set; }

        [JsonProperty("instagram_followers")]
        public object InstagramFollowers { get; set; }

        [JsonProperty("has_invite")]
        public bool HasInvite { get; set; }

        [JsonProperty("company_website")]
        public string CompanyWebsite { get; set; }

        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("company_description")]
        public string CompanyDescription { get; set; }

        [JsonProperty("referral")]
        public object Referral { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("is_sms_enabled")]
        public bool IsSmsEnabled { get; set; }

        [JsonProperty("location_latitude")]
        public object LocationLatitude { get; set; }

        [JsonProperty("location_longitude")]
        public object LocationLongitude { get; set; }

        [JsonProperty("location_name")]
        public object LocationName { get; set; }

        [JsonProperty("location_city_name")]
        public object LocationCityName { get; set; }

        [JsonProperty("location_admin1_code")]
        public object LocationAdmin1Code { get; set; }

        [JsonProperty("location_timezone")]
        public object LocationTimezone { get; set; }

        [JsonProperty("company_address")]
        public object CompanyAddress { get; set; }

        [JsonProperty("industry")]
        public object Industry { get; set; }

        [JsonProperty("twitter_followers")]
        public object TwitterFollowers { get; set; }

        [JsonProperty("youtube_followers")]
        public object YoutubeFollowers { get; set; }
    }
    public class Avatar
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("large")]
        public Large Large { get; set; }

        [JsonProperty("small")]
        public Small Small { get; set; }

        [JsonProperty("medium")]
        public Medium Medium { get; set; }

        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        [JsonProperty("original")]
        public Original Original { get; set; }
    }

    public class Root
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("payment_method_connected")]
        public bool PaymentMethodConnected { get; set; }

        [JsonProperty("is_staff")]
        public bool IsStaff { get; set; }

        [JsonProperty("email_verified")]
        public bool EmailVerified { get; set; }

        [JsonProperty("client_profile")]
        public ClientProfile ClientProfile { get; set; }

        [JsonProperty("has_password")]
        public bool HasPassword { get; set; }

        [JsonProperty("avatar")]
        public Avatar Avatar { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }
    }

}
