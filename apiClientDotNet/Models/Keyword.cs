using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class Keyword
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
