using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class UserKey
    {
        [JsonProperty("key")]
        public string Key;
        
        [JsonProperty("expirationDate")]
        public long? ExpirationDate;
        
        [JsonProperty("action")]
        public string Action;
    }
}