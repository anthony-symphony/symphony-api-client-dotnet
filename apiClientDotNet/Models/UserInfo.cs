using System.Collections.Generic;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class UserInfo
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("workPhoneNumber")]
        public string WorkPhoneNumber { get; set; }

        [JsonProperty("mobilePhoneNumber")]
        public string MobilePhoneNumber { get; set; }

        [JsonProperty("jobFunction")]
        public string JobFunction { get; set; }

        [JsonProperty("department")]
        public string Department { get; set; }

        [JsonProperty("division")]
        public string Division { get; set; }

        [JsonProperty("avatars")]
        public List<Avatar> Avatars { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }
    }
}
