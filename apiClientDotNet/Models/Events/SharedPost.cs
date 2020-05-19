using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models.Events
{
    public class SharedPost
    {
        [JsonProperty("message")]
        public InboundMessage message { get; set; }

        [JsonProperty("sharedMessage")]
        public InboundMessage sharedMessage { get; set; }
    }
}
