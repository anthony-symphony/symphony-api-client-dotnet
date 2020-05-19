using System;
using System.Collections.Generic;
using apiClientDotNet.Models;
using apiClientDotNet.Utils;
using System.Net.Http;
using apiClientDotNet.Clients.Constants;

namespace apiClientDotNet.Clients
{
    public class ConnectionsClient : ApiClient
    {
        public ConnectionsClient(ISymClient client)
        {
            SymClient = client;
        }
        
        public List<InboundConnectionRequest> GetPendingConnections()
        {
            return GetConnections();
        }

        public List<InboundConnectionRequest> GetInboundPendingConnections()
        {
            return GetConnections("PENDING_INCOMING");
        }

        public List<InboundConnectionRequest> GetAllConnections()
        {
            return GetConnections("ALL");
        }

        public List<InboundConnectionRequest> GetAcceptedConnections()
        {
            return GetConnections("ACCEPTED");
        }

        public List<InboundConnectionRequest> GetRejectedConnections()
        {
            return GetConnections("REJECTED");
        }

        public List<InboundConnectionRequest> GetConnections(string status = null, List<long> userIds = null)
        {
            var requestParams = new QueryBuilder();
            requestParams.AddParameter("status", status);
            if (userIds != null)
            {
                requestParams.AddParameter("userIds", String.Join(",", userIds));
            }
            var requestUri = PodConstants.ListConnections + requestParams.Query;
            var result = ExecuteRequest<List<InboundConnectionRequest>>(HttpMethod.Get, new Uri(requestUri, UriKind.Relative));
            return result.ParsedObject;
        }

        public InboundConnectionRequest AcceptConnectionRequest(long userId)
        {
            var requestUri = new Uri(PodConstants.AcceptConnection, UriKind.Relative);
            var user = new
            {
                userId = userId
            };
            var result = ExecuteRequest<InboundConnectionRequest>(HttpMethod.Post, requestUri, user);
            return result.ParsedObject;
        }

        public InboundConnectionRequest RejectConnectionRequest(long userId)
        {
            var requestUri = new Uri(PodConstants.RejectConnection, UriKind.Relative);
            var user = new
            {
                userId = userId
            };
            var result = ExecuteRequest<InboundConnectionRequest>(HttpMethod.Post, requestUri, user);
            return result.ParsedObject;
        }

        public InboundConnectionRequest SendConnectionRequest(long userId)
        {
            var requestUri = new Uri(PodConstants.SendConnectionRequest, UriKind.Relative);
            var user = new
            {
                userId = userId
            };
            var result = ExecuteRequest<InboundConnectionRequest>(HttpMethod.Post, requestUri, user);
            return result.ParsedObject;
        }

        public InboundConnectionRequest GetConnectionRequestStatus(long userId)
        {
            var requestUri = new Uri(PodConstants.GetConnectionStatus.Replace("{userId}", userId.ToString()), UriKind.Relative);
            var result = ExecuteRequest<InboundConnectionRequest>(HttpMethod.Get, requestUri);
            return result.ParsedObject;
        }

        public bool RemoveConnection(long userId)
        {
            var requestUri = new Uri(PodConstants.RemoveConnection.Replace("{userId}", userId.ToString()), UriKind.Relative);
            var result = ExecuteRequest<SimpleResponse>(HttpMethod.Post, requestUri);
            return result.HttpResponse.IsSuccessStatusCode;
         }
    }
}

