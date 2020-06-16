using System.Collections.Generic;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class InboundMessage
    {
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        [JsonProperty("timestamp")]
        public long? Timestamp { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("attachments")]
        public List<Attachment> Attachments { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("stream")]
        public Stream Stream { get; set; }

        [JsonProperty("externalRecipients")]
        public bool? ExternalRecipients { get; set; }

        [JsonProperty("diagnostic")]
        public string Diagnostic { get; set; }

        [JsonProperty("userAgent")]
        public string UserAgent { get; set; }

        [JsonProperty("originalFormat")]
        public string OriginalFormat { get; set; }

        [JsonProperty("messageText")]
        public string MessageText { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
