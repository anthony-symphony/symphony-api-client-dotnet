using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class SuppressionResult
    {
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        [JsonProperty("suppressed")]
        public bool? Suppressed { get; set; }

        [JsonProperty("suppressionDate")]
        public long? SuppressionDate { get; set; }
    }
}
