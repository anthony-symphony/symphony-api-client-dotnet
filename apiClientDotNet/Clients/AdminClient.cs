using System;
using apiClientDotNet.Models;
using apiClientDotNet.Clients.Constants;
using apiClientDotNet.Utils;
using System.Net.Http;
using System.Collections.Generic;
using System.IO;

namespace apiClientDotNet.Clients
{
    public class AdminClient : ApiClient
    {
        public AdminClient(ISymClient client) 
        {
            SymClient = client;        
        }

        public List<InboundImportMessage> ImportMessages (List<OutboundImportMessage> messageList) 
        {
            var requestUri = new Uri(AgentConstants.MessageImport, UriKind.Relative);
            var result = ExecuteRequest<List<InboundImportMessage>>(HttpMethod.Post, requestUri, messageList);
            return result.ParsedObject;
        }

        public SuppressionResult SuppressMessage (String id) 
        {
            var requestUri = new Uri(PodConstants.AdminMessageSuppression.Replace("{id}", id), UriKind.Relative);
            var result = ExecuteRequest<SuppressionResult>(HttpMethod.Post, requestUri);
            return result.ParsedObject;
        }

        public AdminStreamInfoList ListEnterpriseStreams (AdminStreamFilter filter, int? skip = 0, int? limit = 100)
        {
            var requestParams = new QueryBuilder();
            requestParams.AddParameter("skip", skip);
            requestParams.AddParameter("limit", limit);
            var requestUri = PodConstants.AdminListStreamsEnterprise + requestParams.Query;
            var result = ExecuteRequest<AdminStreamInfoList>(HttpMethod.Post, new Uri(requestUri, UriKind.Relative));
            return result.ParsedObject;
        }

        public StreamInfo CreateIm(long [] userIds)
        {
            var requestUri = new Uri(PodConstants.AdminCreateIm, UriKind.Relative);
            var result = ExecuteRequest<StreamInfo>(HttpMethod.Post, requestUri, userIds);
            return result.ParsedObject;
        }

        public AdminUserInfo GetUser(long userId)
        {
            var requestUri = new Uri(PodConstants.AdminGetUser.Replace("{id}",userId.ToString()), UriKind.Relative);
            var result = ExecuteRequest<AdminUserInfo>(HttpMethod.Get, requestUri);
            return result.ParsedObject;
        }

        public List<AdminUserInfo> ListUsers(int? skip = 0, int? limit = 1000)
        {
            var requestParams = new QueryBuilder();
            requestParams.AddParameter("skip", skip);
            requestParams.AddParameter("limit", limit);
            var requestUri = PodConstants.AdminListUsers + requestParams.Query;
            var result = ExecuteRequest<List<AdminUserInfo>>(HttpMethod.Get, new Uri(requestUri, UriKind.Relative));
            return result.ParsedObject;
        }

        public AdminUserInfo CreateUser(AdminNewUser newUser)
        {
            var requestUri = new Uri(PodConstants.AdminCreateUser, UriKind.Relative);
            var result = ExecuteRequest<AdminUserInfo>(HttpMethod.Post, requestUri, newUser);
            return result.ParsedObject;
        }

        public AdminUserInfo UpdateUser(long userId, AdminUserAttributes newAttributes)
        {
            var requestUri = new Uri(PodConstants.AdminUpdateUser.Replace("{id}", userId.ToString()), UriKind.Relative);
            var result = ExecuteRequest<AdminUserInfo>(HttpMethod.Post, requestUri, newAttributes);
            return result.ParsedObject;
        }

        public Avatar GetUserAvatar(long userId)
        {
            var requestUri = new Uri(PodConstants.AdminGetAvatar.Replace("{id}", userId.ToString()), UriKind.Relative);
            var result = ExecuteRequest<Avatar>(HttpMethod.Get, requestUri);
            return result.ParsedObject;
        }

        public bool UpdateUserAvatar(long userId, string newAvatarPath)
        {
            if (!File.Exists(newAvatarPath)) 
            {
                throw new FileNotFoundException();
            }
            var requestUri = new Uri(PodConstants.AdminUpdateAvatar.Replace("{id}", userId.ToString()), UriKind.Relative);
            Byte[] avatarBytes = File.ReadAllBytes(newAvatarPath);
            String base64Avatar = Convert.ToBase64String(avatarBytes);
            var avatarPayload = new
            {
                image = base64Avatar
            };
            var result = ExecuteRequest<SimpleResponse>(HttpMethod.Post, requestUri, avatarPayload);
            return result.HttpResponse.IsSuccessStatusCode;
        }

        public string GetUserStatus(long userId)
        {
            var requestUri = new Uri(PodConstants.AdminGetUserStatus.Replace("{id}", userId.ToString()), UriKind.Relative);
            var result = ExecuteRequest<StatusObject>(HttpMethod.Get, requestUri);
            return result.ParsedObject.Status;
        }

        public bool UpdateUserStatus(long userId, StatusObject updatedStatus)
        {
            var requestUri = new Uri(PodConstants.AdminUpdateUserStatus.Replace("{id}", userId.ToString()), UriKind.Relative);
            var result = ExecuteRequest<SimpleResponse>(HttpMethod.Post, requestUri, updatedStatus);
            return result.HttpResponse.IsSuccessStatusCode;
        }

        public List<string> ListPodFeatures()
        {
            var requestUri = new Uri(PodConstants.AdminGetPodFeatures, UriKind.Relative);
            var result = ExecuteRequest<List<string>>(HttpMethod.Get, requestUri);
            return result.ParsedObject;
        }

        public List<FeatureEntitlement> GetUserEntitlements(long userId)
        {
            var requestUri = new Uri(PodConstants.AdminGetUserFeatures.Replace("{id}",userId.ToString()), UriKind.Relative);
            var result = ExecuteRequest<List<FeatureEntitlement>>(HttpMethod.Get, requestUri);
            return result.ParsedObject;
        }

        public bool UpdateUserEntitlements(long userId, List<FeatureEntitlement> updatedFeatureSet)
        {
            var requestUri = new Uri(PodConstants.AdminUpdateUserFeatures.Replace("{id}",userId.ToString()), UriKind.Relative);
            var result = ExecuteRequest<SimpleResponse>(HttpMethod.Post, requestUri, updatedFeatureSet);
            return result.HttpResponse.IsSuccessStatusCode;
        }

        public List<ApplicationEntitlement> GetUserApplicationEntitlements (long userId)
        {
            var requestUri = new Uri(PodConstants.AdminGetUserApplications.Replace("{id}",userId.ToString()), UriKind.Relative);
            var result = ExecuteRequest<List<ApplicationEntitlement>>(HttpMethod.Get, requestUri);
            return result.ParsedObject;
        }

        public List<ApplicationEntitlement> UpdateUserApplicationEntitlements (long userId, List<ApplicationEntitlement> updatedUserApps)
        {
            var requestUri = new Uri(PodConstants.AdminUpdateUserApplications.Replace("{id}",userId.ToString()), UriKind.Relative);
            var result = ExecuteRequest<List<ApplicationEntitlement>>(HttpMethod.Post, requestUri, updatedUserApps);
            return result.ParsedObject;
        }
    }
}