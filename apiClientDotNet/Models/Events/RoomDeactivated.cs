using Newtonsoft.Json;

namespace apiClientDotNet.Models.Events
{
    public class RoomDeactivated
    {
        [JsonProperty("stream")]
        public Stream Stream { get; set; }
    }
}
