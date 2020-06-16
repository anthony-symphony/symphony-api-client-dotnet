using System.Collections.Generic;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class UserSearchResult
    {
        [JsonProperty("count")]
        public int? Count { get; set; }

        [JsonProperty("skip")]
        public int? Skip { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("filters")]
        public Dictionary<string, string> Filters { get; set; }

        [JsonProperty("users")]
        public List<UserInfo> Users { get; set; }

        [JsonProperty("limit")]
        public int? Limit { get; set; }
    }
}
