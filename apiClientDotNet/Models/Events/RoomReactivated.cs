using Newtonsoft.Json;

namespace apiClientDotNet.Models.Events
{
    public class RoomReactivated
    {
        [JsonProperty("stream")]
        public Stream Stream { get; set; }
    }
}
