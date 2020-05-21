using Newtonsoft.Json;

namespace apiClientDotNet.Models.Events
{
    public class ConnectionAccepted
    {
        [JsonProperty("fromUser")]
        public User FromUser { get; set; }
    }
}
