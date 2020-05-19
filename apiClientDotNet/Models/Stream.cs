using System.Collections.Generic;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class Stream
    {
        [JsonProperty("streamId")]
        public string StreamId { get; set; }

        [JsonProperty("streamType")]
        public string StreamType { get; set; }

        [JsonProperty("roomName")]
        public string RoomName { get; set; }

        [JsonProperty("members")]
        public List<User> Members { get; set; }

        [JsonProperty("external")]
        public bool External { get; set; }

        [JsonProperty("crossPod")]
        public bool CrossPod { get; set; }

    }
}
