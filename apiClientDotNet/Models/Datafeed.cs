using System;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class Datafeed
    {
        [JsonProperty("id")]
        public string DatafeedId { get; set; }


        [Obsolete("Property is deprecated. Use DatafeedId")]
        public string datafeedID 
        {
            get { return DatafeedId; }
            set { DatafeedId = value; }
        }
    }
}
