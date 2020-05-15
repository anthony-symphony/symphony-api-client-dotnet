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


        [Obsolete("Property is deprecated. Use Description")]
        public string description 
        { 
            get { return Description; } 
            set { Description = value; } 
        }
        [Obsolete("Property is deprecated. Use RoomName")]
        public string roomName 
        { 
            get { return roomName; } 
            set { RoomName = value; } 
        }
        [Obsolete("Property is deprecated. Use RoomDescription")]
        public string roomDescription 
        { 
            get { return RoomDescription; } 
            set { RoomDescription = value; } 
        }
        [Obsolete("Property is deprecated. Use Members")]
        public List<long> members 
        { 
            get { return Members; }
            set { Members = value; } 
        }
        [Obsolete("Property is deprecated. Use CreatedByUserId")]
        public long createdByUserId
        {
            get { return CreatedByUserId; }
            set { CreatedByUserId = value; }
        }
        [Obsolete("Property is deprecated. Use CreatedDate")]
        public long createdDate 
        { 
            get { return CreatedDate; }
            set { CreatedDate = value; } 
        }
        [Obsolete("Property is deprecated. Use LastModifiedDate")]
        public long lastModifiedDate 
        { 
            get { return LastMessageDate; } 
            set { LastMessageDate = value; } 
        }
        [Obsolete("Property is deprecated. Use OriginCompany")]
        public string originCompany
        {
            get { return OriginCompany; }
            set { OriginCompany = value; }
        }
        [Obsolete("Property is deprecated. Use OriginCompanyId")]
        public int originCompanyId
        {
            get { return OriginCompanyId; }
            set { OriginCompanyId = value; }
        }
        [Obsolete("Property is deprecated. Use MembersCount")]
        public int membersCount
        {
            get { return MembersCount; }
            set { MembersCount = value; }
        }
        [Obsolete("Property is deprecated. Use LastMessageDate")]
        public long lastMessageDate
        {
            get { return LastMessageDate; }
            set { LastMessageDate = value; }
        }
    }
}
