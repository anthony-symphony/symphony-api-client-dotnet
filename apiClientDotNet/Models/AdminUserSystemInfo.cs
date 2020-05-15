using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class AdminUserSystemInfo
    {
        [JsonProperty("id")]
        public long Id;
        
        [JsonProperty("status")]
        public string Status;
        
        [JsonProperty("createdBy")]
        public string CreatedBy;
        
        [JsonProperty("createdDate")]
        public long CreatedDate;
        
        [JsonProperty("lastUpdatedDate")]
        public long LastUpdatedDate;
        
        [JsonProperty("lastLoginDate")]
        public long LastLoginDate;
    }
}