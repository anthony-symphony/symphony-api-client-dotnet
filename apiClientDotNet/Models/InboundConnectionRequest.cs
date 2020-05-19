using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class InboundConnectionRequest
    {
        [JsonProperty("userId")]
        public long UserId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("firstRequestedAt")]
        public long FirstRequestedAt { get; set; }

        [JsonProperty("updatedAt")]
        public long UpdatedAt { get; set; }

        [JsonProperty("requestCounter")]
        public int RequestCounter { get; set; }
    }
}
