using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class StatusObject
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
