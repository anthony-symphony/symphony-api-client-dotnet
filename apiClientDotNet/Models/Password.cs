using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class Password
    {
        [JsonProperty("hhSalt")]
        public string HhSalt;
        
        [JsonProperty("hhPassword")]
        public string HhPassword;
        
        [JsonProperty("khSalt")]
        public string KhSalt;
        
        [JsonProperty("khPassword")]
        public string KhPassword;
    }
}