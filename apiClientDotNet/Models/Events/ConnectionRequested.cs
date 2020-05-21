using Newtonsoft.Json;

namespace apiClientDotNet.Models.Events
{
    public class ConnectionRequested
    {
        [JsonProperty("toUser")]
        public User ToUser { get; set; }
    }
}
