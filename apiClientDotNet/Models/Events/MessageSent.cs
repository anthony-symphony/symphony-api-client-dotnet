using Newtonsoft.Json;

namespace apiClientDotNet.Models.Events
{
    public class MessageSent
    {
        [JsonProperty("message")]
        public InboundMessage Message { get; set; }
    }
}
