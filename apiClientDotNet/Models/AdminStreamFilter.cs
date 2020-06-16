using System.Collections.Generic;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class AdminStreamFilter
    {
        [JsonProperty("streamTypes")]
        public List<string> StreamTypes { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("privacy")]
        public string Privacy { get; set; }

        [JsonProperty("startDate")]
        public long? StartDate { get; set; }

        [JsonProperty("endDate")]
        public long? EndDate { get; set; }
    }
}
