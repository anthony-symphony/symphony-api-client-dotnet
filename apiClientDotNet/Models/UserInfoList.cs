using System.Collections.Generic;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class UserInfoList
    {
        [JsonProperty("users")]
        public List<UserInfo> Users { get; set; }

    }
}
