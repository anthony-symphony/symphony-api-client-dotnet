namespace apiClientDotNet.Clients.Constants 
{
    public class AgentConstants 
    {
        public const string CreateDatafeed = "/agent/v4/datafeed/create";
        public const string ReadDatafeed = "/agent/v4/datafeed/{id}/read";
        public const string CreateMessage = "/agent/v4/stream/{sid}/message/create";
        public const string GetMessages = "/agent/v4/stream/{sid}/message";
        public const string GetAttachment = "/v1/stream/{sid}/attachment";
        public const string SearchMessages = "/agent/v1/message/search";
        public const string MessageImport = "/agent/v4/message/import" ;
        public const string Share = "/agent/v3/stream/{sid}/share";
        public const string ListSignals = "/agent/v1/signals/list";
        public const string GetSignal = "/agent/v1/signals/{id}/get" ;
        public const string CreateSignal = "/agent/v1/signals/create";
        public const string UpdateSignal = "/agent/v1/signals/{id}/update";
        public const string DeleteSignal = "/agent/v1/signals/{id}/delete";
        public const string SubscribeSignalPath = "/agent/v1/signals/{id}/subscribe";
        public const string UnsubscribeSignal = "/agent/v1/signals/{id}/unsubscribe";
        public const string GetSubscribers = "/v1/signals/{id}/subscribers";
    }
}
