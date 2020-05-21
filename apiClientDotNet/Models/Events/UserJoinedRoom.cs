using Newtonsoft.Json;

namespace apiClientDotNet.Models.Events
{
    public class UserJoinedRoom
    {
        [JsonProperty("stream")]
        public Stream Stream { get; set; }

        [JsonProperty("affectedUser")]
        public User AffectedUser { get; set; }
    }
}
