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
        public bool? IsExternal { get; set; }

        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }

        [JsonProperty("isPublic")]
        public bool? IsPublic { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("crossPod")]
        public bool? CrossPod { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("attributes")]
        public AdminStreamAttributes Attributes { get; set; }
    }
}
