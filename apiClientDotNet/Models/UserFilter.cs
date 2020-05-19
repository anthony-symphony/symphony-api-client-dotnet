using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class UserFilter
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

    }
}
