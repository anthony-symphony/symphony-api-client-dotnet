using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace apiClientDotNet.Models
{
    public class OutboundMessage
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("attachments")]
        public List<FileStream> Attachments { get; set; }

    }
}
