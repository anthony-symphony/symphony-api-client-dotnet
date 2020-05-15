using System;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class Status
    {
        [JsonProperty("status")]
        public String status { get; set; }
    }
}
