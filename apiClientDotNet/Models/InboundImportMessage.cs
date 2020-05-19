using System;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class InboundImportMessage
    {
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        [JsonProperty("originatingSystemId")]
        public string OriginatingSystemId { get; set; }

        [JsonProperty("originalMessageId")]
        public string OriginalMessageId { get; set; }

        [JsonProperty("diagnostic")]
        public string Diagnostic { get; set; }
    }
}
