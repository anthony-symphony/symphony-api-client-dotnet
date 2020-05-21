using Newtonsoft.Json;

namespace apiClientDotNet.Models.Events
{
    public class MessageSuppressed
    {
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        [JsonProperty("stream")]
        public Stream Stream { get; set; }
    }
}
