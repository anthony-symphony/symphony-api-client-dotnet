using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class RoomMember
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("owner")]
        public bool? Owner { get; set; }

        [JsonProperty("joinDate")]
        public long? JoinDate { get; set; }

    }
}
