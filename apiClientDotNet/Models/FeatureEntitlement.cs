using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class FeatureEntitlement
    {
        [JsonProperty("entitlment")]
        public string Entitlment;
        
        [JsonProperty("enabled")]
        public bool? Enabled;
    }
}