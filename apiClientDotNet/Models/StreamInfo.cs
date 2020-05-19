using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class StreamInfo
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("crossPod")]
        public bool CrossPod { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }
        
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("lastMessageDate")]
        public long LastMessageDate { get; set; }

        [JsonProperty("streamType")]
        public StreamType StreamType { get; set; }

        [JsonProperty("streamAttributes")]
        public StreamAttributes StreamAttributes { get; set; }

        [JsonProperty("roomAttributes")]
        public RoomName RoomAttributes { get; set; }
    }
}
