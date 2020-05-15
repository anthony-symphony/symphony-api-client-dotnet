using System;
using System.Collections.Generic;
using apiClientDotNet.Models;
using apiClientDotNet.Clients.Constants;
using System.Net.Http;

namespace apiClientDotNet.Clients
{
    public class PresenceClient : ApiClient
    {
        public PresenceClient(ISymClient client)
        {
            SymClient = client;

        }

        public UserPresence GetUserPresence(long userId, bool local)
        {
            var requestUri = new Uri(PodConstants.GetUserPresence.Replace("{uid}",userId.ToString()), UriKind.Relative);
            var result = ExecuteRequest<UserPresence>(HttpMethod.Get, requestUri);
            return result.ParsedObject;
        }

        public UserPresence SetPresence(string status)
        {
            var requestUri = new Uri(PodConstants.SetPresence, UriKind.Relative);
            UserPresence newStatus = new UserPresence();
            newStatus.category = status;
            var result = ExecuteRequest<UserPresence>(HttpMethod.Post, requestUri, newStatus);
            return result.ParsedObject;
        }

        public bool RegisterInterestExtUser(List<long> userIds)
        {
            var requestUri = new Uri(PodConstants.RegisterPresenceInterest, UriKind.Relative);
            var result = ExecuteRequest<SimpleResponse>(HttpMethod.Post, requestUri, userIds);
            return result.HttpResponse.IsSuccessStatusCode;
        }

        #region Legacy Forwarders

        public UserPresence getUserPresence(long userId, bool local)
        {
            return GetUserPresence(userId, local);
        }

        public UserPresence setPresence(string status)
        {
            return SetPresence(status);
        }

        public void registerInterestExtUser(List<long> userIds) 
        {
            RegisterInterestExtUser(userIds);
        }
        #endregion
    }
}
