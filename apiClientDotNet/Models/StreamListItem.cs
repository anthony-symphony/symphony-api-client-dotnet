using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class StreamListItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("crossPod")]
        public bool CrossPod { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("streamType")]
        public TypeObject StreamType { get; set; }

        [JsonProperty("streamAttributes")]
        public StreamAttributes StreamAttributes { get; set; }

        [JsonProperty("roomAttributes")]
        public RoomName RoomAttributes { get; set; }

    }
}
