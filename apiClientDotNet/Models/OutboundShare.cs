using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class OutboundShare
    {

        [JsonProperty("articleId")]
        public string ArticleId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("subTitle")]
        public string SubTitle { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("publisher")]
        public string Publisher { get; set; }

        [JsonProperty("publishDate")]
        public long? PublishDate { get; set; }

        [JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("articleUrl")]
        public string ArticleUrl { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("appId")]
        public string AppId { get; set; }

        [JsonProperty("appName")]
        public string AppName { get; set; }

        [JsonProperty("appIconUrl")]
        public string AppIconUrl { get; set; }
    }
}
