using System;
using System.Collections.Generic;
using apiClientDotNet.Models;
using apiClientDotNet.Clients.Constants;
using apiClientDotNet.Utils;
using System.Net.Http;

namespace apiClientDotNet.Clients
{
    public class UserClient : ApiClient
    {
        public UserClient(ISymClient client)
        {
            SymClient = client;

        }
        private List<UserInfo> GetUsersV3(List<long> userIds, List<string> emails = null, List<string> usernames = null, bool? local = null) 
        {
            var queryBuilder = new QueryBuilder();
            if (userIds != null)
            {
                queryBuilder.AddParameter("uid", String.Join(",", userIds));
            }
            else if (emails != null)
            {
                queryBuilder.AddParameter("email", String.Join(",", emails));
            }
            else if (usernames != null)
            {
                local = true;
                queryBuilder.AddParameter("username", String.Join(",", usernames));
            }
            queryBuilder.AddParameter("local", local);
            var requestUri = new Uri(PodConstants.GetUsersV3 + queryBuilder.Query, UriKind.Relative);
            var result = ExecuteRequest<UserInfoList>(HttpMethod.Get, requestUri);
            return result.ParsedObject.users;
        }

        public List<UserInfo> GetUserFromEmail(string email, bool? local) 
        {
            return GetUsersV3(null, new List<string> {email}, null, local);
        }

        public List<UserInfo> GetUsersByEmail(List<string> emailList, bool? local) 
        {
            return GetUsersV3(null, emailList, null, local);
        }

        public UserInfo GetUserFromId(long id, bool? local)
        {
            return GetUsersV3(new List<long> {id}, null, null, local)[0];
        }

        public List<UserInfo> GetUsersById(List<long> userIds, bool? local)
        {
            return GetUsersV3(userIds, null, null, local);
        }
        
        public UserInfo GetUserFromUsername(string username)
        {
            return GetUsersV3(null, null, new List<string> {username}, true)[0];
        }

        public List<UserInfo> GetUsersByUsername(List<string> usernames, bool? local)
        {
            return GetUsersV3(null, null, usernames, local);
        }

        public UserSearchResult SearchUsers(string query, UserFilter filter = null, bool? local = null, int? skip = null, int? limit = null) 
        {
            var queryBuilder = new QueryBuilder();
            if (limit == 0)
            {
                limit = 1000;
            }
            queryBuilder.AddParameter("local", local);
            queryBuilder.AddParameter("skip", skip);
            queryBuilder.AddParameter("limit", limit);
            var requestUri = PodConstants.SearchUsers + queryBuilder.Query;
            var requestObject = new 
            {
                query = query,
                filters = filter
            };
            var result = ExecuteRequest<UserSearchResult>(HttpMethod.Post, new Uri(requestUri, UriKind.Relative), requestObject);
            return result.ParsedObject;
        }
        
        public UserInfo GetSessionUser()
        {
            var requestUri = new Uri(PodConstants.GetSessionUser, UriKind.Relative);
            var result = ExecuteRequest<UserInfo>(HttpMethod.Get, requestUri);
            return result.ParsedObject;
        }


        #region Legacy Forwarders
        public UserInfo getUserFromUsername(string username) 
        {
            return GetUserFromUsername(username);
        }
        public List<UserInfo> getUserFromId(long id, bool? local) {
            return GetUsersV3(new List<long> {id}, null, null, local);
        }

        public List<UserInfo> getUserFromEmail(string email, bool? local)
        {
            return GetUsersV3(null, new List<string> {email}, null, local);
        }

        public List<UserInfo> getUsersFromIdList(List<long> idList, bool? local) {
            return GetUsersById(idList, local);
        }

        public List<UserInfo> getUsersFromEmailList(List<string> emailList, bool? local) {
            return getUsersV3(emailList, null, local);
        }

        public List<UserInfo> getUsersV3(List<string> emailList, List<long> idList, bool? local) 
        { 
            return GetUsersV3(idList, emailList, null, local);
        }

        public UserSearchResult searchUsers(string query, bool? local, int? skip, int? limit, UserFilter userFilter)
        {
            return SearchUsers(query, userFilter, local, skip, limit);
        }

        public UserInfo getSessionUser()
        {
            return GetSessionUser();
        }
        #endregion
    }
}