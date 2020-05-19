using System.Collections.Generic;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class SignalSubscriptionResult
    {
        [JsonProperty("requestedSubscription")]
        public int RequestedSubscription { get; set; }

        [JsonProperty("successfulSubscription")]
        public int SuccessfulSubscription { get; set; }

        [JsonProperty("failedSubscription")]
        public int FailedSubscription { get; set; }

        [JsonProperty("subscriptionErrors")]
        public List<long> SubscriptionErrors { get; set; }
    }
}
