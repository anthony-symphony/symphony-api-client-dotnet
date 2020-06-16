using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class Signal
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("timestamp")]
        public long? Timestamp { get; set; }

        [JsonProperty("companyWide")]
        public bool? CompanyWide { get; set; }

        [JsonProperty("visibleOnProfile")]
        public bool? VisibleOnProfile { get; set; }
    }
}
