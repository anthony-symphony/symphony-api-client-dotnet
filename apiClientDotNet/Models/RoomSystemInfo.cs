using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class RoomSystemInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("creationDate")]
        public long CreationDate { get; set; }

        [JsonProperty("createdByUserId")]
        public long CreatedByUserId { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }
    }
}
