using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class MessageStatusUser
    {
        [JsonProperty("read")]
        public string Read { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("timestamp")]
        public long? Timestamp { get; set; }

    }
}
