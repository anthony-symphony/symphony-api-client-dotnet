using System.Collections.Generic;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class RoomSearchResult
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("skip")]
        public int Skip { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("query")]
        public RoomSearchQuery Query { get; set; }

        [JsonProperty("rooms")]
        public List<RoomInfo> Rooms { get; set; }

    }
}
