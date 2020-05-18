namespace apiClientDotNet.Clients.Constants 
{
    public class AgentConstants 
    {
        public const string AgentPrefix = "/agent";
        public const string CreateDatafeed = AgentPrefix + "/v4/datafeed/create";
        public const string ReadDatafeed = AgentPrefix + "/v4/datafeed/{id}/read";
        public const string CreateMessage = AgentPrefix +  "/v4/stream/{sid}/message/create";
        public const string GetMessages = AgentPrefix + "/v4/stream/{sid}/message";
        public const string GetAttachment = AgentPrefix + "/v1/stream/{sid}/attachment";
        public const string SearchMessages = AgentPrefix + "/v1/message/search";
        public const string MessageImport = AgentPrefix + "/v4/message/import" ;
        public const string Share = AgentPrefix + "/v3/stream/{sid}/share";
        public const string ListSignals = AgentPrefix + "/v1/signals/list";
        public const string GetSignal = AgentPrefix + "/v1/signals/{id}/get" ;
        public const string CreateSignal = AgentPrefix + "/v1/signals/create";
        public const string UpdateSignal = AgentPrefix + "/v1/signals/{id}/update";
        public const string DeleteSignal = AgentPrefix + "/v1/signals/{id}/delete";
        public const string SubscribeSignalPath = AgentPrefix + "/v1/signals/{id}/subscribe";
        public const string UnsubscribeSignal = AgentPrefix + "/v1/signals/{id}/unsubscribe";
        public const string GetSubscribers = AgentPrefix + "/v1/signals/{id}/subscribers";
    }
}
