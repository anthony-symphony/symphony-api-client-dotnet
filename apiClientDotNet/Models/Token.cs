using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class TokenObject
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
