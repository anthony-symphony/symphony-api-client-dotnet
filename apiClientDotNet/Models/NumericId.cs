using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class NumericId
    {
    
        [JsonProperty("id")]
        public long? Id { get; set; }
    }
}
