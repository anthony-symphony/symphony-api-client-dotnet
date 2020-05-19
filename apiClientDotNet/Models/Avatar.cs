using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class Avatar
    {
        [JsonProperty("size")]
        public string Size{ get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
