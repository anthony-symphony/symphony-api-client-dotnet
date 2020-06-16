using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class OutboundImportMessage
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("intendedMessageTimestamp")]
        public long? IntendedMessageTimestamp { get; set; }

        [JsonProperty("intendedMessageFromUserId")]
        public long? IntendedMessageFromUserId { get; set; }

        [JsonProperty("originatingSystemId")]
        public string OriginatingSystemId { get; set; }

        [JsonProperty("originalMessageId")]
        public string OriginalMessageId { get; set; }

        [JsonProperty("streamId")]
        public string StreamId { get; set; }
    }
}
