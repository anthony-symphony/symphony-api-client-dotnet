using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;


namespace apiClientDotNet.Models
{
    public class AdminStreamAttributes
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("roomName")]
        public string RoomName { get; set; }

        [JsonProperty("roomDescription")]
        public string RoomDescription { get; set; }

        [JsonProperty("members")]
        public List<long> Members { get; set; }

        [JsonProperty("createdByUserId")]
        public long CreatedByUserId { get; set; }

        [JsonProperty("createdDate")]
        public long CreatedDate { get; set; }

        [JsonProperty("lastModifiedDate")]
        public long LastModifiedDate { get; set; }

        [JsonProperty("originCompany")]
        public string OriginCompany { get; set; }

        [JsonProperty("originCompanyId")]
        public int OriginCompanyId { get; set; }

        [JsonProperty("membersCount")]
        public int MembersCount { get; set; }

        [JsonProperty("lastMessageDate")]
        public long LastMessageDate { get; set; }
    }
}
