using System.Collections.Generic;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class RoomProperties
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("creatorUser")]
        public User CreatorUser { get; set; }

        [JsonProperty("createdDate")]
        public long? CreatedDate { get; set; }

        [JsonProperty("external")]
        public bool? External { get; set; }

        [JsonProperty("crossPod")]
        public bool? CrossPod { get; set; }

        [JsonProperty("isPublic")]
        public bool? IsPublic { get; set; }

        [JsonProperty("copyProtected")]
        public bool? CopyProtected { get; set; }

        [JsonProperty("readOnly")]
        public bool? ReadOnly { get; set; }

        [JsonProperty("discoverable")]
        public bool? Discoverable { get; set; }

        [JsonProperty("membersCanInvite")]
        public bool? MembersCanInvite { get; set; }

        [JsonProperty("keywords")]
        public List<Keyword> Keywords { get; set; }

        [JsonProperty("canViewHistory")]
        public bool? CanViewHistory { get; set; }

    }
}
