using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class AdminStreamInfo
    {
        [JsonProperty("streamTypes")]
        public string Id { get; set; }

        [JsonProperty("isExternal")]
        public bool IsExternal { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("isPublic")]
        public bool IsPublic { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("crossPod")]
        public bool CrossPod { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("attributes")]
        public AdminStreamAttributes Attributes { get; set; }


        #region Legacy Forwarders
        [Obsolete("Property is deprecated. Use Id")]
        public string id 
        { 
            get { return Id; } 
            set { Id = value; }
        }

        [Obsolete("Property is deprecated. Use IsExternal")]
        public bool isExternal 
        { 
            get { return IsExternal; } 
            set { IsExternal = value; } 
        }
        [Obsolete("Property is deprecated. Use IsActive")]
        public bool isActive 
        { 
            get { return IsActive; } 
            set { IsActive = value; }
        }
        [Obsolete("Property is deprecated. Use IsPublic")]
        public bool isPublic 
        { 
            get { return IsPublic; } 
            set { IsPublic = value; }
        }
        [Obsolete("Property is deprecated. Use Type")]
        public string type 
        { 
            get { return Type; } 
            set { Type = value; } 
        }
        [Obsolete("Property is deprecated. Use CrossPod")]
        public bool crossPod 
        { 
            get { return CrossPod; } 
            set { CrossPod = value; } 
        }
        [Obsolete("Property is deprecated. Use Origin")]
        public string origin 
        { 
            get { return Origin; } 
            set { Origin = value; } 
        }
        [Obsolete("Property is deprecated. Use Attributes")]
        public AdminStreamAttributes attributes 
        { 
            get { return Attributes; } 
            set { Attributes = value; }
        }
        #endregion
    }
}
