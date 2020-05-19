using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class RoomName
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
