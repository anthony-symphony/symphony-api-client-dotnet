using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class UserPresence
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("userId")]
        public long? UserId { get; set; }

        [JsonProperty("timestamp")]
        public long? Timestamp { get; set; }

    }
}
