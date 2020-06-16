using Newtonsoft.Json;
using System.Collections.Generic;

namespace apiClientDotNet.Models
{
    public class ApplicationEntitlement
    {
        [JsonProperty("appId")]
        public string AppId;
        
        [JsonProperty("appName")]
        public string AppName;
        
        [JsonProperty("listed")]
        public bool? Listed;
        
        [JsonProperty("install")]
        public bool? Install;
        
        [JsonProperty("products")]
        public List<ApplicationProduct> Products;
    }
}