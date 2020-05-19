using System.Collections.Generic;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class RoomSearchQuery
    {
        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("labels")]
        public List<string> Labels { get; set; }

        [JsonProperty("active")]
        public bool? Active { get; set; }

        [JsonProperty("private")]
        public bool? IsPrivate { get; set; }

        [JsonProperty("creator")]
        public NumericId Creator { get; set; }

        [JsonProperty("owner")]
        public NumericId Owner { get; set; }

        [JsonProperty("member")]
        public NumericId Member { get; set; }
    }
}
