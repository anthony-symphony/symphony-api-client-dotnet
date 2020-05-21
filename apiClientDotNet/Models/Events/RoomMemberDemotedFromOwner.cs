using Newtonsoft.Json;

namespace apiClientDotNet.Models.Events
{
    public class RoomMemberDemotedFromOwner
    {
        [JsonProperty("stream")]
        public Stream Stream { get; set; }

        [JsonProperty("affectedUser")]
        public User AffectedUser { get; set; }
    }
}
