using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class SignalSubscriber
    {
        [JsonProperty("pushed")]
        public bool? Pushed { get; set; }

        [JsonProperty("owner")]
        public bool? Owner { get; set; }

        [JsonProperty("subscriberName")]
        public string SubscriberName { get; set; }

        [JsonProperty("userId")]
        public long? UserId { get; set; }

        [JsonProperty("timestamp")]
        public long? Timestamp { get; set; }
    }
}
