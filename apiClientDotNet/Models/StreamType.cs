using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class StreamType
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
