using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class TypeObject
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
