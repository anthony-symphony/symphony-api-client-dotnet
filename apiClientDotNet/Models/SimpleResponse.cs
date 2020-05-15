using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class SimpleResponse
    {

        [JsonProperty("format")]
        public string Format;

        [JsonProperty("message")]
        public string Message;
    }
}