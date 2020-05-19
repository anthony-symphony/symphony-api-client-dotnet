using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class Initiator
    {

        [JsonProperty("user")]
        public User User { get; set; }
    }
}
