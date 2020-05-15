using System;
using System.Collections.Generic;
using apiClientDotNet.Models;
using apiClientDotNet.Utils;
using System.Net.Http;
using Newtonsoft.Json;
using apiClientDotNet.Clients.Constants;

namespace apiClientDotNet.Clients
{
    public class SignalsClient : ApiClient
    {
        public SignalsClient(ISymClient client)
        {
            SymClient = client;

        }

        public List<Signal> ListSignals(int? skip = 0, int? limit = 0)
        {
            var requestParams = new QueryBuilder();
            requestParams.AddParameter("skip", skip);
            requestParams.AddParameter("limit", limit);
            var requestUri = AgentConstants.ListSignals + requestParams.Query;
            var result = ExecuteRequest<List<Signal>>(HttpMethod.Get, new Uri(requestUri,UriKind.Relative));
            return result.ParsedObject;
        }

        public Signal GetSignal(string id)
        {
            var requestUri = new Uri(AgentConstants.GetSignal.Replace("{id}", id.ToString()), UriKind.Relative);
            var result = ExecuteRequest<Signal>(HttpMethod.Get, requestUri);
            return result.ParsedObject;
        }

        public Signal CreateSignal(Signal signal)
        {
            var requestUri = new Uri(AgentConstants.CreateSignal, UriKind.Relative);
            var result = ExecuteRequest<Signal>(HttpMethod.Post, requestUri, signal);
            return result.ParsedObject;
        }

        public Signal UpdateSignal(Signal signal)
        {
            var requestUri = new Uri(AgentConstants.UpdateSignal.Replace("{id}", signal.id), UriKind.Relative);
            var result = ExecuteRequest<Signal>(HttpMethod.Post, requestUri, signal);
            return result.ParsedObject;
        }

        public bool DeleteSignal(string id)
        {
            var requestUri = new Uri(AgentConstants.DeleteSignal.Replace("{id}", id), UriKind.Relative);
            var result = ExecuteRequest<SimpleResponse>(HttpMethod.Post, requestUri);
            return result.HttpResponse.IsSuccessStatusCode;
        }

        public SignalSubscriptionResult SubscribeSignal(string id, List<long> uids = null, bool? pushed = null)
        {
            var requestParams = new QueryBuilder();
            requestParams.AddParameter("pushed", pushed);
            var requestUri = AgentConstants.SubscribeSignalPath.Replace("{id}", id) + requestParams.Query;
            var result = ExecuteRequest<SignalSubscriptionResult>(HttpMethod.Post, new Uri(requestUri, UriKind.Relative), uids);
            return result.ParsedObject;
        }


        public SignalSubscriptionResult UnsubscribeSignal(string id, List<long> uids)
        {
            var requestUri = new Uri(AgentConstants.UnsubscribeSignal.Replace("{id}", id), UriKind.Relative);
            var result = ExecuteRequest<SignalSubscriptionResult>(HttpMethod.Post, requestUri, uids);
            return result.ParsedObject;
        }

        public SignalSubscriberList GetSignalSubscribers(string id, int? skip, int? limit)
        {
            var requestParams = new QueryBuilder();
            requestParams.AddParameter("skip", skip.ToString());
            requestParams.AddParameter("limit", limit.ToString());
            var requestUri = AgentConstants.GetSubscribers.Replace("{id}", id) + requestParams.Query;
            var result = ExecuteRequest<SignalSubscriberList>(HttpMethod.Get, new Uri(requestUri, UriKind.Relative));
            return result.ParsedObject;
        }

        #region Legacy Forwarders

        public List<Signal> listSignals(int? skip, int? limit)
        {
            return ListSignals(skip, limit);
        }

        public Signal getSignal(string id)
        {
            return GetSignal(id);
        }

        public Signal createSignal(Signal signal)
        {
            return CreateSignal(signal);
        }

        public void deleteSignal(string id)
        {
            DeleteSignal(id);
        }

        public Signal updateSignal(Signal signal)
        {
            return UpdateSignal(signal);
        }

        public SignalSubscriptionResult subscribeSignal(string id, bool self, List<long> uids, bool pushed)
        {
            if (self)
            {
                uids = null;
            }
            return SubscribeSignal(id, uids, pushed);
        }

        public SignalSubscriptionResult unsubscribeSignal(string id, bool self, List<long> uids) 
        {
            if (self)
            {
                uids = null;
            }
            return UnsubscribeSignal(id,uids);
        }

        public SignalSubscriberList getSignalSubscribers(String id, int? skip, int? limit) 
        {
            return GetSignalSubscribers(id, skip, limit);
        }
        #endregion
    }
}
