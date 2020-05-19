using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class StringId
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
