using Newtonsoft.Json;

namespace apiClientDotNet.Models.Events
{
    public class RoomCreated
    {
        [JsonProperty("stream")]
        public Stream Stream { get; set; }

        [JsonProperty("roomProperties")]
        public RoomProperties RoomProperties { get; set; }
    }
}
