using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class RoomAttributes
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("membersCanInvite")]
        public bool MembersCanInvite { get; set; }

        [JsonProperty("discoverable")]
        public bool Discoverable { get; set; }

        [JsonProperty("public")]
        public bool IsPublic { get; set; }

        [JsonProperty("readOnly")]
        public bool ReadOnly { get; set; }

        [JsonProperty("copyProtected")]
        public bool CopyProtected { get; set; }

        [JsonProperty("crossPod")]
        public bool CrossPod { get; set; }

        [JsonProperty("viewHistory")]
        public bool ViewHistory { get; set; }

        [JsonProperty("multiLateralRoom")]
        public bool? MultiLateralRoom { get; set; }

        [JsonProperty("keywords")]
        public List<Keyword> Keywords { get; set; }

    }
}
