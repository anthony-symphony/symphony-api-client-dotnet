using Newtonsoft.Json;
using System.Collections.Generic;

namespace apiClientDotNet.Models
{
    public class AdminStreamInfoList 
    {
        [JsonProperty("count")]
        public int Count;
        
        [JsonProperty("skip")]
        public int Skip;
        
        [JsonProperty("limit")]
        public int Limit;
        
        [JsonProperty("filter")]
        public AdminStreamFilter Filter;
        
        [JsonProperty("streams")]
        public List<AdminStreamInfo> Streams;
    }
}
