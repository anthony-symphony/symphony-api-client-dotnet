using System;
using System.Collections.Generic;
using apiClientDotNet.Models;
using apiClientDotNet.Clients;
using apiClientDotNet.Clients.Constants;
using System.Net.Http;


namespace apiClientDotNet
{
    public class DatafeedClient : ApiClient
    {
        public DatafeedClient(SymBotClient symClient)
        {
            SymClient = symClient;
        }

        public Datafeed CreateDatafeed()
        {
            var requestUri = new Uri(AgentConstants.CreateDatafeed, UriKind.Relative);
            var result = ExecuteRequest<Datafeed>(HttpMethod.Post, requestUri, UriKind.Relative);
            return result.ParsedObject;
        }

        public List<DatafeedEvent> GetEventsFromDatafeed(Datafeed datafeed)
        {
            var requestUri = new Uri(AgentConstants.ReadDatafeed.Replace("{id}", datafeed.DatafeedId), UriKind.Relative);
            var result = ExecuteRequest<List<DatafeedEvent>>(HttpMethod.Get, requestUri);
            return result.ParsedObject;
        }
    }
}
