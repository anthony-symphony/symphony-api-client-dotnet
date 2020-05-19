using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class MessageStatus
    {
        [JsonProperty("read")]
        public List<MessageStatusUser> Read { get; set; }

        [JsonProperty("delivered")]
        public List<MessageStatusUser> Delivered { get; set; }

        [JsonProperty("sent")]
        public List<MessageStatusUser> Sent { get; set; }
    }
}
