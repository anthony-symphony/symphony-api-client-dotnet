﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class ImageInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("dimension")]
        public int Dimension { get; set; }
    }
}
