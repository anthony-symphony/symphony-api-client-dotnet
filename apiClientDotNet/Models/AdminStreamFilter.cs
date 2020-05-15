using System.Collections.Generic;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class AdminStreamFilter
    {
        [JsonProperty("streamTypes")]
        public List<string> StreamTypes { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("privacy")]
        public string Privacy { get; set; }

        [JsonProperty("startDate")]
        public long StartDate { get; set; }

        [JsonProperty("endDate")]
        public long EndDate { get; set; }


        #region Legacy Forwarders
        public List<string> streamTypes 
        { 
            get { return StreamTypes; } 
            set { StreamTypes = value; } 
        }

        public string scope 
        { 
            get { return Scope; } 
            set { Scope = value; } 
        }

        public string origin 
        { 
            get { return Origin; } 
            set { Origin = value; }
        }

        public string status 
        { 
            get { return Status; } 
            set { Status = value; }
        }

        public string privacy 
        { 
            get { return Privacy; } 
            set { Privacy = value; }
        }

        public long startDate 
        { 
            get { return StartDate; }
            set { StartDate = value; }
        }

        public long endDate 
        { 
            get { return EndDate; }
            set { EndDate = value;}
        }

        #endregion
    }
}
