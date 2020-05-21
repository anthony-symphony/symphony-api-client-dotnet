using Newtonsoft.Json;

namespace apiClientDotNet.Models.Events
{
    public class RoomUpdated
    {
        [JsonProperty("stream")]
        public Stream Stream { get; set; }

        [JsonProperty("newRoomProperties")]
        public RoomProperties NewRoomProperties { get; set; }
    }
}
