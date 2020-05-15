using System.Collections.Generic;
using Newtonsoft.Json;

namespace apiClientDotNet.Models 
{
    public class AdminUserInfo
    {
        [JsonProperty("userAttributes")]
        public AdminUserAttributes UserAttributes;
        
        [JsonProperty("userSystemInfo")]
        public AdminUserSystemInfo UserSystemInfo;
        
        [JsonProperty("roles")]
        public List<string> Roles;
        
        [JsonProperty("features")]
        public List<long> Features;
        
        [JsonProperty("apps")]
        public List<long> Apps;
        
        [JsonProperty("groups")]
        public List<long> Groups;
        
        [JsonProperty("disclaimers")]
        public List<long> Disclaimers;
        
        [JsonProperty("avatar")]
        public Avatar Avatar;
    }
}