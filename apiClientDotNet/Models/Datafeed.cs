using System;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class Datafeed
    {
        [JsonProperty("id")]
        public string DatafeedId { get; set; }
    }
}
