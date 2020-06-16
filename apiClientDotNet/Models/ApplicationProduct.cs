using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class ApplicationProduct
    {
        [JsonProperty("appId")]
        public string AppId;
        
        [JsonProperty("name")]
        public string Name;
        
        [JsonProperty("sku")]
        public string Sku;
        
        [JsonProperty("subscribed")]
        public bool? Subscribed;
        
        [JsonProperty("type")]
        public string Type;
    }
}