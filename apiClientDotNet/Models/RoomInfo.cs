using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class RoomInfo
    {
        [JsonProperty("roomAttributes")]
        public RoomAttributes RoomAttributes { get; set; }

        [JsonProperty("roomSystemInfo")]
        public RoomSystemInfo RoomSystemInfo { get; set; }
    }
}
