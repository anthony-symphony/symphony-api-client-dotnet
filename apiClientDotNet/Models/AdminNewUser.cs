using Newtonsoft.Json;
using System.Collections.Generic;

namespace apiClientDotNet.Models
{
    public class AdminNewUser
    {
        [JsonProperty("userAttributes")]
        public AdminUserAttributes UserAttributes;
        
        [JsonProperty("roles")]
        public List<string> Roles;
        
        [JsonProperty("password")]
        public Password Password;
    }
}