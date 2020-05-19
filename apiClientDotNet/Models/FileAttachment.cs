using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class FileAttachment
    {
        [JsonProperty("fileContent")]
        public byte[] FileContent { get; set; }

        [JsonProperty("fileName")]
        public string FileName { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

    }
}
