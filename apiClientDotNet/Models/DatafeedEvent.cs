using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class DatafeedEvent
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("timestamp")]
        public long? Timestamp { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("initiator")]
        public Initiator Initiator { get; set; }

        [JsonProperty("diagnostic")]
        public string Diagnositc { get; set; }

        [JsonProperty("payload")]
        public EventPayload Payload { get; set; }

    }
}
