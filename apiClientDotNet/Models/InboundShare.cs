using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class InboundShare
    {
        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("v2messageType")]
        public String V2messageType { get; set; }

        [JsonProperty("streamId")]
        public String StreamId { get; set; }

        [JsonProperty("message")]
        public String Message { get; set; }

        [JsonProperty("userId")]
        public long UserId { get; set; }
    }
}
