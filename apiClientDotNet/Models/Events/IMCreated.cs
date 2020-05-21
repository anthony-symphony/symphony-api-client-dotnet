using Newtonsoft.Json;

namespace apiClientDotNet.Models.Events
{
    public class IMCreated
    {
        [JsonProperty("stream")]
        public Stream Stream { get; set; }
    }
}
