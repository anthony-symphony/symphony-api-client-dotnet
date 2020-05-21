using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace apiClientDotNet.Models.Events
{
    public class SymphonyElementsAction
    {
        [JsonProperty("formStream")]
        public Stream FormStream
        {
            get { return Stream; }
            set { Stream = value;}
        }

        [JsonProperty("stream")]
        public Stream Stream { get; set; }

        [JsonProperty("formMessageId")]
        public string FormMessageId { get; set; }

        [JsonProperty("formId")]
        public string FormId { get; set; }

        [JsonProperty("formValues")]
        public Dictionary<string, object> FormValues { get; set; }

        [OnDeserialized]
        internal void FixIds(StreamingContext context)
        {
            Stream.StreamId = Stream.StreamId.Replace('/', '_').Replace('+', '-').Replace("=","");
            FormMessageId = FormMessageId.Replace('/', '_').Replace('+', '-').Replace("=","");
        }
    }
}
